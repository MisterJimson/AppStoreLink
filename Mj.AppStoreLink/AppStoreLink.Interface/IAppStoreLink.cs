namespace Mj.AppStoreLink
{
    public interface IAppStoreLink
    {
        void Init(string myAndroidPackageName, string myiTunesId, string myWindowsStoreId = null);
        void OpenMyAppStorePage();
        void OpenAppStorePage(string androidPackageName, string iTunesId, string windowsStoreId = null);
    }
}
