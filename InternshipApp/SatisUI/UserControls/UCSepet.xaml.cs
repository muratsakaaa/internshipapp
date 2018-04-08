using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BL;
using DevExpress.Xpf.Core;
using DAL;

namespace SatisUI.UserControls
{
    /// <summary>
    /// Interaction logic for UCSepet.xaml
    /// </summary>
    public partial class UCSepet : UserControl
    {
        public UCSepet()
        {
            InitializeComponent();
            GetSepetList();
           
        }

        public void GetSepetList()
        {
            ExceptionCatcher.ExceptionFinder(() => {
                gridControl_sepet.ItemsSource = BL.SepetHelper.Sepet;
            });           
        }

        private void DeleteRow_Click(object sender, RoutedEventArgs e)
        {
            ExceptionCatcher.ExceptionFinder(() => {
                var id = Convert.ToInt16(gridControl_sepet.GetFocusedRowCellValue(gridcolumn_urunId));

                if (SepetHelper.Sepet.Exists(x => x.UrunID == id))
                {
                    int rowIndex = SepetHelper.Sepet.FindIndex(x => x.UrunID == id);
                    MessageBoxResult result = DXMessageBox.Show("Ürünü Silinecek Onaylıyor Musunuz?", "Uyarı", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes, MessageBoxOptions.None);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            SepetHelper.Sepet.RemoveAt(rowIndex);
                            MessageBox.Show("Ürün Silindi!");
                            gridControl_sepet.ItemsSource = null;
                            GetSepetList();

                            break;

                        case MessageBoxResult.No:
                            break;
                    }

                }
            });            
        }

        public void AcceptedBasket()
        {
            ExceptionCatcher.ExceptionFinder(() => {
                if (combobox_musteri.SelectedItem == null)
                {
                    MessageBox.Show("Müşteri Seçiniz!");
                }
                else
                {
                    using (SDB sdb = new SDB())
                    {

                        for (int i = 0; i < SepetHelper.Sepet.Count; i++)
                        {
                            Sati sati = new Sati();
                            sati.SatisUrunID = SepetHelper.Sepet[i].UrunID;
                            sati.SatisTarih = DateTime.Now;
                            sati.SatisAdet = SepetHelper.Sepet[i].urunAdet;
                            sati.SatisFiyat = Convert.ToDecimal(SepetHelper.Sepet[i].urunToplamFiyat);
                            sati.SatisPerID = AuthenticateHelperr.LoginUser[0].PersonelID;
                            sati.SatisMusID = Convert.ToInt32(combobox_musteri.EditValue);

                            DAL.DAL dal = new DAL.DAL();
                            dal.SatisRapor(sati);
                        }
                        MainWindow window = (MainWindow)Window.GetWindow(this);
                        MessageBox.Show("Satış Yapıldı");
                        window.TabControlMain.SelectedContainer.Close();
                        window.AcceptBasket.IsEnabled = false;
                        window.CancelBasket.IsEnabled = false;
                        SepetHelper.Sepet = null;
                    }
                }
            });                        
        }

        private void FillCustomerList()
        {
            ExceptionCatcher.ExceptionFinder(() => {
                using (SDB sdb = new SDB())
                {
                    DAL.DAL dal = new DAL.DAL();
                    combobox_musteri.Items.Clear();
                    var query = (from m in sdb.Musteris
                                 select new
                                 {

                                     musteriId = m.MusteriID,
                                     musteriAdSoyad = m.MusteriAdi + " " + m.MusteriSoyadi,
                                 }).ToList();

                    combobox_musteri.ItemsSource = query;
                }
            });           
        }

        private void SepetEkrani_Loaded(object sender, RoutedEventArgs e)
        {
            FillCustomerList();
        }

        private void gridcolumn_siparisadet_Loaded(object sender, RoutedEventArgs e)
        {
         
        }
    }
}
