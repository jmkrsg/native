using ReisekostenNative.Services;
using SQLite;
using System.Collections.Generic;
using System.IO;

namespace ReisekostenNative
{
    class BelegDB
    {
        private string path;

        public BelegDB()
        {
            this.path = Path.Combine(ConfigurationService.Instance.Datadirectory, "/belegDB.db");
        }

        private string createDatabase()
        {
            try
            {
                var connection = new SQLiteAsyncConnection(path);
                connection.CreateTableAsync<BelegDAO>();
                return "Database created";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }

        private string insertBeleg(BelegDAO beleg)
        {
            try
            {
                var db = new SQLiteAsyncConnection(path);
                db.InsertAsync(beleg);
                return "Single data file inserted";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }
    }
}
