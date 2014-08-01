using System;
using RemoteControl.Operations;

namespace RemoteControl
{
    public class Operation<TResult, TParameter> : IOperation<TResult, TParameter>
    {
        private readonly string _operationName;

        /// <summary>
        /// Initializes a new instance of the <see cref="Operation{TResult, TParameter}"/> class.
        /// </summary>
        /// <param name="operationName">Name of the operation.</param>
        public Operation(string operationName)
        {
            _operationName = operationName;
        }

        /// <summary>
        /// Executes this operation.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public IPromisse<TResult> Execute(TParameter parameters)
        {
            throw new NotImplementedException();
        }
    }
}