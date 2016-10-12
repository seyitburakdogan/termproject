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
    public partial class Page1 : PhoneApplicationPage
    {
        public static MobileServiceClient MobileService = new MobileServiceClient(
       "https://burakproje2.azure-mobile.net/",
            //"RxJGREQyGGqrTHoaTIxhpcbikPDpbU33"
       "AhWoTjbCXmlMUkbLGBzxfuPnvieTXn87"
        );

        private MobileServiceCollection<Ders, Ders> dersler;
        private IMobileServiceTable<Ders> dersTable = MobileService.GetTable<Ders>();
        public Page1()
        {
            InitializeComponent();

        }
        string dersSinif;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string GelenNumara = "";
            string GelenIsim = "";
            string GelenSinif = "";
            if (NavigationContext.QueryString.TryGetValue("numara", out GelenNumara)
             && NavigationContext.QueryString.TryGetValue("ad", out GelenIsim)
             && NavigationContext.QueryString.TryGetValue("sinif", out GelenSinif)
                )
            {
                txtIsim.Text = GelenIsim;
                txtSinif.Text = GelenSinif + ". Sınıf";
                txtNumara.Text = "Öğrenci No: " + GelenNumara;
                dersSinif = GelenSinif;
            }
        }

        private async void ContentPanel_Loaded(object sender, RoutedEventArgs e)
        {
           
            txtBaslik.Text = dersSinif + ". SINIFLAR İÇİN MEVCUT DERSLER:";
            dersler = await dersTable
                .Where(u => u.DersSinif == dersSinif)
                   .ToCollectionAsync();
            _listDersListesi.ItemsSource = dersler;
        }

        private void _listDersListesi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //txt_Tiklanan.Text = "" + _listDersListesi.SelectedItem;
        }

        private void _listDersListesi_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }

        private void grid_12_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            string dersadi = ((Grid)sender).Tag.ToString();
            try
            {
                //MessageBox.Show( "Name_" + ((Grid)sender).Tag.ToString() );             
                NavigationService.Navigate(new Uri("/KonuSec.xaml?numara=" + txtNumara.Text + "&ad=" + txtIsim.Text + "&sinif=" + txtSinif.Text + "&ders=" + dersadi + "", UriKind.Relative));
            }

            catch
            {

            }
        }


    }
}