using System;
using System.IO;

namespace RemoteControl.Messaging
{

    interface IMessager
    {
        Boolean InitializeMessager(MessagerContext ctx);

        void PushMessage(String message);

        String PopMessage();
    }

    internal class MessagerContext
    {
        public String QueueName { get; set; }
    }

    class FileSystemMessager : IMessager
    {
        private String _seedFileName = "messager";


        private int IncrementSeed()
        {
            
        }

        public bool InitializeMessager(MessagerContext ctx)
        {
            ctx.QueueName.EnsureNotEmpty("QueueName should not be empty.");

            if (Directory.Exists(ctx.QueueName))
            {
                
            }

        }

        public void PushMessage(string message)
        {
            throw new NotImplementedException();
        }

        public string PopMessage()
        {
            throw new NotImplementedException();
        }
    }
}
