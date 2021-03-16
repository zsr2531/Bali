using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CodeGenHelpers;
using Microsoft.CodeAnalysis;

namespace Bali.SourceGenerators.Readers
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
                var processor = new TypeProcessor(_builder, underlyingType, $"{_access}({_type.Name}) ");
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

            var method = _builder.AddMethod($"Read{type.Name}List", Accessibility.Private)
                .WithReturnType($"IList<{type.Name}>")
                .AddParameter("IBigEndianReader", "reader")
                .MakeStaticMethod();

            var processor = new TypeProcessor(_builder, type, "var element = ");
            string step = processor.Process();

            method.WithBody(w =>
            {
                w.AppendLine("ushort count = reader.ReadU2();");
                w.AppendLine($"var list = new List<{type.Name}>(count);");

                using (w.Block("for (int i = 0; i < count; i++)"))
                {
                    w.AppendLine(step);
                    w.AppendLine("list.Add(element);");
                }

                w.AppendLine("return list;");
            });

            return $"{_access}{method.Name}(reader);";
        }

        private string ProcessUserDataStructure()
        {
            if (CheckExistingMethod(n => n == _type.Name) is { } existing)
                return existing;

            var method = _builder.AddMethod($"Read{_type.Name}", Accessibility.Private)
                .WithReturnType(_type.Name)
                .AddParameter("IBigEndianReader", "reader")
                .MakeStaticMethod();

            var steps = new List<string>();

            var properties = _type.GetMembers().Where(m => m is IPropertySymbol).Cast<IPropertySymbol>().ToArray();
            foreach (var property in properties)
            {
                var type = property.Type as INamedTypeSymbol;
                var processor = new TypeProcessor(_builder, type, $"var {property.Name} = ");
                steps.Add(processor.Process());
            }

            method.WithBody(w =>
            {
                foreach (string step in steps)
                    w.AppendLine(step);
                
                w.AppendLine($"return new {_type.Name}({string.Join(", ", properties.Select(p => p.Name))});");
            });

            return $"{_access}{method.Name}(reader);";
        }

        private string ProcessSpecialType(ITypeSymbol symbol)
        {
            string method = symbol.SpecialType switch
            {
                SpecialType.System_Byte => "ReadU1",
                SpecialType.System_UInt16 => "ReadU2",
                SpecialType.System_UInt32 => "ReadU4",
                SpecialType.System_UInt64 => "ReadU8",
                SpecialType.System_SByte => "ReadI1",
                SpecialType.System_Int16 => "ReadI2",
                SpecialType.System_Int32 => "ReadI4",
                SpecialType.System_Int64 => "ReadI8",
                SpecialType.System_Single => "ReadR4",
                SpecialType.System_Double => "ReadR8",
                _ => $"throw new NotSupportedException(\"Unsupported special type: {symbol.MetadataName}\");"
            };

            return method.Length > 20
                ? method
                : $"{_access}reader.{method}();";
        }

        private string CheckExistingMethod(Func<string, bool> predicate)
        {
            var existing = _builder.Methods.SingleOrDefault(m =>
            {
                var parameters = m.Parameters;
                if (parameters.Count != 1)
                    return false;

                var first = parameters.First();
                return first.Type == "IBigEndianReader" && predicate(m.ReturnType);
            });

            return existing is not null
                ? $"{_access}{existing.Name}(reader);"
                : null;
        }
    }
}