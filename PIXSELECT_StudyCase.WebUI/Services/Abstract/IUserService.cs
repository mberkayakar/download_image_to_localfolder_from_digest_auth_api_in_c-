using PIXSELECT_StudyCase.WebUI.Entities.DTO.UserDto;
using PIXSELECT_StudyCase.WebUI.Models;
using System.Collections.Generic;

namespace PIXSELECT_StudyCase.WebUI.Services.Abstract
{
    public interface IUserService
    {
        public string LoginMethod(string username, string password);
        public GetUserİnformation GetUserİnformation(string username, string password);






    }
}
