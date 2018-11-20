using System;
using System.Threading;
using System.Threading.Tasks;

namespace LeeVox.Sdk
{
    public static class TaskExtensions
    {
        /// <summary>
        /// Waits for the <c>System.Threading.Tasks.Task</c> to complete execution, then returns its result.
        /// </summary>
        public static TResult WaitAndReturn<TResult>(this Task<TResult> task)
        {
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Waits for the <c>System.Threading.Tasks.Task</c> to complete execution within a specified
        /// number of milliseconds, then returns its result.
        /// </summary>
        /// <remarks>
        /// returns default value if timeout.
        /// </remarks>
        public static TResult WaitAndReturn<TResult>(this Task<TResult> task, int millisecondsTimeout)
            => WaitAndReturn(task, millisecondsTimeout, default(TResult));

        /// <summary>
        /// Waits for the <c>System.Threading.Tasks.Task</c> to complete execution within a specified
        /// number of milliseconds, then returns its result.
        /// </summary>
        /// <param name="returnValueIfTimeout">return value if timeout</param>
        public static TResult WaitAndReturn<TResult>(this Task<TResult> task, int millisecondsTimeout, TResult returnValueIfTimeout)
        {
            return task.Wait(millisecondsTimeout) ? task.Result : returnValueIfTimeout;
        }

        /// <summary>
        /// Waits for the <c>System.Threading.Tasks.Task</c> to complete execution within a specified
        /// time interval, then returns its result.
        /// </summary>
        /// <remarks>
        /// returns default value if timeout.
        /// </remarks>
        public static TResult WaitAndReturn<TResult>(this Task<TResult> task, TimeSpan timeout)
            => WaitAndReturn(task, timeout, default(TResult));

        /// <summary>
        /// Waits for the <c>System.Threading.Tasks.Task</c> to complete execution within a specified
        /// time interval, then returns its result.
        /// </summary>
        /// <param name="returnValueIfTimeout">return value if timeout</param>
        public static TResult WaitAndReturn<TResult>(this Task<TResult> task, TimeSpan timeout, TResult returnValueIfTimeout)
        {
            return task.Wait(timeout) ? task.Result : returnValueIfTimeout;
        }

        /// <summary>
        /// Waits for the <c>System.Threading.Tasks.Task</c> to complete execution or until cancellation token
        /// is canceled, then returns its result.
        /// </summary>
        /// <remarks>
        /// returns default value if canceled.
        /// </remarks>
        public static TResult WaitAndReturn<TResult>(this Task<TResult> task, CancellationToken cancellationToken)
            => WaitAndReturn(task, cancellationToken, default(TResult));

        /// <summary>
        /// Waits for the <c>System.Threading.Tasks.Task</c> to complete execution or until cancellation token
        /// is canceled, then returns its result.
        /// </summary>
        /// <param name="returnValueIfCanceled">return value if canceled</param>
        public static TResult WaitAndReturn<TResult>(this Task<TResult> task, CancellationToken cancellationToken, TResult returnValueIfCanceled)
        {
            try
            {
                task.Wait(cancellationToken);
                return task.Result;
            }
            catch (OperationCanceledException)
            {
                return returnValueIfCanceled;
            }
        }

        /// <summary>
        /// Waits for the <c>System.Threading.Tasks.Task</c> to complete execution within a specified
        /// number of milliseconds or until cancellation token is canceled, then returns its result.
        /// </summary>
        /// <remarks>
        /// returns default value if timeout or canceled.
        /// </remarks>
        public static TResult WaitAndReturn<TResult>(this Task<TResult> task, int millisecondsTimeout, CancellationToken cancellationToken)
            => WaitAndReturn(task, millisecondsTimeout, cancellationToken, default(TResult));

        /// <summary>
        /// Waits for the <c>System.Threading.Tasks.Task</c> to complete execution within a specified
        /// number of milliseconds or until cancellation token is canceled, then returns its result.
        /// </summary>
        /// <param name="returnValueIfTimeoutOrCanceled">return value if timeout or canceled</param>
        public static TResult WaitAndReturn<TResult>(this Task<TResult> task, int millisecondsTimeout, CancellationToken cancellationToken, TResult returnValueIfTimeoutOrCanceled)
        {
            try
            {
                return task.Wait(millisecondsTimeout, cancellationToken) ? task.Result : returnValueIfTimeoutOrCanceled;
            }
            catch (OperationCanceledException)
            {
                return returnValueIfTimeoutOrCanceled;
            }
        }
    }
}