﻿using System.Collections.Generic;
using System.Linq;
using CodeGenHelpers;
using Microsoft.CodeAnalysis;

namespace Bali.SourceGenerators.Builders
{
    [Generator]
    public class BuilderGenerator : SourceGeneratorBase
    {
        private static readonly string AttributeSource;
        private static readonly string FullAttributeName = $"{AttributeNamespace}.{AttributeName}";

        private const string AttributeNamespace = "Bali.SourceGeneration";
        private const string AttributeName = "AutoBuilderAttribute";
        private const string BuilderNamespace = "Bali.Metadata.Builders";

        public BuilderGenerator()
            : base(FullAttributeName, AttributeSource) { }

        static BuilderGenerator()
        {
            var builder = CodeBuilder.Create(AttributeNamespace)
                .AddNamespaceImport("System")
                .AddNamespaceImport("System.Runtime.CompilerServices")
                .AddClass(AttributeName)
                    .SetBaseClass("Attribute")
                    .AddAttribute("CompilerGenerated")
                    .AddAttribute("AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)");

            AttributeSource = builder.Build();
        }

        protected override void Execute(List<INamedTypeSymbol> targets, Compilation compilation, GeneratorExecutionContext context)
        {
            foreach (var attribute in targets)
            {
                string source = ProcessClass(attribute, compilation);
                context.AddSource(attribute.Name + "Builder", source);
            }

            var builder = CodeBuilder.Create("Bali.SourceGeneration")
                .AddNamespaceImport("System.Collections.Generic")
                .AddNamespaceImport("Bali.Metadata.Builders")
                .AddNamespaceImport("System.Runtime.CompilerServices")
                .AddClass("AutoGeneratedBuilders")
                    .AddAttribute("CompilerGenerated")
                    .MakeStaticClass()
                    .MakeInternalClass()
                    .AddMethod("AddToCache", Accessibility.Internal)
                        .MakeStaticMethod()
                        .WithReturnType("void")
                        .AddParameter("IJvmAttributeDirector", "director")
                        .WithBody(w =>
                        {
                            foreach (var target in targets)
                            {
                                string attributeName = target.Name;
                                string withoutAttribute = attributeName.Substring(0, attributeName.Length - 9);
                                w.AppendLine($"director[\"{withoutAttribute}\"] = new {attributeName}Builder(director);");
                            }
                        })
                .Class;
            
            context.AddSource("AutoGeneratedBuilders", builder.Build());
        }

        private static string ProcessClass(INamedTypeSymbol attribute, Compilation compilation)
        {
            string attributeName = attribute.Name;
            string builderName = attributeName + "Builder";
            
            var builder = CreateBuilder(builderName, attributeName);
            var steps = new List<string>();

            foreach (var property in attribute.GetMembers().Where(m => m is IPropertySymbol).Cast<IPropertySymbol>())
            {
                if (property.Type is not INamedTypeSymbol type)
                {
                    steps.Add($"throw new NotSupportedException(\"Unsupported type {property.Type.Name}\");");
                    continue;
                }

                var processor = new TypeProcessor(builder.Class, type, $"attribute.{property.Name}");
                steps.Add(processor.Process());
            }

            builder.WithBody(w =>
            {
                foreach (string step in steps)
                    w.AppendLine(step);
            });
            
            return builder.Class.Build();
        }

        private static MethodBuilder CreateBuilder(string builderName, string attributeName)
        {
            return CodeBuilder.Create(BuilderNamespace)
                .AddNamespaceImport("System")
                .AddNamespaceImport("System.IO")
                .AddNamespaceImport("System.Collections.Generic")
                .AddNamespaceImport("System.Runtime.CompilerServices")
                .AddNamespaceImport("Bali.IO")
                .AddNamespaceImport("Bali.Metadata.Attributes")
                    .AddClass(builderName)
                    .WithSummary($"Provides an implementation of the <see cref=\"IJvmAttributeBuilder\"/> contract that can build <see cref=\"{attributeName}\"/>s.")
                    .AddAttribute("CompilerGenerated")
                    .MakePublicClass()
                    .SetBaseClass($"JvmAttributeBuilderBase<{attributeName}>")
                    .AddConstructor(Accessibility.Public)
                        .WithInheritDoc()
                        .WithBaseCall(new Dictionary<string, string>
                        {
                            { "IJvmAttributeDirector", "director" }
                        })
                        .Class
                    .AddProperty("Name", Accessibility.Public)
                        .SetType("override string") // Hack :)
                        .WithGetterExpression($"\"{attributeName.Substring(0, attributeName.Length - 9)}\"")
                        .WithInheritDoc()
                        .Class
                    .AddMethod("WriteBody", Accessibility.Protected)
                        .Override()
                        .WithInheritDoc()
                        .AddParameter("Stream", "stream")
                        .AddParameter(attributeName, "attribute");
        }
    }
}