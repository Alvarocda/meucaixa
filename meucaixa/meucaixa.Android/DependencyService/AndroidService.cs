using meucaixa.Droid.DependencyService;
using meucaixa.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidService))]
namespace meucaixa.Droid.DependencyService
{
    class AndroidService : IAndroid
    {
        public void FechaApp()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}