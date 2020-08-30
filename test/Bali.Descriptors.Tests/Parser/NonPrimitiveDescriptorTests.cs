using System;
using Bali.IO.Descriptors;
using Xunit;

namespace Bali.Descriptors.Tests.Parser
{
    public class NonPrimitiveDescriptorTests
    {
        [Theory]
        [InlineData("Ljava/lang/String;", "java/lang/String")]
        [InlineData("Ljava/lang/Object;", "java/lang/Object")]
        [InlineData("Ljava/util/ArrayList;", "java/util/ArrayList")]
        [InlineData("Ljava/util/HashMap;", "java/util/HashMap")]
        public void Normal(string input, string className)
        {
            var lexer = new DescriptorLexer(input.AsMemory());
            var parser = new FieldDescriptorParser(lexer.Lex());
            var descriptor = parser.Parse();
            
            Assert.Equal(0, descriptor.ArrayRank);
            Assert.Equal(className, Assert.IsType<NonPrimitiveFieldDescriptor>(descriptor).ClassName);
            Assert.Empty(((NonPrimitiveFieldDescriptor) descriptor).GenericParameters);
        }

        [Theory]
        [InlineData("Ljava/util/List<Ljava/lang/Integer;>;", "java/util/List", "java/lang/Integer")]
        [InlineData("Ljava/util/HashSet<Ljava/lang/String>;", "java/util/HashSet", "java/lang/String")]
        [InlineData("Lcom/company/utils/CustomDataType<Ljava/lang/Boolean;>;", "com/company/utils/CustomDataType", "java/lang/Boolean")]
        public void Generic(string input, string className, string genericClassName)
        {
            var lexer = new DescriptorLexer(input.AsMemory());
            var parser = new FieldDescriptorParser(lexer.Lex());
            var descriptor = parser.Parse();
            
            Assert.Equal(0, descriptor.ArrayRank);
            Assert.IsType<NonPrimitiveFieldDescriptor>(descriptor);
            var nonPrimitive = (NonPrimitiveFieldDescriptor) descriptor;
            Assert.Equal(className, nonPrimitive.ClassName);
            Assert.Equal(1, nonPrimitive.GenericParameters.Count);
            Assert.IsType<NonPrimitiveFieldDescriptor>(nonPrimitive.GenericParameters[0]);
            var genericParameter = (NonPrimitiveFieldDescriptor) nonPrimitive.GenericParameters[0];
            Assert.Equal(genericClassName, genericParameter.ClassName);
        }

        [Theory]
        [InlineData("Ljava/util/List<Ljava/util/HashSet<Ljava/lang/Object;>;>;", "java/util/List", "java/util/HashSet", "java/lang/Object")]
        [InlineData("Ljava/util/HashSet<Lcom/company/utils/CustomDataType<Ljava/lang/Integer;>;>;", "java/util/HashSet", "com/company/utils/CustomDataType", "java/lang/Integer")]
        [InlineData("Lcom/company/utils/CustomDataType<Ljava/util/ArrayList<Ljava/lang/String;>;>;", "com/company/utils/CustomDataType", "java/util/ArrayList", "java/lang/String")]
        public void NestedGeneric(string input, string className, string genericClassName1, string genericClassName2)
        {
            var lexer = new DescriptorLexer(input.AsMemory());
            var parser = new FieldDescriptorParser(lexer.Lex());
            var descriptor = parser.Parse();
            
            Assert.Equal(0, descriptor.ArrayRank);
            Assert.IsType<NonPrimitiveFieldDescriptor>(descriptor);
            var nonPrimitive = (NonPrimitiveFieldDescriptor) descriptor;
            Assert.Equal(className, nonPrimitive.ClassName);
            Assert.Equal(1, nonPrimitive.GenericParameters.Count);
            Assert.IsType<NonPrimitiveFieldDescriptor>(nonPrimitive.GenericParameters[0]);
            var genericParameter = (NonPrimitiveFieldDescriptor) nonPrimitive.GenericParameters[0];
            Assert.Equal(genericClassName1, genericParameter.ClassName);
            Assert.Equal(1, genericParameter.GenericParameters.Count);
            Assert.IsType<NonPrimitiveFieldDescriptor>(genericParameter.GenericParameters[0]);
            var genericParameter2 = (NonPrimitiveFieldDescriptor) genericParameter.GenericParameters[0];
            Assert.Equal(genericClassName2, genericParameter2.ClassName);
            Assert.Empty(genericParameter2.GenericParameters);
        }
    }
}