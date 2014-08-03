using System;

namespace RemoteControl.Operations
{
    /// <summary>
    /// Metadata describing an operation.
    /// </summary>
    class MetaOperation
    {
        public Object Parameter { get; set; }
        public Object Result { get; set; }
        public String OperationName { get; set; }
    }
}