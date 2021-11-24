using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace theEDTB.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click Me Again!";
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            //find some way to revert the buttons after having click me again. And to fix the button displacement issue
            (sender as Button).Text = "PSYCH!";
        }
    }
}