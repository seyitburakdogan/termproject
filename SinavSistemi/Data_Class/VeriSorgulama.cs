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
using System.Collections.Generic;
using System.Linq;

namespace SinavSistemi.Data_Class
{
    public class VeriSorgulama
    {
        public static void Baslat()
        {
            //TumVeri_DataContext ctx = new TumVeri_DataContext(TumVeri_DataContext.ConnectionString);
            //if (ctx.DatabaseExists() == false)
            //{
            //    ctx.CreateDatabase();

            //    //Yaptığın değişiklikleri veri kaynağına yansıtırsın.
            //    ctx.SubmitChanges();

            //    //Burada diğer başlangıç satırlarını kodlayabilirsin. Örneğin statik bazı verileri, veritabanındaki bir tabloya ekleyebilirsin.
            //    IlkVeriEkle();
            //}
        }

        private static void IlkVeriEkle()
        {
            //List<Ders> dersler = new List<Ders>();
            //dersler.Add(new Ders { DersID = 1, DersAdi = "TARİH", DersSinif = "2" });
            //dersler.Add(new Ders { DersID = 2, DersAdi = "COĞRAFYA", DersSinif = "2" });
            //dersler.Add(new Ders { DersID = 3, DersAdi = "İNGİLİZCE", DersSinif = "3" });
            //dersler.Add(new Ders { DersID = 4, DersAdi = "TÜRKÇE", DersSinif = "1" });
            //dersler.Add(new Ders { DersID = 5, DersAdi = "DİN KÜLTÜRÜ", DersSinif = "1" });
            //dersler.Add(new Ders { DersID = 6, DersAdi = "PSİKOLOJİ", DersSinif = "1" });
            //dersler.Add(new Ders { DersID = 7, DersAdi = "BİYOLOJİ", DersSinif = "4" });

            //List<Konu> konular = new List<Konu>();
            //konular.Add(new Konu { KonuAdi = "Osmanlı Tarihi", KonuDers = "TARİH" });
            //konular.Add(new Konu { KonuAdi = "Selçuklu Tarihi", KonuDers = "TARİH" });
            //konular.Add(new Konu { KonuAdi = "Türkiye Tarihi", KonuDers = "TARİH" });
            //konular.Add(new Konu { KonuAdi = "İç Anadolu", KonuDers = "COĞRAFYA" });
            //konular.Add(new Konu { KonuAdi = "Doğu Anadolu", KonuDers = "COĞRAFYA" });
            //konular.Add(new Konu { KonuAdi = "Marmara", KonuDers = "COĞRAFYA" });
            //konular.Add(new Konu { KonuAdi = "Simple Past", KonuDers = "İNGİLİZCE" });
            //konular.Add(new Konu { KonuAdi = "Present Perfect", KonuDers = "İNGİLİZCE" });
            //konular.Add(new Konu { KonuAdi = "Past Continous", KonuDers = "İNGİLİZCE" });
            //konular.Add(new Konu { KonuAdi = "Freud Dönemi", KonuDers = "PSİKOLOJİ" });
            //konular.Add(new Konu { KonuAdi = "Hegel Dönemi", KonuDers = "PSİKOLOJİ" });
            //konular.Add(new Konu { KonuAdi = "Sokrates Dönemi", KonuDers = "PSİKOLOJİ" });
            //konular.Add(new Konu { KonuAdi = "Sözcükte Anlam", KonuDers = "TÜRKÇE" });
            //konular.Add(new Konu { KonuAdi = "Cümlede Anlam", KonuDers = "TÜRKÇE" });
            //konular.Add(new Konu { KonuAdi = "Fiilimsiler", KonuDers = "TÜRKÇE" });
            //konular.Add(new Konu { KonuAdi = "İslamda Namaz", KonuDers = "DİN KÜLTÜRÜ" });
            //konular.Add(new Konu { KonuAdi = "İslamda Oruç", KonuDers = "DİN KÜLTÜRÜ" });
            //konular.Add(new Konu { KonuAdi = "İslamda Hac", KonuDers = "DİN KÜLTÜRÜ" });
            //konular.Add(new Konu { KonuAdi = "Hayvanlar Alemi", KonuDers = "BİYOLOJİ" });
            //konular.Add(new Konu { KonuAdi = "Bitkiler Alemi", KonuDers = "BİYOLOJİ" });
            //konular.Add(new Konu { KonuAdi = "Mikroorganizmalar", KonuDers = "BİYOLOJİ" });

            //List<Sinav> sinavlar = new List<Sinav>();
            //sinavlar.Add(new Sinav { SinavID = 1, SinavAdi = "Sınav 1", KonuAdi = "Sözcükte Anlam" });
            //sinavlar.Add(new Sinav { SinavID = 2, SinavAdi = "Sınav 2", KonuAdi = "Sözcükte Anlam" });
            //sinavlar.Add(new Sinav { SinavID = 3, SinavAdi = "Sınav 3", KonuAdi = "Sözcükte Anlam" });
            //sinavlar.Add(new Sinav { SinavID = 4, SinavAdi = "Sınav 1", KonuAdi = "Cümlede Anlam" });
            //sinavlar.Add(new Sinav { SinavID = 5, SinavAdi = "Sınav 2", KonuAdi = "Cümlede Anlam" });
            //sinavlar.Add(new Sinav { SinavID = 6, SinavAdi = "Sınav 3", KonuAdi = "Cümlede Anlam" });

            //DersEkle(dersler);
            //KonuEkle(konular);
            //SinavEkle(sinavlar);
            KullaniciEkle();
        }

