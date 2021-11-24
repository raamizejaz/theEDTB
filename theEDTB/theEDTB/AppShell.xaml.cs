﻿using System;
using System.Collections.Generic;
using theEDTB.ViewModels;
using theEDTB.Views;
using Xamarin.Forms;

namespace theEDTB
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
