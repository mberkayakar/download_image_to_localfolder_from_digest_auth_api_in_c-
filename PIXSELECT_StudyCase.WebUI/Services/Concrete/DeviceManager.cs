using PIXSELECT_StudyCase.WebUI.Helper.Security;
using PIXSELECT_StudyCase.WebUI.Models;
using PIXSELECT_StudyCase.WebUI.Services.Abstract;
using System.Collections.Generic;

namespace PIXSELECT_StudyCase.WebUI.Services.Concrete
{
    public class DeviceManager : IDeviceService
    {
        private readonly IUserService _userService;
        public DeviceManager(IUserService userService)
        {
            _userService = userService;
        }

        public string GetSnapShotandGetAdress(string HashForSnapshot)
        {
            throw new System.NotImplementedException();
        }

        public string LoginFunction(string Username, string Password)
        {

            var criptedtext = "";

            if (Username !=null && Username != "" && Password!=null && Password!= "")
            {
                criptedtext = EncriptedText.CreateMD5Generator(Username + " " + Password);
            }

            Dictionary<string, UserModel> openWith = new Dictionary<string, UserModel>();
            return "";
        }




    }
}
