using Xunit;

namespace SweetCaptcha.Tests
{
    public class Tests
    {
        private readonly SweetCaptcha _sut;

        public Tests()
        {
            _sut = new SweetCaptcha(
                "http://sweetcaptcha.com/api", 
                "your_app_id", 
                "your_app_secret");
        }

        [Fact]
        public void GetHtml_ShouldReturnString()
        {
            // Fixture setup
            // Exercise system
            var result = _sut.GetHtml().Result;
            // Verify outcome
            Assert.NotEqual(string.Empty, result);
            // Teardown
        }

        [Fact]
        public void Check_ShouldReturnValidResult()
        {
            // Fixture setup
            var anonymousKey = "e7f52170ebdd93c";
            var anonymousValue = "9a66bc7151";
            // Exercise system
            var result = _sut.Check(anonymousKey, anonymousValue).Result;
            // Verify outcome
            Assert.True(result);
            // Teardown
        }
    }
}
