using Android.App;
using Android.Widget;
using WanderersDiary.Client.Droid.Services;
using WanderersDiary.Client.Services.Alert;

[assembly: Xamarin.Forms.Dependency(typeof(ToastService))]
namespace WanderersDiary.Client.Droid.Services
{
    public class ToastService : IAlertService
    {
        public void LongAlert(string message) => ShowToast(message, ToastLength.Long);

        public void ShortAlert(string message) => ShowToast(message, ToastLength.Short);

        private void ShowToast(string message, ToastLength toastLength)
        {
            Toast.MakeText(Application.Context, message, toastLength).Show();
        }
    }
}