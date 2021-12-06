using System;
using theEDTB.Services;
using theEDTB.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace theEDTB
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
            //MainPage = new NavigationPage(new SelectDevicePage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
