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

    }
}
