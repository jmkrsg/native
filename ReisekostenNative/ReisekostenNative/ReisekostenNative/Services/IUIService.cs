using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IO.Swagger.Model;

namespace ReisekostenNative.Services
{
    public interface IUIService
    {
        void CreateBeleg(Beleg beleg, Action<Task<int>> callback);
        void Export(string user, Action<Task<List<Beleg>>> callback);
        void GetBelegarten(Action<Task<List<string>>> callback);
        void GetBelege(string user, Action<Task<List<Beleg>>> callback);
        void GetBelegStati(Action<Task<List<string>>> callback);
        void GetExported(string user, Action<Task<List<Beleg>>> callback);
        void UpdateBeleg(Beleg beleg);
    }
}