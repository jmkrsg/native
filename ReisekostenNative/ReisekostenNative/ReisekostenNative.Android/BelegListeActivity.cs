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
    [Activity(Label = "@string/app_name", Icon = "@drawable/icon", Theme = "@style/Theme.AppCompat.Light.DarkActionBar")]
    public class BelegListe : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.beleg_liste);

            List<Beleg> belegeList = new List<Beleg>();
            belegeList.Add(new Beleg(1,"Beschreibung", new DateTime(), "Typ", 0, Beleg.StatusEnum.ABGELEHNT, null, 0));
            belegeList.Add(new Beleg(1, "Beschreibung2", new DateTime(), "Typ2", 0, Beleg.StatusEnum.ABGELEHNT, null, 0));





            BelegeAdapter adapter = new BelegeAdapter(belegeList);

            RecyclerView belegeView = FindViewById<RecyclerView>(Resource.Id.rv_belege);
            belegeView.AddItemDecoration(new DividerItemDecoration(this, 0));
            belegeView.SetLayoutManager(new LinearLayoutManager(this));

            belegeView.SetAdapter(adapter);
            

        }
    }
}