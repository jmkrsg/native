using PCLStorage;
using ReisekostenNative.Models;
using ReisekostenNative.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReisekostenNative.DAO
{
    public class BelegArtenDAO
    {
        private static BelegArtenDAO instance;
        private SQLiteAsyncConnection connection;

        private string path;

        public static BelegArtenDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BelegArtenDAO();
                }
                return instance;
            }
        }

        public BelegArtenDAO()
        {
            this.path = Path.Combine(ConfigurationService.Instance.Datadirectory, "belegDB.db3");
            createDatabase();
        }

        private string createDatabase()
        {
            try
            {


                connection = new SQLiteAsyncConnection(path);
                if (FileSystem.Current.LocalStorage.CheckExistsAsync(path).Result == ExistenceCheckResult.NotFound)
                {

                }

                connection.CreateTableAsync<BelegArt>();
                return "Database created";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }

        public Task<int> StoreBelegArt(BelegArt belegArt)
        {
            return connection.InsertOrReplaceAsync(belegArt);

        }

        public List<Task<int>> StoreBelegArten(IList<BelegArt> belegArten)
        {
            var belegArtenIDs = new List<Task<int>>();
            foreach (var belegArt in belegArten)
            {
                belegArtenIDs.Add(StoreBelegArt(belegArt));
            }
            return belegArtenIDs;
        }

        public Task<int> DeleteBelegArt(BelegArt belegArt)
        {
            return connection.DeleteAsync(belegArt);
        }

        public Task<BelegArt> GetBeleg(string name)
        {
            return connection.Table<BelegArt>().Where(belegArt => belegArt.Name == name).FirstAsync();
        }

        public Task<List<BelegArt>> GetBelegArten()
        {
            return connection.Table<BelegArt>().ToListAsync();
        }
    }
}
