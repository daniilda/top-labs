using Xunit;

namespace Bridge.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var device = new Tv();
            var basicRemote = new BasicRemote(device);
            basicRemote.Power();
            Assert.Contains("I'm enabled", device.PrintStatus());
        }

        [Fact]
        public void Test2()
        {
            var device = new Tv();
            Assert.Contains("I'm disabled", device.PrintStatus());
        }

        [Fact]
        public void Test3()
        {
            var device = new Tv();
            var basicRemote = new BasicRemote(device);
            basicRemote.ChannelUp();
            Assert.Contains("Current channel is 1", device.PrintStatus());
        }

        [Fact]
        public void Test4()
        {
            var device = new Tv();
            var basicRemote = new BasicRemote(device);
            basicRemote.ChannelUp();
            basicRemote.ChannelUp();
            basicRemote.ChannelDown();
            Assert.Contains("Current channel is 1", device.PrintStatus());
        }

        [Fact]
        public void Test5()
        {
            var device = new Tv();
            var basicRemote = new BasicRemote(device);
            basicRemote.VolumeUp();
            basicRemote.VolumeUp();
            basicRemote.VolumeDown();
            Assert.Contains("Current volume is 10%", device.PrintStatus());
        }

        [Fact]
        public void Test6()
        {
            var device = new Tv();
            var basicRemote = new BasicRemote(device);
            basicRemote.VolumeUp();
            Assert.Contains("Current volume is 10%", device.PrintStatus());
        }

        [Fact]
        public void Test7()
        {
            var device = new Tv();
            var basicRemote = new BasicRemote(device);
            basicRemote.VolumeDown();
            basicRemote.VolumeDown();
            basicRemote.VolumeDown();
            Assert.Contains("Current volume is 0%", device.PrintStatus());
        }

        [Fact]
        public void Test8()
        {
            var device = new Tv();
            var basicRemote = new BasicRemote(device);
            basicRemote.ChannelDown();
            basicRemote.ChannelDown();
            basicRemote.ChannelDown();
            Assert.Contains("Current channel is -3", device.PrintStatus()); //expected behaviour =)
        }

        [Fact]
        public void Test9()
        {
            var device = new Tv();
            var basicRemote = new AdvanceRemote(device);
            basicRemote.VolumeUp();
            basicRemote.VolumeUp();
            basicRemote.Mute();
            Assert.Contains("Current volume is 0%", device.PrintStatus()); //expected behaviour =)
        }

        [Fact]
        public void Test10()
        {
            var device = new Tv();
            Assert.Contains("I'm TV", device.PrintStatus());
        }

        [Fact]
        public void Test11()
        {
            var device = new Radio();
            var basicRemote = new BasicRemote(device);
            basicRemote.Power();
            Assert.Contains("I'm enabled", device.PrintStatus());
        }

        [Fact]
        public void Test12()
        {
            var device = new Radio();
            Assert.Contains("I'm disabled", device.PrintStatus());
        }

        [Fact]
        public void Test13()
        {
            var device = new Radio();
            var basicRemote = new BasicRemote(device);
            basicRemote.ChannelUp();
            Assert.Contains("Current channel is 1", device.PrintStatus());
        }

        [Fact]
        public void Test14()
        {
            var device = new Radio();
            var basicRemote = new BasicRemote(device);
            basicRemote.ChannelUp();
            basicRemote.ChannelUp();
            basicRemote.ChannelDown();
            Assert.Contains("Current channel is 1", device.PrintStatus());
        }

        [Fact]
        public void Test15()
        {
            var device = new Radio();
            var basicRemote = new BasicRemote(device);
            basicRemote.VolumeUp();
            basicRemote.VolumeUp();
            basicRemote.VolumeDown();
            Assert.Contains("Current volume is 10%", device.PrintStatus());
        }

        [Fact]
        public void Test16()
        {
            var device = new Radio();
            var basicRemote = new BasicRemote(device);
            basicRemote.VolumeUp();
            Assert.Contains("Current volume is 10%", device.PrintStatus());
        }

        [Fact]
        public void Test17()
        {
            var device = new Radio();
            var basicRemote = new BasicRemote(device);
            basicRemote.VolumeDown();
            basicRemote.VolumeDown();
            basicRemote.VolumeDown();
            Assert.Contains("Current volume is 0%", device.PrintStatus());
        }

        [Fact]
        public void Test18()
        {
            var device = new Radio();
            var basicRemote = new BasicRemote(device);
            basicRemote.ChannelDown();
            basicRemote.ChannelDown();
            basicRemote.ChannelDown();
            Assert.Contains("Current channel is -3", device.PrintStatus()); //expected behaviour =)
        }

        [Fact]
        public void Test19()
        {
            var device = new Radio();
            var basicRemote = new AdvanceRemote(device);
            basicRemote.VolumeUp();
            basicRemote.VolumeUp();
            basicRemote.Mute();
            Assert.Contains("Current volume is 0%", device.PrintStatus()); //expected behaviour =)
        }
        
        [Fact]
        public void Test20()
        {
            var device = new Radio();
            Assert.Contains("I'm radio", device.PrintStatus());
        }
    }
}