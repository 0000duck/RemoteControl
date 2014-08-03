using System;

namespace RemoteControl
{
    /// <summary>
    /// Helper class for Promisses
    /// </summary>
    public static class Promisses
    {
        /// <summary>
        /// The infinite waiting time.
        /// </summary>
        public const int INFINITE = -1;
    }

    /// <summary>
    /// Represents a promisse of a future value.
    /// </summary>
    /// <typeparam name="T">type of the future value.</typeparam>
    public interface IPromisse<out T>
    {
        /// <summary>
        /// Gets or sets a value indicating whether this promisse is completed.
        /// </summary>
        /// <value>
        /// <c>true</c> if this promisse is completed; otherwise, <c>false</c>.
        /// </value>
        Boolean IsCompleted { get; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        T Value { get; }

        /// <summary>
        /// Waits for this promisse to came thru.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns><c>true</c> if promisse has came thru; otherwise, <c>false</c></returns>
        Boolean Wait(int timeout);
    }
}