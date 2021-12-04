using Xunit;

namespace Adapter.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var hole = new RoundHole(5);
            var roundStick = new RoundStick(5);
            Assert.True(hole.Fits(roundStick)); // TRUE
        }

        [Fact]
        public void Test2()
        {
            var hole = new RoundHole(5);

            var smallSquareStick = new SquareStick(5);

            var smallSquareStickAdapter = new SquareStickAdapter(smallSquareStick);

            Assert.True(hole.Fits(smallSquareStickAdapter));
        }

        [Fact]
        public void Test3()
        {
            var hole = new RoundHole(5);
            var largeSquareStick = new SquareStick(10);
            var largeSquareStickAdapter = new SquareStickAdapter(largeSquareStick);

            Assert.False(hole.Fits(largeSquareStickAdapter)); // FALSE
        }
    }
}
