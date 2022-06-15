using PIXSELECT_StudyCase.WebUI.Helper.Security;
using PIXSELECT_StudyCase.WebUI.Models;
using PIXSELECT_StudyCase.WebUI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Net;

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
            if (!string.IsNullOrEmpty(HashForSnapshot))
            {
                var user = _userService.GetUserİnformation(HashForSnapshot);
                if (user != null)
                {
                    var localpath = LoginAndGetİmageFromService(user.UserName, user.Password);
                    if (!string.IsNullOrEmpty(localpath))
                    {
                        return localpath;

                    }
                }
            }

            return null;


        }

        public string LoginAndGetİmageFromService(string Username, string Password)
        {

            var webClient = new WebClient();
            var credentialCache = new CredentialCache();
            credentialCache.Add(new Uri("http://212.125.30.226:60213/cgi-bin/snapshot.cgi?channel=2"), "Digest", new NetworkCredential(Username, Password));
            webClient.Credentials = credentialCache;
            var imgStream = new MemoryStream(webClient.DownloadData("http://212.125.30.226:60213/cgi-bin/snapshot.cgi?channel=2"));
            var Image = new System.Drawing.Bitmap(imgStream);
            EncoderParameters encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);



            var path = System.IO.Directory.GetCurrentDirectory();


            string outputFileName = path+"\\Media\\"+System.Guid.NewGuid().ToString()+"resim.jpeg";
            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(outputFileName, FileMode.Create, FileAccess.ReadWrite))
                {
                    Image.Save(memory, ImageFormat.Jpeg);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            return outputFileName;

        }
    }
}
