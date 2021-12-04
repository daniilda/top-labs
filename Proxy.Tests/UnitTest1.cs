using System.Security.Cryptography;
using Xunit;

namespace Proxy.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var native = new YouTubeVideoDownloader(new ThpYoutubeApiClient());
            var smart = new YouTubeVideoDownloader(new CachedYoutubeApiClient());

            Assert.Equal(native.RenderPopularVideosPage(), smart.RenderPopularVideosPage());
        }

        [Fact]
        public void Test2()
        {
            var native = new YouTubeVideoDownloader(new ThpYoutubeApiClient());
            var smart = new YouTubeVideoDownloader(new CachedYoutubeApiClient());

            Assert.Equal(native.RenderVideoPage("2121"), smart.RenderVideoPage("2121"));
        }
        
        [Theory]
        [InlineData("2121")]
        [InlineData("3131")]
        public void Test3(string id)
        {
            var native = new YouTubeVideoDownloader(new ThpYoutubeApiClient());

            Assert.Contains(id, native.RenderVideoPage(id));

        }
        
        [Theory]
        [InlineData("2121")]
        [InlineData("3131")]
        public void Test4(string id)
        {
            var smart = new YouTubeVideoDownloader(new CachedYoutubeApiClient());

            Assert.Contains(id, smart.RenderVideoPage(id));

        }

        [Fact]
        public void Test5()
        {
            var smart = new YouTubeVideoDownloader(new CachedYoutubeApiClient());

            Assert.Contains("321",smart.RenderPopularVideosPage());
        }

        [Fact]
        public void Test6()
        {
            var native = new YouTubeVideoDownloader(new ThpYoutubeApiClient());
            
            Assert.Contains("322",native.RenderPopularVideosPage());
        }
    }
}