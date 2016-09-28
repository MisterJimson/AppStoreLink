using System;
using System.Collections.Generic;
using System.Text;

namespace Mj.AppStoreLink
{
    public static class AppStoreLinkService
    {
        private static IAppStoreLink instance;
        public static IAppStoreLink Instance
        {
            get { return instance ?? instanceInit.Value; }
            set { instance = value; }
        }

        private static readonly Lazy<IAppStoreLink> instanceInit = new Lazy<IAppStoreLink>(() =>
        {
#if PCL
            throw new ArgumentException("This is the PCL library, not the platform library.  You must install the nuget package in your main application project");
#else
            return new AppStoreLink();
#endif
        });
    }
}
