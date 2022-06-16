using PIXSELECT_StudyCase.WebUI.Entities.DTO.UserDto;
using PIXSELECT_StudyCase.WebUI.Entities.ErrorModel;
using PIXSELECT_StudyCase.WebUI.Helper.Security;
using PIXSELECT_StudyCase.WebUI.Services.Abstract;
using PIXSELECT_StudyCase.WebUI.VirtaulDataBase;
using System;


namespace PIXSELECT_StudyCase.WebUI.Services.Concrete
{
    public class UserManager : IUserService
    {

       

        public GetUserİnformation GetUserİnformation(string hash)
        {

            if (!string.IsNullOrEmpty(hash))
            {
                try
                {
                    var userkey = VirtualDataBase.Userİnformation[hash];
                    GetUserİnformation user = new GetUserİnformation();
                    user.UserName = userkey.username;
                    user.Password = userkey.password;
                    user.HashCode = hash;
                    if (userkey == null)
                    {
                        throw new ArgumentException("Not Found User İn DataBase");
                    }
                    return user;
                }
                catch (Exception EX)
                {

                    return null;

                }
                
            }
            throw new ArgumentException("Not Found Hash İn Parameters");


        }

        public string LoginMethod(string username, string password)
        {

             
                if (String.IsNullOrEmpty(username))
                    throw new NotFoundError("Username Bilgisi bulunamadı ");
                if (String.IsNullOrEmpty(password))
                    throw new NotFoundError("Password Bilgisi bulunamadı");

                var model = EncriptedText.CreateMD5Generator(username + " " + password);

            try
            {
                var userkey = VirtualDataBase.Userİnformation[model];

                if (userkey == null)
                {
                    throw new NotFoundError("Not Found User İn DataBase");
                }

                return model;

            }
            catch (Exception)
            {
                throw new NotFoundError("Sistemde Bu şifre ve kullanıcı id sine ait bir kayıt bulunamadı ");
            }
            }
           
        }
}
