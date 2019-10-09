using Microsoft.AspNetCore.Mvc;

namespace NetCoreBootstrap.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        public JsonResult Json(object value) => new JsonResult(value);
    }
}