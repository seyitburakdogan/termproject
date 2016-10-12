using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Data.Linq.Mapping;
using Newtonsoft.Json;

namespace SinavSistemi.Data_Class
{
    public class Soru
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "SoruNo")]
        public int SoruNo { get; set; }

        [JsonProperty(PropertyName = "SoruMetni")]
        public string SoruMetni { get; set; }

        [JsonProperty(PropertyName = "SecenekA")]
        public string SecenekA { get; set; }

        [JsonProperty(PropertyName = "SecenekB")]
        public string SecenekB { get; set; }

        [JsonProperty(PropertyName = "SecenekC")]
        public string SecenekC { get; set; }

        [JsonProperty(PropertyName = "SecenekD")]
        public string SecenekD { get; set; }

        [JsonProperty(PropertyName = "Cevap")]
        public string Cevap { get; set; }

        [JsonProperty(PropertyName = "SinavAdi")]
        public string SinavAdi { get; set; }

        [JsonProperty(PropertyName = "KonuAdi")]
        public string KonuAdi { get; set; }

        [JsonProperty(PropertyName = "DersAdi")]
        public string DersAdi { get; set; }

        [JsonProperty(PropertyName = "DersSinif")]
        public string DersSinif { get; set; }
    }
}
