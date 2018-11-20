using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeeVox.Sdk;

namespace LeeVox.Sdk.Test
{
    [TestClass]
    public class TaskExtensionTests
    {
        [TestMethod]
        public void BasicWaitAndReturn()
        {
            int actual, expected, secondsToWait, timeout;
            TimeSpan time;

            secondsToWait = 3;

            actual = -1;
            expected = secondsToWait;
            actual = NewTask(secondsToWait).WaitAndReturn();
            Assert.AreEqual(expected, actual, $"should block the thread for {secondsToWait} seconds then return {expected}.");

            actual = -1;
            timeout = 1;
            expected = default(int);
            actual = NewTask(secondsToWait).WaitAndReturn(timeout * 1000);
            Assert.AreEqual(expected, actual, $"should return default value if timeout.");

            actual = -1;
            timeout = 1;
            expected = 5;
            actual = NewTask(secondsToWait).WaitAndReturn(timeout * 1000, expected);
            Assert.AreEqual(expected, actual, $"should return expected value if timeout.");

            actual = 1;
            time = TimeSpan.FromSeconds(2);
            expected = default(int);
            actual = NewTask(secondsToWait).WaitAndReturn(time);
            Assert.AreEqual(expected, actual, $"should return default value if run out of time.");

            actual = -1;
            time = TimeSpan.FromSeconds(2);
            expected = 5;
            actual = NewTask(secondsToWait).WaitAndReturn(time, expected);
            Assert.AreEqual(expected, actual, $"should return expected value if run out of time.");
        }

        [TestMethod]
        public void WaitAndRunWithCancellation()
        {
            int actual, expected, secondsToWait, timeout;
            CancellationTokenSource tokenSource;

            secondsToWait = 3;

            actual = -1;
            tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(1000);
            expected = default(int);
            actual = NewTask(secondsToWait).WaitAndReturn(tokenSource.Token);
            Assert.AreEqual(expected, actual, $"should return default value if canceled.");

            actual = -1;
            tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(2000);
            expected = 5;
            actual = NewTask(secondsToWait).WaitAndReturn(tokenSource.Token, expected);
            Assert.AreEqual(expected, actual, $"should return expected value if canceled.");

            actual = -1;
            timeout = 2;
            tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(1000);
            expected = default(int);
            actual = NewTask(secondsToWait).WaitAndReturn(timeout, tokenSource.Token);
            Assert.AreEqual(expected, actual, $"should return default value if timeout or canceled.");

            actual = -1;
            timeout = 1;
            tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(2000);
            expected = 5;
            actual = NewTask(secondsToWait).WaitAndReturn(tokenSource.Token, expected);
            Assert.AreEqual(expected, actual, $"should return expected value if timeout or canceled.");
        }

        private Task<int> NewTask(int secondsToWait)
        {
            return Task.Run(() => {
                Task.Delay(secondsToWait * 1000).Wait();
                return secondsToWait;
            });
        }
    }
}