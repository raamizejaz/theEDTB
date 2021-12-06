using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Acr;

namespace theEDTB.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e) //UNUSED, BUT IF DELETED WILL CAUSE UNCOMPILABLE ERROR. WILL FIND WORKAROUND FOR THIS IN 404 IF NEEDED
        {
            (sender as Button).Text = "Click Me Again!";
        }

        int counter = 0; //COUNTER FOR CLICKS ON BUTTONS SET FOR THE COMMUNICATION METHOD PROTOCOLS
        private void OnButtonClicked(object sender, EventArgs e) //UNUSED, BUT IF DELETED WILL CAUSE UNCOMPILABLE ERROR. WILL FIND WORKAROUND FOR THIS IN 404 IF NEEDED
        {
            counter++;
            if(counter == 1) 
            {
                (sender as Button).Text = "HELLOWORLD!";
            }
            else
            {
                (sender as Button).Text = "psych!!!";
                counter = 0;
            }
        }
        private void On232Clicked(object sender, EventArgs e) //IF RS-232 BUTTON IS CLICKED
        {
            counter++;
            if (counter == 1) //IF RS-232 IS SELECTED
            {
                (sender as Button).Text = "232 Selected!";
                DisplayAlert("RS-232", message: "https://en.wikipedia.org/wiki/RS-422", "ok"); //CAN'T CLICK ON HYPERLINK IN APP, BUT UNNECESSARY, IT IS JUST A PLACEHOLDER
              
                
            }
            else //FOR IF BUTTON IS CLICKED AGAIN, SO UNSELECTING THE CHOICE
            {
                (sender as Button).Text = "RS-232";
                counter = 0;
            }
        }
        private void On422Clicked(object sender, EventArgs e) //IF RS-422 BUTTON IS CLICKED
        {
            counter++;
            if (counter == 1) //IF RS-422 IS SELECTED
            {
                (sender as Button).Text = "422 Selected!";
                DisplayAlert("RS-232", message: "https://en.wikipedia.org/wiki/RS-422", "ok");
            }
            else //IF RS-422 IS DESELECTED
            {
                (sender as Button).Text = "RS-422"; 
                counter = 0;
            }
        }
        private void On485Clicked(object sender, EventArgs e) //IF RS-485 BUTTON IS CLICKED
        {
            counter++;
            if (counter == 1) //IF RS-485 IS SELECTED
            {
                (sender as Button).Text = "485 Selected!";
                DisplayAlert("RS-232", message: "https://en.wikipedia.org/wiki/RS-485", "ok");
            }
            else //IF RS-485 IS DESELECTED
            {
                (sender as Button).Text = "RS-485";
                counter = 0;
            }
        }
        private void OnCANClicked(object sender, EventArgs e) //IF CAN BUTTON IS CLICKED
        {
            counter++;
            if (counter == 1) //IF CAN IS SELECTED
            {
                (sender as Button).Text = "CAN Selected!";
                DisplayAlert("RS-232", message: "https://en.wikipedia.org/wiki/CAN_bus", "ok");
            }
            else //IF CAN IS DESELECTED
            {
                (sender as Button).Text = "CAN";
                counter = 0;
            }
        }
        private void OnI2CClicked(object sender, EventArgs e) //IF I2C BUTTON IS CLICKED
        {
            counter++;
            if (counter == 1) //IF I2C IS SELECTED
            {
                (sender as Button).Text = "I2C Selected!";
                DisplayAlert("RS-232", message: "https://en.wikipedia.org/wiki/I2C", "ok");
            }
            else //IF I2C IS DESELECTED
            {
                (sender as Button).Text = "I2C";
                counter = 0;
            }
        }
        private void OnSPIClicked(object sender, EventArgs e) //IF SPI BUTTON IS CLICKED
        {
            counter++;
            if (counter == 1) //IF SPI IS SELECTED
            {
                (sender as Button).Text = "SPI Selected!";
                DisplayAlert("RS-232", message: "https://en.wikipedia.org/wiki/Serial_Peripheral_Interface", "ok");
            }
            else //IF SPI IS DESELECTED
            {
                (sender as Button).Text = "SPI";
                counter = 0;
            }
        }
        private void OnMODBUSClicked(object sender, EventArgs e) //IF MODBUS BUTTON IS CLICKED
        {
            counter++;
            if (counter == 1) //IF MODBUS IS SELECTED
            {
                (sender as Button).Text = "MODBUS Selected!";
                DisplayAlert("RS-232", message: "https://en.wikipedia.org/wiki/Modbus", "ok");
            }
            else //IF MODBUS IS DESELECTED
            {
                (sender as Button).Text = "MODBUS";
                counter = 0;
            }
        }
 
        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e) //Baud Rate Slider
        {
            //double value = ((Slider)sender).Value;
            double value = e.NewValue;
            BaudRateSlider.Rotation = value; //value of slider, rotates the label by that degrees
            displayLabel.Text = String.Format("{0}",value);

        }

        private void Frequency_ValueChanged(object sender, ValueChangedEventArgs e) //Frequency Slider
        {
            double value1 = e.NewValue;
            FrequencySlider.Rotation = value1; //value of slider, rotates the label by that degrees
            displayLabel1.Text = String.Format("{0}",value1);  //Displays the value of slider on the right hand side
        }

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
                byte[] data;
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