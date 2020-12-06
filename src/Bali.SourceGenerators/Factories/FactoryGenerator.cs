﻿using System.Collections.Generic;
using System.Linq;
using CodeGenHelpers;
using Microsoft.CodeAnalysis;

namespace Bali.SourceGenerators.Factories
{
    [Generator]
    public class FactoryGenerator : SourceGeneratorBase
    {
        private static readonly string AttributeSource;
        private static readonly string FullAttributeName = $"{AttributeNamespace}.{AttributeName}";

        private const string AttributeNamespace = "Bali.SourceGeneration";
        private const string AttributeName = "AutoFactoryAttribute";
        private const string FactoryNamespace = "Bali.Metadata.Factories";

        public FactoryGenerator()
            : base(FullAttributeName, AttributeSource) { }

        static FactoryGenerator()
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
                context.AddSource(attribute.Name + "Factory", source);
            }

            var builder = CodeBuilder.Create("Bali.SourceGeneration")
                .AddNamespaceImport("System.Collections.Generic")
                .AddNamespaceImport("Bali.Metadata.Factories")
                .AddNamespaceImport("System.Runtime.CompilerServices")
                .AddClass("AutoGeneratedFactories")
                    .AddAttribute("CompilerGenerated")
                    .MakeStaticClass()
                    .MakeInternalClass()
                    .AddMethod("AddToCache", Accessibility.Internal)
                        .MakeStaticMethod()
                        .WithReturnType("void")
                        .AddParameter("IJvmAttributeFactoryFacade", "facade")
                        .WithBody(w =>
                        {
                            foreach (var target in targets)
                            {
                                string attributeName = target.Name;
                                string withoutAttribute = attributeName.Substring(0, attributeName.Length - 9);
                                w.AppendLine($"facade[\"{withoutAttribute}\"] = new {attributeName}Factory(facade);");
                            }
                        })
                .Class;
            
            context.AddSource("AutoGeneratedFactories", builder.Build());
        }

        private static string ProcessClass(INamedTypeSymbol attribute, Compilation compilation)
        {
            string attributeName = attribute.Name;
            string builderName = attributeName + "Factory";
            
            var builder = CreateBuilder(builderName, attributeName);
            var steps = new List<string>();

            var properties = attribute.GetMembers().Where(m => m is IPropertySymbol).Cast<IPropertySymbol>().ToArray();
            foreach (var property in properties)
            {
                if (property.Type is not INamedTypeSymbol type)
                {
                    steps.Add($"throw new NotSupportedException(\"Unsupported type {property.Type.Name}\");");
                    continue;
                }

                var processor = new TypeProcessor(builder.Class, type, $"var {property.Name} = ");
                steps.Add(processor.Process());
            }

            builder.WithBody(w =>
            {
                foreach (string step in steps)
                    w.AppendLine(step);
                
                w.AppendLine($"return new {attributeName}({string.Join(", ", properties.Select(p => p.Name).Prepend("nameIndex"))});");
            });
            
            return builder.Class.Build();
        }

        private static MethodBuilder CreateBuilder(string builderName, string attributeName)
        {
            return CodeBuilder.Create(FactoryNamespace)
                .AddNamespaceImport("System")
                .AddNamespaceImport("System.IO")
                .AddNamespaceImport("System.Collections.Generic")
                .AddNamespaceImport("System.Runtime.CompilerServices")
                .AddNamespaceImport("Bali.IO")
                .AddNamespaceImport("Bali.Metadata.Attributes")
                    .AddClass(builderName)
                    .WithSummary($"Provides an implementation of the <see cref=\"IJvmAttributeFactory\"/> contract that can create <see cref=\"{attributeName}\"/>s.")
                    .AddAttribute("CompilerGenerated")
                    .MakePublicClass()
                    .SetBaseClass($"JvmAttributeFactoryBase")
                    .AddConstructor(Accessibility.Public)
                        .WithInheritDoc()
                        .WithBaseCall(new Dictionary<string, string>
                        {
                            { "IJvmAttributeFactoryFacade", "attributeFactoryFacade" }
                        })
                        .Class
                    .AddProperty("Name", Accessibility.Public)
                        .SetType("override string") // Hack :)
                        .WithGetterExpression($"\"{attributeName.Substring(0, attributeName.Length - 9)}\"")
                        .WithInheritDoc()
                        .Class
                    .AddMethod("Read", Accessibility.Public)
                        .Override()
                        .WithReturnType("JvmAttribute")
                        .WithInheritDoc()
                        .AddParameter("Stream", "stream")
                        .AddParameter("ushort", "nameIndex");
        }
    }
}