using System;
using System.Collections.Generic;
using System.ComponentModel;
using theEDTB.Models;
using theEDTB.ViewModels;
using theEDTB.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.BluetoothClassic.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace theEDTB.Views
{
    public partial class NewItemPage : ContentPage
    {
        ItemsViewModel _viewModel;
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            FillBondedDevices();
            BindingContext = new NewItemViewModel();
        }
        private void FillBondedDevices()
        {
            var adapter = DependencyService.Resolve<IBluetoothAdapter>();
            lvBondedDevices.ItemsSource = adapter.BondedDevices;
        }

        private async void lvBondedDevices_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var device = (BluetoothDeviceModel)e.SelectedItem;
            if (device != null)
            { 
                await Navigation.PushAsync(new Page1 { BindingContext = device });
            }
            lvBondedDevices.SelectedItem = null;
        }

    }
}