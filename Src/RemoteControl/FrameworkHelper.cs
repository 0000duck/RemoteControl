using System;
using Newtonsoft.Json;
using RemoteControl.Messaging;
using RemoteControl.Operations;
using RemoteControl.Scheduling;

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
            var scheduler = GetScheduler();

            return scheduler.Schedule<TResult>(metaOperation);
        }

        private static ExecutionScheduler GetScheduler()
        {
            var requestMessager = new FileSystemMessager();
            var responseMessager = new FileSystemMessager();

            requestMessager.InitializeMessager(
                new MessagerContext
                {
                    QueueName = "RequestQueue1"
                });

            responseMessager.InitializeMessager(
                new MessagerContext
                {
                    QueueName = "ResponseQueue1"
                });

            return new ExecutionScheduler(requestMessager, responseMessager);
        }

        public static void AddOperationHandler(String operationName, Func<Object, Object> operationFunc)
        {
            throw new NotImplementedException();
        }
    }

}
