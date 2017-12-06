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
using Android.Support.V7.Widget;
using IO.Swagger.Model;


namespace ReisekostenNative.Droid
{
    class BelegeAdapter : RecyclerView.Adapter
    {
        List<Beleg> belege;

        public BelegeAdapter(List<Beleg> belege)
        {
            this.belege = belege;
        }

        public override int ItemCount => belege.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ((BelegViewHolder)holder).bind(belege[position]);
            
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                    Inflate(Resource.Layout.beleg_eintrag, parent, false);
            BelegViewHolder vh = new BelegViewHolder(itemView);
            return vh;
        }
    }


    class BelegViewHolder : RecyclerView.ViewHolder
    {

        TextView art;
        TextView datum;
        TextView bezeichnung;

        public BelegViewHolder(View itemView) : base(itemView)
        {
            art = itemView.FindViewById<TextView>(Resource.Id.art);
            datum = itemView.FindViewById<TextView>(Resource.Id.datum);
            bezeichnung = itemView.FindViewById<TextView>(Resource.Id.bezeichnung);
        }

        public void bind(Beleg e)
        {
            DateTime date = e.Date.Value;
            art.Text = e.Type.ToString();
            if(date != null)
            {
                datum.Text = date.ToString("dd.MM.yyyy");
            }
            else { datum.Text = ""; }
            bezeichnung.Text = e.Description.ToString();

        }
    }
}