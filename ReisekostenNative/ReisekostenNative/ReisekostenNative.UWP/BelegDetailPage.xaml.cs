using IO.Swagger.Model;
using ReisekostenNative.Services;
using ReisekostenNative.UWP.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Imaging;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ReisekostenNative.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BelegDetailPage : Page
    {
        public BelegDetailModel ViewModel { get; set; }

        private StorageFile Photo { get; set; }

        public BelegDetailPage()
        {
            this.InitializeComponent();
            this.Loaded += BelegDetailPage_Loaded;
        }

        private void BelegDetailPage_Loaded(object sender, RoutedEventArgs e)
        {
            UIService.Instance.GetBelegarten((o) => {
                ViewModel.TypeList = o.Result as List<string>;
                Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => { Bindings.Update(); });
            });
        }

        private void MockViewModel()
        {
            ViewModel.StatusList = new List<string>();
            ViewModel.StatusList.Add("ERFASST");
            ViewModel.StatusList.Add("EXPORTIERT");
            ViewModel.StatusList.Add("GEBUCHT");
            ViewModel.StatusList.Add("ABGELEHNT");
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            ViewModel = new BelegDetailModel();

            MockViewModel();

            if (e.Parameter != null)
            {
                ViewModel.SelectedBeleg = (Beleg)e.Parameter;
                ViewModel.Mode = ViewMode.Edit;
            }
            else
            {
                ViewModel.SelectedBeleg = new Beleg();
                ViewModel.Mode = ViewMode.Create;
            }


        }

        private void Abbrechen_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void Speichern_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private async void AddImage_ClickAsync(object sender, RoutedEventArgs e)
        {
            CameraCaptureUI captureUI = new CameraCaptureUI();
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            captureUI.PhotoSettings.CroppedSizeInPixels = new Size(200, 200);
            Photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);
            this.pictureButton.Visibility = Visibility.Visible;
            this.Frame.Navigate(typeof(PhotoPage), Photo);
        }

        private void AppBarToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (Photo != null)
            {
                this.Frame.Navigate(typeof(PhotoPage), Photo);
            }
        }
    }
}
