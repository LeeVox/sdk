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
        const int SECONDS = 1000;

        [TestMethod]
        public void BasicWaitAndReturn()
        {
            string actual, expected;
            int secondsToWait, timeout;
            TimeSpan time;

            secondsToWait = 2;

            actual = "";
            expected = secondsToWait.ToString();
            actual = NewTask(secondsToWait).WaitAndReturn();
            Assert.AreEqual(expected, actual, $"should block the thread for ${secondsToWait} seconds then return ${expected}.");

            actual = "";
            timeout = 99 * SECONDS;
            expected = secondsToWait.ToString();
            actual = NewTask(secondsToWait).WaitAndReturn(timeout);
            Assert.AreEqual(expected, actual, $"should block the thread for ${secondsToWait} seconds then return ${expected} with no timeout.");

            actual = "";
            timeout = 1 * SECONDS;
            expected = default(string);
            actual = NewTask(secondsToWait).WaitAndReturn(timeout);
            Assert.AreEqual(expected, actual, $"should return default(string) if timeout.");

            actual = "";
            timeout = 1 * SECONDS;
            expected = "timeout";
            actual = NewTask(secondsToWait).WaitAndReturn(timeout, expected);
            Assert.AreEqual(expected, actual, $"should return expected value if timeout.");

            actual = "";
            time = TimeSpan.FromSeconds(99);
            expected = secondsToWait.ToString();
            actual = NewTask(secondsToWait).WaitAndReturn(time);
            Assert.AreEqual(expected, actual, $"should block the thread for ${secondsToWait} then return ${expected} within a timepsan.");

            actual = "";
            time = TimeSpan.FromSeconds(1);
            expected = default(string);
            actual = NewTask(secondsToWait).WaitAndReturn(time);
            Assert.AreEqual(expected, actual, $"should return default(string) if run out of time.");

            actual = "";
            time = TimeSpan.FromSeconds(1);
            expected = "timeout";
            actual = NewTask(secondsToWait).WaitAndReturn(time, expected);
            Assert.AreEqual(expected, actual, $"should return expected value if run out of time.");
        }

        [TestMethod]
        public void WaitAndRunWithCancellation()
        {
            string actual, expected;
            int secondsToWait, timeout;
            CancellationTokenSource tokenSource;

            secondsToWait = 2;

            actual = "";
            tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(99 * SECONDS);
            expected = secondsToWait.ToString();
            actual = NewTask(secondsToWait).WaitAndReturn(tokenSource.Token);
            Assert.AreEqual(expected, actual, $"should block the thread for ${secondsToWait} then return ${expected}.");

            actual = "";
            tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(1 * SECONDS);
            expected = default(string);
            actual = NewTask(secondsToWait).WaitAndReturn(tokenSource.Token);
            Assert.AreEqual(expected, actual, $"should return default(string) if canceled.");

            actual = "";
            tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(1 * SECONDS);
            expected = "canceled";
            actual = NewTask(secondsToWait).WaitAndReturn(tokenSource.Token, expected);
            Assert.AreEqual(expected, actual, $"should return expected value if canceled.");

            actual = "";
            timeout = 99 * SECONDS;
            tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(99 * SECONDS);
            expected = secondsToWait.ToString();
            actual = NewTask(secondsToWait).WaitAndReturn(timeout, tokenSource.Token);
            Assert.AreEqual(expected, actual, $"should block the thread for ${secondsToWait} then return ${expected}.");

            actual = "";
            timeout = 1 * SECONDS;
            tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(99 * SECONDS);
            expected = default(string);
            actual = NewTask(secondsToWait).WaitAndReturn(timeout, tokenSource.Token);
            Assert.AreEqual(expected, actual, $"should return default(string) if timeout but not canceled.");

            actual = "";
            timeout = 1 * SECONDS;
            tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(99 * SECONDS);
            expected = "timeout";
            actual = NewTask(secondsToWait).WaitAndReturn(timeout, tokenSource.Token, expected);
            Assert.AreEqual(expected, actual, $"should return ${expected} if timeout but not canceled.");

            actual = "";
            timeout = 99 * SECONDS;
            tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(1 * SECONDS);
            expected = default(string);
            actual = NewTask(secondsToWait).WaitAndReturn(timeout, tokenSource.Token);
            Assert.AreEqual(expected, actual, $"should return default(string) if no timeout but canceled.");

            actual = "";
            timeout = 99 * SECONDS;
            tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(1 * SECONDS);
            expected = "canceled";
            actual = NewTask(secondsToWait).WaitAndReturn(timeout, tokenSource.Token, expected);
            Assert.AreEqual(expected, actual, $"should return ${expected} if no timeout but canceled.");
        }

        private Task<string> NewTask(int secondsToWait)
        {
            return Task.Run(() => {
                Task.Delay(secondsToWait * SECONDS).Wait();
                return secondsToWait.ToString();
            });
        }
    }
}