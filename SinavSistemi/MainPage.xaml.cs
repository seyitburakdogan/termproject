using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SinavSistemi.Resources;
using SinavSistemi.Data_Class;
using Microsoft.WindowsAzure.MobileServices;

namespace SinavSistemi
{
    public partial class MainPage : PhoneApplicationPage
    {
        public static MobileServiceClient MobileService = new MobileServiceClient(
       "https://burakproje2.azure-mobile.net/",
       //"RxJGREQyGGqrTHoaTIxhpcbikPDpbU33"
       "AhWoTjbCXmlMUkbLGBzxfuPnvieTXn87"
        );

        private MobileServiceCollection<Konu, Konu> konular;
        private IMobileServiceTable<Konu> konuTable = MobileService.GetTable<Konu>();

        private MobileServiceCollection<Kullanici, Kullanici> kullanicilar;
        private IMobileServiceTable<Kullanici> kullaniciTable = MobileService.GetTable<Kullanici>();

        private MobileServiceCollection<Ders, Ders> dersler;
        private IMobileServiceTable<Ders> dersTable = MobileService.GetTable<Ders>();

        public MainPage()
        {
            InitializeComponent();
            //txt_numara.Text = "12345";
            //txt_sifre.Password = "12345";
        }

        private async void btn_giris_Click(object sender, RoutedEventArgs e)
        {  
            kullanicilar = await kullaniciTable 
                .Where(u => u.KullaniciNo == txt_numara.Text)
                .Where(u => u.Sifre == txt_sifre.Password)
                   .ToCollectionAsync();
            if (kullanicilar.Count != 0)
            {
                if (kullanicilar[0].Rol == "Akademisyen")
                {
                    NavigationService.Navigate(new Uri("/SoruEkle.xaml", UriKind.Relative));
                }
                else
                {                   
                    NavigationService.Navigate(new Uri("/DersSec.xaml?numara=" + kullanicilar[0].KullaniciNo + "&ad=" + kullanicilar[0].KullaniciIsim + "&sinif=" + kullanicilar[0].Sinif + "", UriKind.Relative));
                    KullaniciInfo.KullaniciID = kullanicilar[0].Id;
                }             
            }
            else
            {
                MessageBox.Show("Eksik ya da hatalı bilgi!");
            }
            //btn_giris.IsEnabled = false;
        }

        private void g2_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MessageBox.Show("GridName : " + ((Grid)sender).Name);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            //VERİ EKLEME

            //TodoItem newItem = new TodoItem() { Text = "Burak dogan proje" };

            //await todoTable.InsertAsync(newItem);

            //VERİ ÇEKME

            // items = await todoTable
            //        //.Where(todoItem => todoItem.Complete == false)
            //        .ToCollectionAsync();

            //MessageBox.Show(items[0].Text);

            // VERİ GÜNCELLEME

            //items = await todoTable
            //    //.Where(todoItem => todoItem.Complete == false)
            //        .ToCollectionAsync();
            //items[0].Text = "BrkDGN";
            //await todoTable.UpdateAsync(items[0]);
            //items.Remove(items[0]);

            //VERİ SİLME

            //items = await todoTable
            //    //.Where(todoItem => todoItem.Complete == false)
            //       .ToCollectionAsync();

            ////await todoTable.DeleteAsync(items[0]);
            //await todoTable.DeleteAsync(items[0]);


            //List<Kullanici> liste = new List<Kullanici>();

            //liste.Add(new Kullanici() { KullaniciIsim = "Muammer Karaağaç", KullaniciNo = "4444", Rol = "Ogrenci", Sifre = "4444", Sinif = "4" });
            ////liste.Add(new Kullanici() { KullaniciIsim = "Murat Sercan", KullaniciNo = "111", Rol = "Ogrenci", Sifre = "111", Sinif = "1" });
            ////liste.Add(new Kullanici() { KullaniciIsim = "Oğuzhan Gedik", KullaniciNo = "222", Rol = "Ogrenci", Sifre = "222", Sinif = "2" });
            ////liste.Add(new Kullanici() { KullaniciIsim = "Gürkan Demirel", KullaniciNo = "333", Rol = "Ogrenci", Sifre = "333", Sinif = "3" });
            ////liste.Add(new Kullanici() { KullaniciIsim = "Mahmut Uzun", KullaniciNo = "444", Rol = "Ogrenci", Sifre = "444", Sinif = "4" });

            //for (int i = 0; i < liste.Count; i++)
            //{

            //    await kullaniciTable.InsertAsync(liste[i]);
            //    MessageBox.Show("Eklendi : " + i);
            //}

            //await todoTable.InsertAsync(newItem);

            //kullanicilar = await kullaniciTable
            //    //.Where(todoItem => todoItem.Complete == false)
            //       .ToCollectionAsync();

            //List<Ders> liste = new List<Ders>();
            //liste.Add(new Ders() { DersAdi = "Bilgisayar Mühendisliğine Giriş", DersSinif = "1" });
            //liste.Add(new Ders() { DersAdi = "Fizik", DersSinif = "1" });
            //liste.Add(new Ders() { DersAdi = "Programlama", DersSinif = "1" });
            //liste.Add(new Ders() { DersAdi = "İnkilap Tarihi ve Atatürkçülük", DersSinif = "1" });
            //liste.Add(new Ders() { DersAdi = "Kesikli Matematik", DersSinif = "2" });
            //liste.Add(new Ders() { DersAdi = "Diferansiyel Denklemler", DersSinif = "2" });
            //liste.Add(new Ders() { DersAdi = "Veri Yapıları ve Algoritma", DersSinif = "2" });
            //liste.Add(new Ders() { DersAdi = "Mantıksal Tasarım", DersSinif = "2" });
            //liste.Add(new Ders() { DersAdi = "İşaret ve Sistemler", DersSinif = "3" });
            //liste.Add(new Ders() { DersAdi = "İşletim Sistemleri", DersSinif = "3" });
            //liste.Add(new Ders() { DersAdi = "Otomata Teorisi", DersSinif = "3" });
            //liste.Add(new Ders() { DersAdi = "Yazılım Mühendisliği", DersSinif = "3" });
            //liste.Add(new Ders() { DersAdi = "Bilgisayar Ağları", DersSinif = "4" });
            //liste.Add(new Ders() { DersAdi = "Sayısal Filtreler", DersSinif = "4" });
            //liste.Add(new Ders() { DersAdi = "İş Hayatına Hazılrık", DersSinif = "4" });
            //liste.Add(new Ders() { DersAdi = "Veri Madenciliği", DersSinif = "4" });

