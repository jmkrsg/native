using IO.Swagger.Model;
using PCLStorage;
using ReisekostenNative.Services;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ReisekostenNative
{
    public class BelegDAO
    {
        private static BelegDAO instance;
        private SQLiteAsyncConnection connection;

        private string path;

        public static BelegDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BelegDAO();
                }
                return instance;
            }
        }

        public BelegDAO()
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

                connection.CreateTableAsync<Beleg>();
                return "Database created";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }

        public Task<int> StoreBeleg(Beleg beleg)
        {
            return connection.InsertOrReplaceAsync(beleg);

        }

        public Task<int> DeleteBeleg(Beleg beleg)
        {
            return connection.DeleteAsync(beleg);
        }

        public Task<Beleg> GetBeleg(int belegID)
        {
            return connection.Table<Beleg>().Where(beleg => beleg.BelegID == belegID).FirstAsync();
        }

        public Task<List<Beleg>> GetBelege()
        {
            return connection.Table<Beleg>().ToListAsync();
        }

        public Task<List<Beleg>> GetBelegeByStatus(Beleg.StatusEnum belegStatus)
        {
            return connection.Table<Beleg>().Where(beleg => beleg.Status.Equals(belegStatus)).ToListAsync();
        }

        public List<Task<int>> StoreBelege(IList<Beleg> belege)
        {
            var belegIDs = new List<Task<int>>();
            foreach (Beleg beleg in belege)
            {
                belegIDs.Add(StoreBeleg(beleg));
            }
            return belegIDs;
        }
    }
}
