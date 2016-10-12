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

namespace SinavSistemi
{
    public partial class KonuSec : PhoneApplicationPage
    {
        public static MobileServiceClient MobileService = new MobileServiceClient(
      "https://burakproje2.azure-mobile.net/",
            //"RxJGREQyGGqrTHoaTIxhpcbikPDpbU33"
      "AhWoTjbCXmlMUkbLGBzxfuPnvieTXn87"
       );

        private MobileServiceCollection<Konu, Konu> konular;
        private IMobileServiceTable<Konu> konuTable = MobileService.GetTable<Konu>();
        string dersAdi = "";
        public KonuSec()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string GelenNumara = "";
            string GelenIsim = "";
            string GelenSinif = "";
            string GelenDers = "";
            if (NavigationContext.QueryString.TryGetValue("numara", out GelenNumara)
             && NavigationContext.QueryString.TryGetValue("ad", out GelenIsim)
             && NavigationContext.QueryString.TryGetValue("sinif", out GelenSinif)
                && NavigationContext.QueryString.TryGetValue("ders", out GelenDers)
                )
            {
                txtIsim.Text = GelenIsim;
                txtSinif.Text = GelenSinif;
                txtNumara.Text = GelenNumara;
                dersAdi = GelenDers;
            }
        }

        private async void ContentPanel_Loaded(object sender, RoutedEventArgs e)
        {
            txtBaslik.Text = dersAdi + " Dersi Konuları:";
            konular = await konuTable
                .Where(u => u.KonuDers == dersAdi)
                   .ToCollectionAsync();
            _listKonuListesi.ItemsSource = konular;
        }


        private void grid_12_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            string konuadi = ((Grid)sender).Tag.ToString();
            try
            {
                //MessageBox.Show( "Name_" + ((Grid)sender).Tag.ToString() );             
                NavigationService.Navigate(new Uri("/SinavSec.xaml?numara=" + txtNumara.Text + "&ad=" + txtIsim.Text + "&sinif=" + txtSinif.Text + "&konu=" + konuadi + "", UriKind.Relative));
            }

            catch
            {

            }
        }


    }
}