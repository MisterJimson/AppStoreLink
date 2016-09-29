using System;

namespace Mj.AppStoreLink
{
    public class AppStoreLink : IAppStoreLink
    {
        public void OpenAppStorePage(string androidPackageName, string iTunesId, string windowsStoreId = null)
        {
            if (string.IsNullOrEmpty(windowsStoreId))
                return;

            var uri = new Uri($"ms-windows-store://pdp/?ProductId={windowsStoreId}");
            Windows.System.Launcher.LaunchUriAsync(uri);
        }
    }
}