        private static void KullaniciEkle()
        {
            //TumVeri_DataContext ctx = new TumVeri_DataContext(TumVeri_DataContext.ConnectionString);
            //ctx.Kullanicilar.InsertOnSubmit(new Kullanici { KullaniciIsim = "Personel", KullaniciID = 11, KullaniciNo = "12345", Sifre = "12345", Sinif = "YOK" });
            //ctx.Kullanicilar.InsertOnSubmit(new Kullanici { KullaniciIsim = "Demba Ba", KullaniciID = 12, KullaniciNo = "150", Sifre = "12345", Sinif = "1" });
            //ctx.Kullanicilar.InsertOnSubmit(new Kullanici { KullaniciIsim = "Veli Kavlak", KullaniciID = 13, KullaniciNo = "250", Sifre = "12345", Sinif = "2" });
            //ctx.Kullanicilar.InsertOnSubmit(new Kullanici { KullaniciIsim = "Cenk Tosun", KullaniciID = 14, KullaniciNo = "350", Sifre = "12345", Sinif = "3" });
            //ctx.Kullanicilar.InsertOnSubmit(new Kullanici { KullaniciIsim = "Ersan Gülüm", KullaniciID = 15, KullaniciNo = "450", Sifre = "12345", Sinif = "4" });
            //ctx.SubmitChanges();
        }
        public static void DersEkle(List<Ders> list_ders)
        {
            TumVeri_DataContext ctx = new TumVeri_DataContext(TumVeri_DataContext.ConnectionString);

            ctx.Dersler.InsertAllOnSubmit(list_ders);

            ctx.SubmitChanges();
        }

        public static void KonuEkle(List<Konu> list_konu)
        {
            TumVeri_DataContext ctx = new TumVeri_DataContext(TumVeri_DataContext.ConnectionString);

            ctx.Konular.InsertAllOnSubmit(list_konu);

            ctx.SubmitChanges();
        }

        public static void SinavEkle(Sinav EklenecekSinav)
        {
            TumVeri_DataContext ctx = new TumVeri_DataContext(TumVeri_DataContext.ConnectionString);

            ctx.Sinavlar.InsertOnSubmit(EklenecekSinav);

            ctx.SubmitChanges();
        }

        public static void SoruEkle(List<Soru> list_soru)
        {
            TumVeri_DataContext ctx = new TumVeri_DataContext(TumVeri_DataContext.ConnectionString);

            ctx.Sorular.InsertAllOnSubmit(list_soru);

            ctx.SubmitChanges();
        }

        public static Kullanici VarMi(string numara, string sifre)
        {
            Kullanici kul = new Kullanici();

            TumVeri_DataContext ctx = new TumVeri_DataContext(TumVeri_DataContext.ConnectionString);

            try
            {
                kul = (from u in ctx.Kullanicilar
                       where u.KullaniciNo == numara && u.Sifre == sifre
                       select u).First();

            }
            catch
            {

            }

            return kul;
        }
        //public static List<Ders> DersGetir(string derssinif)
        //{
        //    TumVeri_DataContext ctx = new TumVeri_DataContext(TumVeri_DataContext.ConnectionString);
        //    List<Ders> dersliste = (from u in ctx.Dersler orderby u.DersSinif ascending where u.DersSinif == derssinif select u).ToList();
        //    return dersliste;
        //}

        //public static List<Konu> KonuGetir(string dersadi)
        //{
        //    TumVeri_DataContext ctx = new TumVeri_DataContext(TumVeri_DataContext.ConnectionString);
        //    List<Konu> konuliste = (from u in ctx.Konular where u.KonuDers == dersadi select u).ToList();
        //    return konuliste;
        //}

        //public static List<Sinav> SinavGetir(string konuadi)
        //{
        //    TumVeri_DataContext ctx = new TumVeri_DataContext(TumVeri_DataContext.ConnectionString);
        //    List<Sinav> sinavliste = (from u in ctx.Sinavlar where u.KonuAdi == konuadi select u).ToList();
        //    return sinavliste;
        //}

        //public static List<Soru> SoruGetir(int soruno)
        //{
        //    TumVeri_DataContext ctx = new TumVeri_DataContext(TumVeri_DataContext.ConnectionString);
        //    List<Soru> soruliste = (from u in ctx.Sorular where u.SoruNo == soruno select u).ToList();
        //    return soruliste;
        //}

    }
}