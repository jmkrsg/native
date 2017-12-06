using ReisekostenNative.Services;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ReisekostenNative
{
    class BelegDB
    {
        private static BelegDB instance;
        private SQLiteAsyncConnection connection;

        private string path;

        public static BelegDB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BelegDB();
                }
                return instance;
            }
        }

        public BelegDB()
        {
            this.path = Path.Combine(ConfigurationService.Instance.Datadirectory, "/belegDB.db3");
            createDatabase();
        }

        private string createDatabase()
        {
            try
            {
                connection = new SQLiteAsyncConnection(path);
                connection.CreateTableAsync<BelegDAO>();
                return "Database created";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }

        public Task<int> StoreBeleg(BelegDAO beleg)
        {
            return connection.InsertOrReplaceAsync(beleg);
        }

        public Task<int> DeleteBeleg(BelegDAO beleg)
        {
            return connection.DeleteAsync(beleg);
        }

        public Task<BelegDAO> GetBeleg(int belegnummer)
        {
            return connection.Table<BelegDAO>().Where(beleg => beleg.Belegnummer == belegnummer).FirstAsync();
        }

        public Task<List<BelegDAO>> GetBelege()
        {
            return connection.Table<BelegDAO>().ToListAsync();
        }
    }
}
