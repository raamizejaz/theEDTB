using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theEDTB.Models;
using theEDTB.ViewModels;
using theEDTB.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.IO;
using Plugin.BluetoothLE;
using Plugin.BLE;
using Plugin.BLE.Abstractions;
using System.Collections.ObjectModel;
using Android.Bluetooth;
using Plugin.BLE.Abstractions.Exceptions;
using Plugin.BLE.Abstractions.Contracts;
using IDevice = Plugin.BLE.Abstractions.Contracts.IDevice;
using Plugin.BLE.Abstractions.EventArgs;

namespace theEDTB.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;
        IBluetoothLE ble;  //BLUETOOTH LOW ENERGY
        Plugin.BLE.Abstractions.Contracts.IAdapter adapter;
        ObservableCollection<IDevice> deviceList;
        IDevice device;
        public ItemsPage()
        {
            InitializeComponent();
            ble = CrossBluetoothLE.Current;
            adapter = CrossBluetoothLE.Current.Adapter;
            deviceList = new ObservableCollection<IDevice>();
            lv.ItemsSource = deviceList;
            BindingContext = _viewModel = new ItemsViewModel();
        }
        private void btnStatus_Clicked(object sender, EventArgs e) //CHECKING IF BLUETOOTH CONNECTIVITY IS ON/OFF/AVAILABLE ON MOBILE DEVICE
        {
            var state = ble.State;
            DisplayAlert("Notice", state.ToString(), "ok! ");
            if(state == BluetoothState.Off)
            {
                txtErrorBle.BackgroundColor = Color.Red;
                txtErrorBle.TextColor = Color.White;
                txtErrorBle.Text = "Your bluetooth is off! Turn on to proceed!";
                //DisplayAlert("Bluetooth is turned off! Turn it on", "None", "okay");
            }
        }

       

        private async void btnScan_Clicked(object sender, EventArgs e)
        {
            try 
            {
            deviceList.Clear();
            adapter.DeviceDiscovered += (s, a) => //WILL ADD DEVICE TO CLEARED LIST TO BE SELECTED
            {
                deviceList.Add(a.Device);
            };
            if (!ble.Adapter.IsScanning) //IF THE SCANNER IS NOT RUNNING
            {
                await adapter.StartScanningForDevicesAsync();
            }
         
            }
            catch (Exception ex)
            {
                 DisplayAlert("Notice", ex.Message.ToString(), "Error");
            }
        }

        private async void btnConnect_Clicked(object sender, EventArgs e)
        {
            try
            {
               
                if (device != null) //IF DEVICE IS AVAIABLE
                {
                    await adapter.ConnectToDeviceAsync(device); //CONNECT TO SELECTED DEVICE
                    DisplayAlert("Device:", "Connected!" , "ok");
                }
                else //IF THERE IS NO DEVICE AVAILABLE
                {
                    DisplayAlert("Notice","no device selected", "ok");
                }
            }
            catch (DeviceConnectionException ex)
            {
                 DisplayAlert("Notice", ex.Message.ToString(), "ok");
            }
        }

        //ALL CODE AFTER THIS POINT IS UNNECESSARY, BUT FOR SOME ODD REASON, APPLICATION BUILD FAILS IF COMMENTED OUT. WILL FIGURE SOlUTION FOR THIS IN 404!
        private  void btnKnowConnect_Clicked(object sender, EventArgs e)
        {
            

        }

        private  void btnGetServices_Clicked(object sender, EventArgs e)
        {
           
        }

        private  void btnGetCharacters_Clicked(object sender, EventArgs e)
        {
           

        }

        private  void btnDescriptors_Clicked(object sender, EventArgs e)
        {
           
        }

        private  void btnGetRW_Clicked(object sender, EventArgs e)
        {
           
        }

        private  void btnUpdate_Clicked(object sender, EventArgs e) 
        {
      
        }

        private  void btnDescRW_Clicked(object sender, EventArgs e)
        {
           
        }

        private void Lv_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
         
        }
    
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

       
    }
}