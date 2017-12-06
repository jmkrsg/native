﻿using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReisekostenNative.Services
{
    public class UIService
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
            client.GetBelegeByUserAsync(user).ContinueWith((o) => callback(o));
        }

        public async void GetExported(string user, Action<Task<List<Beleg>>> callback)
        {
            this.client.GetBelegeByUserAsync(user).ContinueWith(o => callback(o));
        }

        public async void CreateBeleg(string user, Beleg beleg, Action<Task<int>> callback)
        {
            beleg.Date = DateTime.UtcNow.Date;
            beleg.Status = Beleg.StatusEnum.ERFASST;

            client.CreateBeleg(user, beleg).ContinueWith((o) => callback(o));
        }

        public async void UpdateBeleg(string user, int belegnummer, Beleg beleg)
        {
            this.client.UpdateBeleg(user, belegnummer, beleg);
        }

        public async void GetBelegStati(Action<Task<List<string>>> callback)
        {
            this.client.GetStatiAsync().ContinueWith((o) => callback(o));
        }
    }
}
