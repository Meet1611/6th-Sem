using Microsoft.AspNetCore.Mvc;

namespace Routing_demo.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet("Meet/{id:int}")]
        [MapToApiVersion("1.0")]
        public IActionResult GetV1(int id)
        {
            return Ok($"V1 response. Id = {id}");
        }

        [HttpGet("Meet/{id:int}/{id2:int}")]
        [MapToApiVersion("2.0")]
        public IActionResult GetV2(int id, int id2)
        {
            return Ok($"V2 response. Id = {id}, Id2 = {id2}");
        }
    }
}
