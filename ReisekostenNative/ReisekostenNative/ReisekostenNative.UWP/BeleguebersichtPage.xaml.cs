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

    public class Beleg
    {
        public string Id { get; set; }
        public DateTime Belegdatum { get; set; }
        public string Belegart { get; set; }

        public Decimal Betrag { get; set; }
        public string Bezeichnung { get; set; }
        public string Status { get; set; }
    }

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BeleguebersichtPage : Page
    {
        public BeleguebersichtPage()
        {
            this.InitializeComponent();
            BelegListe = new List<Beleg>();
            Beleg b = new Beleg();
            b.Belegart = "test";
            BelegListe.Add(b);
        }

        public List<Beleg> BelegListe { get; set; }
    }
}
