using System;

namespace AmpLib.TCG.Exceptions
{
    [Serializable]
    public class MinionIsNotAliveException : Exception
    {
        public MinionIsNotAliveException() { }

        public MinionIsNotAliveException(string message) : base(message) { }
    }
}