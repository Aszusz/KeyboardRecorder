using System;
using System.Threading;
using System.Windows.Input;
using KeyboardRecorder;
using KeyboardRecorder.RecorderStateMachine;
using KeyboardToolkit.Receiver;
using KeyboardToolkit.Sender;
using KeyboardToolkit.StateMonitor;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class RecorderTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void KeyCombinationSendReceive()
        {
            var sender = new KeyCombinationSender(new KeySender());
            var receiver = new KeyCombinationReceiver(new KeyReceiver(), new KeyStateMonitor());

            var are = new AutoResetEvent(false);
            KeyCombination actual = null;
            receiver.KeyCombinationReceived += combination =>
            {
                actual = combination;
                are.Set();
            };
            receiver.Install();

            var expected = new KeyCombination(Key.D, KeyModifier.LCtrl | KeyModifier.LShift);
            sender.Send(expected);

            are.WaitOne(100);
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}