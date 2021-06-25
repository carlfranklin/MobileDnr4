using DotNetRocks.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DotNetRocks
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
        }
    }
}