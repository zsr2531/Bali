namespace Bali.Emit
{
    /// <summary>
    /// The raw opcode of a JVM instruction.
    /// </summary>
    public enum JvmCode : byte
    {
        /// <summary>
        /// Load onto the stack a reference from an array.
        /// </summary>
        Aaload = 0x32,

        /// <summary>
        /// Store a reference in an array.
        /// </summary>
        Aastore = 0x53,

        /// <summary>
        /// Push a <i>null</i> reference onto the stack.
        /// </summary>
        AconstNull = 0x01,

        /// <summary>
        /// Load a reference onto the stack from a local variable <i>#index</i>.
        /// </summary>
        Aload = 0x19,

        /// <summary>
        /// Load a reference onto the stack from local variable 0.
        /// </summary>
        Aload0 = 0x2a,

        /// <summary>
        /// Load a reference onto the stack from local variable 1.
        /// </summary>
        Aload1 = 0x2b,

        /// <summary>
        /// Load a reference onto the stack from local variable 2.
        /// </summary>
        Aload2 = 0x2c,

        /// <summary>
        /// Load a reference onto the stack from local variable 3.
        /// </summary>
        Aload3 = 0x2d,

        /// <summary>
        /// Create a new array of references of length <i>count</i> and component type identified by the class reference <i>index</i> (<c>indexbyte1 &lt;&lt; 8 | indexbyte2</c>) in the constant pool.
        /// </summary>
        Anewarray = 0xbd,

        /// <summary>
        /// Return a reference from a method.
        /// </summary>
        Areturn = 0xb0,

        /// <summary>
        /// Get the length of an array.
        /// </summary>
        Arraylength = 0xbe,

        /// <summary>
        /// Store a reference into a local variable <i>#index</i>.
        /// </summary>
        Astore = 0x3a,

        /// <summary>
        /// Store a reference into local variable 0.
        /// </summary>
        Astore0 = 0x4b,

        /// <summary>
        /// Store a reference into local variable 1.
        /// </summary>
        Astore1 = 0x4c,

        /// <summary>
        /// Store a reference into local variable 2.
        /// </summary>
        Astore2 = 0x4d,

        /// <summary>
        /// Store a reference into local variable 3.
        /// </summary>
        Astore3 = 0x4e,

        /// <summary>
        /// Throws an error or exception (notice that the rest of the stack is cleared, leaving only a reference to the Throwable).
        /// </summary>
        Athrow = 0xbf,

        /// <summary>
        /// Load a byte or Boolean value from an array.
        /// </summary>
        Baload = 0x33,

        /// <summary>
        /// Store a byte or Boolean value into an array.
        /// </summary>
        Bastore = 0x54,

        /// <summary>
        /// Push a <i>byte</i> onto the stack as an integer <i>value</i>.
        /// </summary>
        Bipush = 0x10,

        /// <summary>
        /// Reserved for breakpoints in Java debuggers; should not appear in any class file.
        /// </summary>
        Breakpoint = 0xca,

        /// <summary>
        /// Load a char from an array.
        /// </summary>
        Caload = 0x34,

        /// <summary>
        /// Store a char into an array.
        /// </summary>
        Castore = 0x55,

        /// <summary>
        /// Checks whether an <i>objectref</i> is of a certain type, the class reference of which is in the constant pool at <i>index</i> (<c>indexbyte1 &lt;&lt; 8 | indexbyte2</c>).
        /// </summary>
        Checkcast = 0xc0,

        /// <summary>
        /// Convert a double to a float.
        /// </summary>
        D2F = 0x90,

        /// <summary>
        /// Convert a double to an int.
        /// </summary>
        D2I = 0x8e,

        /// <summary>
        /// Convert a double to a long.
        /// </summary>
        D2L = 0x8f,

        /// <summary>
        /// Add two doubles.
        /// </summary>
        Dadd = 0x63,

        /// <summary>
        /// Load a double from an array.
        /// </summary>
        Daload = 0x31,

        /// <summary>
        /// Store a double into an array.
        /// </summary>
        Dastore = 0x52,

        /// <summary>
        /// Compare two doubles, 1 on NaN.
        /// </summary>
        Dcmpg = 0x98,

        /// <summary>
        /// Compare two doubles, -1 on NaN.
        /// </summary>
        Dcmpl = 0x97,

        /// <summary>
        /// Push the constant <i>0.0</i> (a <i>double</i>) onto the stack.
        /// </summary>
        Dconst0 = 0x0e,

        /// <summary>
        /// Push the constant <i>1.0</i> (a <i>double</i>) onto the stack.
        /// </summary>
        Dconst1 = 0x0f,

        /// <summary>
        /// Divide two doubles.
        /// </summary>
        Ddiv = 0x6f,

        /// <summary>
        /// Load a double <i>value</i> from a local variable <i>#index</i>.
        /// </summary>
        Dload = 0x18,

        /// <summary>
        /// Load a double from local variable 0.
        /// </summary>
        Dload0 = 0x26,

        /// <summary>
        /// Load a double from local variable 1.
        /// </summary>
        Dload1 = 0x27,

        /// <summary>
        /// Load a double from local variable 2.
        /// </summary>
        Dload2 = 0x28,

        /// <summary>
        /// Load a double from local variable 3.
        /// </summary>
        Dload3 = 0x29,

        /// <summary>
        /// Multiply two doubles.
        /// </summary>
        Dmul = 0x6b,

        /// <summary>
        /// Negate a double.
        /// </summary>
        Dneg = 0x77,

        /// <summary>
        /// Get the remainder from a division between two doubles.
        /// </summary>
        Drem = 0x73,

        /// <summary>
        /// Return a double from a method.
        /// </summary>
        Dreturn = 0xaf,

        /// <summary>
        /// Store a double <i>value</i> into a local variable <i>#index</i>.
        /// </summary>
        Dstore = 0x39,

        /// <summary>
        /// Store a double into local variable 0.
        /// </summary>
        Dstore0 = 0x47,

        /// <summary>
        /// Store a double into local variable 1.
        /// </summary>
        Dstore1 = 0x48,

        /// <summary>
        /// Store a double into local variable 2.
        /// </summary>
        Dstore2 = 0x49,

        /// <summary>
        /// Store a double into local variable 3.
        /// </summary>
        Dstore3 = 0x4a,

        /// <summary>
        /// Subtract a double from another.
        /// </summary>
        Dsub = 0x67,

        /// <summary>
        /// Duplicate the value on top of the stack.
        /// </summary>
        Dup = 0x59,

        /// <summary>
        /// Insert a copy of the top value into the stack two values from the top. value1 and value2 must not be of the type double or long..
        /// </summary>
        DupX1 = 0x5a,

        /// <summary>
        /// Insert a copy of the top value into the stack two (if value2 is double or long it takes up the entry of value3, too) or three values (if value2 is neither double nor long) from the top.
        /// </summary>
        DupX2 = 0x5b,

        /// <summary>
        /// Duplicate top two stack words (two values, if value1 is not double nor long; a single value, if value1 is double or long).
        /// </summary>
        Dup2 = 0x5c,

        /// <summary>
        /// Duplicate two words and insert beneath third word (see explanation above).
        /// </summary>
        Dup2X1 = 0x5d,

        /// <summary>
        /// Duplicate two words and insert beneath fourth word.
        /// </summary>
        Dup2X2 = 0x5e,

        /// <summary>
        /// Convert a float to a double.
        /// </summary>
        F2d = 0x8d,

        /// <summary>
        /// Convert a float to an int.
        /// </summary>
        F2I = 0x8b,

        /// <summary>
        /// Convert a float to a long.
        /// </summary>
        F2L = 0x8c,

        /// <summary>
        /// Add two floats.
        /// </summary>
        Fadd = 0x62,

        /// <summary>
        /// Load a float from an array.
        /// </summary>
        Faload = 0x30,

        /// <summary>
        /// Store a float in an array.
        /// </summary>
        Fastore = 0x51,

        /// <summary>
        /// Compare two floats, 1 on NaN.
        /// </summary>
        Fcmpg = 0x96,

        /// <summary>
        /// Compare two floats, -1 on NaN.
        /// </summary>
        Fcmpl = 0x95,

        /// <summary>
        /// Push <i>0.0f</i> on the stack.
        /// </summary>
        Fconst0 = 0x0b,

        /// <summary>
        /// Push <i>1.0f</i> on the stack.
        /// </summary>
        Fconst1 = 0x0c,

        /// <summary>
        /// Push <i>2.0f</i> on the stack.
        /// </summary>
        Fconst2 = 0x0d,

        /// <summary>
        /// Divide two floats.
        /// </summary>
        Fdiv = 0x6e,

        /// <summary>
        /// Load a float <i>value</i> from a local variable <i>#index</i>.
        /// </summary>
        Fload = 0x17,

        /// <summary>
        /// Load a float <i>value</i> from local variable 0.
        /// </summary>
        Fload0 = 0x22,

        /// <summary>
        /// Load a float <i>value</i> from local variable 1.
        /// </summary>
        Fload1 = 0x23,

        /// <summary>
        /// Load a float <i>value</i> from local variable 2.
        /// </summary>
        Fload2 = 0x24,

        /// <summary>
        /// Load a float <i>value</i> from local variable 3.
        /// </summary>
        Fload3 = 0x25,

        /// <summary>
        /// Multiply two floats.
        /// </summary>
        Fmul = 0x6a,

        /// <summary>
        /// Negate a float.
        /// </summary>
        Fneg = 0x76,

        /// <summary>
        /// Get the remainder from a division between two floats.
        /// </summary>
        Frem = 0x72,

        /// <summary>
        /// Return a float.
        /// </summary>
        Freturn = 0xae,

        /// <summary>
        /// Store a float <i>value</i> into a local variable <i>#index</i>.
        /// </summary>
        Fstore = 0x38,

        /// <summary>
        /// Store a float <i>value</i> into local variable 0.
        /// </summary>
        Fstore0 = 0x43,

        /// <summary>
        /// Store a float <i>value</i> into local variable 1.
        /// </summary>
        Fstore1 = 0x44,

        /// <summary>
        /// Store a float <i>value</i> into local variable 2.
        /// </summary>
        Fstore2 = 0x45,

        /// <summary>
        /// Store a float <i>value</i> into local variable 3.
        /// </summary>
        Fstore3 = 0x46,

        /// <summary>
        /// Subtract two floats.
        /// </summary>
        Fsub = 0x66,

        /// <summary>
        /// Get a field <i>value</i> of an object <i>objectref</i>, where the field is identified by field reference in the constant pool <i>index</i> (<c>indexbyte1 &lt;&lt; 8 | indexbyte2</c>).
        /// </summary>
        Getfield = 0xb4,

        /// <summary>
        /// Get a static field <i>value</i> of a class, where the field is identified by field reference in the constant pool <i>index</i> (<c>indexbyte1 &lt;&lt; 8 | indexbyte2</c>).
        /// </summary>
        Getstatic = 0xb2,

        /// <summary>
        /// Goes to another instruction at <i>branchoffset</i> (signed short constructed from unsigned bytes <c>branchbyte1 &lt;&lt; 8 | branchbyte2</c>).
        /// </summary>
        Goto = 0xa7,

        /// <summary>
        /// Goes to another instruction at <i>branchoffset</i> (signed int constructed from unsigned bytes <c>branchbyte1 &lt;&lt; 24 | branchbyte2 &lt;&lt; 16 | branchbyte3 &lt;&lt; 8 | branchbyte4</c>).
        /// </summary>
        GotoW = 0xc8,

        /// <summary>
        /// Convert an int into a byte.
        /// </summary>
        I2B = 0x91,

        /// <summary>
        /// Convert an int into a character.
        /// </summary>
        I2C = 0x92,

        /// <summary>
        /// Convert an int into a double.
        /// </summary>
        I2d = 0x87,

        /// <summary>
        /// Convert an int into a float.
        /// </summary>
        I2F = 0x86,

        /// <summary>
        /// Convert an int into a long.
        /// </summary>
        I2L = 0x85,

        /// <summary>
        /// Convert an int into a short.
        /// </summary>
        I2S = 0x93,

        /// <summary>
        /// Add two ints.
        /// </summary>
        Iadd = 0x60,

        /// <summary>
        /// Load an int from an array.
        /// </summary>
        Iaload = 0x2e,

        /// <summary>
        /// Perform a bitwise AND on two integers.
        /// </summary>
        Iand = 0x7e,

        /// <summary>
        /// Store an int into an array.
        /// </summary>
        Iastore = 0x4f,

        /// <summary>
        /// Load the int value −1 onto the stack.
        /// </summary>
        IconstM1 = 0x02,

        /// <summary>
        /// Load the int value 0 onto the stack.
        /// </summary>
        Iconst0 = 0x03,

        /// <summary>
        /// Load the int value 1 onto the stack.
        /// </summary>
        Iconst1 = 0x04,

        /// <summary>
        /// Load the int value 2 onto the stack.
        /// </summary>
        Iconst2 = 0x05,

        /// <summary>
        /// Load the int value 3 onto the stack.
        /// </summary>
        Iconst3 = 0x06,

        /// <summary>
        /// Load the int value 4 onto the stack.
        /// </summary>
        Iconst4 = 0x07,

        /// <summary>
        /// Load the int value 5 onto the stack.
        /// </summary>
        Iconst5 = 0x08,

        /// <summary>
        /// Divide two integers.
        /// </summary>
        Idiv = 0x6c,

        /// <summary>
        /// If references are equal, branch to instruction at <i>branchoffset</i> (signed short constructed from unsigned bytes <c>branchbyte1 &lt;&lt; 8 | branchbyte2</c>).
        /// </summary>
        IfAcmpeq = 0xa5,

        /// <summary>
        /// If references are not equal, branch to instruction at <i>branchoffset</i> (signed short constructed from unsigned bytes <c>branchbyte1 &lt;&lt; 8 | branchbyte2</c>).
        /// </summary>
        IfAcmpne = 0xa6,

        /// <summary>
        /// If ints are equal, branch to instruction at <i>branchoffset</i> (signed short constructed from unsigned bytes <c>branchbyte1 &lt;&lt; 8 | branchbyte2</c>).
        /// </summary>
        IfIcmpeq = 0x9f,

        /// <summary>
        /// If <i>value1</i> is greater than or equal to <i>value2</i>, branch to instruction at <i>branchoffset</i> (signed short constructed from unsigned bytes <c>branchbyte1 &lt;&lt; 8 | branchbyte2</c>).
        /// </summary>
        IfIcmpge = 0xa2,

        /// <summary>
        /// If <i>value1</i> is greater than <i>value2</i>, branch to instruction at <i>branchoffset</i> (signed short constructed from unsigned bytes <c>branchbyte1 &lt;&lt; 8 | branchbyte2</c>).
        /// </summary>
        IfIcmpgt = 0xa3,

        /// <summary>
        /// If <i>value1</i> is less than or equal to <i>value2</i>, branch to instruction at <i>branchoffset</i> (signed short constructed from unsigned bytes <c>branchbyte1 &lt;&lt; 8 | branchbyte2</c>).
        /// </summary>
        IfIcmple = 0xa4,

        /// <summary>
        /// If <i>value1</i> is less than <i>value2</i>, branch to instruction at <i>branchoffset</i> (signed short constructed from unsigned bytes <c>branchbyte1 &lt;&lt; 8 | branchbyte2</c>).
        /// </summary>
        IfIcmplt = 0xa1,

        /// <summary>
        /// If ints are not equal, branch to instruction at <i>branchoffset</i> (signed short constructed from unsigned bytes <c>branchbyte1 &lt;&lt; 8 | branchbyte2</c>).
        /// </summary>
        IfIcmpne = 0xa0,

        /// <summary>
        /// If <i>value</i> is 0, branch to instruction at <i>branchoffset</i> (signed short constructed from unsigned bytes <c>branchbyte1 &lt;&lt; 8 | branchbyte2</c>).
        /// </summary>
        Ifeq = 0x99,

        /// <summary>
        /// If <i>value</i> is greater than or equal to 0, branch to instruction at <i>branchoffset</i> (signed short constructed from unsigned bytes <c>branchbyte1 &lt;&lt; 8 | branchbyte2</c>).
        /// </summary>
        Ifge = 0x9c,

        /// <summary>
        /// If <i>value</i> is greater than 0, branch to instruction at <i>branchoffset</i> (signed short constructed from unsigned bytes <c>branchbyte1 &lt;&lt; 8 | branchbyte2</c>).
        /// </summary>
        Ifgt = 0x9d,

        /// <summary>
        /// If <i>value</i> is less than or equal to 0, branch to instruction at <i>branchoffset</i> (signed short constructed from unsigned bytes <c>branchbyte1 &lt;&lt; 8 | branchbyte2</c>).
        /// </summary>
        Ifle = 0x9e,

        /// <summary>
        /// If <i>value</i> is less than 0, branch to instruction at <i>branchoffset</i> (signed short constructed from unsigned bytes <c>branchbyte1 &lt;&lt; 8 | branchbyte2</c>).
        /// </summary>
        Iflt = 0x9b,

        /// <summary>
        /// If <i>value</i> is not 0, branch to instruction at <i>branchoffset</i> (signed short constructed from unsigned bytes <c>branchbyte1 &lt;&lt; 8 | branchbyte2</c>).
        /// </summary>
        Ifne = 0x9a,

        /// <summary>
        /// If <i>value</i> is not null, branch to instruction at <i>branchoffset</i> (signed short constructed from unsigned bytes <c>branchbyte1 &lt;&lt; 8 | branchbyte2</c>).
        /// </summary>
        Ifnonnull = 0xc7,

        /// <summary>
        /// If <i>value</i> is null, branch to instruction at <i>branchoffset</i> (signed short constructed from unsigned bytes <c>branchbyte1 &lt;&lt; 8 | branchbyte2</c>).
        /// </summary>
        Ifnull = 0xc6,

        /// <summary>
        /// Increment local variable <i>#index</i> by signed byte <i>const</i>.
        /// </summary>
        Iinc = 0x84,

        /// <summary>
        /// Load an int <i>value</i> from a local variable <i>#index</i>.
        /// </summary>
        Iload = 0x15,

        /// <summary>
        /// Load an int <i>value</i> from local variable 0.
        /// </summary>
        Iload0 = 0x1a,

        /// <summary>
        /// Load an int <i>value</i> from local variable 1.
        /// </summary>
        Iload1 = 0x1b,

        /// <summary>
        /// Load an int <i>value</i> from local variable 2.
        /// </summary>
        Iload2 = 0x1c,

        /// <summary>
        /// Load an int <i>value</i> from local variable 3.
        /// </summary>
        Iload3 = 0x1d,

        /// <summary>
        /// Reserved for implementation-dependent operations within debuggers; should not appear in any class file.
        /// </summary>
        Impdep1 = 0xfe,

        /// <summary>
        /// Reserved for implementation-dependent operations within debuggers; should not appear in any class file.
        /// </summary>
        Impdep2 = 0xff,

        /// <summary>
        /// Multiply two integers.
        /// </summary>
        Imul = 0x68,

        /// <summary>
        /// Negate int.
        /// </summary>
        Ineg = 0x74,

        /// <summary>
        /// Determines if an object <i>objectref</i> is of a given type, identified by class reference <i>index</i> in constant pool (<c>indexbyte1 &lt;&lt; 8 | indexbyte2</c>).
        /// </summary>
        Instanceof = 0xc1,

        /// <summary>
        /// Invokes a dynamic method and puts the result on the stack (might be void); the method is identified by method reference <i>index</i> in constant pool (<c>indexbyte1 &lt;&lt; 8 | indexbyte2</c>).
        /// </summary>
        Invokedynamic = 0xba,

        /// <summary>
        /// Invokes an interface method on object <i>objectref</i> and puts the result on the stack (might be void); the interface method is identified by method reference <i>index</i> in constant pool (<c>indexbyte1 &lt;&lt; 8 | indexbyte2</c>).
        /// </summary>
        Invokeinterface = 0xb9,

        /// <summary>
        /// Invoke instance method on object <i>objectref</i> and puts the result on the stack (might be void); the method is identified by method reference <i>index</i> in constant pool (<c>indexbyte1 &lt;&lt; 8 | indexbyte2</c>).
        /// </summary>
        Invokespecial = 0xb7,

        /// <summary>
        /// Invoke a static method and puts the result on the stack (might be void); the method is identified by method reference <i>index</i> in constant pool (<c>indexbyte1 &lt;&lt; 8 | indexbyte2</c>).
        /// </summary>
        Invokestatic = 0xb8,

        /// <summary>
        /// Invoke virtual method on object <i>objectref</i> and puts the result on the stack (might be void); the method is identified by method reference <i>index</i> in constant pool (<c>indexbyte1 &lt;&lt; 8 | indexbyte2</c>).
        /// </summary>
        Invokevirtual = 0xb6,

        /// <summary>
        /// Bitwise int OR.
        /// </summary>
        Ior = 0x80,

        /// <summary>
        /// Logical int remainder.
        /// </summary>
        Irem = 0x70,

        /// <summary>
        /// Return an integer from a method.
        /// </summary>
        Ireturn = 0xac,

        /// <summary>
        /// Int shift left.
        /// </summary>
        Ishl = 0x78,

        /// <summary>
        /// Int arithmetic shift right.
        /// </summary>
        Ishr = 0x7a,

        /// <summary>
        /// Store int <i>value</i> into variable <i>#index</i>.
        /// </summary>
        Istore = 0x36,

        /// <summary>
        /// Store int <i>value</i> into variable 0.
        /// </summary>
        Istore0 = 0x3b,

        /// <summary>
        /// Store int <i>value</i> into variable 1.
        /// </summary>
        Istore1 = 0x3c,

        /// <summary>
        /// Store int <i>value</i> into variable 2.
        /// </summary>
        Istore2 = 0x3d,

        /// <summary>
        /// Store int <i>value</i> into variable 3.
        /// </summary>
        Istore3 = 0x3e,

        /// <summary>
        /// Int subtract.
        /// </summary>
        Isub = 0x64,

        /// <summary>
        /// Int logical shift right.
        /// </summary>
        Iushr = 0x7c,

        /// <summary>
        /// Int xor.
        /// </summary>
        Ixor = 0x82,

        /// <summary>
        /// Jump to subroutine at <i>branchoffset</i> (signed short constructed from unsigned bytes <c>branchbyte1 &lt;&lt; 8 | branchbyte2</c>) and place the return address on the stack.
        /// </summary>
        Jsr = 0xa8,

        /// <summary>
        /// Jump to subroutine at <i>branchoffset</i> (signed int constructed from unsigned bytes <c>branchbyte1 &lt;&lt; 24 | branchbyte2 &lt;&lt; 16 | branchbyte3 &lt;&lt; 8 | branchbyte4</c>) and place the return address on the stack.
        /// </summary>
        JsrW = 0xc9,

        /// <summary>
        /// Convert a long to a double.
        /// </summary>
        L2d = 0x8a,

        /// <summary>
        /// Convert a long to a float.
        /// </summary>
        L2F = 0x89,

        /// <summary>
        /// Convert a long to a int.
        /// </summary>
        L2I = 0x88,

        /// <summary>
        /// Add two longs.
        /// </summary>
        Ladd = 0x61,

        /// <summary>
        /// Load a long from an array.
        /// </summary>
        Laload = 0x2f,

        /// <summary>
        /// bitwise AND of two longs.
        /// </summary>
        Land = 0x7f,

        /// <summary>
        /// Store a long to an array.
        /// </summary>
        Lastore = 0x50,

        /// <summary>
        /// Push 0 if the two longs are the same, 1 if value1 is greater than value2, -1 otherwise.
        /// </summary>
        Lcmp = 0x94,

        /// <summary>
        /// Push <i>0L</i> (the number zero with type <i>long</i>) onto the stack.
        /// </summary>
        Lconst0 = 0x09,

        /// <summary>
        /// Push <i>1L</i> (the number one with type <i>long</i>) onto the stack.
        /// </summary>
        Lconst1 = 0x0a,

        /// <summary>
        /// Push a constant <i>#index</i> from a constant pool (String, int, float, Class, java.lang.invoke.MethodType, java.lang.invoke.MethodHandle, or a dynamically-computed constant) onto the stack.
        /// </summary>
        Ldc = 0x12,

        /// <summary>
        /// Push a constant <i>#index</i> from a constant pool (String, int, float, Class, java.lang.invoke.MethodType, java.lang.invoke.MethodHandle, or a dynamically-computed constant) onto the stack (wide <i>index</i> is constructed as <c>indexbyte1 &lt;&lt; 8 | indexbyte2</c>).
        /// </summary>
        LdcW = 0x13,

        /// <summary>
        /// Push a constant <i>#index</i> from a constant pool (double, long, or a dynamically-computed constant) onto the stack (wide <i>index</i> is constructed as <c>indexbyte1 &lt;&lt; 8 | indexbyte2</c>).
        /// </summary>
        Ldc2W = 0x14,

        /// <summary>
        /// Divide two longs.
        /// </summary>
        Ldiv = 0x6d,

        /// <summary>
        /// Load a long value from a local variable <i>#index</i>.
        /// </summary>
        Lload = 0x16,

        /// <summary>
        /// Load a long value from a local variable 0.
        /// </summary>
        Lload0 = 0x1e,

        /// <summary>
        /// Load a long value from a local variable 1.
        /// </summary>
        Lload1 = 0x1f,

        /// <summary>
        /// Load a long value from a local variable 2.
        /// </summary>
        Lload2 = 0x20,

        /// <summary>
        /// Load a long value from a local variable 3.
        /// </summary>
        Lload3 = 0x21,

        /// <summary>
        /// Multiply two longs.
        /// </summary>
        Lmul = 0x69,

        /// <summary>
        /// Negate a long.
        /// </summary>
        Lneg = 0x75,

        /// <summary>
        /// A target address is looked up from a table using a key and execution continues from the instruction at that address.
        /// </summary>
        Lookupswitch = 0xab,

        /// <summary>
        /// Bitwise OR of two longs.
        /// </summary>
        Lor = 0x81,

        /// <summary>
        /// Remainder of division of two longs.
        /// </summary>
        Lrem = 0x71,

        /// <summary>
        /// Return a long value.
        /// </summary>
        Lreturn = 0xad,

        /// <summary>
        /// Bitwise shift left of a long <i>value1</i> by int <i>value2</i> positions.
        /// </summary>
        Lshl = 0x79,

        /// <summary>
        /// Bitwise shift right of a long <i>value1</i> by int <i>value2</i> positions.
        /// </summary>
        Lshr = 0x7b,

        /// <summary>
        /// Store a long <i>value</i> in a local variable <i>#index</i>.
        /// </summary>
        Lstore = 0x37,

        /// <summary>
        /// Store a long <i>value</i> in a local variable 0.
        /// </summary>
        Lstore0 = 0x3f,

        /// <summary>
        /// Store a long <i>value</i> in a local variable 1.
        /// </summary>
        Lstore1 = 0x40,

        /// <summary>
        /// Store a long <i>value</i> in a local variable 2.
        /// </summary>
        Lstore2 = 0x41,

        /// <summary>
        /// Store a long <i>value</i> in a local variable 3.
        /// </summary>
        Lstore3 = 0x42,

        /// <summary>
        /// Subtract two longs.
        /// </summary>
        Lsub = 0x65,

        /// <summary>
        /// Bitwise shift right of a long <i>value1</i> by int <i>value2</i> positions, unsigned.
        /// </summary>
        Lushr = 0x7d,

        /// <summary>
        /// Bitwise XOR of two longs.
        /// </summary>
        Lxor = 0x83,

        /// <summary>
        /// Enter monitor for object ("grab the lock" – start of synchronized() section).
        /// </summary>
        Monitorenter = 0xc2,

        /// <summary>
        /// Exit monitor for object ("release the lock" – end of synchronized() section).
        /// </summary>
        Monitorexit = 0xc3,

        /// <summary>
        /// Create a new array of <i>dimensions</i> dimensions of type identified by class reference in constant pool <i>index</i> (<c>indexbyte1 &lt;&lt; 8 | indexbyte2</c>); the sizes of each dimension is identified by <i>count1</i>, [<i>count2</i>, etc.].
        /// </summary>
        Multianewarray = 0xc5,

        /// <summary>
        /// Create new object of type identified by class reference in constant pool <i>index</i> (<c>indexbyte1 &lt;&lt; 8 | indexbyte2</c>).
        /// </summary>
        New = 0xbb,

        /// <summary>
        /// Create new array with <i>count</i> elements of primitive type identified by <i>atype</i>.
        /// </summary>
        Newarray = 0xbc,

        /// <summary>
        /// Perform no operation.
        /// </summary>
        Nop = 0x00,

        /// <summary>
        /// Discard the top value on the stack.
        /// </summary>
        Pop = 0x57,

        /// <summary>
        /// Discard the top two values on the stack (or one value, if it is a double or long).
        /// </summary>
        Pop2 = 0x58,

        /// <summary>
        /// Set field to <i>value</i> in an object <i>objectref</i>, where the field is identified by a field reference <i>index</i> in constant pool (<c>indexbyte1 &lt;&lt; 8 | indexbyte2</c>).
        /// </summary>
        Putfield = 0xb5,

        /// <summary>
        /// Set static field to <i>value</i> in a class, where the field is identified by a field reference <i>index</i> in constant pool (<c>indexbyte1 &lt;&lt; 8 | indexbyte2</c>).
        /// </summary>
        Putstatic = 0xb3,

        /// <summary>
        /// Continue execution from address taken from a local variable <i>#index</i> (the asymmetry with jsr is intentional).
        /// </summary>
        Ret = 0xa9,

        /// <summary>
        /// Return void from method.
        /// </summary>
        Return = 0xb1,

        /// <summary>
        /// Load short from array.
        /// </summary>
        Saload = 0x35,

        /// <summary>
        /// Store short to array.
        /// </summary>
        Sastore = 0x56,

        /// <summary>
        /// Push a short onto the stack as an integer <i>value</i>.
        /// </summary>
        Sipush = 0x11,

        /// <summary>
        /// Swaps two top words on the stack (note that value1 and value2 must not be double or long).
        /// </summary>
        Swap = 0x5f,

        /// <summary>
        /// Continue execution from an address in the table at offset <i>index</i>.
        /// </summary>
        Tableswitch = 0xaa,

        /// <summary>
        /// Execute <i>opcode</i>, where <i>opcode</i> is either iload, fload, aload, lload, dload, istore, fstore, astore, lstore, dstore, or ret, but assume the <i>index</i> is 16 bit; or execute iinc, where the <i>index</i> is 16 bits and the constant to increment by is a signed 16 bit short.
        /// </summary>
        Wide = 0xc4
    }
}