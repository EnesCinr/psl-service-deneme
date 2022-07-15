using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PSL.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/location")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        [HttpGet("{id}")]
        public void Get(int id)
        {

        }

        [HttpGet]
        public void Get()
        {

        }

        [HttpPost]
        public void Post()
        {

        }


        [HttpPut]
        public void Put()
        {

        }


        [HttpDelete]
        public void Delete()
        {

        }
    }
}
