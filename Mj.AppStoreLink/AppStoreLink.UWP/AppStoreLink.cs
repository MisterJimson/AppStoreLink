using System;

namespace Mj.AppStoreLink
{
    public class AppStoreLink : IAppStoreLink
    {
        private string myWindowsStoreId;

        public void Init(string myiTunesId, string myWindowsStoreId = null)
        {
            this.myWindowsStoreId = myWindowsStoreId;
        }

        public void OpenMyAppStorePage()
        {
            if (myWindowsStoreId == null)
                throw new ArgumentException($"{nameof(myWindowsStoreId)} is null, did you call init?");

            OpenAppPage(this.myWindowsStoreId);
        }

        public void OpenAppStorePage(string androidPackageName, string iTunesId, string windowsStoreId = null)
        {
            OpenAppPage(windowsStoreId);
        }

        private void OpenAppPage(string windowsStoreId)
        {
            if (string.IsNullOrEmpty(windowsStoreId))
                return;

            var uri = new Uri($"ms-windows-store://pdp/?ProductId={windowsStoreId}");
            Windows.System.Launcher.LaunchUriAsync(uri);
        }
    }
}
