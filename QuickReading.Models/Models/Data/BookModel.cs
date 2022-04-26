using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReading.Models.Models.Data
{
    public class BookModel
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("full_sort_key")]
        public string FullSortKey { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("cover_color")]
        public string CoverColor { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("cover")]
        public string Cover { get; set; }

        [JsonProperty("epoch")]
        public string Epoch { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("has_audio")]
        public bool HasAudio { get; set; }

        [JsonProperty("genre")]
        public string Genre { get; set; }

        [JsonProperty("simple_thumb")]
        public Uri SimpleThumb { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("cover_thumb")]
        public string CoverThumb { get; set; }

        [JsonProperty("liked")]
        public object Liked { get; set; }

    }

}

