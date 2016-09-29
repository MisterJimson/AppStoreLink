using System;
using Foundation;
using UIKit;

namespace Mj.AppStoreLink
{
    public class AppStoreLink : IAppStoreLink
    {
        private string myiTunesId;

        public void Init(string myAndroidPackageName, string myiTunesId, string myWindowsStoreId = null)
        {
            this.myiTunesId = myiTunesId;
        }

        public void OpenMyAppStorePage()
        {
            if (myiTunesId == null)
                throw new ArgumentException($"{nameof(myiTunesId)} is null, did you call init?");

            OpenAppPage(this.myiTunesId);
        }

        public void OpenAppStorePage(string androidPackageName, string iTunesId, string windowsStoreId = null)
        {
            OpenAppPage(iTunesId);
        }

        private void OpenAppPage(string iTunesId)
        {
            if (string.IsNullOrEmpty(iTunesId))
                return;

			NSUrl appUrl = new NSUrl($"itms-apps://itunes.apple.com/app/id{iTunesId}");

            if (UIApplication.SharedApplication.CanOpenUrl(appUrl))
            {
                UIApplication.SharedApplication.OpenUrl(appUrl);
            }
        }
    }
}