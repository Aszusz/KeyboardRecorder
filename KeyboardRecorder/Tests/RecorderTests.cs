using System.Collections.Generic;
using System.Threading;
using KeyboardAPI.APIs;
using NUnit.Framework;
using Recorder;

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
        public void Test()
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

        //[Test]
        //public void Test()
        //{
        //    var keyboard = new Keyboard();
        //    var recorder = new Recorder();

        //    recorder.Record();
        //    keyboard.Send(new[]
        //    {
        //        new KeyEventArgs(Key.KeyP, KeyAction.KeyDown),
        //        new KeyEventArgs(Key.KeyP, KeyAction.KeyUp)
        //    });

        //    recorder.Play();

        //}
    }
}