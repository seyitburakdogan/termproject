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

//KULLANICILAR TABLOSUNUN OLUŞTURULDUĞU SINIF
namespace SinavSistemi.Data_Class
{
    public class Kullanici
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "KullaniciIsim")]
        public string KullaniciIsim { get; set; }

        [JsonProperty(PropertyName = "KullaniciNo")]
        public string KullaniciNo { get; set; }

        [JsonProperty(PropertyName = "Sifre")]
        public string Sifre { get; set; }

        [JsonProperty(PropertyName = "Sinif")]
        public string Sinif { get; set; }

        [JsonProperty(PropertyName = "Rol")]
        public string Rol { get; set; }

    }
}