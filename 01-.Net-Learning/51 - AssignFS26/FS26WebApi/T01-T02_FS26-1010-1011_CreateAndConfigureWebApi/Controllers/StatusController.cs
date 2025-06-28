using FS26WebApi.Configs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FS26WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly MySettings _mySettings;

        public StatusController(MySettings mySettings)
        {
            _mySettings = mySettings;
        }

        [HttpGet]
        public IActionResult GetStatus()
        {
            var result = new
            {
                AppName = _mySettings.AppName,
                Version = _mySettings.Version,
                Now = DateTime.Now.ToString("s")
            };
            return Ok(result);
        }
    }
}
