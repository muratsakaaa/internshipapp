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

namespace SatisUI.UserControls
{
    /// <summary>
    /// Interaction logic for UCProductList.xaml
    /// </summary>
    public partial class UCProductList : UserControl
    {      
        public UCProductList()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            GetUrunList();
        }

        private void GetUrunList()
        {
            ExceptionCatcher.ExceptionFinder(() => {
                DAL.DAL dal = new DAL.DAL();
                List<UrunKategoriEntity> list = dal.GetUrunList();
                gridControl_ProductCardView.ItemsSource = list;
            });        
        }

        private void SepetEkle_Click(object sender, RoutedEventArgs e)
        {
            SepetEkle();
        }
      
        public void SepetEkle()
        {
            ExceptionCatcher.ExceptionFinder(() => {
                SepetEntity sepeteEklenecek = new SepetEntity();
                sepeteEklenecek.UrunAd = gridControl_ProductCardView.GetFocusedRowCellValue(urunName).ToString();
                sepeteEklenecek.UrunID = Convert.ToInt16(gridControl_ProductCardView.GetFocusedRowCellValue(urunId));
                sepeteEklenecek.UrunFiyat = Convert.ToInt16(gridControl_ProductCardView.GetFocusedRowCellValue(urunFiyat));
                sepeteEklenecek.urunAdet = 1;
                sepeteEklenecek.urunToplamFiyat = Convert.ToInt32(sepeteEklenecek.UrunFiyat);

                if (SepetHelper.Sepet.Exists(x => x.UrunID == sepeteEklenecek.UrunID))
                {
                    int rowIndex = SepetHelper.Sepet.FindIndex(x => x.UrunID == sepeteEklenecek.UrunID);
                    SepetHelper.Sepet[rowIndex].urunAdet++;
                    SepetHelper.Sepet[rowIndex].urunToplamFiyat = Convert.ToInt32(SepetHelper.Sepet[rowIndex].UrunFiyat * SepetHelper.Sepet[rowIndex].urunAdet);
                }
                else
                {

                    BL.SepetHelper.Sepet.Add(sepeteEklenecek);
                }

            });          
        }
    }
}
