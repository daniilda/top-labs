using System;
using System.Collections.Generic;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }
    }
    
    public interface IYoutubeApiClient
    {
        List<string> PopularVideo();
        Video GetVideo(string id);
    }
    
    public class ThpYoutubeApiClient : IYoutubeApiClient
    {
        public List<string> PopularVideo()
        {
            return new List<string>();
        }

        public Video GetVideo(string id)
        {
            return new Video();
        }
    }

    public class CachedYoutubeApiClient : IYoutubeApiClient
    {
        private readonly ThpYoutubeApiClient _api;
        private readonly Dictionary<string, Video> _set;

        private CachedYoutubeApiClient()
        {
            _api = new ThpYoutubeApiClient();
            _set = new Dictionary<string, Video>();
        }
        
        public List<string> PopularVideo()
        {
            return new List<string>();
        }

        public Video GetVideo(string id)
        {
            if (_set.ContainsKey(id))
            {
                return _set[id];
            }

            var temp = _api.GetVideo(id);
            _set.Add(id, temp);
            return temp;
        }
    }

    public class Video
    {
        public string Id { get; init; }
        public string Title { get; init; }
        public string Data { get; init; }

        public Video(string id = null!, string title = null!, string data = null!)
        {
            Id = id ?? "435435";
            Title = title ?? "Title";
            Data = data ?? "Data";
        }
    }
}