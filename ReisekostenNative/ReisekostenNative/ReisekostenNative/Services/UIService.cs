using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReisekostenNative.Services
{
    public class UIService : IUIService
    {
        private static UIService instance;

        private RESTClient.RESTClient client;

        public static UIService Instance
        {
            get
            {
                return instance ?? (instance = new UIService());
            }
        }

        private UIService()
        {
            client = new RESTClient.RESTClient();
        }

        public async void GetBelegarten(Action<Task<List<string>>> callback)
        {
           client.GetTypesAsync().ContinueWith((o) => callback(o));
        }

        public async void GetBelege(string user, Action<Task<List<Beleg>>> callback)
        {
            await Task.Factory.StartNew(() =>
            {
                List<Beleg> alleBelege = this.client.GetBelegeByUserAsync(user).Result;
                List<Beleg> belegeFromDB = BelegDAO.Instance.GetBelegeByUser(user).Result;

                foreach (var beleg in alleBelege)
                {
                    if (BelegDAO.Instance.GetBelegByBelegnummer(beleg.Belegnummer.Value) == null)
                    {
                        BelegDAO.Instance.StoreBeleg(beleg);
                    }
                }

                return alleBelege;
            }).ContinueWith((o) => callback(o));
        }

        public async void GetBelegeFromSvc(string user, Action<Task<List<Beleg>>> callback)
        {
            this.client.GetBelegeByUserAsync(user).ContinueWith((o) => callback(o));
        }

        public async void GetExported(string user, Action<Task<List<Beleg>>> callback)
        {
            BelegDAO.Instance.GetBelegeByUserAndStatus(user, Beleg.StatusEnum.EXPORTIERT).ContinueWith(o => callback(o));
        }

        public async void CreateBeleg(Beleg beleg, Action<Task<int>> callback)
        {
            if (beleg.Date == null)
            {
                beleg.Date = DateTime.UtcNow.Date;
            }

            beleg.Status = Beleg.StatusEnum.ERFASST;

            BelegDAO.Instance.StoreBeleg(beleg).ContinueWith((o) => callback(o));
        }

        public async void UpdateBeleg(Beleg beleg)
        {
            if (beleg.Status == Beleg.StatusEnum.ERFASST)
            {
                BelegDAO.Instance.StoreBeleg(beleg);
            }
        }

        public async void GetBelegStati(Action<Task<List<string>>> callback)
        {
            this.client.GetStatiAsync().ContinueWith((o) => callback(o));
        }

        public async void Export(string user, Action<Task<List<Beleg>>> callback)
        {
            await Task.Factory.StartNew(() =>
             {
                 List<Beleg> belege = BelegDAO.Instance.GetBelegeByUserAndStatus(user, Beleg.StatusEnum.ERFASST).Result.ToList();
                 foreach (var beleg in belege)
                 {
                     beleg.Status = Beleg.StatusEnum.EXPORTIERT;
                     beleg.Belegnummer = this.client.CreateBeleg(user, beleg).Result;

                     // TODO: um thumbnail-rückgabe erweitern
                     beleg.Thumbnail = this.client.UpdateImage(user, beleg.Belegnummer.Value, beleg.BelegImage).Result;
                     BelegDAO.Instance.StoreBeleg(beleg);
                 }

                 return belege;
             }).ContinueWith((o) => callback(o));

            ////List<Beleg> belege = BelegDAO.Instance.GetBelegeByUserAndStatus(user, Beleg.StatusEnum.ERFASST).Result.ToList();
            ////foreach (var beleg in belege)
            ////{
            ////    beleg.Status = Beleg.StatusEnum.EXPORTIERT;
            ////    beleg.Belegnummer = this.client.CreateBeleg(user, beleg).Result;

            ////    // TODO: um thumbnail-rückgabe erweitern
            ////    this.client.UpdateImage(user, beleg.Belegnummer.Value, beleg.BelegImage);
            ////    await BelegDAO.Instance.StoreBeleg(beleg);
            ////}

            ////return belege;
        }
    }
}
