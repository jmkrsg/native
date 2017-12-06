using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReisekostenNative.Models
{
    public class BelegArt
    {
        [PrimaryKey]
        public string Name { get; set; }

        public BelegArt() { }

        public BelegArt(string Name)
        {
            this.Name = Name;
        }
    }
}
