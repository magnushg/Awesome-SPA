using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Awesome_SPA.Services;
using Awsome_SPA.Models;

namespace Awesome_SPA.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IInstagramService _instagramService;

        public ValuesController(IInstagramService instagramService)
        {
            _instagramService = instagramService;
        }

        // GET api/values
        public InstagramData Get()
        {
            return _instagramService.GetImagesForUser(2);
        }

        // GET api/values/5
        public InstagramData Get(int userId)
        {
            return _instagramService.GetImagesForUser(userId);
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