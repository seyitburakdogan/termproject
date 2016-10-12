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
//Dikkat
using System.Data.Linq;

namespace SinavSistemi.Data_Class
{
    public class TumVeri_DataContext : DataContext
    {
        public const string ConnectionString = "isostore:/DataBase.sdf";
        public Table<Kullanici> Kullanicilar { get; set; }
        public Table<Ders> Dersler { get; set; }
        public Table<Konu> Konular { get; set; }
        public Table<Soru> Sorular { get; set; }
        public Table<Sinav> Sinavlar { get; set; }

        public TumVeri_DataContext(string connectionString) : base(connectionString)
        {
            //this.Kullanicilar = this.GetTable<Kullanici>();
            //this.Dersler = this.GetTable<Ders>();
            //this.Konular = this.GetTable<Konu>();
            //this.Sorular = this.GetTable<Soru>();
            //this.Sinavlar = this.GetTable<Sinav>();
        }
    }
}