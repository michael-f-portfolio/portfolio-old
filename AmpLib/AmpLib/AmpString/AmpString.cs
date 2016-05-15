using System;
using System.Collections;

namespace AmpLib.AmpString
{
    public enum AmpStringEnum { Boolean, Integer }

    public class AmpString : IComparable<string>, IEnumerable, ICloneable
    {
        public char[] Content { get; set; }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public static string Concat(int start, int end)
        {
            throw new NotImplementedException();
        }

        public static string Contains(string str)
        {
            throw new NotImplementedException();
        }

        public static bool EndsWith(string str)
        {
            throw new NotImplementedException();
        }

        public static int Equals(string str)
        {
            throw new NotImplementedException();
        }

        public static bool Equals(string str, AmpStringEnum returnType)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public static int Length()
        {
            throw new NotImplementedException();
        }

        public static char[] ToChar()
        {
            throw new NotImplementedException();
        }

        public static bool StartsWith(string startsWith)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(string other)
        {
            throw new NotImplementedException();
        }
    }
}