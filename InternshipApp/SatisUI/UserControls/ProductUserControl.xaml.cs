using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using DAL;
using System.Collections;
using System.Drawing;
using BL;
using DevExpress.Xpf.WindowsUI;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.Native;
using DevExpress.Xpf.Ribbon;
using System.Windows.Media.Imaging;


namespace SatisUI.UserControls
{
    /// <summary>
    /// Interaction logic for productUserControl.xaml
    /// </summary>
    public partial class ProductUserControl : UserControl
    {
        UrunKategoriEntity Urunentity;

        public ProductUserControl()
        {
            InitializeComponent();
            GetUrunList();
        }

        private void Pro_pic_upload_Click(object sender, RoutedEventArgs e)
        {
            ExceptionCatcher.ExceptionFinder(() => {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.DefaultExt = ".txt";
                //   dlg.Filter = "Pic Documents (.jpg)|*.jpg*";
                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {
                    string filename = dlg.FileName;
                    Pro_pic_url.Text = filename;
                }
            });           
        }

        private void FillCategoryList()
        {
            ExceptionCatcher.ExceptionFinder(() => {
                using (SDB sdb = new SDB())
                {
                    productCat_combobox.Items.Clear();
                    var kategoriList = sdb.Kategoris.ToList();
                    productCat_combobox.ItemsSource = kategoriList;
                }
            });           
        }
        
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (UCProduct.IsLoaded)
            {
                FillCategoryList();
                RibbonControl();
            }
        }

        //SAVE İşlemini Yapıyor
        public void AddNewItem()
        {
            ExceptionCatcher.ExceptionFinder(() => {
                using (SDB sdbContext = new SDB())
                {
                    if (Urunentity == null)
                    {
                        Urun urun = new Urun();
                        urun.UrunAd = productName.Text;
                        urun.UrunFiyat = Convert.ToDecimal(productPrice.Text);
                        urun.UrunKod = productCode.Text;
                        urun.UrunStok = Convert.ToInt16(txtedit_productStok.Text);
                        urun.UrunKatID = ((Kategori)productCat_combobox.SelectedItem).KategoriID;
                        urun.UrunPic = BL.ImageHelper.ConvertImageToByte(Pro_pic_url.Text);

                        pro_image.Source = new BitmapImage(new Uri(Pro_pic_url.Text));
                        DAL.DAL dal = new DAL.DAL();
                        dal.NewRecord(urun);

                        FormContainer.Visibility = Visibility.Collapsed;
                        GridControl_ProductList.ItemsSource = null;
                        GetUrunList();
                    }
                    else
                    {
                        Urun urun = new Urun();
                        urun.UrunID = Urunentity.UrunID;
                        urun.UrunAd = productName.Text;
                        urun.UrunFiyat = Convert.ToDecimal(productPrice.Text);
                        urun.UrunKod = productCode.Text;
                        urun.UrunStok = Convert.ToInt16(txtedit_productStok.Text);
                        if (Urunentity.UrunPic != null)
                        {
                            urun.UrunPic = Urunentity.UrunPic;
                        }

                        urun.UrunKatID = ((Kategori)productCat_combobox.SelectedItem).KategoriID;
                        DAL.DAL dal = new DAL.DAL();
                        dal.UpdateRecord(urun);
                        MainWindow window = (MainWindow)Window.GetWindow(this);
                        window.RibbonController();
                        FormContainer.Visibility = Visibility.Collapsed;
                        GridControl_ProductList.ItemsSource = null;
                        GetUrunList();
                        ClearForm();
                    }
                }
            });                                 
        }

        private void GetUrunList()
        {
            ExceptionCatcher.ExceptionFinder(() => {
                DAL.DAL dal = new DAL.DAL();
                List<UrunKategoriEntity> list = dal.GetUrunList();
                GridControl_ProductList.ItemsSource = list;

            });           
        }

        public void NewRecord()
        {
            ExceptionCatcher.ExceptionFinder(() => {
                if (FormContainer.Visibility == Visibility.Collapsed)
                {
                    ClearForm();
                    FormContainer.Visibility = Visibility.Visible;
                }

            });           
        }

        public void EditItem()
        {
            ExceptionCatcher.ExceptionFinder(() => {
                if (Urunentity == null)
                {
                    MessageBox.Show("Lütfen bir Ürün Seçiniz!");
                }
                else
                {
                    FormContainer.Visibility = Visibility.Visible;
                    productName.Text = Urunentity.UrunAd;
                    productPrice.Text = Urunentity.UrunFiyat.ToString();
                    productCode.Text = Urunentity.UrunKod;
                    txtedit_productStok.Text = Urunentity.UrunStok.ToString();
                    productCat_combobox.Text = Urunentity.KategoriAdi;
                    pro_image.Source = BL.ImageHelper.ConvertByteToImage(Urunentity.UrunPic);
                }
            });               
        }

        public void DeleteItem()
        {
            ExceptionCatcher.ExceptionFinder(() => {
                using (SDB sdb = new SDB())
                {
                    var urun = new Urun { UrunID = Urunentity.UrunID };
                    DAL.DAL dal = new DAL.DAL();
                    MessageBoxResult result = DXMessageBox.Show("Ürünü Silinecek Onaylıyor Musunuz?", "Uyarı", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes, MessageBoxOptions.None);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            dal.DeleteRecord(urun);
                            MessageBox.Show("Ürün Silindi!");
                            GridControl_ProductList.ItemsSource = null;
                            GetUrunList();
                            break;

                        case MessageBoxResult.No:
                            break;

                    }

                }
            });         
        }

        public void CancelItem()
        {
            ExceptionCatcher.ExceptionFinder(() => {
                FormContainer.Visibility = Visibility.Collapsed;
                productName.Text = null;
                productPrice.Text = null;
                productCode.Text = null;
                productCat_combobox.Text = null;
                txtedit_productStok.Text = null;
            });                   
        }

        private void GridControl_ProductList_SelectedItemChanged(object sender, DevExpress.Xpf.Grid.SelectedItemChangedEventArgs e)
        {
            Urunentity = (UrunKategoriEntity)GridControl_ProductList.SelectedItem;
        }

        private void ClearForm()
        {
            ExceptionCatcher.ExceptionFinder(() => {
                Urunentity = null;
                productName.Text = null;
                productPrice.Text = null;
                productCode.Text = null;
                Pro_pic_url.Text = null;
                pro_image.Source = null;
                txtedit_productStok.Text = null;
            });            
        }

        private void GridControl_ProductList_SelectionChanged(object sender, DevExpress.Xpf.Grid.GridSelectionChangedEventArgs e)
        {

        }

        private void RibbonControl()
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);

            // SAYFA HANGİ MODDA İSE
            //MAİN window üzerinde method yarat
            //o methodu burada çağır (komponentlere göre true false göndersin)
            //mainde herbir komponent için gelen bool değeri IsEnableda ver
            window.RibbonController();
        }
    }
}
