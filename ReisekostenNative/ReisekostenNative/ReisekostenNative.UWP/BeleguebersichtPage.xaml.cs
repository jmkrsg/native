using ReisekostenNative.UWP.Help;
using ReisekostenNative.UWP.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ReisekostenNative.UWP
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BeleguebersichtPage : Page
    {
        public BelegOverviewModel ViewModel { get; set; }

        public BeleguebersichtPage()
        {
            this.InitializeComponent();
            ViewModel = new BelegOverviewModel();
            ViewModel.BelegListe = new BelegGenerator().GenerateData(20);
        }

        public string Username { get; set; }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // navigate to detailPage and edit given item
            this.Frame.Navigate(typeof(BelegDetailPage), e.ClickedItem);
        }

        private void AppBarToggleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BelegDetailPage), null);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
            {
                Username = e.Parameter as string;
            }
        }
    }
}
