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
using Android.Support.V7.Widget.Helper;
using Android.Widget;

namespace ReisekostenNative.Droid
{
    [Activity(Label = "@string/app_name", Icon = "@drawable/icon", Theme = "@style/MyAppTheme")]
    public class BelegListe : AppCompatActivity, Android.Support.V4.Widget.SwipeRefreshLayout.IOnRefreshListener/*, ItemTouchHelper.SimpleCallback*/
    {
        RecyclerView belegeView;
        string user;
        Android.Support.V4.Widget.SwipeRefreshLayout srl;

        public void OnRefresh()
        {
            UIService.Instance.GetBelege(user, (o) => this.Finished(o));
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.beleg_liste);
            user=Intent.Extras.GetString("USER");

            belegeView = FindViewById<RecyclerView>(Resource.Id.rv_belege);
            belegeView.AddItemDecoration(new DividerItemDecoration(this, 0));
            belegeView.SetLayoutManager(new LinearLayoutManager(this));
            srl = FindViewById<Android.Support.V4.Widget.SwipeRefreshLayout>(Resource.Id.swipe_refresh);

            srl.SetOnRefreshListener(this);

            View addButton = FindViewById(Resource.Id.fab_add);
            addButton.Click += delegate {
                Intent intent = new Intent(this, typeof(BelegErfassenActivity));
                intent.PutExtra("USER", user);
                StartActivity(intent);
            };

            srl.Refreshing = true;
            UIService.Instance.GetBelege(user, (o) => this.Finished(o));
        }


        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.liste_menu, menu);

            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.action_upload)
            {
                UIService.Instance.Export(user, (o) => Finished(o));

                return true;
            }

            return false;
        }



        public void belegClicked(Beleg beleg)
        {
            if(beleg != null)
            {
                Intent intent = new Intent(this, typeof(BelegErfassenActivity));
                intent.PutExtra("USER", user);
                intent.PutExtra("BELEG", beleg.BelegID.ToString());
                StartActivity(intent);
            }
        }

        private void Finished (object o)
        {
            Task<List<Beleg>> task = o as Task<List<Beleg>>;
            if(task != null)
            {
                RunOnUiThread(() =>
                {
                    srl.Refreshing = false;
                    List<Beleg> belege = task.Result;
                    if(belege != null)
                    {
                        BelegeAdapter adapter = new BelegeAdapter(belege, this);
                        belegeView.SetAdapter(adapter);
                    }
                });

            }
        }
    }
}