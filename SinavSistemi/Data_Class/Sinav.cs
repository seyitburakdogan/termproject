using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavSistemi.Data_Class
{
    public class Sinav
    {
            public string Id { get; set; }

            [JsonProperty(PropertyName = "SinavAdi")]
            public string SinavAdi { get; set; }

            [JsonProperty(PropertyName = "SinavDers")]
            public string SinavDers { get; set; }

            [JsonProperty(PropertyName = "KonuAdi")]
            public string KonuAdi { get; set; }

        
    }
}
