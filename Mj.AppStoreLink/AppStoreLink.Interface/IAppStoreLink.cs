namespace Mj.AppStoreLink
{
    public interface IAppStoreLink
    {
        void OpenAppStorePage(string androidPackageName, string iTunesId, string windowsStoreId = null);
    }
}
