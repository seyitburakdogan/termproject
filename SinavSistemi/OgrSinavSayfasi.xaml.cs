using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using Microsoft.WindowsAzure.MobileServices;
using SinavSistemi.Data_Class;

namespace SinavSistemi
{
    public partial class OgrSinavSayfasi : PhoneApplicationPage
    {
        public static MobileServiceClient MobileService = new MobileServiceClient(
      "https://burakproje2.azure-mobile.net/",
            //"RxJGREQyGGqrTHoaTIxhpcbikPDpbU33"
      "AhWoTjbCXmlMUkbLGBzxfuPnvieTXn87"
       );

        private MobileServiceCollection<Soru, Soru> sorular;
        private IMobileServiceTable<Soru> soruTable = MobileService.GetTable<Soru>();

        private MobileServiceCollection<Sonuc, Sonuc> sonuclar;
        private IMobileServiceTable<Sonuc> sonucTable = MobileService.GetTable<Sonuc>();

        int soruNo = 1;
        int ToplamSoruSayisi = 0;
        int dogruSayisi = 0;
        int yanlisSayisi = 0;
        string sinavAdi = "";
        string konuAdi = "";
        string tiklanan = "";
        List<string> liste = new List<string>();
        public OgrSinavSayfasi()
        {
            InitializeComponent();
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            string GelenNumara = "";
            string GelenIsim = "";
            string GelenSinif = "";
            string GelenSinav = "";
            string GelenKonu = "";
            if (NavigationContext.QueryString.TryGetValue("numara", out GelenNumara)
             && NavigationContext.QueryString.TryGetValue("ad", out GelenIsim)
             && NavigationContext.QueryString.TryGetValue("sinif", out GelenSinif)
                && NavigationContext.QueryString.TryGetValue("sinav", out GelenSinav)
                && NavigationContext.QueryString.TryGetValue("konu", out GelenKonu)
                )
            {
                txtIsim.Text = GelenIsim;
                txtSinif.Text = GelenSinif;
                txtNumara.Text = GelenNumara;
                sinavAdi = GelenSinav;
                konuAdi = GelenKonu;
            }

            ToplamSoruSayisi = (await soruTable.Where((u => u.SinavAdi == sinavAdi)).Where(u => u.KonuAdi == konuAdi).ToCollectionAsync()).Count;
            txtToplamSoru.Text = "TOPLAM SORU SAYISI: " + ToplamSoruSayisi.ToString();
        }


        private async void ContentPanel_Loaded(object sender, RoutedEventArgs e)
        {
           
           
            //_listSoruListesi.ItemsSource = Data_Class.VeriSorgulama.SoruGetir(soruNo);
            sorular = await soruTable
               .Where(u => u.SinavAdi == sinavAdi)
               //.Where(u => u.SoruNo == soruNo)
               .Where(u => u.KonuAdi == konuAdi)
                  .ToCollectionAsync();
            _listSoruListesi.ItemsSource = sorular;
          
        }

        private void grid_12_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            tiklanan = ((RadioButton)sender).Content.ToString();
            liste.Add(tiklanan);
        }

        private async void btn_bitir_Click(object sender, RoutedEventArgs e)
        {
            btn_bitir.IsEnabled = false;
            sorular = await soruTable
               .Where(u => u.SinavAdi == sinavAdi)
               .Where(u => u.KonuAdi == konuAdi)
                  .ToCollectionAsync();

            try
            {
                for (int i = 0; i < sorular.Count; i++)
                {
                    if (sorular[i].Cevap == liste[i])
                    {
                        dogruSayisi++;
                    }
                    else
                    {
                        yanlisSayisi++;
                    }
                    await sonucTable.InsertAsync(new Sonuc { KullaniciId = KullaniciInfo.KullaniciID , 
                                                             SoruId = sorular[i].Id , 
                                                             SinavId = KullaniciInfo.SinavID , 
                                                             Secenek = liste[i] 
                                                           }
                                                 );
                }//for
                MessageBox.Show("Doğru sayısı:" + dogruSayisi + "\n" + "Yanlis sayisi:" + yanlisSayisi);
                btn_bitir.IsEnabled = false;
            }
            catch
            {
                MessageBox.Show("Lütfen tüm soruları cevaplandırınız.");
            }
           

                
            
            
            

        }

        //private async void btn_Sonraki_Click(object sender, RoutedEventArgs e)
        //{
        //    if (btn_Sonraki.Content.ToString() == "Sonraki Soru")
        //    {
        //        soruNo++;
        //        sorular = await soruTable
        //           .Where(u => u.SinavAdi == sinavAdi)
        //           .Where(u => u.SoruNo == soruNo)
        //           .Where(u => u.KonuAdi == konuAdi)
        //              .ToCollectionAsync();
        //        _listSoruListesi.ItemsSource = sorular;



        //        if (soruNo >= ToplamSoruSayisi)
        //        {
        //            btn_Sonraki.Content = "Bitir";
        //        }
        //        if (soruNo == 1)
        //        {
        //            btn_Onceki.IsEnabled = false;
        //        }
        //        else
        //        {
        //            btn_Onceki.IsEnabled = true;
        //        }

                

        //    }

        //    else
        //    {
        //        //bitirme işlemleri 
        //        sorular = await soruTable
        //           .Where(u => u.SinavAdi == sinavAdi)
        //           .Where(u => u.KonuAdi == konuAdi)
        //              .ToCollectionAsync();
        //        for (int i = 0; i < sorular.Count; i++)
        //        {
        //            if (sorular[i].Cevap==tiklanan)
        //            {
        //                dogruSayisi++;
        //            }
        //            else
        //            {
        //                yanlisSayisi++;
        //            }
        //        }
        //        MessageBox.Show("Doğru sayısı:" + dogruSayisi + "\n" + "Yanlis sayisi:" + yanlisSayisi);
        //    }


        //}

        //private async void btn_Onceki_Click(object sender, RoutedEventArgs e)
        //{
        //    soruNo--;
        //    sorular = await soruTable
        //       .Where(u => u.SinavAdi == sinavAdi)
        //       .Where(u => u.SoruNo == soruNo)
        //       .Where(u => u.KonuAdi == konuAdi)
        //          .ToCollectionAsync();
        //    _listSoruListesi.ItemsSource = sorular;
        //    if (soruNo < ToplamSoruSayisi)
        //    {
        //        btn_Sonraki.Content = "Sonraki Soru";
        //    }
        //    if (soruNo == 1)
        //    {
        //        btn_Onceki.IsEnabled = false;
        //    }
        //    else
        //    {
        //        btn_Onceki.IsEnabled = true;
        //    }
        //}
    }
}