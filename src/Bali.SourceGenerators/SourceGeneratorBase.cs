using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Bali.SourceGenerators
{
    public abstract class SourceGeneratorBase : ISourceGenerator
    {
        private readonly string _attributeName;
        private readonly string _attributeSource;

        protected SourceGeneratorBase(string attributeName, string attributeSource)
        {
            _attributeName = attributeName;
            _attributeSource = attributeSource;
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new SyntaxReceiver());
        }

        public void Execute(GeneratorExecutionContext context)
        {
            context.AddSource(_attributeName, _attributeSource);

            if (context.SyntaxReceiver is not SyntaxReceiver receiver)
                return;
            
            var options = ((CSharpCompilation) context.Compilation).SyntaxTrees[0].Options as CSharpParseOptions;
            var withAttribute = CSharpSyntaxTree.ParseText(SourceText.From(_attributeSource, Encoding.UTF8), options);
            var compilation = context.Compilation.AddSyntaxTrees(withAttribute);
            
            var toProcess = new List<INamedTypeSymbol>();
            var builderAttribute = compilation.GetTypeByMetadataName(_attributeName);

            foreach (var candidate in receiver.Candidates)
            {
                var model = compilation.GetSemanticModel(candidate.SyntaxTree);
                var symbol = model.GetDeclaredSymbol(candidate);
                var attributes = symbol!.GetAttributes();

                if (!attributes.Any(ad => ad.AttributeClass!.Equals(builderAttribute, SymbolEqualityComparer.Default)))
                    continue;
                
                toProcess.Add(symbol);
            }
            
            Execute(toProcess, context);
        }

        protected abstract void Execute(
            List<INamedTypeSymbol> targets, GeneratorExecutionContext context);

        private sealed class SyntaxReceiver : ISyntaxReceiver
        {
            public List<ClassDeclarationSyntax> Candidates
            {
                get;
            } = new();
            
            public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
            {
                if (syntaxNode is ClassDeclarationSyntax @class && @class.AttributeLists.Count > 0)
                    Candidates.Add(@class);
            }
        }
    }
}