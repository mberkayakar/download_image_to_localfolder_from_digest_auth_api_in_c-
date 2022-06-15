using PIXSELECT_StudyCase.WebUI.Models;
using System.Collections.Generic;

namespace PIXSELECT_StudyCase.WebUI.VirtaulDataBase
{
    public static class VirtualDataBase
    {
        // Buranın oluşturulmas sebebi sistemde sizin belirtmiş olduğunuz md5 in karşılıgını alabilmek maksadı 
        // sanal bir veri tabanı gibi sözlüğümü oluşturdum.

        // Entity Framework yardımı ve seed data mekaniği kullanılarak projenin ayaga kaldırılması anında da 
        // bu süreç yürütülebilirdi kullanacağınız bilgisayarda süreçleri yürütebilmek için kütüphane ve 
        // araçların olmama ihtimali göz önüne alınarak bu şekilde bir süreç belirlendi. 

        public static Dictionary<string, UserModel> Userİnformation = new Dictionary<string, UserModel>
        {
            ["bcca755a8f221f8ee83bd05e52b11f29"] = new UserModel() { Username = "test", Password = "test?123" },

        };



    }
}
