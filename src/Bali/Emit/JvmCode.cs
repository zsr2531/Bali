using System.Diagnostics.CodeAnalysis;

namespace Bali.Emit
{
    /// <summary>
    /// The raw opcode of a JVM instruction.
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum JvmCode : byte
    {
        /// <summary>
        /// Loads a reference from an array.
        /// </summary>
        Aaload = 0x32,
        
        /// <summary>
        /// Stores a reference into an array.
        /// </summary>
        Aastore = 0x53,
        
        /// <summary>
        /// Pushes <c>null</c> onto the stack.
        /// </summary>
        Aconst_Null = 0x1,
        
        /// <summary>
        /// Loads a reference from a local variable.
        /// </summary>
        /// <remarks>
        /// The aload instruction cannot be used to load a value of type <c>returnAddress</c> from a local variable onto the operand stack.
        /// This asymmetry with the astore instruction (<see cref="Astore"/>) is intentional.
        /// </remarks>
        Aload = 0x19,
        
        /// <inheritdoc cref="Aload" />
        Aload_0 = 0x2a,

        /// <inheritdoc cref="Aload" />
        Aload_1 = 0x2b,

        /// <inheritdoc cref="Aload" />
        Aload_2 = 0x2c,

        /// <inheritdoc cref="Aload" />
        Aload_3 = 0x2d,
        
        /// <summary>
        /// Creates a new array of reference.
        /// </summary>
        Anewarray = 0xbd,
        
        /// <summary>
        /// Returns a reference from a method.
        /// </summary>
        Areturn = 0xb0,
        
        /// <summary>
        /// Gets the length of an array.
        /// </summary>
        Arraylength = 0xbe,
        
        /// <summary>
        /// Stores a reference into a local variable.
        /// </summary>
        /// <remarks>
        /// The astore instruction is used with an objectref of type <c>returnAddress</c> when implementing the <i>finally</i> clause of the Java programming language (§3.13).
        /// The aload instruction (<see cref="Aload"/>) cannot be used to load a value of type <c>returnAddress</c> from a local variable onto the operand stack.
        /// This asymmetry with the <see cref="Aload"/> instruction is intentional.
        /// </remarks>
        Astore = 0x3a,
        
        /// <inheritdoc cref="Astore" />
        Astore_0 = 0x4b,

        /// <inheritdoc cref="Astore" />
        Astore_1 = 0x4c,

        /// <inheritdoc cref="Astore" />
        Astore_2 = 0x4d,

        /// <inheritdoc cref="Astore" />
        Astore_3 = 0x4e,
        
        /// <summary>
        /// Throws an exception or an error.
        /// </summary>
        /// <remarks>If the exception to be thrown is <c>null</c>, a <c>NullPointerException</c> will be thrown instead.</remarks>
        Athrow = 0xbf,
        
        /// <summary>
        /// Loads a <c>byte</c>/<c>boolean</c> from an array.
        /// </summary>
        Baload = 0x33,
        
        /// <summary>
        /// Stores a <c>byte</c>/<c>boolean</c> into an array.
        /// </summary>
        Bastore = 0x54,
        
        /// <summary>
        /// Pushes a <c>byte</c> onto the stack sign-extended to an <c>int</c>.
        /// </summary>
        Bipush = 0x10,
        
        /// <summary>
        /// Loads a <c>char</c> from an array.
        /// </summary>
        Caload = 0x34,
        
        /// <summary>
        /// Stores a <c>char</c> into an array.
        /// </summary>
        Castore = 0x55,
        
        /// <summary>
        /// Checks whether the object is of given type.
        /// </summary>
        Checkcast = 0xc0,
        
        /// <summary>
        /// Converts a <c>double</c> to a <c>float</c>.
        /// </summary>
        D2f = 0x90,
        
        /// <summary>
        /// Converts a <c>double</c> to an <c>int</c>.
        /// </summary>
        D2i = 0x8e,
        
        /// <summary>
        /// Converts a <c>double</c> to a <c>long</c>.
        /// </summary>
        D2l = 0x8f,
        
        /// <summary>
        /// Adds two <c>double</c>s.
        /// </summary>
        Dadd = 0x63,
        
        /// <summary>
        /// Loads a <c>double</c> from an array.
        /// </summary>
        Daload = 0x31,
        
        /// <summary>
        /// Stores a <c>double</c> into an array.
        /// </summary>
        Dastore = 0x52,
        
        /// <summary>
        /// Compares two <c>double</c>s, and determines which one is greater.
        /// </summary>
        Dcmpg = 0x98,
        
        /// <summary>
        /// Compares two <c>double</c>s, and determines which one is lesser.
        /// </summary>
        Dcmpl = 0x97,
        
        /// <summary>
        /// Pushes the constant 0.0 as a <c>double</c> onto the stack.
        /// </summary>
        Dconst_0 = 0xe,
        
        /// <summary>
        /// Pushes the constant 1.0 as a <c>double</c> onto the stack.
        /// </summary>
        Dconst_1 = 0xf,
        
        /// <summary>
        /// Divides two <c>double</c>s.
        /// </summary>
        Ddiv = 0x6f,
        
        /// <summary>
        /// Loads a <c>double</c> from a local variable.
        /// </summary>
        Dload = 0x18,
        
        /// <inheritdoc cref="Dload" />
        Dload_0 = 0x26,
        
        /// <inheritdoc cref="Dload" />
        Dload_1 = 0x27,
        
        /// <inheritdoc cref="Dload" />
        Dload_2 = 0x28,
        
        /// <inheritdoc cref="Dload" />
        Dload_3 = 0x29,
        
        /// <summary>
        /// Multiplies two <c>double</c>s.
        /// </summary>
        Dmul = 0x6b,
        
        /// <summary>
        /// Negates a <c>double</c>.
        /// </summary>
        Dneg = 0x77,
        
        /// <summary>
        /// Divides two <c>double</c>s and gets the remainder.
        /// </summary>
        Drem = 0x73,
        
        /// <summary>
        /// Returns a <c>double</c> from a method.
        /// </summary>
        Dreturn = 0xaf,
        
        /// <summary>
        /// Stores a <c>double</c> into a local variable.
        /// </summary>
        Dstore = 0x39,
        
        /// <inheritdoc cref="Dstore" />
        Dstore_0 = 0x47,
        
        /// <inheritdoc cref="Dstore" />
        Dstore_1 = 0x48,
        
        /// <inheritdoc cref="Dstore" />
        Dstore_2 = 0x49,
        
        /// <inheritdoc cref="Dstore" />
        Dstore_3 = 0x4a,
        
        /// <summary>
        /// Subtracts two <c>double</c>s.
        /// </summary>
        Dsub = 0x67,
        
        /// <summary>
        /// Duplicates the value at the top of the stack.
        /// </summary>
        /// <remarks>Cannot be used on a <c>long</c> nor a <c>double</c>.</remarks>
        Dup = 0x59,
        
        /// <summary>
        /// Duplicates the value at the top of the stack and inserts it two values down.
        /// </summary>
        /// <remarks>Cannot be used on a <c>long</c> nor a <c>double</c>.</remarks>
        Dup_X1 = 0x5a,
        
        /// <summary>
        /// Duplicates the value at the top of the stack and inserts it two or three values down.
        /// </summary>
        /// <remarks>
        /// If the item to duplicate is a <c>long</c> or a <c>double</c>, the instruction inserts the duplicated value two values down.
        /// Otherwise, the duplicated item is inserted three values down.
        /// </remarks>
        Dup_X2 = 0x5b,
        
        /// <summary>
        /// Duplicates the top one or two values on the stack.
        /// </summary>
        /// <remarks>
        /// If the item to duplicate is a <c>long</c> or a <c>double</c>, the instruction duplicates only 1 value
        /// Otherwise, the instruction duplicates two values.
        /// </remarks>
        Dup2 = 0x5c,
        
        /// <summary>
        /// Duplicates the top one or two values and inserts them two or three values down on the stack.
        /// </summary>
        /// <remarks>
        /// If the item to duplicate is a <c>long</c> or a <c>double</c>, the instruction duplicates one value and inserts it two values down.
        /// Otherwise the instruction duplicates three values and inserts them three values down.
        /// </remarks>
        Dup2_X1 = 0x5d,
        
        /// <summary>
        /// Duplicates the top one or two values and inserts them two, three or four values down.
        /// </summary>
        /// <remarks>
        /// If the top 4 values are not <c>long</c> nor <c>double</c>: the instruction takes the top 2 values and duplicates them 4 values down.
        /// If the top value is <c>long</c> or <c>double</c> and the next two are not: the instruction takes the top value and duplicates it three values down.
        /// If the top 2 values are not <c>long</c> nor <c>double</c> but the third one is: the instruction takes the top two values and duplicates them three values down.
        /// If the top 2 values are both <c>long</c> or <c>double</c>: the instruction takes the top value and inserts it two values down.
        /// </remarks>
        Dup2_X2 = 0x5e,
        
        /// <summary>
        /// Converts a <c>float</c> to a <c>double</c>.
        /// </summary>
        F2d = 0x8d,
        
        /// <summary>
        /// Converts a <c>float</c> to an <c>int</c>.
        /// </summary>
        F2i = 0x8b,
        
        /// <summary>
        /// Converts a <c>float</c> to a <c>long</c>.
        /// </summary>
        F2l = 0x8c,
        
        /// <summary>
        /// Adds two <c>float</c>s.
        /// </summary>
        Fadd = 0x62,
        
        /// <summary>
        /// Loads a <c>float</c> from an array.
        /// </summary>
        Faload = 0x30,
        
        /// <summary>
        /// Stores a <c>float</c> into an array.
        /// </summary>
        Fastore = 0x51,
        
        /// <summary>
        /// Compares two <c>float</c>s, and determines which one is greater.
        /// </summary>
        Fcmpg = 0x96,
        
        /// <summary>
        /// Compares two <c>float</c>s, and determines which one is lesser.
        /// </summary>
        Fcmpl = 0x95,
        
        /// <summary>
        /// Pushes the constant 0.0 as a <c>float</c> onto the stack.
        /// </summary>
        Fconst_0 = 0xb,
        
        /// <summary>
        /// Pushes the constant 1.0 as a <c>float</c> onto the stack.
        /// </summary>
        Fconst_1 = 0xc,
        
        /// <summary>
        /// Pushes the constant 2.0 as a <c>float</c> onto the stack.
        /// </summary>
        Fconst_2 = 0xd,
        
        /// <summary>
        /// Divides two <c>float</c>s.
        /// </summary>
        Fdiv = 0x6e,
        
        /// <summary>
        /// Loads a <c>float</c> from a local variable.
        /// </summary>
        Fload = 0x17,
        
        /// <inheritdoc cref="Fload" />
        Fload_0 = 0x22,
        
        /// <inheritdoc cref="Fload" />
        Fload_1 = 0x23,
        
        /// <inheritdoc cref="Fload" />
        Fload_2 = 0x24,
        
        /// <inheritdoc cref="Fload" />
        Fload_3 = 0x25,
        
        /// <summary>
        /// Multiplies two <c>float</c>s.
        /// </summary>
        Fmul = 0x6a,
        
        /// <summary>
        /// Negates a <c>float</c>.
        /// </summary>
        Fneg = 0x76,
        
        /// <summary>
        /// Divides two <c>float</c> and gets the remainder.
        /// </summary>
        Frem = 0x72,
        
        /// <summary>
        /// Returns a <c>float</c> from a method.
        /// </summary>
        Freturn = 0xae,
        
        /// <summary>
        /// Stores a <c>float</c> into a local variable.
        /// </summary>
        Fstore = 0x38,
        
        /// <inheritdoc cref="Fstore" />
        Fstore_0 = 0x43,
        
        /// <inheritdoc cref="Fstore" />
        Fstore_1 = 0x44,
        
        /// <inheritdoc cref="Fstore" />
        Fstore_2 = 0x45,
        
        /// <inheritdoc cref="Fstore" />
        Fstore_3 = 0x46,
        
        /// <summary>
        /// Subtracts two <c>float</c>s.
        /// </summary>
        Fsub = 0x66,
        
        /// <summary>
        /// Gets the value of a field.
        /// </summary>
        Getfield = 0xb4,
        
        /// <summary>
        /// Gets the value of a static field.
        /// </summary>
        Getstatic = 0xb2,
        
        /// <summary>
        /// Unconditional jump.
        /// </summary>
        Goto = 0xa7,
        
        /// <inheritdoc cref="Goto" />
        Goto_w = 0xc8,
        
        /// <summary>
        /// Converts an <c>int</c> to a <c>byte</c>.
        /// </summary>
        I2b = 0x91,
        
        /// <summary>
        /// Converts an <c>int</c> to a <c>char</c>.
        /// </summary>
        I2c = 0x92,
        
        /// <summary>
        /// Converts an <c>int</c> to a <c>double</c>.
        /// </summary>
        I2d = 0x87,
        
        /// <summary>
        /// Converts an <c>int</c> to a <c>float</c>.
        /// </summary>
        I2f = 0x86,
        
        /// <summary>
        /// Converts an <c>int</c> to a <c>long</c>.
        /// </summary>
        I2l = 0x85,
        
        /// <summary>
        /// Converts an <c>int</c> to a <c>short</c>.
        /// </summary>
        I2s = 0x93,
        
        /// <summary>
        /// Adds two <c>int</c>s.
        /// </summary>
        Iadd = 0x60,
        
        /// <summary>
        /// Loads an <c>int</c> from an array.
        /// </summary>
        Iaload = 0x2e,
        
        /// <summary>
        /// Performs a bitwise AND on two <c>int</c>s.
        /// </summary>
        Iand = 0x7e,
        
        /// <summary>
        /// Stores an <c>int</c> into an array.
        /// </summary>
        Iastore = 0x4f,
        
        /// <summary>
        /// Pushes the constant -1 as an <c>int</c> onto the stack.
        /// </summary>
        Iconst_M1 = 0x2,
        
        /// <summary>
        /// Pushes the constant 0 as an <c>int</c> onto the stack.
        /// </summary>
        Iconst_0 = 0x3,
        
        /// <summary>
        /// Pushes the constant 1 as an <c>int</c> onto the stack.
        /// </summary>
        Iconst_1 = 0x4,
        
        /// <summary>
        /// Pushes the constant 2 as an <c>int</c> onto the stack.
        /// </summary>
        Iconst_2 = 0x5,
        
        /// <summary>
        /// Pushes the constant 3 as an <c>int</c> onto the stack.
        /// </summary>
        Iconst_3 = 0x6,
        
        /// <summary>
        /// Pushes the constant 4 as an <c>int</c> onto the stack.
        /// </summary>
        Iconst_4 = 0x7,
        
        /// <summary>
        /// Pushes the constant 5 as an <c>int</c> onto the stack.
        /// </summary>
        Iconst_5 = 0x8,
        
        /// <summary>
        /// Divides two <c>int</c>s.
        /// </summary>
        Idiv = 0x6c,
        
        /// <summary>
        /// Branches if reference comparison is equal.
        /// </summary>
        If_Acmpeq = 0xa5,
        
        /// <summary>
        /// Branches if reference comparison is not equal.
        /// </summary>
        If_Acmpne = 0xa6,
        
        /// <summary>
        /// Branches if int comparison is equal.
        /// </summary>
        If_Icmpeq = 0x9f,
        
        /// <summary>
        /// Branches if int comparison is not equal.
        /// </summary>
        If_Icmpne = 0xa0,
        
        /// <summary>
        /// Branches if int comparison is less.
        /// </summary>
        If_Icmplt = 0xa1,
        
        /// <summary>
        /// Branches if int comparison is greater or equal.
        /// </summary>
        If_Icmpge = 0xa2,
        
        /// <summary>
        /// Branches if int comparison is greater.
        /// </summary>
        If_Icmpgt = 0xa3,
        
        /// <summary>
        /// Branches if int comparison is less or equal.
        /// </summary>
        If_Icmple = 0xa4,
        
        /// <summary>
        /// Branches if int comparison with 0 is equal.
        /// </summary>
        Ifeq = 0x99,
        
        /// <summary>
        /// Branches if int comparison with 0 is not equal.
        /// </summary>
        Ifne = 0x9a,
        
        /// <summary>
        /// Branches if int comparison with 0 is less.
        /// </summary>
        Iflt = 0x9b,
        
        /// <summary>
        /// Branches if int comparison with 0 is greater or equal.
        /// </summary>
        Ifge = 0x9c,
        
        /// <summary>
        /// Branches if int comparison with 0 is greater.
        /// </summary>
        Ifgt = 0x9d,
        
        /// <summary>
        /// Branches if int comparison with 0 is less or equal.
        /// </summary>
        Ifle = 0x9e,
        
        /// <summary>
        /// Branches if reference is not <c>null</c>.
        /// </summary>
        Ifnonnull = 0xc7,
        
        /// <summary>
        /// Branches if reference is <c>null</c>.
        /// </summary>
        Ifnull = 0xc6,
        
        /// <summary>
        /// Increments a local variable by a constant.
        /// </summary>
        Iinc = 0x84,
        
        /// <summary>
        /// Loads an <c>int</c> from a local variable.
        /// </summary>
        Iload = 0x15,
        
        /// <inheritdoc cref="Iload"/>
        Iload_0 = 0x1a,
        
        /// <inheritdoc cref="Iload"/>
        Iload_1 = 0x1b,
        
        /// <inheritdoc cref="Iload"/>
        Iload_2 = 0x1c,
        
        /// <inheritdoc cref="Iload"/>
        Iload_3 = 0x1d,
        
        /// <summary>
        /// Multiplies two <c>int</c>s.
        /// </summary>
        Imul = 0x68,
        
        /// <summary>
        /// Negates an <c>int</c>.
        /// </summary>
        Ineg = 0x74,
        
        /// <summary>
        /// Determines if the object is of given type.
        /// </summary>
        Instanceof = 0xc1,
        
        /// <summary>
        /// Invokes a dynamic method.
        /// </summary>
        Invokedynamic = 0xba,
        
        /// <summary>
        /// Invokes an interface method.
        /// </summary>
        Invokeinterface = 0xb9,
        
        /// <summary>
        /// Invokes an instance method; special handling for superclass, private, and instance initialization method invocations.
        /// </summary>
        Invokespecial = 0xb7,
        
        /// <summary>
        /// Invokes a <c>static</c> method.
        /// </summary>
        Invokestatic = 0xb8,
        
        /// <summary>
        /// Invokes an instance method with dynamic dispatch based on the class.
        /// </summary>
        Invokevirtual = 0xb6,
        
        /// <summary>
        /// Performs a bitwise OR on two <c>int</c>s.
        /// </summary>
        Ior = 0x80,
        
        /// <summary>
        /// Takes the remainder value of two <c>int</c>s.
        /// </summary>
        Irem = 0x70,
        
        /// <summary>
        /// Returns an <c>int</c> from a method.
        /// </summary>
        Ireturn = 0xac,
        
        /// <summary>
        /// Shifts an <c>int</c> left.
        /// </summary>
        Ishl = 0x78,
        
        /// <summary>
        /// Shifts an <c>int</c> right with sign extension.
        /// </summary>
        Ishr = 0x7a,
        
        /// <summary>
        /// Stores an <c>int</c> into a local variable.
        /// </summary>
        Istore = 0x36,
        
        /// <inheritdoc cref="Istore"/>
        Istore_0 = 0x3b,
        
        /// <inheritdoc cref="Istore"/>
        Istore_1 = 0x3c,
        
        /// <inheritdoc cref="Istore"/>
        Istore_2 = 0x3d,
        
        /// <inheritdoc cref="Istore"/>
        Istore_3 = 0x3e,
        
        /// <summary>
        /// Subtracts two <c>int</c>s.
        /// </summary>
        Isub = 0x64,
        
        /// <summary>
        /// Shifts an <c>int</c> right with zero extension.
        /// </summary>
        Iushr = 0x7c,
        
        /// <summary>
        /// Performs a bitwise XOR on two <c>int</c>s.
        /// </summary>
        Ixor = 0x82,
        
        /// <summary>
        /// Jumps to a subroutine.
        /// </summary>
        Jsr = 0xa8,
        
        /// <inheritdoc cref="Jsr"/>
        Jsr_W = 0xc9,
        
        /// <summary>
        /// Converts a <c>long</c> to a <c>double</c>.
        /// </summary>
        L2d = 0x8a,
        
        /// <summary>
        /// Converts a <c>long</c> to a <c>float</c>.
        /// </summary>
        L2f = 0x89,
        
        /// <summary>
        /// Converts a <c>long</c> to a <c>int</c>.
        /// </summary>
        L2i = 0x88,
        
        /// <summary>
        /// Adds two <c>long</c>s.
        /// </summary>
        Ladd = 0x61,
        
        /// <summary>
        /// Loads a <c>long</c> from an array.
        /// </summary>
        Laload = 0x2f,
        
        /// <summary>
        /// Performs a bitwise AND on two <c>long</c>s.
        /// </summary>
        Land = 0x7f,
        
        /// <summary>
        /// Stores a <c>long</c> into an array.
        /// </summary>
        Lastore = 0x50,
        
        /// <summary>
        /// Compares two <c>long</c>s.
        /// </summary>
        Lcmp = 0x94,
        
        /// <summary>
        /// Pushes the constant 0 as <c>long</c> onto the stack.
        /// </summary>
        Lconst_0 = 0x9,
        
        /// <summary>
        /// Pushes the constant 1 as <c>long</c> onto the stack.
        /// </summary>
        Lconst_1 = 0xa,
        
        /// <summary>
        /// Pushes a constant from the constant pool onto the stack.
        /// </summary>
        Ldc = 0x12,
        
        /// <inheritdoc cref="Ldc"/>
        Ldc_W = 0x13,
        
        /// <summary>
        /// Pushes a <c>long</c> or a <c>double</c> from the constant pool onto the stack.
        /// </summary>
        Ldc2_W = 0x14,
        
        /// <summary>
        /// Divides two <c>long</c>s.
        /// </summary>
        Ldiv = 0x6d,
        
        /// <summary>
        /// Loads a <c>long</c> from a local variable.
        /// </summary>
        Lload = 0x16,
        
        /// <inheritdoc cref="Lload"/>
        Lload_0 = 0x1e,
        
        /// <inheritdoc cref="Lload"/>
        Lload_1 = 0x1f,
        
        /// <inheritdoc cref="Lload"/>
        Lload_2 = 0x20,
        
        /// <inheritdoc cref="Lload"/>
        Lload_3 = 0x21,
        
        /// <summary>
        /// Multiplies two <c>long</c>s.
        /// </summary>
        Lmul = 0x69,
        
        /// <summary>
        /// Negates a <c>long</c>.
        /// </summary>
        Lneg = 0x75,
        
        /// <summary>
        /// Jumps to the target address based on the key from the jump table.
        /// </summary>
        Lookupswitch = 0xab,
        
        /// <summary>
        /// Performs a bitwise OR on two <c>long</c>s.
        /// </summary>
        Lor = 0x81,
        
        /// <summary>
        /// Takes the remainder of two <c>long</c>s.
        /// </summary>
        Lrem = 0x71,
        
        /// <summary>
        /// Returns a <c>long</c> from a method.
        /// </summary>
        Lreturn = 0xad,
        
        /// <summary>
        /// Shifts a <c>long</c> left.
        /// </summary>
        Lshl = 0x79,
        
        /// <summary>
        /// Shifts a <c>long</c> right with sign extension.
        /// </summary>
        Lshr = 0x7b,
        
        /// <summary>
        /// Stores a <c>long</c> into a local variable.
        /// </summary>
        Lstore = 0x37,
        
        /// <inheritdoc cref="Lstore"/>
        Lstore_0 = 0x3f,
        
        /// <inheritdoc cref="Lstore"/>
        Lstore_1 = 0x40,
        
        /// <inheritdoc cref="Lstore"/>
        Lstore_2 = 0x41,
        
        /// <inheritdoc cref="Lstore"/>
        Lstore_3 = 0x42,
        
        /// <summary>
        /// Subtracts two <c>long</c>s.
        /// </summary>
        Lsub = 0x65,
        
        /// <summary>
        /// Shifts a <c>long</c> right with zero extension.
        /// </summary>
        Lushr = 0x7d,
        
        /// <summary>
        /// Performs a bitwise XOR on two <c>long</c>s.
        /// </summary>
        Lxor = 0x83,
        
        /// <summary>
        /// Enters the monitor for the object.
        /// </summary>
        Monitorenter = 0xc2,
        
        /// <summary>
        /// Exits the monitor for the object.
        /// </summary>
        Monitorexit = 0xc3,
        
        /// <summary>
        /// Creates a new multi-dimensional array.
        /// </summary>
        Multinewarray = 0xc5,
        
        /// <summary>
        /// Creates a new object.
        /// </summary>
        New = 0xbb,
        
        /// <summary>
        /// Creates a new one-dimensional array.
        /// </summary>
        Newarray = 0xbc,
        
        /// <summary>
        /// Do nothing.
        /// </summary>
        Nop = 0x0,
        
        /// <summary>
        /// Pops the top value off the stack.
        /// </summary>
        Pop = 0x57,
        
        /// <summary>
        /// Pops the top one or two values off the stack.
        /// </summary>
        /// <remarks>
        /// If the top value is a <c>long</c> or a <c>double</c>, the instruction pops 1 item off the stack.
        /// If the top 2 values are not <c>long</c>s nor <c>double</c>s, the instruction pops 2 items off the stack.
        /// </remarks>
        Pop2 = 0x58,
        
        /// <summary>
        /// Sets a field's value to the object.
        /// </summary>
        Putfield = 0xb5,
        
        /// <summary>
        /// Sets a static field's value to the object.
        /// </summary>
        Putstatic = 0xb3,
        
        /// <summary>
        /// Returns from subroutine.
        /// </summary>
        /// <remarks>Used in combination with <see cref="Jsr"/>.</remarks>
        Ret = 0xa9,
        
        /// <summary>
        /// Returns <c>void</c> from a method.
        /// </summary>
        Return = 0xb1,
        
        /// <summary>
        /// Loads a <c>short</c> from an array.
        /// </summary>
        Saload = 0x35,
        
        /// <summary>
        /// Stores a <c>short</c> into an array.
        /// </summary>
        Sastore = 0x56,
        
        /// <summary>
        /// Pushes a <c>short</c> onto the stack.
        /// </summary>
        Sipush = 0x11,
        
        /// <summary>
        /// Swaps the top two values on the stack.
        /// </summary>
        /// <remarks>Cannot be used on <c>long</c>s, nor <c>double</c>s.</remarks>
        Swap = 0x5f,
        
        /// <summary>
        /// Jumps to the target address based on the index.
        /// </summary>
        Tableswitch = 0xaa,
        
        /// <summary>
        /// Prefix opcode used to grant additional bytes to the following opcodes:
        /// <list type="bullet">
        /// <item><description><see cref="Iload"/></description></item>
        /// <item><description><see cref="Fload"/></description></item>
        /// <item><description><see cref="Aload"/></description></item>
        /// <item><description><see cref="Lload"/></description></item>
        /// <item><description><see cref="Dload"/></description></item>
        /// <item><description><see cref="Istore"/></description></item>
        /// <item><description><see cref="Fstore"/></description></item>
        /// <item><description><see cref="Astore"/></description></item>
        /// <item><description><see cref="Lstore"/></description></item>
        /// <item><description><see cref="Dstore"/></description></item>
        /// <item><description><see cref="Ret"/></description></item>
        /// <item><description><see cref="Iinc"/></description></item>
        /// </list>
        /// </summary>
        Wide = 0xc4
    }
}