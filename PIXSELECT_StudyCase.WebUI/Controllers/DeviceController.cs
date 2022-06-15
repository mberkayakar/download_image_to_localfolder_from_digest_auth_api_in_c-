using Microsoft.AspNetCore.Mvc;
using PIXSELECT_StudyCase.WebUI.Services.Abstract;
using System.Security.Cryptography;
using System.Text;

namespace PIXSELECT_StudyCase.WebUI.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {
        
        private readonly IDeviceService _deviceservice;
        private readonly IUserService _userservice;


        public DeviceController(IDeviceService deviceservice , IUserService userService)
        {
            _deviceservice = deviceservice;
            _userservice = userService;
        }


        [HttpGet("login")]
        public IActionResult Login([FromQuery] string username ,string password)
        {
            var model = _userservice.LoginMethod(username, password);
            if (string.IsNullOrEmpty(model))
                return NotFound();
            
            return Ok(model);
        }



        [HttpGet("getSnapshot")]
        public IActionResult getSnapshot([FromQuery] string sorgu)
        {

            if (!string.IsNullOrEmpty(sorgu))
            {
                
                return Ok();
            }
            return BadRequest("İstek için bir adet md5 kodu giriniz.");

        }








    }
}
