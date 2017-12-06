using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using IO.Swagger.Model;
using System.Threading.Tasks;
using ReisekostenNative.Services;

namespace ReisekostenNative.Droid
{
    [Activity(Label = "@string/app_name", Icon = "@drawable/icon", Theme = "@style/MyAppTheme")]
    public class BelegListe : AppCompatActivity
    {
        RecyclerView belegeView;
        string user;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.beleg_liste);
            user=Intent.Extras.GetString("USER");

            belegeView = FindViewById<RecyclerView>(Resource.Id.rv_belege);
            belegeView.AddItemDecoration(new DividerItemDecoration(this, 0));
            belegeView.SetLayoutManager(new LinearLayoutManager(this));

            View addButton = FindViewById(Resource.Id.fab_add);
            addButton.Click += delegate {
                Intent intent = new Intent(this, typeof(BelegErfassenActivity));
                intent.PutExtra("USER", user);
                StartActivity(intent);
            };

            UIService.Instance.GetBelege(user, (o) => this.Finished(o));
        }

        private void Finished (object o)
        {
            Task<List<Beleg>> task = o as Task<List<Beleg>>;
            if(task != null)
            {
                RunOnUiThread(() =>
                {
                    List<Beleg> belege = task.Result;
                    if(belege != null)
                    {
                        BelegeAdapter adapter = new BelegeAdapter(belege);
                        belegeView.SetAdapter(adapter);
                    }
                });

            }
        }
    }
}