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

namespace SinavSistemi
{
    public partial class SinavOlustur : PhoneApplicationPage
    {

        public static MobileServiceClient MobileService = new MobileServiceClient(
"https://burakproje2.azure-mobile.net/",
            //"RxJGREQyGGqrTHoaTIxhpcbikPDpbU33"
"AhWoTjbCXmlMUkbLGBzxfuPnvieTXn87"
);

        private MobileServiceCollection<Sinav, Sinav> sinavlar;
        private IMobileServiceTable<Sinav> sinavTable = MobileService.GetTable<Sinav>();

        private MobileServiceCollection<Soru, Soru> sorular;
        private IMobileServiceTable<Soru> soruTable = MobileService.GetTable<Soru>();



        List<Soru> list_Sorular = new List<Soru>();
        Sinav NewSinav;
        string cevap;
        int SoruNo = 1;
        public SinavOlustur()
        {
            InitializeComponent();
            txtSoruNo.Text = SoruNo.ToString();

        }
        private void ContentPanel_Loaded(object sender, RoutedEventArgs e)
        {

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string GelenSinif = "";
            string GelenDers = "";
            string GelenKonu = "";
            string GelenIsim = "";
            if (NavigationContext.QueryString.TryGetValue("sinif", out GelenSinif)
             && NavigationContext.QueryString.TryGetValue("ders", out GelenDers)
                && NavigationContext.QueryString.TryGetValue("konu", out GelenKonu)
                && NavigationContext.QueryString.TryGetValue("isim", out GelenIsim)
                )
            {
                txtSinif.Text = GelenSinif + ". Sınıf";
                txtDers.Text = GelenDers;
                txtKonu.Text = GelenKonu;
                txtSinavIsim.Text = GelenIsim;
            }
        }


        private void btn_yeniSoru_Click(object sender, RoutedEventArgs e)
        {
            NewSinav = new Sinav() { KonuAdi = txtKonu.Text, SinavAdi = txtSinavIsim.Text, SinavDers = txtDers.Text };

            list_Sorular.Add(
                new Soru
                {
                    DersAdi = txtDers.Text,
                    KonuAdi = txtKonu.Text,
                    SinavAdi = txtSinavIsim.Text,
                    DersSinif = txtSinif.Text,
                    SoruNo = Convert.ToInt32(txtSoruNo.Text),
                    SoruMetni = txtSoruMetni.Text,
                    Cevap = cevap,
                    SecenekA = txtSecA.Text,
                    SecenekB = txtSecB.Text,
                    SecenekC = txtSecC.Text,
                    SecenekD = txtSecD.Text
                });


            Anim_SoruDondur_1.Begin();
        }

        private async void btn_Bitti_Click(object sender, RoutedEventArgs e)
        {

            //VeriSorgulama.SinavEkle(NewSinav);

            //VeriSorgulama.SoruEkle(list_Sorular);

            //MessageBox.Show("Yeni sınav eklendi");


            //List<Kullanici> liste = new List<Kullanici>();

            //liste.Add(new Kullanici() { KullaniciIsim = "Burak Doğan", KullaniciNo = "12345", Rol = "Akademisyen", Sifre = "12345", Sinif = "0" });
            //liste.Add(new Kullanici() { KullaniciIsim = "Murat Sercan", KullaniciNo = "111", Rol = "Ogrenci", Sifre = "111", Sinif = "1" });
            //liste.Add(new Kullanici() { KullaniciIsim = "Oğuzhan Gedik", KullaniciNo = "222", Rol = "Ogrenci", Sifre = "222", Sinif = "2" });
            //liste.Add(new Kullanici() { KullaniciIsim = "Gürkan Demirel", KullaniciNo = "333", Rol = "Ogrenci", Sifre = "333", Sinif = "3" });
            //liste.Add(new Kullanici() { KullaniciIsim = "Mahmut Uzun", KullaniciNo = "444", Rol = "Ogrenci", Sifre = "444", Sinif = "4" });
            await sinavTable.InsertAsync(NewSinav);
            for (int i = 0; i < list_Sorular.Count; i++)
            {

                await soruTable.InsertAsync(list_Sorular[i]);
            }

            MessageBox.Show("Sınav başarıyla eklendi.");



        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                txtDogruSecenek.Text = cevap = (sender as RadioButton).Content.ToString().Split('(')[1];
            }
            catch { }
        }

        private void Anim_SoruDondur_1_Completed(object sender, EventArgs e)
        {
            Anim_SoruDondur_1.Stop();

            foreach (var item in grdSoruMetin.Children)
            {
                if (item is TextBox)
                {
                    (item as TextBox).Text = "";
                }
            }

            foreach (var item in grdSoruSecenek.Children)
            {
                if (item is TextBox)
                {
                    (item as TextBox).Text = "";
                }
            }

            SoruNo++;
            txtSoruNo.Text = SoruNo.ToString();

            Anim_SoruDondur_2.Begin();
        }

        private void Anim_SoruDondur_2_Completed(object sender, EventArgs e)
        {
            Anim_SoruDondur_2.Stop();
        }


    }
}