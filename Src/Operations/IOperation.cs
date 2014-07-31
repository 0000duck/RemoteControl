using System.Collections.Generic;

namespace RemoteControl.Operations
{
    /// <summary>
    /// 
    /// Operation: <br />
    /// This interface is ment to represent an operation. <br />
    /// It could be remote operation as well as local.
    /// 
    /// </summary>
    public interface IOperation
    {
        /// <summary>
        /// Executes this operation.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>A sequence of results.</returns>
        IEnumerable<IResult> Execute(IEnumerable<IParameter> parameters);
    }
}