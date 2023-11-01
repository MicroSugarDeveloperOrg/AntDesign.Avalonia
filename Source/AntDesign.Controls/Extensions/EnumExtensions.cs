using System.Runtime.CompilerServices;

namespace AntDesign.Controls.Extensions;
internal static class EnumExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public unsafe static bool HasAllFlags<T>(this T value, T flags) where T : unmanaged, Enum
    {
        if (sizeof(T) == 1)
        {
            byte num = Unsafe.As<T, byte>(ref value);
            byte b = Unsafe.As<T, byte>(ref flags);
            return (num & b) == b;
        }

        if (sizeof(T) == 2)
        {
            short num2 = Unsafe.As<T, short>(ref value);
            short num3 = Unsafe.As<T, short>(ref flags);
            return (num2 & num3) == num3;
        }

        if (sizeof(T) == 4)
        {
            int num4 = Unsafe.As<T, int>(ref value);
            int num5 = Unsafe.As<T, int>(ref flags);
            return (num4 & num5) == num5;
        }

        if (sizeof(T) == 8)
        {
            long num6 = Unsafe.As<T, long>(ref value);
            long num7 = Unsafe.As<T, long>(ref flags);
            return (num6 & num7) == num7;
        }

        throw new NotSupportedException("Enum with size of " + Unsafe.SizeOf<T>() + " are not supported");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public unsafe static bool HasAnyFlag<T>(this T value, T flags) where T : unmanaged, Enum
    {
        if (sizeof(T) == 1)
        {
            byte num = Unsafe.As<T, byte>(ref value);
            byte b = Unsafe.As<T, byte>(ref flags);
            return (num & b) != 0;
        }

        if (sizeof(T) == 2)
        {
            short num2 = Unsafe.As<T, short>(ref value);
            short num3 = Unsafe.As<T, short>(ref flags);
            return (num2 & num3) != 0;
        }

        if (sizeof(T) == 4)
        {
            int num4 = Unsafe.As<T, int>(ref value);
            int num5 = Unsafe.As<T, int>(ref flags);
            return (num4 & num5) != 0;
        }

        if (sizeof(T) == 8)
        {
            long num6 = Unsafe.As<T, long>(ref value);
            long num7 = Unsafe.As<T, long>(ref flags);
            return (num6 & num7) != 0;
        }

        throw new NotSupportedException("Enum with size of " + Unsafe.SizeOf<T>() + " are not supported");
    }
}