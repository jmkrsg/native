using System;
using SQLite;

namespace ReisekostenNative
{
    class BelegDAO
    {
        [PrimaryKey, AutoIncrement]
        public int Belegnummer { get; set; }
        public string User { get; set; }
        public string Description { get; set; }
        public DateTime date { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public byte[] Thumbnail { get; set; }
        public int BelegSize { get; set; }
    }
}
