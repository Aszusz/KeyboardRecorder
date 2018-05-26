using System.Collections.Generic;
using System.Threading;
using KeyboardAPI.APIs;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class KeyboardApiTests
    {
        private IKeyboard _keyboard;

        [SetUp]
        public void SetUp()
        {
            _keyboard = new Keyboard();
            _keyboard.Install();
        }

        [TearDown]
        public void TearDown()
        {
            _keyboard.Uninstall();
            _keyboard.Dispose();
        }

        [Test]
        public void SendingKeyToKeyboardShouldFireReceivedEvent()
        {
            var expected = new List<KeyEventArgs>()
            {
                new KeyEventArgs(Key.KeyP, KeyAction.KeyDown),
                new KeyEventArgs(Key.KeyP, KeyAction.KeyUp)
            };

            var actual = new List<KeyEventArgs>();

            var cde = new CountdownEvent(2);

            _keyboard.Received += (sender, args) =>
            {
                actual.Add(args);
                cde.Signal();
            };

            _keyboard.Send(expected);

            cde.Wait(100);
            Assert.That(actual, Is.EquivalentTo(expected));
        }
    }
}