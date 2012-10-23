using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Awesome_SPA.Services;
using Awesome_SPA.Models;

namespace Awesome_SPA.Controllers
{
    public class ImagesController : ApiController
    {
        private readonly IInstagramService _instagramService;

        public ImagesController(IInstagramService instagramService)
        {
            _instagramService = instagramService;
        }

        // GET api/values
        public IEnumerable<InstagramBasicData> Get()
        {
            return _instagramService.GetImagesFromTag("bouvet");
        }

        // GET api/values/5
        public IEnumerable<InstagramBasicData> Get(string searchTerm)
        {
            return _instagramService.GetImagesFromTag(searchTerm);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}