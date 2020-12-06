using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CodeGenHelpers;
using Microsoft.CodeAnalysis;

namespace Bali.SourceGenerators.Builders
{
    public class TypeProcessor
    {
        private readonly ClassBuilder _builder;
        private readonly INamedTypeSymbol _type;
        private readonly string _access;

        public TypeProcessor(ClassBuilder builder, INamedTypeSymbol type, string access)
        {
            _builder = builder;
            _type = type ?? throw new ArgumentNullException(nameof(type));
            _access = access;
        }

        public string Process()
        {
            if (_type.EnumUnderlyingType is { } underlyingType)
            {
                var processor = new TypeProcessor(_builder, underlyingType, $"({underlyingType.Name}) {_access}");
                return processor.Process();
            }
            if (_type.SpecialType != SpecialType.None)
                return ProcessSpecialType(_type);
            if (_type.IsGenericType && _type.Name == "IList")
                return ProcessList(_type.TypeArguments[0] as INamedTypeSymbol);

            return ProcessUserDataStructure();
        }

        private string ProcessList(INamedTypeSymbol type)
        {
            if (CheckExistingMethod(n => n == $"IList<{_type.Name}>") is { } existing)
                return existing;

            var method = _builder.AddMethod($"Write{type.Name}List", Accessibility.Private)
                .AddParameter("Stream", "stream")
                .AddParameter($"IList<{type.Name}>", "list")
                .MakeStaticMethod();

            var processor = new TypeProcessor(_builder, type, "element");
            string step = processor.Process();

            method.WithBody(w =>
            {
                w.AppendLine("stream.WriteU2((ushort) list.Count);");
                
                using var block = w.Block("foreach (var element in list)");
                w.AppendLine(step);
            });

            return $"{method.Name}(stream, {_access});";
        }

        private string ProcessUserDataStructure()
        {
            if (CheckExistingMethod(n => n == _type.Name) is { } existing)
                return existing;

            var method = _builder.AddMethod($"Write{_type.Name}", Accessibility.Private)
                .AddParameter("Stream", "stream")
                .AddParameter(_type, "data")
                .MakeStaticMethod();

            var steps = new List<string>();

            foreach (var property in _type.GetMembers().Where(m => m is IPropertySymbol).Cast<IPropertySymbol>())
            {
                var type = property.Type as INamedTypeSymbol;
                var processor = new TypeProcessor(_builder, type, $"data.{property.Name}");
                steps.Add(processor.Process());
            }

            method.WithBody(w =>
            {
                foreach (string step in steps)
                    w.AppendLine(step);
            });

            return $"{method.Name}(stream, {_access});";
        }

        private string ProcessSpecialType(ITypeSymbol symbol)
        {
            string method = symbol.SpecialType switch
            {
                SpecialType.System_Byte => "WriteU1",
                SpecialType.System_UInt16 => "WriteU2",
                SpecialType.System_UInt32 => "WriteU4",
                SpecialType.System_UInt64 => "WriteU8",
                SpecialType.System_SByte => "WriteI1",
                SpecialType.System_Int16 => "WriteI2",
                SpecialType.System_Int32 => "WriteI4",
                SpecialType.System_Int64 => "WriteI8",
                SpecialType.System_Single => "WriteR4",
                SpecialType.System_Double => "WriteR8",
                _ => $"throw new NotSupportedException(\"Unsupported special type: {symbol.MetadataName}\");"
            };

            return method.Length > 20
                ? method
                : $"stream.{method}({_access});";
        }

        private string CheckExistingMethod(Func<string, bool> predicate)
        {
            var existing = _builder.Methods.SingleOrDefault(m =>
            {
                var target = typeof(MethodBuilder).GetField("_parameters", BindingFlags.NonPublic | BindingFlags.Instance);
                var parameters = (List<ParameterBuilder<MethodBuilder>>) target!.GetValue(m);
                if (parameters.Count != 2)
                    return false;

                var first = parameters[0];
                var second = parameters[1];

                return first.Type == "Stream" && predicate(second.Name);
            });

            return existing is not null
                ? $"{existing.Name}(stream, {_access});"
                : null;
        }
    }
}