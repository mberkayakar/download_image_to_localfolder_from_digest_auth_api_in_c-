using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PIXSELECT_StudyCase.WebUI.Services.Abstract;
using PIXSELECT_StudyCase.WebUI.Services.Concrete;

namespace Northwind.Business.IOC.Microsoft
{
    public static class MicrosoftDependencies
    {
        public static void AddCustomDependencies(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserManager>();
            services.AddTransient<IDeviceService, DeviceManager>();
        }
    }
}