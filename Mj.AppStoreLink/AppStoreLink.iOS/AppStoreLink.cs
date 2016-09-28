using System;
using Foundation;
using UIKit;


namespace Mj.AppStoreLink
{
    public class AppStoreLink : IAppStoreLink
    {
        public void OpenAppStorePage(string androidPackageName, string iTunesId)
        {
            OpenAppPage(iTunesId);
        }

        private void OpenAppPage(string iTunesId)
        {
			NSUrl appUrl = new NSUrl($"itms-apps://itunes.apple.com/app/{iTunesId}");

            if (UIApplication.SharedApplication.CanOpenUrl(appUrl))
            {
                UIApplication.SharedApplication.OpenUrl(appUrl);
            }
        }
    }
}