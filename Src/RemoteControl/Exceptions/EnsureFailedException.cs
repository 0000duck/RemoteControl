using System;

namespace RemoteControl.Exceptions
{
    public class EnsureFailedException : Exception
    {
        public EnsureFailedException(string message) : base(message) {}
    }
}