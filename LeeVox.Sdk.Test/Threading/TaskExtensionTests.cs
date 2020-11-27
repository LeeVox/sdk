using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace LeeVox.Sdk.Test
{
    public class TaskExtensionTests
    {
        const int SECONDS = 1000;

        [Fact]
        public void BasicWaitAndReturn()
        {
            string actual, expected;
            int secondsToWait, timeout;
            TimeSpan time;

            secondsToWait = 2;

            actual = "";
            expected = secondsToWait.ToString();
            actual = NewTask(secondsToWait).WaitAndReturn();
            actual.Should().BeEquivalentTo(expected, $"should block the thread for {secondsToWait} seconds then return {expected}.");

            actual = "";
            timeout = 99 * SECONDS;
            expected = secondsToWait.ToString();
            actual = NewTask(secondsToWait).WaitAndReturn(timeout);
            actual.Should().BeEquivalentTo(expected, $"should block the thread for {secondsToWait} seconds then return {expected} with no timeout.");

            actual = "";
            timeout = 1 * SECONDS;
            expected = default(string);
            actual = NewTask(secondsToWait).WaitAndReturn(timeout);
            actual.Should().BeEquivalentTo(expected, $"should return default(string) if timeout.");

            actual = "";
            timeout = 1 * SECONDS;
            expected = "timeout";
            actual = NewTask(secondsToWait).WaitAndReturn(timeout, expected);
            actual.Should().BeEquivalentTo(expected, $"should return expected value if timeout.");

            actual = "";
            time = TimeSpan.FromSeconds(99);
            expected = secondsToWait.ToString();
            actual = NewTask(secondsToWait).WaitAndReturn(time);
            actual.Should().BeEquivalentTo(expected, $"should block the thread for {secondsToWait} then return {expected} within a timepsan.");

            actual = "";
            time = TimeSpan.FromSeconds(1);
            expected = default(string);
            actual = NewTask(secondsToWait).WaitAndReturn(time);
            actual.Should().BeEquivalentTo(expected, $"should return default(string) if run out of time.");

            actual = "";
            time = TimeSpan.FromSeconds(1);
            expected = "timeout";
            actual = NewTask(secondsToWait).WaitAndReturn(time, expected);
            actual.Should().BeEquivalentTo(expected, $"should return expected value if run out of time.");
        }

        [Fact]
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
            actual.Should().BeEquivalentTo(expected, $"should block the thread for {secondsToWait} then return {expected}.");

            actual = "";
            tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(1 * SECONDS);
            expected = default(string);
            actual = NewTask(secondsToWait).WaitAndReturn(tokenSource.Token);
            actual.Should().BeEquivalentTo(expected, $"should return default(string) if canceled.");

            actual = "";
            tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(1 * SECONDS);
            expected = "canceled";
            actual = NewTask(secondsToWait).WaitAndReturn(tokenSource.Token, expected);
            actual.Should().BeEquivalentTo(expected, $"should return expected value if canceled.");

            actual = "";
            timeout = 99 * SECONDS;
            tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(99 * SECONDS);
            expected = secondsToWait.ToString();
            actual = NewTask(secondsToWait).WaitAndReturn(timeout, tokenSource.Token);
            actual.Should().BeEquivalentTo(expected, $"should block the thread for {secondsToWait} then return {expected}.");

            actual = "";
            timeout = 1 * SECONDS;
            tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(99 * SECONDS);
            expected = default(string);
            actual = NewTask(secondsToWait).WaitAndReturn(timeout, tokenSource.Token);
            actual.Should().BeEquivalentTo(expected, $"should return default(string) if timeout but not canceled.");

            actual = "";
            timeout = 1 * SECONDS;
            tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(99 * SECONDS);
            expected = "timeout";
            actual = NewTask(secondsToWait).WaitAndReturn(timeout, tokenSource.Token, expected);
            actual.Should().BeEquivalentTo(expected, $"should return {expected} if timeout but not canceled.");

            actual = "";
            timeout = 99 * SECONDS;
            tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(1 * SECONDS);
            expected = default(string);
            actual = NewTask(secondsToWait).WaitAndReturn(timeout, tokenSource.Token);
            actual.Should().BeEquivalentTo(expected, $"should return default(string) if no timeout but canceled.");

            actual = "";
            timeout = 99 * SECONDS;
            tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(1 * SECONDS);
            expected = "canceled";
            actual = NewTask(secondsToWait).WaitAndReturn(timeout, tokenSource.Token, expected);
            actual.Should().BeEquivalentTo(expected, $"should return {expected} if no timeout but canceled.");
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