            //for (int i = 0; i < liste.Count; i++)
            //{
            //    await dersTable.InsertAsync(liste[i]);
            //}

            //List<Konu> liste = new List<Konu>();
            //liste.Add(new Konu() { KonuAdi = "Bool Cebri", KonuDers = "Bilgisayar Mühendisliğine Giriş" });
            //liste.Add(new Konu() { KonuAdi = "Akış Şemaları", KonuDers = "Bilgisayar Mühendisliğine Giriş" });
            //liste.Add(new Konu() { KonuAdi = "Vektörler", KonuDers = "Fizik" });
            //liste.Add(new Konu() { KonuAdi = "İş Enerji", KonuDers = "Fizik" });
            //liste.Add(new Konu() { KonuAdi = "Dinamik", KonuDers = "Fizik" });
            //liste.Add(new Konu() { KonuAdi = "Değişkenler", KonuDers = "Programlama" });
            //liste.Add(new Konu() { KonuAdi = "Koşul Deyimleri", KonuDers = "Programlama" });
            //liste.Add(new Konu() { KonuAdi = "Döngüler", KonuDers = "Programlama" });
            //liste.Add(new Konu() { KonuAdi = "Pointerlar", KonuDers = "Programlama" });
            //liste.Add(new Konu() { KonuAdi = "Osmanlıda Gerileme Dönemi", KonuDers = "İnkilap Tarihi ve Atatürkçülük" });
            //liste.Add(new Konu() { KonuAdi = "Osmanlıda Yıkılış Dönemi", KonuDers = "İnkilap Tarihi ve Atatürkçülük" });
            //liste.Add(new Konu() { KonuAdi = "Ayrıksal Matematiksel Yapılar", KonuDers = "Kesikli Matematik" });
            //liste.Add(new Konu() { KonuAdi = "Bernoli Denklemleri", KonuDers = "Diferansiyel Denklemler" });
            //liste.Add(new Konu() { KonuAdi = "Riccati Denklemleri", KonuDers = "Diferansiyel Denklemler" });
            //liste.Add(new Konu() { KonuAdi = "Algoritma Bilgisi", KonuDers = "Veri Yapıları ve Algoritma" });
            //liste.Add(new Konu() { KonuAdi = "Mantık Kapıları", KonuDers = "Mantıksal Tasarım" });
            //liste.Add(new Konu() { KonuAdi = "Mantıksal İşaretler", KonuDers = "Mantıksal Tasarım" });
            //liste.Add(new Konu() { KonuAdi = "Sinyaller", KonuDers = "İşaret ve Sistemler" });
            //liste.Add(new Konu() { KonuAdi = "Kutupsal Gösterim", KonuDers = "İşaret ve Sistemler" });
            //liste.Add(new Konu() { KonuAdi = "Process Yapısı", KonuDers = "İşletim Sistemleri" });
            //liste.Add(new Konu() { KonuAdi = "Deadlock", KonuDers = "İşletim Sistemleri" });
            //liste.Add(new Konu() { KonuAdi = "Turing Makineleri", KonuDers = "Otomata Teorisi" });
            //liste.Add(new Konu() { KonuAdi = "Sonlu Durum Makineleri", KonuDers = "Otomata Teorisi" });
            //liste.Add(new Konu() { KonuAdi = "Yazılıma Giriş", KonuDers = "Yazılım Mühendisliği" });
            //liste.Add(new Konu() { KonuAdi = "Proje Yönetimi", KonuDers = "Yazılım Mühendisliği" });
            //liste.Add(new Konu() { KonuAdi = "Ağlara Giriş", KonuDers = "Bilgisayar Ağları" });
            //liste.Add(new Konu() { KonuAdi = "TCP,UDP,HTTP Kavramları", KonuDers = "Bilgisayar Ağları" });
            //liste.Add(new Konu() { KonuAdi = "FIR Filtre Tasarımı", KonuDers = "Sayısal Filtreler" });
            //liste.Add(new Konu() { KonuAdi = "IIR Filtre Tasarımı", KonuDers = "Sayısal Filtreler" });
            //liste.Add(new Konu() { KonuAdi = "Girişimcilik", KonuDers = "İş Hayatına Hazılrık" });
            //liste.Add(new Konu() { KonuAdi = "Mülakat Bilgisi", KonuDers = "İş Hayatına Hazılrık" });
            //liste.Add(new Konu() { KonuAdi = "CV Hazırlama", KonuDers = "İş Hayatına Hazılrık" });
            //liste.Add(new Konu() { KonuAdi = "Veri Kaynakları", KonuDers = "Veri Madenciliği" });
            //liste.Add(new Konu() { KonuAdi = "Veri Ambarları", KonuDers = "Veri Madenciliği" });

            
            //for (int i = 0; i < liste.Count; i++)
            //{
            //    await konuTable.InsertAsync(liste[i]);

            //}



            MessageBox.Show("");

        }


    }
}