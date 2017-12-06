using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReisekostenNative.Models
{
    public class IntWrapper
    {
        [JsonProperty("value")]
        public int? Value {get;set;}
    }
}
