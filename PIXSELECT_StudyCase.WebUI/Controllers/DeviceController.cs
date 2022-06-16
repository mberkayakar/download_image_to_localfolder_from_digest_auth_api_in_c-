using Microsoft.AspNetCore.Mvc;
using PIXSELECT_StudyCase.WebUI.Entities.ErrorModel;
using PIXSELECT_StudyCase.WebUI.Models;
using PIXSELECT_StudyCase.WebUI.Services.Abstract;
using System;
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


        [HttpPost("login")]
        public IActionResult Login([FromBody] UserModel user)
        {
          
            var model = _userservice.LoginMethod(user.username, user.password);
            if (string.IsNullOrEmpty(model))
                return NotFound();
            
            return Ok(model);
        }



        [HttpGet("getSnapshot")]
        public IActionResult getSnapshot([FromQuery] string sorgu)
        {

            if (!string.IsNullOrEmpty(sorgu))
            {
                var model = _deviceservice.GetSnapShotandGetAdress(sorgu);
                return Ok("Resim: \n\n "+model+" \n\n yoluna kaydedilmiştir.");
            }
            return BadRequest("İstek için bir adet md5 kodu giriniz.");

        }

         

    }
}
