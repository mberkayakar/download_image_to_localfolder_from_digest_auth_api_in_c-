namespace PIXSELECT_StudyCase.WebUI.Services.Abstract
{
    public interface IDeviceService
    {

        public string LoginAndGetİmageFromService(string Username, string Password);
        public string GetSnapShotandGetAdress(string HashForSnapshot);

    }
}
