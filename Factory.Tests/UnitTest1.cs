using Xunit;

namespace Factory.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var a = new WebWindow();
            Assert.Contains("Веб",a.Render());
        }

        [Fact]
        public void Test2()
        {
            var b = new MobWindow();
            Assert.Contains("Мобильная",b.Render());
        }
    }
}