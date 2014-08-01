using System;

namespace RemoteControl.Operations
{
    /// <summary>
    /// Operation: 
    /// <br />
    /// This interface is ment to represent an operation. 
    /// <br />
    /// It could be remote operation as well as local.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <typeparam name="TParameter">The type of the parameter.</typeparam>
    public interface IOperation<TResult, in TParameter>
    {
        /// <summary>
        /// Executes this operation.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// A promisse of a result.
        /// </returns>
        IPromisse<TResult> Execute(TParameter parameters);
    }
}