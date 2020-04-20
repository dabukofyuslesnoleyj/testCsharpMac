using System;


namespace testCsharp
{
    public enum MessageType
    {
        Info,
        Warning,
        Error
    }
    public static class Utility_Funcs 
    {
        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}