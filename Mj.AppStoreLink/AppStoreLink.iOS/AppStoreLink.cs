using System;
using Foundation;
using UIKit;


namespace Mj.AppStoreLink
{
    public class AppStoreLink : IAppStoreLink
    {
        public void OpenAppStorePage(string androidPackageName, string iTunesAppUrl)
        {
            OpenAppPage(iTunesAppUrl);
        }

        private void OpenAppPage(string iTunesAppUrl)
        {
            NSUrl appUrl = new NSUrl(iTunesAppUrl);

            if (UIApplication.SharedApplication.CanOpenUrl(appUrl))
            {
                UIApplication.SharedApplication.OpenUrl(appUrl);
            }
        }
    }
}