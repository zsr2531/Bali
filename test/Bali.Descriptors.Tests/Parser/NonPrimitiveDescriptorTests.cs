using System;
using Xunit;

namespace Bali.Descriptors.Tests.Parser
{
    public class NonPrimitiveDescriptorTests
    {
        [Fact]
        public void MissingSemicolon()
        {
            var lexer = new DescriptorLexer("Ljava/lang/Object".AsMemory());
            var parser = new FieldDescriptorParser(lexer.Lex());

            Assert.Throws<DescriptorParserException>(() => parser.Parse());
        }

        [Fact]
        public void NoGenericParameters()
        {
            var lexer = new DescriptorLexer("Ljava/util/List<>;".AsMemory());
            var parser = new FieldDescriptorParser(lexer.Lex());

            Assert.Throws<DescriptorParserException>(() => parser.Parse());
        }
        
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
        [InlineData("Ljava/util/HashSet<Ljava/lang/String;>;", "java/util/HashSet", "java/lang/String")]
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
        [Theory]
        [InlineData("[[Ljava/lang/String;", "java/lang/String", 2)]
        [InlineData("[[[[Ljava/util/ArrayList;", "java/util/ArrayList", 4)]
        [InlineData("[Ljava/lang/Object;", "java/lang/Object", 1)]
        [InlineData("[[[[[[Ljava/util/HashMap;", "java/util/HashMap", 6)]
        public void Array(string input, string className, int arrayRank)
        {
            var lexer = new DescriptorLexer(input.AsMemory());
            var parser = new FieldDescriptorParser(lexer.Lex());
            var descriptor = parser.Parse();
            
            Assert.Equal(arrayRank, descriptor.ArrayRank);
            Assert.Equal(className, Assert.IsType<NonPrimitiveFieldDescriptor>(descriptor).ClassName);
            Assert.Empty(((NonPrimitiveFieldDescriptor) descriptor).GenericParameters);
        }

        [Theory]
        [InlineData("[[[Ljava/util/List<[[Ljava/lang/Integer;>;", "java/util/List", 3, "java/lang/Integer", 2)]
        [InlineData("[Ljava/util/HashSet<[[[[Ljava/lang/String;>;", "java/util/HashSet", 1, "java/lang/String", 4)]
        [InlineData("[[[[[Lcom/company/utils/CustomDataType<[[[Ljava/lang/Boolean;>;", "com/company/utils/CustomDataType", 5, "java/lang/Boolean", 3)]
        public void ArrayGeneric(string input, string className, int arrayRank1, string genericClassName, int arrayRank2)
        {
            var lexer = new DescriptorLexer(input.AsMemory());
            var parser = new FieldDescriptorParser(lexer.Lex());
            var descriptor = parser.Parse();
            
            Assert.Equal(arrayRank1, descriptor.ArrayRank);
            Assert.IsType<NonPrimitiveFieldDescriptor>(descriptor);
            var nonPrimitive = (NonPrimitiveFieldDescriptor) descriptor;
            Assert.Equal(className, nonPrimitive.ClassName);
            Assert.Equal(1, nonPrimitive.GenericParameters.Count);
            Assert.IsType<NonPrimitiveFieldDescriptor>(nonPrimitive.GenericParameters[0]);
            Assert.Equal(arrayRank2, nonPrimitive.GenericParameters[0].ArrayRank);
            var genericParameter = (NonPrimitiveFieldDescriptor) nonPrimitive.GenericParameters[0];
            Assert.Equal(genericClassName, genericParameter.ClassName);
        }

        [Theory]
        [InlineData("[Ljava/util/List<[Ljava/util/HashSet<[[Ljava/lang/Object;>;>;", "java/util/List", 1, "java/util/HashSet", 1, "java/lang/Object", 2)]
        [InlineData("[[[Ljava/util/HashSet<[[[[[Lcom/company/utils/CustomDataType<[[Ljava/lang/Integer;>;>;", "java/util/HashSet", 3, "com/company/utils/CustomDataType", 5, "java/lang/Integer", 2)]
        [InlineData("[[Lcom/company/utils/CustomDataType<[Ljava/util/ArrayList<[[[[Ljava/lang/String;>;>;", "com/company/utils/CustomDataType", 2, "java/util/ArrayList", 1, "java/lang/String", 4)]
        public void ArrayNestedGeneric(string input, string className, int arrayRank1, string genericClassName1, int arrayRank2,  string genericClassName2, int arrayRank3)
        {
            var lexer = new DescriptorLexer(input.AsMemory());
            var parser = new FieldDescriptorParser(lexer.Lex());
            var descriptor = parser.Parse();
            
            Assert.Equal(arrayRank1, descriptor.ArrayRank);
            Assert.IsType<NonPrimitiveFieldDescriptor>(descriptor);
            var nonPrimitive = (NonPrimitiveFieldDescriptor) descriptor;
            Assert.Equal(className, nonPrimitive.ClassName);
            Assert.Equal(1, nonPrimitive.GenericParameters.Count);
            Assert.IsType<NonPrimitiveFieldDescriptor>(nonPrimitive.GenericParameters[0]);
            Assert.Equal(arrayRank2, nonPrimitive.GenericParameters[0].ArrayRank);
            var genericParameter = (NonPrimitiveFieldDescriptor) nonPrimitive.GenericParameters[0];
            Assert.Equal(genericClassName1, genericParameter.ClassName);
            Assert.Equal(1, genericParameter.GenericParameters.Count);
            Assert.IsType<NonPrimitiveFieldDescriptor>(genericParameter.GenericParameters[0]);
            Assert.Equal(arrayRank3, genericParameter.GenericParameters[0].ArrayRank);
            var genericParameter2 = (NonPrimitiveFieldDescriptor) genericParameter.GenericParameters[0];
            Assert.Equal(genericClassName2, genericParameter2.ClassName);
            Assert.Empty(genericParameter2.GenericParameters);
        }
    }
}