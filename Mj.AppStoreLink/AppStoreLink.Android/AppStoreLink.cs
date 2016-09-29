using System;
using Android.App;
using Android.Content;
using Uri = Android.Net.Uri;

namespace Mj.AppStoreLink
{
    public class AppStoreLink : IAppStoreLink
    {
        private string myAndroidPackageName;

        public void Init(string myAndroidPackageName, string myiTunesId, string myWindowsStoreId = null)
        {
            this.myAndroidPackageName = myAndroidPackageName;
        }

        public void OpenMyAppStorePage()
        {
            if (myAndroidPackageName == null)
                throw new ArgumentException($"{nameof(myAndroidPackageName)} is null, did you call init?");

            OpenAppPage(this.myAndroidPackageName);
        }

        public void OpenAppStorePage(string androidPackageName, string iTunesId, string windowsStoreId = null)
        {
            OpenAppPage(androidPackageName);
        }

        private void OpenAppPage(string packageName)
        {
            if (string.IsNullOrEmpty(packageName))
                return;

            string url;

            try
            {
                Application.Context.PackageManager.GetPackageInfo("com.android.vending", 0);
                url = "market://details?id=" + packageName;

                Intent intent = new Intent(Intent.ActionView, Uri.Parse(url));
                intent.AddFlags(ActivityFlags.NewTask | ActivityFlags.ClearWhenTaskReset);
                Application.Context.StartActivity(intent);
            }
            catch (Exception e)
            {
                url = "https://play.google.com/store/apps/details?id=" + packageName;
            }

            Intent fallbackIntent = new Intent(Intent.ActionView, Uri.Parse(url));
            fallbackIntent.AddFlags(ActivityFlags.NewTask | ActivityFlags.ClearWhenTaskReset);
            Application.Context.StartActivity(fallbackIntent);
        }
    }
}