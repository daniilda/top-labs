using System;

namespace ChainOfResponsibility
{
    public static class HelpExtensions
    {
        public static T ThrowIfIncorrectType<T>(this object obj) where T : class
            => (obj as T) ?? throw new InvalidCastException($"{obj.GetType()} is not {typeof(T)}");
    }
}