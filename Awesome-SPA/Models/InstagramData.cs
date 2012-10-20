using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Awsome_SPA.Models
{
    public class InstagramData
    {
        public Meta meta { get; set; }
        public Data[] data { get; set; }
    }

    public class Meta
    {
        public int code { get; set; }
    }

    public class Location
    {
        public double latitude { get; set; }
        public string name { get; set; }
        public double longitude { get; set; }
        public int id { get; set; }
    }

    public class From
    {
        public string username { get; set; }
        public string profile_picture { get; set; }
        public string id { get; set; }
        public string full_name { get; set; }
    }

    public class CommentsData
    {
        public string created_time { get; set; }
        public string text { get; set; }
        public From from { get; set; }
        public string id { get; set; }
    }

    public class Comments
    {
        public int count { get; set; }
        public CommentsData[] data { get; set; }
    }

    public class LikesData
    {
        public string username { get; set; }
        public string profile_picture { get; set; }
        public string id { get; set; }
        public string full_name { get; set; }
    }

    public class Likes
    {
        public int count { get; set; }
        public LikesData[] data { get; set; }
    }

    public class Low_Resolution
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Thumbnail
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Standard_Resolution
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Images
    {
        public Low_Resolution low_resolution { get; set; }
        public Thumbnail thumbnail { get; set; }
        public Standard_Resolution standard_resolution { get; set; }
    }

    public class CaptionFrom
    {
        public string username { get; set; }
        public string profile_picture { get; set; }
        public string id { get; set; }
        public string full_name { get; set; }
    }

    public class Caption
    {
        public string created_time { get; set; }
        public string text { get; set; }
        public CaptionFrom from { get; set; }
        public string id { get; set; }
    }

    public class User
    {
        public string username { get; set; }
        public string website { get; set; }
        public string bio { get; set; }
        public string profile_picture { get; set; }
        public string full_name { get; set; }
        public string id { get; set; }
    }

    public class Data
    {
        public object attribution { get; set; }
        public object[] tags { get; set; }
        public string type { get; set; }
        public Location location { get; set; }
        public Comments comments { get; set; }
        public string filter { get; set; }
        public string created_time { get; set; }
        public string link { get; set; }
        public Likes likes { get; set; }
        public Images images { get; set; }
        public Caption caption { get; set; }
        public bool user_has_liked { get; set; }
        public string id { get; set; }
        public User user { get; set; }
    }
}