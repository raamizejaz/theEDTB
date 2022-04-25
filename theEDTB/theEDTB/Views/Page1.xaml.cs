using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.BluetoothClassic.Abstractions;
using System.Windows.Input;

namespace theEDTB.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }
        // private async void btnconnect(object sender, EventArgs e)
        //{

        //}
        private async void btnTransmit_Clicked(object sender, EventArgs e)
        {
            const int BufferSize = 1;
            const int OffsetDefault = 0;
            var device = (BluetoothDeviceModel)BindingContext;
            if (device != null)
            {
                var adapter = DependencyService.Resolve<IBluetoothAdapter>();
                using (var connection = adapter.CreateConnection(device))
                {

                    if (await connection.RetryConnectAsync(retriesCount: 2))
                    {
                        byte[] buffer = new byte[BufferSize] { (byte)stepperDigit.Value };
                        if (!await connection.RetryTransmitAsync(buffer, OffsetDefault, buffer.Length))
                        {
                            await DisplayAlert("Error 2", "cannot send data", "close");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Error 1", "Cannot connect", "close");
                    }
                }
            }
        }

        private async void btnRecive_Clicked(object sender, EventArgs e)
        {
            const int BufferSize = 1;
            const int OffsetDefault = 0;
            var device = (BluetoothDeviceModel)BindingContext;
            if (device != null)
            {
                var adapter = DependencyService.Resolve<IBluetoothAdapter>();
                using (var connection = adapter.CreateConnection(device))
                {
                    if (await connection.RetryConnectAsync(retriesCount: 2))
                    {
                        byte[] buffer = new byte[BufferSize];
                        if (!(await connection.RetryReciveAsync(buffer, OffsetDefault, buffer.Length)).Succeeded)
                        {
                            await DisplayAlert("Error 3", "cannot Receive data", "close");
                        }
                        else
                        {
                            stepperDigit.Value = buffer.FirstOrDefault();
                        }
                    }
                    else
                    {
                        await DisplayAlert("Error 4", "Cannot connect", "close");
                    }
                }
            }
        }
        private void Button_Clicked(object sender, EventArgs e) //UNUSED, BUT IF DELETED WILL CAUSE UNCOMPILABLE ERROR. WILL FIND WORKAROUND FOR THIS IN 404 IF NEEDED
        {
            (sender as Button).Text = "Click Me Again!";
        }


        int counter = 0; //COUNTER FOR CLICKS ON BUTTONS SET FOR THE COMMUNICATION METHOD PROTOCOLS

        private void OnButtonClicked(object sender, EventArgs e) //UNUSED, BUT IF DELETED WILL CAUSE UNCOMPILABLE ERROR. WILL FIND WORKAROUND FOR THIS IN 404 IF NEEDED
        {
            counter++;
            if (counter == 1)
            {
                (sender as Button).Text = "HELLOWORLD!";
            }
            else
            {
                (sender as Button).Text = "psych!!!";
                counter = 0;
            }
        }
        int binarynumber = 1;
        public int Value232
        {
            set
            {
                value = 2;
                binarynumber = value;
            }
            get
            {
                return binarynumber;
            }

        }
        public ICommand Setbinaryvalue { private set; get; }
        private void On232Clicked(object sender, EventArgs e) //IF RS-232 BUTTON IS CLICKED
        {
            counter++;
            if (counter == 1) //IF RS-232 IS SELECTED
            {
                (sender as Button).Text = "232 Selected!";
                (sender as Button).BackgroundColor = Color.Red;

                binarynumber = 0;
                string bin = Convert.ToString(binarynumber, 10);

                string result = string.Empty; //string to store binary version of text in
                foreach (byte value in bin) //for each byte in the text
                {
                    string binarybyte = Convert.ToString(binarynumber, 2); //converts byte into binary from text
                    while (binarybyte.Length < 3) //1 byte, 8bits, cannot exceed that per letter
                    {
                        binarybyte = "0" + binarybyte;
                    }
                    result += binarybyte; //stores the binary converted byte into result. Similar to arrays in theory
                }                //string bin = Convert.ToString(binarynumber, 2);
                DisplayAlert("RS-232", message: "mux bit is " + result, "ok");

                stepperDigit.Value = Convert.ToDouble(result);
                displayLabel.Text = result;
                //CAN'T CLICK ON HYPERLINK IN APP, BUT UNNECESSARY, IT IS JUST A PLACEHOLDER
                Setbinaryvalue = new Command(() => binarynumber *= 1);

            }
            else //FOR IF BUTTON IS CLICKED AGAIN, SO UNSELECTING THE CHOICE
            {
                (sender as Button).Text = "RS-232";
                (sender as Button).BackgroundColor = Color.DarkRed;
                displayLabel.Text = "0";
                counter = 0;
                //stepperDigit.Value = 0;
            }
        }
        private void On422Clicked(object sender, EventArgs e) //IF RS-422 BUTTON IS CLICKED
        {
            counter++;
            if (counter == 1) //IF RS-422 IS SELECTED
            {

                (sender as Button).Text = "422 Selected!";
                (sender as Button).BackgroundColor = Color.Red;

                binarynumber = 1;
                string bin = Convert.ToString(binarynumber, 10);

                //byte[] data;
                string result = string.Empty; //string to store binary version of text in
                foreach (byte value in bin) //for each byte in the text
                {
                    string binarybyte = Convert.ToString(binarynumber, 2); //converts byte into binary from text
                    while (binarybyte.Length < 3) //1 byte, 8bits, cannot exceed that per letter
                    {
                        binarybyte = "0" + binarybyte;
                    }
                    result += binarybyte; //stores the binary converted byte into result. Similar to arrays in theory


                }
                DisplayAlert("RS-422", message: "mux bit is " + result, "ok");
                stepperDigit.Value = Convert.ToDouble(result);
                displayLabel.Text = result;

            }
            else //IF RS-422 IS DESELECTED
            {
                (sender as Button).Text = "RS-422";
                (sender as Button).BackgroundColor = Color.DarkRed;
                displayLabel.Text = "0";
                counter = 0;
                //stepperDigit.Value = 0;
            }
        }
        private void On485Clicked(object sender, EventArgs e) //IF RS-485 BUTTON IS CLICKED
        {
            counter++;
            if (counter == 1) //IF RS-485 IS SELECTED
            {
                (sender as Button).Text = "485 Selected!";
                (sender as Button).BackgroundColor = Color.Red;

                binarynumber = 2;
                string bin = Convert.ToString(binarynumber, 10);

                //byte[] data;
                string result = string.Empty; //string to store binary version of text in
                foreach (byte value in bin) //for each byte in the text
                {
                    string binarybyte = Convert.ToString(binarynumber, 2); //converts byte into binary from text
                    while (binarybyte.Length < 3) //1 byte, 8bits, cannot exceed that per letter
                    {
                        binarybyte = "0" + binarybyte;
                    }
                    result += binarybyte; //stores the binary converted byte into result. Similar to arrays in theory


                }
                DisplayAlert("RS-485", message: "mux bit is " + result, "ok");
                stepperDigit.Value = Convert.ToDouble(result);
                displayLabel.Text = result;

            }
            else //IF RS-485 IS DESELECTED
            {
                (sender as Button).Text = "RS-485";
                (sender as Button).BackgroundColor = Color.DarkRed;
                displayLabel.Text = "0";
                counter = 0;
            }
        }
        private void OnCANClicked(object sender, EventArgs e) //IF CAN BUTTON IS CLICKED
        {
            counter++;
            if (counter == 1) //IF CAN IS SELECTED
            {
                (sender as Button).Text = "CAN Selected!";
                (sender as Button).BackgroundColor = Color.Red;

                binarynumber = 3;
                string bin = Convert.ToString(binarynumber, 10);

                //byte[] data;
                string result = string.Empty; //string to store binary version of text in
                foreach (byte value in bin) //for each byte in the text
                {
                    string binarybyte = Convert.ToString(binarynumber, 2); //converts byte into binary from text
                    while (binarybyte.Length < 3) //1 byte, 8bits, cannot exceed that per letter
                    {
                        binarybyte = "0" + binarybyte;
                    }
                    result += binarybyte; //stores the binary converted byte into result. Similar to arrays in theory


                }
                DisplayAlert("CAN", message: "mux bit is " + result, "ok");
                stepperDigit.Value = Convert.ToDouble(result);
                displayLabel.Text = result;

            }
            else //IF CAN IS DESELECTED
            {
                (sender as Button).Text = "CAN";
                (sender as Button).BackgroundColor = Color.DarkRed;
                displayLabel.Text = "0";
                counter = 0;
            }
        }
        private void OnI2CClicked(object sender, EventArgs e) //IF I2C BUTTON IS CLICKED
        {
            counter++;
            if (counter == 1) //IF I2C IS SELECTED
            {
                (sender as Button).Text = "I2C Selected!";
                (sender as Button).BackgroundColor = Color.Red;

                binarynumber = 4;
                string bin = Convert.ToString(binarynumber, 10);

                //byte[] data;
                string result = string.Empty; //string to store binary version of text in
                foreach (byte value in bin) //for each byte in the text
                {
                    string binarybyte = Convert.ToString(binarynumber, 2); //converts byte into binary from text
                    while (binarybyte.Length < 3) //1 byte, 8bits, cannot exceed that per letter
                    {
                        binarybyte = "0" + binarybyte;
                    }
                    result += binarybyte; //stores the binary converted byte into result. Similar to arrays in theory


                }
                DisplayAlert("I2C", message: "mux bit is " + result, "ok");
                stepperDigit.Value = Convert.ToDouble(result);
                displayLabel.Text = result;

            }
            else //IF I2C IS DESELECTED
            {
                (sender as Button).Text = "I2C";
                (sender as Button).BackgroundColor = Color.DarkRed;
                displayLabel.Text = "0";
                counter = 0;
            }
        }
        private void OnSPIClicked(object sender, EventArgs e) //IF SPI BUTTON IS CLICKED
        {
            counter++;
            if (counter == 1) //IF SPI IS SELECTED
            {
                (sender as Button).Text = "SPI Selected!";
                (sender as Button).BackgroundColor = Color.Red;

                binarynumber = 5;
                string bin = Convert.ToString(binarynumber, 10);

                //byte[] data;
                string result = string.Empty; //string to store binary version of text in
                foreach (byte value in bin) //for each byte in the text
                {
                    string binarybyte = Convert.ToString(binarynumber, 2); //converts byte into binary from text
                    while (binarybyte.Length < 3) //1 byte, 8bits, cannot exceed that per letter
                    {
                        binarybyte = "0" + binarybyte;
                    }
                    result += binarybyte; //stores the binary converted byte into result. Similar to arrays in theory


                }
                DisplayAlert("SPI", message: "mux bit is " + result, "ok");
                stepperDigit.Value = Convert.ToDouble(result);
                displayLabel.Text = result;

            }
            else //IF SPI IS DESELECTED
            {
                (sender as Button).Text = "SPI";
                (sender as Button).BackgroundColor = Color.DarkRed;
                displayLabel.Text = "0";
                counter = 0;
            }
        }
        private void OnMODBUSClicked(object sender, EventArgs e) //IF MODBUS BUTTON IS CLICKED
        {
            counter++;
            if (counter == 1) //IF MODBUS IS SELECTED
            {
                (sender as Button).Text = "MODBUS Selected!";
                (sender as Button).BackgroundColor = Color.Red;

                binarynumber = 6;
                string bin = Convert.ToString(binarynumber, 10);

                //byte[] data;
                string result = string.Empty; //string to store binary version of text in
                foreach (byte value in bin) //for each byte in the text
                {
                    string binarybyte = Convert.ToString(binarynumber, 2); //converts byte into binary from text
                    while (binarybyte.Length < 3) //1 byte, 8bits, cannot exceed that per letter
                    {
                        binarybyte = "0" + binarybyte;
                    }
                    result += binarybyte; //stores the binary converted byte into result. Similar to arrays in theory


                }
                DisplayAlert("MODBUS", message: "mux bit is " + result, "ok");
                stepperDigit.Value = Convert.ToDouble(result);
                displayLabel.Text = result;

            }
            else //IF MODBUS IS DESELECTED
            {
                (sender as Button).Text = "MODBUS";
                (sender as Button).BackgroundColor = Color.DarkRed;
                displayLabel.Text = "0";
                counter = 0;
            }
        }

        /*private void Slider_ValueChanged(object sender, ValueChangedEventArgs e) //Baud Rate Slider
        {
            //double value = ((Slider)sender).Value;
            double value = e.NewValue;
            BaudRateSlider.Rotation = value; //value of slider, rotates the label by that degrees
            displayLabel.Text = String.Format("{0}", value);

        }

        private void Frequency_ValueChanged(object sender, ValueChangedEventArgs e) //Frequency Slider
        {
            double value1 = e.NewValue;
            FrequencySlider.Rotation = value1; //value of slider, rotates the label by that degrees
            displayLabel1.Text = String.Format("{0}", value1);  //Displays the value of slider on the right hand side
        }*/

        private void Editor_Completed(object sender, EventArgs e) //Display Method Choices
        {

            var text = ((Editor)sender).Text; //getting text from the message text editor
            //ASCII TEXT RELAY
            DisplayAlert("Message:", text, "okay", "close"); //will display original message in ASCII text
            string v = DisplayMethod.Items[0]; //binary
            string u = DisplayMethod.Items[1]; //Hexadecimal
            int selectedIndex = DisplayMethod.SelectedIndex;

            //hex conversion
            string bin = "";
            if (selectedIndex == 1)
            {
                foreach (char c in text) //for each character in the text
                {
                    int tmp = c;
                    bin += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(tmp.ToString())); //Converts each character to hexadecimal
                }
                DisplayAlert("Message:", bin, "okay", "close"); //displays hex version of message
            }

            //string k = selectedIndex;
            //binary conversion
            if (selectedIndex == 0)
            {
                //byte[] data;
                string result = string.Empty; //string to store binary version of text in
                foreach (byte value in text) //for each byte in the text
                {
                    string binarybyte = Convert.ToString(value, 2); //converts byte into binary from text
                    while (binarybyte.Length < 8) //1 byte, 8bits, cannot exceed that per letter
                    {
                        binarybyte = "0" + binarybyte;
                    }
                    result += binarybyte; //stores the binary converted byte into result. Similar to arrays in theory
                }
                DisplayAlert("Message:", result, "okay", "close");  //displays binary version of message
            }
        }
    }
}