using System;

using Android.App;
using Android.Content;
using Uri = Android.Net.Uri;

namespace Mj.AppStoreLink
{
    public class AppStoreLink : IAppStoreLink
    {
        public void OpenAppStorePage(string androidPackageName, string iTunesId)
        {
            OpenAppPage(androidPackageName);
        }

        private void OpenAppPage(string packageName)
        {
            string url;

            try
            {
                Application.Context.PackageManager.GetPackageInfo("com.android.vending", 0);
                url = "market://details?id=" + packageName;
            }
            catch (Exception e)
            {
                url = "https://play.google.com/store/apps/details?id=" + packageName;
            }

            Intent intent = new Intent(Intent.ActionView, Uri.Parse(url));
            intent.AddFlags(ActivityFlags.NewTask | ActivityFlags.ClearWhenTaskReset);
            Application.Context.StartActivity(intent);
        }
    }
}