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
using DAL;
using BL;
using DevExpress.Xpf.Core.Commands;
using DevExpress.Xpf.Core;

namespace SatisUI.UserControls
{
    /// <summary>
    /// Interaction logic for customerUserControl.xaml
    /// </summary>
    public partial class CustomerUserControl : UserControl
    {
        public CustomerUserControl()
        {
            InitializeComponent();
            GetMusteriList();
        }

        Musteri musteri;

        public void AddNewItem()
        {
            ExceptionCatcher.ExceptionFinder(() => {
                using (SDB sdbContext = new SDB())
                {
                    if (musteri == null)
                    {
                        Musteri musteri = new Musteri();
                        musteri.MusteriAdi = customerName.Text;
                        musteri.MusteriSoyadi = customerLastname.Text;
                        musteri.MusteriAdres = customerAddress.Text;
                        musteri.MusteriTelNo = customerTelNo.Text;
                        DAL.DAL dal = new DAL.DAL();

                        dal.NewRecordMus(musteri);

                        grid_customerForm.Visibility = Visibility.Collapsed;
                        gridControl_customerList.ItemsSource = null;
                        GetMusteriList();
                    }
                    else
                    {
                        Musteri cust = new Musteri();
                        cust.MusteriID = musteri.MusteriID;
                        cust.MusteriAdi = customerName.Text;
                        cust.MusteriSoyadi = customerLastname.Text;
                        cust.MusteriAdres = customerAddress.Text;
                        cust.MusteriTelNo = customerTelNo.Text;

                        DAL.DAL dal = new DAL.DAL();
                        dal.UpdateRecordMus(cust);
                        MainWindow window = (MainWindow)Window.GetWindow(this);
                        window.RibbonController();
                        grid_customerForm.Visibility = Visibility.Collapsed;
                        gridControl_customerList.ItemsSource = null;
                        GetMusteriList();
                        ClearForm();
                    }
                }
            });       
        }

        private void ClearForm()
        {
            ExceptionCatcher.ExceptionFinder(() => {
                musteri = null;
                customerName.Text = null;
                customerLastname.Text = null;
                customerAddress.Text = null;
                customerTelNo.Text = null;
            });        
        }

        private void GetMusteriList()
        {
            ExceptionCatcher.ExceptionFinder(() => {
                DAL.DAL dal = new DAL.DAL();
                List<Musteri> list = dal.GetMusteriList();
                gridControl_customerList.ItemsSource = list;
            });
        }

        public void NewRecord()
        {
            ExceptionCatcher.ExceptionFinder(() => {
                if (grid_customerForm.Visibility == Visibility.Collapsed)
                {
                    musteri = null;
                    grid_customerForm.Visibility = Visibility.Visible;
                }
            });          
        }

        public void EditItem()
        {
            ExceptionCatcher.ExceptionFinder(() => {
                grid_customerForm.Visibility = Visibility.Visible;
                customerName.Text = musteri.MusteriAdi;
                customerLastname.Text = musteri.MusteriSoyadi;
                customerAddress.Text = musteri.MusteriAdres;
                customerTelNo.Text = musteri.MusteriTelNo;
            });
        }

        public void DeleteItem()
        {
            ExceptionCatcher.ExceptionFinder(() => {
                using (SDB sdb = new SDB())
                {
                    var customer = new Musteri { MusteriID = musteri.MusteriID };
                    DAL.DAL dal = new DAL.DAL();
                    MessageBoxResult result = DXMessageBox.Show("Çalışan Silinecek Onaylıyor Musunuz?", "Uyarı", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes, MessageBoxOptions.None);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            dal.DeleteRecordMus(customer);
                            MessageBox.Show("Ürün Silindi!");
                            gridControl_customerList.ItemsSource = null;
                            GetMusteriList();
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
                grid_customerForm.Visibility = Visibility.Collapsed;
                customerName.Text = null;
                customerLastname.Text = null;
                customerAddress.Text = null;
                customerTelNo.Text = null;
            });           
        }

        private void gridControl_customerList_SelectedItemChanged(object sender, DevExpress.Xpf.Grid.SelectedItemChangedEventArgs e)
        {
            musteri = (Musteri)gridControl_customerList.SelectedItem;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            window.RibbonController();
        }
    }
}
