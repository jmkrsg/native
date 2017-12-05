using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ReisekostenNative.Droid
{
    [Activity(Label = "@string/app_name", Icon = "@drawable/icon")]
    public class BelegListe : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.beleg_liste);

            // Create your application here
        }
    }
}