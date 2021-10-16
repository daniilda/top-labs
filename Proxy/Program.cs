using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            var native = new YouTubeVideoDownloader(new ThpYoutubeApiClient());
            var smart = new YouTubeVideoDownloader(new CachedYoutubeApiClient());
            
            Call(native);
            Call(smart);
            
            void Call(YouTubeVideoDownloader downloader)
            {
                downloader.RenderPopularVideosPage();
                downloader.RenderVideoPage("123321");
                downloader.RenderPopularVideosPage();
                downloader.RenderVideoPage("123322");
                downloader.RenderVideoPage("123321");
            }
        }
    }

    public interface IYoutubeApiClient
    {
        public Dictionary<string, Video> GetPopularVideos();
        public Video GetVideo(string id);
    }

    public class ThpYoutubeApiClient : IYoutubeApiClient
    {
        public Dictionary<string, Video> GetPopularVideos()
        {
            ConnectToServer_Debug("http://www.youtube.com");
            return GetRandomVideos_Debug();
        }

        public Video GetVideo(string id)
        {
            ConnectToServer_Debug($@"http://www.youtube.com/{id}");
            return GetSomeVideo_Debug(id);
        }

        #region Debug methods

        //----Методы затычки для имитации внешнего API----//
        private async void ConnectToServer_Debug(string server)
        {
            Console.WriteLine($@"Connecting to {server}...");
            await Task.Delay(500);
            Console.WriteLine("Successfully connected!");
        }

        private Dictionary<string, Video> GetRandomVideos_Debug()
        {
            Console.WriteLine("Downloading populars... ");

            var result = new Dictionary<string, Video>();
            result.Add("123321", new Video("321", "Kitties.avi", "234rdfwec"));
            result.Add("123322", new Video("322", "Kitties2.avi", "234rdfwec123qwe"));
            result.Add("123323", new Video("323", "Kitties3.avi", "234SDFrdfwec"));

            Console.WriteLine("Done!");
            return result;
        }

        private Video GetSomeVideo_Debug(string id)
        {
            Console.WriteLine("Downloading video...");
            Console.WriteLine("Done!");

            return new Video(id, "Some video title", "234r324rf");
        }

        //----Методы затычки для имитации внешнего API----//

        #endregion
    }

    public class CachedYoutubeApiClient : IYoutubeApiClient
    {
        private readonly ThpYoutubeApiClient _api;
        private readonly Dictionary<string, Video> _cache = new Dictionary<string, Video>();
        private Dictionary<string, Video> _cachePopular = new Dictionary<string, Video>();

        public CachedYoutubeApiClient()
            => _api = new ThpYoutubeApiClient(); //let's imagine we have some fancy DI here
        
        public Dictionary<string, Video> GetPopularVideos()
        {
            if (_cachePopular.Count == 0)
                _cachePopular = _api.GetPopularVideos();
            else
                Console.WriteLine("Fetching list from cache.");

            return _cachePopular;
        }

        public Video GetVideo(string id)
        {
            if (_cache.ContainsKey(id))
            {
                Console.WriteLine("Fetching video from cache.");
                return _cache[id];
            }
            
            var result = _api.GetVideo(id);
            _cache.Add(id, result);
            return result;
        }
    }

    public class Video
    {
        public string Id { get; init; }
        public string Title { get; init; }
        public string Data { get; init; }

        public Video(string? id = null, string? title = null, string? data = null)
        {
            Id = id ?? "435435";
            Title = title ?? "Title";
            Data = data ?? "Data";
        }
    }

    public class YouTubeVideoDownloader
    {
        private IYoutubeApiClient _apiClient;

        public YouTubeVideoDownloader(IYoutubeApiClient apiClient)
            => _apiClient = apiClient;

        public void RenderVideoPage(string videoId)
        {
            var video = _apiClient.GetVideo(videoId);
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Video page");
            Console.WriteLine("ID: " + video.Id);
            Console.WriteLine("Title: " + video.Title);
            Console.WriteLine("Data: " + video.Data);
            Console.WriteLine("--------------------------------");
        }

        public void RenderPopularVideosPage()
        {
            var list = _apiClient.GetPopularVideos();
            Console.WriteLine("---- Popular videos ----");
            foreach (var (_,video) in list)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Video");
                Console.WriteLine("ID: " + video.Id);
                Console.WriteLine("Title: " + video.Title);
                Console.WriteLine("--------------------------------");
            }
            
        }
    }
}