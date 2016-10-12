using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavSistemi.Data_Class
{
    public class Sonuc
    {
        public string Id { get; set; }//PROPERTY

        [JsonProperty("KullaniciId")]
        public string KullaniciId { get; set; }//PROPERTY

        [JsonProperty("SinavId")]
        public string SinavId { get; set; }//PROPERTY

        [JsonProperty("SoruId")]
        public string SoruId { get; set; }//PROPERTY

        [JsonProperty("Secenek")]
        public string Secenek { get; set; }//PROPERTY

    }//class
}//namespace
