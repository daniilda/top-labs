using Xunit;

namespace Singleton.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var b = Singleton.GetInstance();
            b.Inc();
            b.Inc();
            b.Inc();
            var bRes = b.Inc() == 3;
            var c = Singleton.GetInstance();
            c.Inc(); 
            b.Inc();
            c.Inc();
            var cRes = c.Inc() == 7;
            Assert.True(cRes && bRes);
        }
    }
}