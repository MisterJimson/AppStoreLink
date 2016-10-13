using System;
using Android.App;
using Android.Content;
using Uri = Android.Net.Uri;

namespace Mj.AppStoreLink
{
    public class AppStoreLink : IAppStoreLink
    {
        public void Init(string myiTunesId, string myWindowsStoreId = null)
        {
            //not needed for Android
        }

        public void OpenMyAppStorePage()
        {
            var packageName = Application.Context.PackageName;
            OpenAppPage(packageName);
        }

        public void OpenAppStorePage(string androidPackageName, string iTunesId, string windowsStoreId = null)
        {
            OpenAppPage(androidPackageName);
        }

        private void OpenAppPage(string packageName)
        {
            if (string.IsNullOrEmpty(packageName))
                return;

            var url = $"market://details?id={packageName}";

            Intent intent = new Intent(Intent.ActionView, Uri.Parse(url));
            intent.AddFlags(ActivityFlags.NewTask | ActivityFlags.ClearWhenTaskReset);

            //if there is an app store that can handle this request, use it.
            //if not, use the browser
            if (intent.ResolveActivity(Application.Context.PackageManager) != null)
            {
                Application.Context.StartActivity(intent);
            }
            else
            {
                url = "https://play.google.com/store/apps/details?id=" + packageName;

                Intent fallbackIntent = new Intent(Intent.ActionView, Uri.Parse(url));
                fallbackIntent.AddFlags(ActivityFlags.NewTask | ActivityFlags.ClearWhenTaskReset);
                Application.Context.StartActivity(fallbackIntent);
            }
        }
    }
}