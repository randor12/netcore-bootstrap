using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreBootstrap.Controllers.Api.V1
{
    [Route("api/v1/[controller]")]
    public class HomeApiController : Controller
    {
        // GET api/v1/homeapi/{id}
        [HttpGet("{id}")]
        public int Get(int id)
        {
            return id;
        }

        // POST api/v1/homeapi
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/v1/homeapi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/v1/homeapi/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
