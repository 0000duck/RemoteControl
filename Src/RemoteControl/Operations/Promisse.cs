using System;
using System.Threading.Tasks;

namespace RemoteControl.Operations
{
    class Promisse<TResult> : IPromisse<TResult>
    {
        private readonly Task<TResult> _task;

        public Promisse(Func<TResult> valueGetter)
        {
            _task = Task.Factory.StartNew(valueGetter);
        }

        public bool IsCompleted { get { return _task.IsCompleted; } }
        public TResult Value { get { return _task.Result; } }
        public bool Wait(int timeout)
        {
            return _task.Wait(timeout);
        }
    }
}
