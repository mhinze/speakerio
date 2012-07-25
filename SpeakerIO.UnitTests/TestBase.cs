using Rhino.Mocks;

namespace SpeakerIO.UnitTests
{
    public class TestBase
    {
        public static TStub S<TStub>() where TStub : class
        {
            return MockRepository.GenerateStub<TStub>();
        }
    }
}