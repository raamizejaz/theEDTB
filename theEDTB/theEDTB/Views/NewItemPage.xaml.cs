using System;
using System.Collections.Generic;
using System.ComponentModel;
using theEDTB.Models;
using theEDTB.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace theEDTB.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}