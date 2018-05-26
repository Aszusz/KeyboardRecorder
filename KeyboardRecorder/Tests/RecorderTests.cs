using System.Collections.Generic;
using System.Threading;
using KeyboardAPI.APIs;
using NUnit.Framework;
using Recorder;
using Recorder.RecorderStateMachine;

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
        public void SendingKeyCombinationShouldFireReceivedEvent()
        {
            var keyboard = new Keyboard();
            var listener = new KeyCombinationListener(keyboard);

            var expected = new List<KeyCombination>
            {
                new KeyCombination(Key.KeyP),
                new KeyCombination(Key.KeyP, KeyMod.Control | KeyMod.Shift)
            };

            var actual = new List<KeyCombination>();

            var cde = new CountdownEvent(expected.Count);

            listener.KeyCombinationReceived += combination =>
            {
                actual.Add(combination);
                cde.Signal();
            };

            listener.Start();

            foreach (var combination in expected)
            {
                listener.Send(combination);
            }
            
            cde.Wait(100);
            listener.Stop();
            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [Test]
        public void Test()
        {
            var recorder = new Recorder.RecorderStateMachine.Recorder();
            recorder.Record();
            Assert.That(recorder.State, Is.InstanceOf<Recording>());
        }
    }
}