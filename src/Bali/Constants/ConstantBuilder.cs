using System;
using System.IO;

namespace Bali.Constants
{
    public static class ConstantBuilder
    {
        public static void BuildConstant(Constant constant, Stream stream)
        {
            switch (constant)
            {
                case ClassConstant classConstant:
                    break;

                case FieldrefConstant fieldrefConstant:
                    break;

                case MethodrefConstant methodrefConstant:
                    break;

                case InterfaceMethodrefConstant interfaceMethodrefConstant:
                    break;

                case StringConstant stringConstant:
                    break;

                case IntegerConstant integerConstant:
                    break;

                case FloatConstant floatConstant:
                    break;

                case LongConstant longConstant:
                    break;

                case DoubleConstant doubleConstant:
                    break;

                case NameAndTypeConstant nameAndTypeConstant:
                    break;

                case Utf8Constant utf8Constant:
                    break;

                case MethodHandleConstant methodHandleConstant:
                    break;

                case MethodTypeConstant methodTypeConstant:
                    break;

                case InvokeDynamicConstant invokeDynamicConstant:
                    break;

                default:
                    throw new NotSupportedException($"Unsupported constant type: {constant.GetType().FullName}");
            }
        }
    }
}