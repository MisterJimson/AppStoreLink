using System;

using Android.App;
using Android.Content;
using Uri = Android.Net.Uri;

namespace Mj.AppStoreLink
{
    public class AppStoreLink : IAppStoreLink
    {
        public void OpenAppStorePage(string androidPackageName, string iTunesAppUrl)
        {
            OpenAppPage(androidPackageName);
        }

        private void OpenAppPage(string packageName)
        {
            try
            {
                Application.Context.StartActivity(new Intent(Intent.ActionView,
                    Uri.Parse("market://details?id=" + packageName)));
            }
            catch (Exception e)
            {
                Application.Context.StartActivity(new Intent(Intent.ActionView,
                    Uri.Parse("https://play.google.com/store/apps/details?id=" + packageName)));

            }
        }
    }
}