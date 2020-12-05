using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;

namespace Bali.SourceGenerators
{
    public abstract class SourceGeneratorBase : ISourceGenerator
    {
        private readonly string _attributeName;
        private readonly string _attributeSource;
        private readonly SyntaxReceiverCreator _syntaxReceiverFactory;

        protected SourceGeneratorBase(string attributeName, string attributeSource, SyntaxReceiverCreator syntaxReceiverFactory = null)
        {
            _attributeName = attributeName;
            _attributeSource = attributeSource;
            _syntaxReceiverFactory = syntaxReceiverFactory;
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            if (_syntaxReceiverFactory is not null)
                context.RegisterForSyntaxNotifications(_syntaxReceiverFactory);
        }

        public void Execute(GeneratorExecutionContext context)
        {
            context.AddSource(_attributeName, _attributeSource);
            
            var options = ((CSharpCompilation) context.Compilation).SyntaxTrees[0].Options as CSharpParseOptions;
            var withAttribute = CSharpSyntaxTree.ParseText(SourceText.From(_attributeSource, Encoding.UTF8), options);
            var compilation = context.Compilation.AddSyntaxTrees(withAttribute);
            
            Execute(compilation, context);
        }

        protected abstract void Execute(Compilation compilation, GeneratorExecutionContext context);
    }
}