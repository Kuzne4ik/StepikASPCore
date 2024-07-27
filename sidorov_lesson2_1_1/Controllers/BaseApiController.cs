using Microsoft.AspNetCore.Mvc;

namespace lesson2_1_1.Controllers
{
    /// <summary>
    /// Base controller class
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
    }
}
