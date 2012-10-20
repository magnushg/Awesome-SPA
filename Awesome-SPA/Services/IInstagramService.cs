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
        InstagramData GetImagesForUser(int userId);
    }

    public class InstagramService : IInstagramService
    {
        public InstagramData GetImagesForUser(int userId)
        {
            var address = "https://api.instagram.com/v1/users/24613827/media/recent/?access_token=24613827.f59def8.557cc0f5848b4738b417ef677d2ced5a";
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            var data = client.DownloadString(address);
            var deserializedData = JsonConvert.DeserializeObject<InstagramData>(data);
            return deserializedData;
        }
    }
}
