namespace PIXSELECT_StudyCase.WebUI.Services.Abstract
{
    public interface IDeviceService
    {

        public string LoginFunction(string Username, string Password);
        public string GetSnapShotandGetAdress(string HashForSnapshot);

    }
}
