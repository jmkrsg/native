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
using ReisekostenNative.Services;
using IO.Swagger.Model;
using System.Threading.Tasks;
using System.ComponentModel;
using ReisekostenNative.UWP.ViewParams;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ReisekostenNative.UWP
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BeleguebersichtPage : Page
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaiseProperty(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public BelegOverviewModel ViewModel { get; set; }

        //public List<Beleg> BelegeListe { get; set; }

        public BeleguebersichtPage()
        {
            this.InitializeComponent();
            ViewModel = new BelegOverviewModel();
            this.Loaded += MainPage_Loaded;
        }

        public string Username { get; set; }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            DetailViewParams viewParams = new DetailViewParams();
            viewParams.Username = this.Username;
            viewParams.Beleg = e.ClickedItem as Beleg;
            viewParams.Mode = ViewMode.Edit;

            // navigate to detailPage and edit given item
            this.Frame.Navigate(typeof(BelegDetailPage), viewParams);
        }

        private void AppBarToggleButton_Click_Add(object sender, RoutedEventArgs e)
        {
            DetailViewParams viewParams = new DetailViewParams();
            viewParams.Username = this.Username;
            viewParams.Mode = ViewMode.Create;
            this.Frame.Navigate(typeof(BelegDetailPage), viewParams);
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //LoadBelege();
        }

        private void LoadBelege()
        {
            UIService.Instance.GetBelege(Username, this.GetBelegeCallback);
        }

        private void GetBelegeCallback(Task<List<Beleg>> belege)
        {
            this.ViewModel.BelegListe = belege.Result;
            //this.BelegeListe = belege.Result;
            //RaiseProperty("BelegListe");
            //RaiseProperty("ViewModel");
            //RaiseProperty("ViewModel.BelegListe");
            Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => {
                this.Bindings.Update();
            });
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
            {
                Username = e.Parameter as string;
            }
        }

        private void AppBarToggleButton_Click_Refresh(object sender, RoutedEventArgs e)
        {
            LoadBelege();
        }

        private void AppBarToggleButton_Click_Export(object sender, RoutedEventArgs e)
        {
            //TODO: Daten exportieren ...
        }
    }
}
