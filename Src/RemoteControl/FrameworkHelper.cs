using System;
using Newtonsoft.Json;
using RemoteControl.Operations;

namespace RemoteControl
{
    public static class FrameworkHelper
    {

        /// <summary>
        /// Encodes the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static String Encode(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// Decodes the specified string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        public static T Decode<T>(this string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }

        /// <summary>
        /// Schedules the operation specified by its metadata.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="metaOperation">The meta operation.</param>
        /// <returns>A promisse of result.</returns>
        internal static IPromisse<TResult> Schedule<TResult>(MetaOperation metaOperation)
        {
            return new MockPromisse<TResult>();
        }
    }

    /// <summary>
    /// Just for testing and thinking process.
    /// </summary>
    public class MockPromisse<T> : IPromisse<T>
    {
        public MockPromisse()
        {
            IsCompleted = true;
            Value = default (T);
        }

        public bool IsCompleted { get; private set; }
        public T Value { get; private set; }
        public bool Wait(long timeout)
        {
            return true;
        }
    }
}
