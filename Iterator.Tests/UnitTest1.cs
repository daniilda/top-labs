using Xunit;

namespace Iterator.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("Number 9")]
        [InlineData("Number 9 LARGE")]
        [InlineData("Number 6 WITH EXTRA DIP")]
        [InlineData("Number 7")]
        [InlineData("Number 45")]
        [InlineData("LargeSoda")]
        public void Test1(string input)
        {
            var menu = new Menu();
            var reader = new MenuReader();
            var result = reader.SeeFoodItems(menu);

            Assert.Contains(input, result);
        }
    }
}