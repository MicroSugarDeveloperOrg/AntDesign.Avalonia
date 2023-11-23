﻿using System.Runtime.CompilerServices;

namespace AntDesign.Toolkit;

[Serializable]
internal sealed class ArgumentNullException : ArgumentException
{
    /// <summary>
    /// Throws an <see cref="System.ArgumentNullException"/> if <paramref name="argument"/> is <see langword="null"/>.
    /// </summary>
    /// <param name="argument">The reference type argument to validate as non-<see langword="null"/>.</param>
    /// <param name="paramName">The name of the parameter with which <paramref name="argument"/> corresponds.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //[CLSCompliant(false)]
    public static void ThrowIfNull(object? argument, string? paramName = null)
    {
        if (argument is null)
            Throw(paramName);
    }

    /// <summary>
    /// A specialized version for generic values.
    /// </summary>
    /// <typeparam name="T">The type of values to check.</typeparam>
    /// <remarks>
    /// This type is needed because if there had been a generic overload with a generic parameter, all calls
    /// would have just been bound by that by the compiler instead of the <see cref="object"/> overload.
    /// </remarks>
    public static class For<T>
    {
        /// <summary>
        /// Throws an <see cref="System.ArgumentNullException"/> if <paramref name="argument"/> is <see langword="null"/>.
        /// </summary>
        /// <param name="argument">The reference type argument to validate as non-<see langword="null"/>.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="argument"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNull(T? argument, string? paramName = null)
        {
            if (argument is null)
            {
                Throw(paramName);
            }
        }
    }

    /// <summary>
    /// Throws an <see cref="System.ArgumentNullException"/>.
    /// </summary>
    /// <param name="paramName">The name of the parameter that failed validation.</param>
    private static void Throw(string? paramName)
    {
        throw new System.ArgumentNullException(paramName);
    }
}
