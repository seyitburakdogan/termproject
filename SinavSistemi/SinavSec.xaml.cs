using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SinavSistemi.Data_Class;
using Microsoft.WindowsAzure.MobileServices;
using System.Windows.Media;

namespace SinavSistemi
{
    public partial class SinavSec : PhoneApplicationPage
    {
        public static MobileServiceClient MobileService = new MobileServiceClient(
      "https://burakproje2.azure-mobile.net/",
            //"RxJGREQyGGqrTHoaTIxhpcbikPDpbU33"
      "AhWoTjbCXmlMUkbLGBzxfuPnvieTXn87"
       );

        //private MobileServiceCollection<Soru, Soru> sorular;
        //private IMobileServiceTable<Soru> soruTable = MobileService.GetTable<Soru>();

        private MobileServiceCollection<Sinav, Sinav> sinavlar;
        private IMobileServiceTable<Sinav> sinavTable = MobileService.GetTable<Sinav>();

        private MobileServiceCollection<Sonuc, Sonuc> sonuclar;
        private IMobileServiceTable<Sonuc> sonucTable = MobileService.GetTable<Sonuc>();

        string konuAdi = "";
        public SinavSec()
        {
            InitializeComponent();

            
        }

         async protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //await sonucTable.InsertAsync(new Sonuc { KullaniciId = "eef", SinavId = "efwe", Secenek = "A" , SoruId = "5" });
            //MessageBox.Show("OKKKKKKKKKKKKK");
            string GelenNumara = "";
            string GelenIsim = "";
            string GelenSinif = "";
            string GelenKonu = "";
            if (NavigationContext.QueryString.TryGetValue("numara", out GelenNumara)
             && NavigationContext.QueryString.TryGetValue("ad", out GelenIsim)
             && NavigationContext.QueryString.TryGetValue("sinif", out GelenSinif)
                && NavigationContext.QueryString.TryGetValue("konu", out GelenKonu)
                )
            {
                txtIsim.Text = GelenIsim;
                txtSinif.Text = GelenSinif;
                txtNumara.Text = GelenNumara;
                konuAdi = GelenKonu;
            }

            /**********************************************/
            sonuclar = await sonucTable.Where(x => x.KullaniciId == KullaniciInfo.KullaniciID).ToCollectionAsync();

            sinavlar = await sinavTable
                           .Where(u => u.KonuAdi == konuAdi)
                              .ToCollectionAsync();

            for (int i = sinavlar.Count-1 ; i >= 0; i--)
            {
                for (int k = sonuclar.Count - 1; k >= 0; k--)
                {
                    if (sinavlar[i].Id == sonuclar[k].SinavId)
                    {
                        sinavlar.RemoveAt(i);
                        break;
                    }
                }
            }
            //for (int i = 0; i < sinavlar.Count; i++)
            //{
            //    Border brd = new Border();
            //    brd.Background = new SolidColorBrush(Colors.Green);
            //    brd.Width = 250;
            //    brd.Height = 40;
            //    ListBoxItem li = new ListBoxItem();
                
            //    li.Foreground = new SolidColorBrush(Colors.Black);
            //    li.Background = new SolidColorBrush(Colors.Green);
            //    li.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            //    li.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            //    li.Content = sinavlar[i].SinavAdi;
            //    brd.Child = li;
            //    _listSinavListesi.Items.Add(brd);
            //}

            _listSinavListesi.ItemsSource = sinavlar;


            if (_listSinavListesi.Items.Count == 0)
            {
                txtBaslik.Text = konuAdi + " konusu için henüz bir sınav eklenmemiş.";
            }
            else
            {
                txtBaslik.Text = konuAdi + " konusu ile ilgili sınavlar:";
            }
            /*************************************************/
        }

        

        private void grid_12_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            string sinavadi = ((Grid)sender).Tag.ToString();


            string sinavId = (((sender as Grid).Children[0] as Grid).Children[2] as TextBlock).Text;

            KullaniciInfo.SinavID = sinavId;
            try
            {
                //MessageBox.Show(((Grid)sender).Tag.ToString());
                NavigationService.Navigate(new Uri("/OgrSinavSayfasi.xaml?numara=" + txtNumara.Text + "&ad=" + txtIsim.Text + "&sinif=" + txtSinif.Text + "&sinav=" + sinavadi + "&konu=" + konuAdi +  "", UriKind.Relative));
            }

            catch
            {

            }
        }
    }
}