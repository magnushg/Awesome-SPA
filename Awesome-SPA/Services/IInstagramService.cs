using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Awsome_SPA.Models;
using Newtonsoft.Json;

namespace Awesome_SPA.Services
{
    public interface IInstagramService
    {
        InstagramData GetImagesFromTag(string searchTerm);
    }

    public class InstagramService : IInstagramService
    {
        public InstagramData GetImagesFromTag(string searchTerm)
        {
            var address = string.Format("https://api.instagram.com/v1/tags/{0}/media/recent?access_token=24613827.f59def8.557cc0f5848b4738b417ef677d2ced5a", searchTerm);
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            var data = client.DownloadString(address);
            var deserializedData = JsonConvert.DeserializeObject<InstagramData>(data);
            return deserializedData;
        }
    }
}
