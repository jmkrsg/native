using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace ReisekostenNative.Droid
{
	[Activity (Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/MyAppTheme")]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.login);


			Button login = FindViewById<Button> (Resource.Id.bt_login);
            EditText benutzer = FindViewById<EditText>(Resource.Id.et_benutzer);


            login.Click += delegate {
                string name = benutzer.Text.ToString();
                if (name != null && name.Length != 0)
                {
                    Intent intent = new Intent(this, typeof(BelegListe));
                    intent.PutExtra("USER", name);
                    StartActivity(intent);
                }
				
			};
		}
	}
}


