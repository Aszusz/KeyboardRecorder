using KeyboardRecorder.RecorderStateMachine;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class RecorderTests
    {
        [Test]
        public void SendingKeyCombinationShouldFireReceivedEvent()
        {
        }

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
            var recorder = new Recorder();
            recorder.Record();
            Assert.That(recorder.State, Is.InstanceOf<Recording>());
        }
    }
}