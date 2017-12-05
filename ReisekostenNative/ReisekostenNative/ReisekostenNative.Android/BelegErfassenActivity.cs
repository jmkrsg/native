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
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using IO.Swagger.Model;


namespace ReisekostenNative.Droid
{
    [Activity(Label = "@string/app_name", Icon = "@drawable/icon", Theme = "@style/MyAppTheme")]
    public class BelegErfassenActivity : AppCompatActivity, DatePickerDialog.IOnDateSetListener
    {

        EditText etDate;
        Beleg beleg;

        public void OnDateSet(DatePicker view, int year, int month, int dayOfMonth)
        {
            DateTime date = new DateTime(year, month + 1, dayOfMonth);
            etDate.Text= date.ToString("dd.MM.yyyy");
            beleg.Date = date;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            beleg = new Beleg(0, "", DateTime.Now, "", 0, Beleg.StatusEnum.ERFASST, null, 0);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.beleg_erfassen);

            etDate = FindViewById<EditText>(Resource.Id.et_date);
            etDate.Click += delegate
            {
                DateTime date = beleg.Date.Value;
                new DatePickerDialog(this, this, date.Year, date.Month, date.Day).Show();
            };


            
            

        }
    }
}