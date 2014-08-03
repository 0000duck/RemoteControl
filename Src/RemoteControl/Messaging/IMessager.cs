using System;

namespace RemoteControl.Messaging
{
    interface IMessager
    {
        Boolean InitializeMessager(MessagerContext ctx);

        void PushMessage(String message);

        String PopMessage();
    }
}