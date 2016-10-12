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
using Windows.UI;
using Microsoft.WindowsAzure.MobileServices;

namespace SinavSistemi
{
    public partial class SoruEkle : PhoneApplicationPage
    {
        public static MobileServiceClient MobileService = new MobileServiceClient(
      "https://burakproje2.azure-mobile.net/",
            //"RxJGREQyGGqrTHoaTIxhpcbikPDpbU33"
      "AhWoTjbCXmlMUkbLGBzxfuPnvieTXn87"
       );

        private MobileServiceCollection<Ders, Ders> dersler;
        private IMobileServiceTable<Ders> dersTable = MobileService.GetTable<Ders>();

        private MobileServiceCollection<Konu, Konu> konular;
        private IMobileServiceTable<Konu> konuTable = MobileService.GetTable<Konu>();

        ListPicker _lstSinif = new ListPicker();

        public SoruEkle()
        {
            InitializeComponent();
            _lstSinif.SelectionChanged += _lstSinif_SelectionChanged;
            _lstDers.SelectionChanged += _lstDers_SelectionChanged;
        }

        async void _lstSinif_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                dersler = await dersTable
                       .Where(u => u.DersSinif == _lstSinif.SelectedItem.ToString())
                       .ToCollectionAsync();
                _lstDers.ItemsSource = dersler;
                //string ders = ((Ders)(_lstDers.SelectedItem)).DersAdi.ToString();
                //konular = await konuTable.Where(u => u.KonuDers == ders).ToCollectionAsync();
                //_lstKonu.ItemsSource = konular;
            }
            catch
            {

            }
        }

        private async void ContentPanel_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _lstSinif.Width = 430;
                _lstSinif.VerticalAlignment = VerticalAlignment.Top;
                _lstSinif.HorizontalAlignment = HorizontalAlignment.Left;
                _lstSinif.Margin = new Thickness(13, 63, 0, 0);
                ContentPanel.Children.Add(_lstSinif);
                _lstSinif.Items.Add("1");
                _lstSinif.Items.Add("2");
                _lstSinif.Items.Add("3");
                _lstSinif.Items.Add("4");
                dersler = await dersTable
                       .Where(u => u.DersSinif == _lstSinif.SelectedItem.ToString())
                       .ToCollectionAsync();
                _lstDers.ItemsSource = dersler;
            }
            catch
            {
               
            }
            
        }

        private async void _lstDers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                string ders = ((Ders)(_lstDers.SelectedItem)).DersAdi.ToString();

                konular = await konuTable.Where(u => u.KonuDers == ders).ToCollectionAsync();

                _lstKonu.ItemsSource = konular;
            }
            catch
            {

            }
        }

        private void btnSoruEkle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.Navigate(new Uri("/SinavOlustur.xaml?sinif=" + _lstSinif.SelectedItem.ToString() + "&ders=" + ((Data_Class.Ders)_lstDers.SelectedItem).DersAdi + "&konu=" + ((Data_Class.Konu)_lstKonu.SelectedItem).KonuAdi + "&isim=" + txtSinavIsmi.Text + "", UriKind.Relative));
            }
            catch
            {
                MessageBox.Show("Konu seçimi yapınız");
            }
        }

        private void btn_Sonuclar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SinavSonuclari.xaml",UriKind.Relative));
        }





    }
}