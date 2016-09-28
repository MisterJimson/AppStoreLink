using System;
using Mj.AppStoreLink;
using Xamarin.Forms;

namespace SampleApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            AppStoreLinkService.Instance.OpenAppStorePage("com.google.android.googlequicksearchbox", null);
        }
    }
}
