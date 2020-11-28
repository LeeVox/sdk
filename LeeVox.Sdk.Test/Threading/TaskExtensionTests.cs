using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace LeeVox.Sdk.Test
{
    public class TaskExtensionTests
    {
        [Fact]
        public void BasicWaitAndReturn()
        {
            string actual, expected;
            int milliSecondsToWait, timeout;
            TimeSpan time;

            milliSecondsToWait = 500;

            actual = "";
            expected = milliSecondsToWait.ToString();
            actual = NewTask(milliSecondsToWait).WaitAndReturn();
            actual.Should().BeEquivalentTo(expected, $"should block the thread for {milliSecondsToWait} seconds then return {expected}.");

            actual = "";
            timeout = 99999;
            expected = milliSecondsToWait.ToString();
            actual = NewTask(milliSecondsToWait).WaitAndReturn(timeout);
            actual.Should().BeEquivalentTo(expected, $"should block the thread for {milliSecondsToWait} seconds then return {expected} with no timeout.");

            actual = "";
            timeout = 250;
            expected = default(string);
            actual = NewTask(milliSecondsToWait).WaitAndReturn(timeout);
            actual.Should().BeEquivalentTo(expected, $"should return default(string) if timeout.");

            actual = "";
            timeout = 250;
            expected = "timeout";
            actual = NewTask(milliSecondsToWait).WaitAndReturn(timeout, expected);
            actual.Should().BeEquivalentTo(expected, $"should return expected value if timeout.");

            actual = "";
            time = TimeSpan.FromMilliseconds(99999);
            expected = milliSecondsToWait.ToString();
            actual = NewTask(milliSecondsToWait).WaitAndReturn(time);
            actual.Should().BeEquivalentTo(expected, $"should block the thread for {milliSecondsToWait} then return {expected} within a timepsan.");

            actual = "";
            time = TimeSpan.FromMilliseconds(250);
            expected = default(string);
            actual = NewTask(milliSecondsToWait).WaitAndReturn(time);
            actual.Should().BeEquivalentTo(expected, $"should return default(string) if run out of time.");

            actual = "";
            time = TimeSpan.FromMilliseconds(250);
            expected = "timeout";
            actual = NewTask(milliSecondsToWait).WaitAndReturn(time, expected);
            actual.Should().BeEquivalentTo(expected, $"should return expected value if run out of time.");
        }

        [Fact]
        public void WaitAndRunWithCancellation()
        {
            string actual, expected;
            int milliSecondsToWait, timeout;
            CancellationTokenSource tokenSource;

            milliSecondsToWait = 500;

            actual = "";
            tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(99999);
            expected = milliSecondsToWait.ToString();
            actual = NewTask(milliSecondsToWait).WaitAndReturn(tokenSource.Token);
            actual.Should().BeEquivalentTo(expected, $"should block the thread for {milliSecondsToWait} then return {expected}.");

            actual = "";
            tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(250);
            expected = default(string);
            actual = NewTask(milliSecondsToWait).WaitAndReturn(tokenSource.Token);
            actual.Should().BeEquivalentTo(expected, $"should return default(string) if canceled.");

            actual = "";
            tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(250);
            expected = "canceled";
            actual = NewTask(milliSecondsToWait).WaitAndReturn(tokenSource.Token, expected);
            actual.Should().BeEquivalentTo(expected, $"should return expected value if canceled.");

            actual = "";
            timeout = 888;
            tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(99999);
            expected = milliSecondsToWait.ToString();
            actual = NewTask(milliSecondsToWait).WaitAndReturn(timeout, tokenSource.Token);
            actual.Should().BeEquivalentTo(expected, $"should block the thread for {milliSecondsToWait} then return {expected}.");

            actual = "";
            timeout = 250;
            tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(99999);
            expected = default(string);
            actual = NewTask(milliSecondsToWait).WaitAndReturn(timeout, tokenSource.Token);
            actual.Should().BeEquivalentTo(expected, $"should return default(string) if timeout but not canceled.");

            actual = "";
            timeout = 250;
            tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(99999);
            expected = "timeout";
            actual = NewTask(milliSecondsToWait).WaitAndReturn(timeout, tokenSource.Token, expected);
            actual.Should().BeEquivalentTo(expected, $"should return {expected} if timeout but not canceled.");

            actual = "";
            timeout = 888;
            tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(250);
            expected = default(string);
            actual = NewTask(milliSecondsToWait).WaitAndReturn(timeout, tokenSource.Token);
            actual.Should().BeEquivalentTo(expected, $"should return default(string) if no timeout but canceled.");

            actual = "";
            timeout = 888;
            tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(250);
            expected = "canceled";
            actual = NewTask(milliSecondsToWait).WaitAndReturn(timeout, tokenSource.Token, expected);
            actual.Should().BeEquivalentTo(expected, $"should return {expected} if no timeout but canceled.");
        }

        private Task<string> NewTask(int milliSecondsToWait)
        {
            return Task.Run(() => {
                Task.Delay(milliSecondsToWait).Wait();
                return milliSecondsToWait.ToString();
            });
        }
    }
}