using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.WindowsAzure.MobileServices;
using SinavSistemi.Data_Class;
using System.Windows.Media;

namespace SinavSistemi
{
    public partial class SinavSonuclari : PhoneApplicationPage
    {
        public static MobileServiceClient MobileService = new MobileServiceClient(
     "https://burakproje2.azure-mobile.net/",
            //"RxJGREQyGGqrTHoaTIxhpcbikPDpbU33"
     "AhWoTjbCXmlMUkbLGBzxfuPnvieTXn87"
      );
        private MobileServiceCollection<Sonuc, Sonuc> sonuclar;
        private IMobileServiceTable<Sonuc> sonucTable = MobileService.GetTable<Sonuc>();

        private MobileServiceCollection<Sinav, Sinav> sinavlar;
        private IMobileServiceTable<Sinav> sinavTable = MobileService.GetTable<Sinav>();

        private MobileServiceCollection<Kullanici, Kullanici> kullanicilar;
        private IMobileServiceTable<Kullanici> kullaniciTable = MobileService.GetTable<Kullanici>();

        private MobileServiceCollection<Soru, Soru> sorular;
        private IMobileServiceTable<Soru> soruTable = MobileService.GetTable<Soru>();
        public SinavSonuclari()
        {
            InitializeComponent();
        }//constructor

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            sonuclar = await sonucTable.ToCollectionAsync();
            kullanicilar = await kullaniciTable.ToCollectionAsync();

            //bu kısımda, sonuçlar tablosunda bulunan kullanıcılar filtrelenmiş ve alınmış oluyor
            for (int k = kullanicilar.Count - 1; k >= 0; k--)
            {
                for (int i = 0; i < sonuclar.Count; i++)
                {
                    if (kullanicilar[k].Id == sonuclar[i].KullaniciId)
                    {
                        break;
                    }//if
                    if (i == sonuclar.Count - 1)
                    {
                        kullanicilar.RemoveAt(k);
                    }
                }//for
            } //for

            sinavlar = await sinavTable.ToCollectionAsync();
            //bu kısımda sonuçlar tablosunda bulunan sınavlar filltrelenmiş oluyor
            for (int k = sinavlar.Count - 1; k >= 0; k--)
            {
                for (int i = 0; i < sonuclar.Count; i++)
                {
                    if (sinavlar[k].Id == sonuclar[i].SinavId)
                    {
                        break;
                    }//if
                    if (i == sonuclar.Count - 1)
                    {
                        sinavlar.RemoveAt(k);
                    }
                }//for
            } //for

            for (int k = 0; k < kullanicilar.Count; k++)
            {
                //MessageBox.Show("Öğrenci :" + kullanicilar[k].KullaniciIsim);

                TextBlock txt = new TextBlock();
                txt.Text = kullanicilar[k].KullaniciIsim;
                txt.Foreground = new SolidColorBrush(Colors.Black);
                spOgrenci.Children.Add(txt);


                List<string> sinavlarID = new List<string>();
                for (int s = 0; s < sonuclar.Count; s++)
                {
                    if (kullanicilar[k].Id == sonuclar[s].KullaniciId)
                    {
                        bool eklensinmi = true;
                        foreach (string item in sinavlarID)
                        {
                            if (item == sonuclar[s].SinavId)
                            {
                                eklensinmi = false;
                                break;
                            }//if
                        }//foreach

                        if (eklensinmi)
                            sinavlarID.Add(sonuclar[s].SinavId);
                    }//if
                }//for         

                sorular = await soruTable.ToCollectionAsync();

                foreach (var sinav in sinavlar)
                {
                    StackPanel spSinav = null;

                    foreach (string ID in sinavlarID)
                    {
                        if (sinav.Id == ID)
                        {
                            spSinav = new StackPanel();
                            spSinav.Background = new SolidColorBrush(Colors.Green);
                            spSinav.Orientation = System.Windows.Controls.Orientation.Horizontal;
                            spSinav.Margin = new Thickness(0, 0, 0, 15);                           
                            //  MessageBox.Show("Ders : " + sinav.SinavDers + " Konu : " + sinav.KonuAdi + "  Sınav : " + sinav.SinavAdi);

                            string[] strDogruYanlis = OgrenciSinavDogruYanlisSayisi(ID);

                            TextBlock tbDers = new TextBlock();
                            tbDers.Margin = new Thickness(0, 0, 25, 0);
                            if (sinav.SinavDers.Length > 7)
                                tbDers.Text = sinav.SinavDers.Substring(0, 8);// lk 8 karakteri aldım sığmıyor ekrana
                            else
                            tbDers.Text = sinav.SinavDers;                           
                            spSinav.Children.Add(tbDers);

                            TextBlock tbKonu = new TextBlock();
                            tbKonu.Margin = new Thickness(0, 0, 25, 0);
                            if (sinav.KonuAdi.Length > 7)
                                tbKonu.Text = sinav.KonuAdi.Substring(0, 8);// lk 8 karakteri aldım sığmıyor ekrana
                            else
                            tbKonu.Text = sinav.KonuAdi;
                            spSinav.Children.Add(tbKonu);

                            TextBlock tbSinavAdi = new TextBlock();
                            tbSinavAdi.Margin = new Thickness(0, 0, 25, 0);
                            if (sinav.SinavAdi.Length > 7)
                                tbSinavAdi.Text = sinav.SinavAdi.Substring(0, 8);// lk 8 karakteri aldım sığmıyor ekrana
                            else
                            tbSinavAdi.Text = sinav.SinavAdi;
                            spSinav.Children.Add(tbSinavAdi);

                            TextBlock tbDogru = new TextBlock();
                            tbDogru.Margin = new Thickness(0, 0, 25, 0);
                            tbDogru.Text = strDogruYanlis[0];
                            spSinav.Children.Add(tbDogru);

                            TextBlock tbYanlis = new TextBlock();
                            tbYanlis.Margin = new Thickness(0, 0, 25, 0);
                            tbYanlis.Text = strDogruYanlis[1];
                            spSinav.Children.Add(tbYanlis);
                        }//if
                    }//foreach
                    if (spSinav != null)
                        spOgrenci.Children.Add(spSinav);
                }//foreach

            }//for

            base.OnNavigatedTo(e);
        }//void

        private string[] OgrenciSinavDogruYanlisSayisi(string SinavID)
        {
            string[] strSonuclar = new string[2] { "0D", "0Y" };
            int DoğruSayisi = 0;
            int YanlisSayisi = 0;


            //bu kısımda sonuçlar tablosunda bulunan sınavlar filltrelenmiş oluyor
            for (int k = sorular.Count - 1; k >= 0; k--)
            {
                for (int i = 0; i < sonuclar.Count; i++)
                {
                    if (sorular[k].Id == sonuclar[i].SoruId && sonuclar[i].SinavId == SinavID)
                    {
                        if (sorular[k].Cevap.Trim().ToLower() == sonuclar[i].Secenek.Trim().ToLower())
                            ++DoğruSayisi;
                        else
                            ++YanlisSayisi;
                        break;
                    }//if
                }//for
            } //for
            strSonuclar[0] = DoğruSayisi + "D";
            strSonuclar[1] = YanlisSayisi + "Y";

            return strSonuclar;
        }//method

    }//class
}//namespace