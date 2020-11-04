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
        /// Stores a reference to an array.
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
        /// Stores a <c>byte</c>/<c>boolean</c> to an array.
        /// </summary>
        Bastore = 0x54,
        
        bipush = 0x10,
        
        caload = 0x34,
        
        castore = 0x55,
        
        checkcast = 0xc0,
        
        d2f = 0x90,
        
        d2i = 0x8e,
        
        d2l = 0x8f,
        
        dadd = 0x63,
        
        daload = 0x31,
        
        dastore = 0x52,
        
        dcmpg = 0x98,
        
        dcmpl = 0x97,
        
        dconst_0 = 0xe,
        
        dconst_1 = 0xf,
        
        ddiv = 0x6f,
        
        dload = 0x18,
        
        dload_0 = 0x26,
        
        dload_1 = 0x27,
        
        dload_2 = 0x28,
        
        dload_3 = 0x29,
        
        dmul = 0x6b,
        
        dneg = 0x77,
        
        drem = 0x73,
        
        dreturn = 0xaf,
        
        dstore = 0x39,
        
        dstore_0 = 0x47,
        
        dstore_1 = 0x48,
        
        dstore_2 = 0x49,
        
        dstore_3 = 0x4a,
        
        dsub = 0x67,
        
        dup = 0x59,
        
        dup_x1 = 0x5a,
        
        dup_x2 = 0x5b,
        
        dup2 = 0x5c,
        
        dup2_x1 = 0x5d,
        
        dup2_x2 = 0x5e,
        
        f2d = 0x8d,
        
        f2i = 0x8b,
        
        f2l = 0x8c,
        
        fadd = 0x62,
        
        faload = 0x30,
        
        fastore = 0x51,
        
        fcmpg = 0x96,
        
        fcmpl = 0x95,
        
        fconst_0 = 0xb,
        
        fconst_1 = 0xc,
        
        fconst_2 = 0xd,
        
        fdiv = 0x6e,
        
        fload = 0x17,
        
        fload_0 = 0x22,
        
        fload_1 = 0x23,
        
        fload_2 = 0x24,
        
        fload_3 = 0x25,
        
        fmul = 0x6a,
        
        fneg = 0x76,
        
        frem = 0x72,
        
        freturn = 0xae,
        
        fstore = 0x38,
        
        fstore_0 = 0x43,
        
        fstore_1 = 0x44,
        
        fstore_2 = 0x45,
        
        fstore_3 = 0x46,
        
        fsub = 0x66,
        
        getfield = 0xb4,
        
        getstatic = 0xb2,
        
        @goto = 0xa7,
        
        goto_w = 0xc8,
        
        i2b = 0x91,
        
        i2c = 0x92,
        
        i2d = 0x87,
        
        i2f = 0x86,
        
        i2l = 0x85,
        
        i2s = 0x93,
        
        iadd = 0x60,
        
        iaload = 0x2e,
        
        iand = 0x7e,
        
        iastore = 0x4f,
        
        iconst_m1 = 0x2,
        
        iconst_0 = 0x3,
        
        iconst_1 = 0x4,
        
        iconst_2 = 0x5,
        
        iconst_3 = 0x6,
        
        iconst_4 = 0x7,
        
        iconst_5 = 0x8,
        
        idiv = 0x6c,
        
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