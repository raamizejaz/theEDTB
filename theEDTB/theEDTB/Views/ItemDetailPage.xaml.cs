using System.ComponentModel;
using theEDTB.ViewModels;
using Xamarin.Forms;

namespace theEDTB.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}