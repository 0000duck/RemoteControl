using RemoteControl.Messaging;
using RemoteControl.Operations;

namespace RemoteControl.Scheduling
{

    /// <summary>
    /// 
    /// Responsible to schedule the execution of operations. <br/>
    /// 
    /// </summary>
    class ExecutionScheduler
    {
        private readonly IMessager _requestMessager;
        private readonly IMessager _responseMessager;

        public ExecutionScheduler(IMessager requestMessager, IMessager responseMessager)
        {
            _requestMessager = requestMessager;
            _responseMessager = responseMessager;
        }

        public IPromisse<TResult> Schedule<TResult>(MetaOperation operation)
        {
            _requestMessager.PushMessage(operation.Encode());

            return new Promisse<TResult>(
                () =>
                {
                    var message = _responseMessager.PopMessage();
                    var response = message.Decode<MetaOperation>();

                    return (TResult) response.Result;
                });

        }

    }



}
