using System;
using RemoteControl.Exceptions;

namespace RemoteControl
{
    static class ContractHelper
    {

        public static void EnsureNotEmpty(this String str, String message, params Object[] args)
        {
            if (String.IsNullOrEmpty(str))
            {
                throw new EnsureFailedException(String.Format(message, args));
            }
        }
        public static void EnsureNotNull(this Object obj, String message, params Object[] args)
        {
            if (obj == null)
            {
                throw new EnsureFailedException(String.Format(message, args));
            }
        }

    }
}
