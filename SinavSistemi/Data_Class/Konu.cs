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
    public class Konu
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "KonuAdi")]
        public string KonuAdi { get; set; }

        [JsonProperty(PropertyName = "KonuDers")]
        public string KonuDers { get; set; }

    }
}
