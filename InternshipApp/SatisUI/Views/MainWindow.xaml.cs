using DevExpress.Xpf.Core;
using SatisUI.UserControls;
using SatisUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DAL;
using BL;
namespace SatisUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            definePanel.Caption = BL.AuthenticateHelperr.LoginUser[0].PersonelAd + " " + BL.AuthenticateHelperr.LoginUser[0].PersonelSoyad;
        }

        private string captionUrunTanim = "Ürün Tanımlama";     
        private string captionPersonelTanim = "Personel Tanımlama";
        private string captionMusteriTanim = "Müşteri Tanımlama";
        private ProductUserControl ProUC;
        private PersonalUserControl PerUC;
        private CustomerUserControl CusUC;
        private UCProductList UCProList;
        private UCSepet UCSepet;
        private UCReport UCReport;

        //Tanımlama Buttonlarının Eventları
        private void navBar_personeltanim_Click(object sender, EventArgs e)
        {
            ExceptionCatcher.ExceptionFinder(() => {

                RibbonPageGroup_Home.IsEnabled = true;
                PerUC = new PersonalUserControl();
                DXTabItem tabItem = new DXTabItem()
                {
                    Header = navBar_personeltanim.Content,
                    Content = PerUC,
                    AllowHide = DevExpress.Utils.DefaultBoolean.True,
                    IsSelected = true
                };

                foreach (DXTabItem item in TabControlMain.Items)
                {
                    if (item.Header == navBar_personeltanim.Content)
                    {
                        TabControlMain.RemoveTabItem(item);
                        break;
                    }
                }
                TabControlMain.Items.Add(tabItem);




            });       
        }

        private void navBar_uruntanim_Click(object sender, EventArgs e)
        {
            ExceptionCatcher.ExceptionFinder(() =>
            {
                RibbonPageGroup_Home.IsEnabled = true;
                ProUC = new ProductUserControl();

                DXTabItem tabItem = new DXTabItem()
                {
                    Header = navBar_uruntanim.Content,
                    Content = ProUC,
                    AllowHide = DevExpress.Utils.DefaultBoolean.True,
                    IsSelected = true
                };

                foreach (DXTabItem item in TabControlMain.Items)
                {
                    if (item.Header == navBar_uruntanim.Content)
                    {
                        TabControlMain.RemoveTabItem(item);
                        break;
                    }

                }

                TabControlMain.Items.Add(tabItem);


            });
        }

        private void navBar_musteritanim_Click(object sender, EventArgs e)
        {
            ExceptionCatcher.ExceptionFinder(() =>
            {
                RibbonPageGroup_Home.IsEnabled = true;
                CusUC = new CustomerUserControl();
                DXTabItem tabItem = new DXTabItem()
                {
                    Header = navBar_musteritanim.Content,
                    Content = CusUC,
                    AllowHide = DevExpress.Utils.DefaultBoolean.True,
                    IsSelected = true
                };

                foreach (DXTabItem item in TabControlMain.Items)
                {
                    if (item.Header == navBar_musteritanim.Content)
                    {
                        TabControlMain.RemoveTabItem(item);
                        break;
                    }
                }
                TabControlMain.Items.Add(tabItem);

            });          
        }

        //Ribbondaki bütün clickleri gerçekleştiren method//
        private void RibbonItem_Click(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            ExceptionCatcher.ExceptionFinder(() =>
            {
                string selectedTabCaption = TabControlMain.SelectedContainer.Header.ToString();
                if (selectedTabCaption == captionUrunTanim)
                {
                    Type type = ((ProductUserControl)ProUC).GetType();
                    MethodInfo info = type.GetMethod(e.Item.Tag.ToString());
                    if (e.Item.Tag.ToString() == "NewRecord")
                    {
                        AddButton.IsEnabled = false;
                        editButton.IsEnabled = false;
                        saveButton.IsEnabled = true;
                        cancelButton.IsEnabled = true;
                        deleteButton.IsEnabled = false;
                    }
                    if (e.Item.Tag.ToString() == "CancelItem")
                    {
                        AddButton.IsEnabled = true;
                        editButton.IsEnabled = true;
                        saveButton.IsEnabled = false;
                        cancelButton.IsEnabled = false;
                        deleteButton.IsEnabled = true;
                    }
                    if (e.Item.Tag.ToString() == "EditItem")
                    {
                        AddButton.IsEnabled = false;
                        editButton.IsEnabled = false;
                        saveButton.IsEnabled = true;
                        cancelButton.IsEnabled = true;
                        deleteButton.IsEnabled = false;
                    }
                    info.Invoke(ProUC, null);
                }
                if (selectedTabCaption == captionPersonelTanim)
                {

                    Type type = ((PersonalUserControl)PerUC).GetType();
                    MethodInfo info = type.GetMethod(e.Item.Tag.ToString());
                    if (e.Item.Tag.ToString() == "NewRecord")
                    {
                        AddButton.IsEnabled = false;
                        editButton.IsEnabled = false;
                        saveButton.IsEnabled = true;
                        cancelButton.IsEnabled = true;
                        deleteButton.IsEnabled = false;
                    }
                    if (e.Item.Tag.ToString() == "CancelItem")
                    {
                        AddButton.IsEnabled = true;
                        editButton.IsEnabled = true;
                        saveButton.IsEnabled = false;
                        cancelButton.IsEnabled = false;
                        deleteButton.IsEnabled = true;
                    }
                    if (e.Item.Tag.ToString() == "EditItem")
                    {
                        AddButton.IsEnabled = false;
                        editButton.IsEnabled = false;
                        saveButton.IsEnabled = true;
                        cancelButton.IsEnabled = true;
                        deleteButton.IsEnabled = false;
                    }
                    info.Invoke(PerUC, null);
                }
                if (selectedTabCaption == captionMusteriTanim)
                {

                    Type type = ((CustomerUserControl)CusUC).GetType();
                    MethodInfo info = type.GetMethod(e.Item.Tag.ToString());
                    if (e.Item.Tag.ToString() == "NewRecord")
                    {
                        AddButton.IsEnabled = false;
                        editButton.IsEnabled = false;
                        saveButton.IsEnabled = true;
                        cancelButton.IsEnabled = true;
                        deleteButton.IsEnabled = false;
                    }
                    if (e.Item.Tag.ToString() == "CancelItem")
                    {
                        AddButton.IsEnabled = true;
                        editButton.IsEnabled = true;
                        saveButton.IsEnabled = false;
                        cancelButton.IsEnabled = false;
                        deleteButton.IsEnabled = true;
                    }
                    if (e.Item.Tag.ToString() == "EditItem")
                    {
                        AddButton.IsEnabled = false;
                        editButton.IsEnabled = false;
                        saveButton.IsEnabled = true;
                        cancelButton.IsEnabled = true;
                        deleteButton.IsEnabled = false;
                    }
                    info.Invoke(CusUC, null);
                }
            });          
        }

        public void RibbonController()
        {
            ExceptionCatcher.ExceptionFinder(() =>
            {
                string selectedTabCaption = TabControlMain.SelectedContainer.Header.ToString();

                if (selectedTabCaption == captionUrunTanim)
                {
                    saveButton.IsEnabled = false;
                    cancelButton.IsEnabled = false;
                    AddButton.IsEnabled = true;
                    editButton.IsEnabled = true;
                    deleteButton.IsEnabled = true;
                }
                if (selectedTabCaption == captionMusteriTanim)
                {
                    saveButton.IsEnabled = false;
                    cancelButton.IsEnabled = false;
                    AddButton.IsEnabled = true;
                    editButton.IsEnabled = true;
                    deleteButton.IsEnabled = true;


                }
                if (selectedTabCaption == captionPersonelTanim)
                {
                    saveButton.IsEnabled = false;
                    cancelButton.IsEnabled = false;
                    AddButton.IsEnabled = true;
                    editButton.IsEnabled = true;
                    deleteButton.IsEnabled = true;


                }
            });
        }

        private void TabControlMain_TabHidden(object sender, TabControlTabHiddenEventArgs e)
        {
            saveButton.IsEnabled = false;
            cancelButton.IsEnabled = false;
            AddButton.IsEnabled = false;
            editButton.IsEnabled = false;
            deleteButton.IsEnabled = false;
            CancelBasket.IsEnabled = false;
            AcceptBasket.IsEnabled = false;
        }

        private void navBar_urunList_Click(object sender, EventArgs e)
        {
            ExceptionCatcher.ExceptionFinder(() =>
            {
                RibbonPageGroup_Home.IsEnabled = false;
                UCProList = new UCProductList();
                DXTabItem tabItem = new DXTabItem()
                {
                    Header = navBar_urunList.Content,
                    Content = UCProList,
                    AllowHide = DevExpress.Utils.DefaultBoolean.True,
                    IsSelected = true
                };

                foreach (DXTabItem item in TabControlMain.Items)
                {
                    if (item.Header == navBar_urunList.Content)
                    {
                        TabControlMain.RemoveTabItem(item);
                        break;
                    }
                }
                TabControlMain.Items.Add(tabItem);
            });          
        }

        private void navBar_raporList_Click(object sender, EventArgs e)
        {
            ExceptionCatcher.ExceptionFinder(() =>
            {
                RibbonPageGroup_Home.IsEnabled = false;
                UCReport = new UCReport();
                DXTabItem tabItem = new DXTabItem()
                {
                    Header = navBar_raporList.Content,
                    Content = UCReport,
                    AllowHide = DevExpress.Utils.DefaultBoolean.True,
                    IsSelected = true
                };

                foreach (DXTabItem item in TabControlMain.Items)
                {
                    if (item.Header == navBar_raporList.Content)
                    {
                        TabControlMain.RemoveTabItem(item);
                        break;
                    }
                }
                TabControlMain.Items.Add(tabItem);
            });           
        }

        private void basketAdd_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            ExceptionCatcher.ExceptionFinder(() =>
            {
                UCSepet = new UCSepet();
                DXTabItem tabItem = new DXTabItem()
                {
                    Header = basketAdd.Content,
                    Content = UCSepet,
                    AllowHide = DevExpress.Utils.DefaultBoolean.True,
                    IsSelected = true
                };

                foreach (DXTabItem item in TabControlMain.Items)
                {
                    if (item.Header == basketAdd.Content)
                    {
                        TabControlMain.RemoveTabItem(item);
                        break;
                    }
                }

                TabControlMain.Items.Add(tabItem);
                AcceptBasket.IsEnabled = true;
                CancelBasket.IsEnabled = true;
            });
        }

        //Siparişi Kapatıp Database e Kaydedicek//
        private void AcceptBasket_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            ExceptionCatcher.ExceptionFinder(() =>
            {
                Type type = ((UCSepet)UCSepet).GetType();
                MethodInfo info = type.GetMethod(e.Item.Tag.ToString());
                info.Invoke(UCSepet, null);
            });                    
        }

        //Siparişten Vazgeçersek//
        private void CancelBasket_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            ExceptionCatcher.ExceptionFinder(() => {

                MessageBoxResult result = DXMessageBox.Show("Sepeti İptal Etmek İstiyor Musunuz?", "Uyarı", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes, MessageBoxOptions.None);
                switch (result)
                {
                    case MessageBoxResult.Yes:

                        TabControlMain.SelectedContainer.Close();
                        SepetHelper.Sepet = null;
                        break;
                    case MessageBoxResult.No:
                        break;

                }
            });         
        }

        private void btn_Logout_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            ExceptionCatcher.ExceptionFinder(() => {
                MessageBoxResult result = DXMessageBox.Show("Çıkış Yapmak İstiyor Musunuz?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes, MessageBoxOptions.None);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        MainWindow window = (MainWindow)Window.GetWindow(this);
                        window.Close();
                        BL.AuthenticateHelperr.LoginUser = null;

                        break;
                    case MessageBoxResult.No:
                        break;

                }
            });           
        }

        private void ManinWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Yetki();          
        }

        public void Yetki()
        {
            ExceptionCatcher.ExceptionFinder(() => {
                List<UserPermisson> list = AuthenticateHelperr.Permisson(Convert.ToInt32(AuthenticateHelperr.LoginUser[0].PersonelRoleID));

                foreach (var item in list)
                {
                    if (item.CompenetName == "navBar_uruntanim")
                    {
                        navBar_uruntanim.IsEnabled = item.EnabledState;
                    }
                    if (item.CompenetName == "navBar_raporList")
                    {
                        navBar_raporList.IsEnabled = item.EnabledState;
                    }
                    if (item.CompenetName == "navBar_personeltanim")
                    {
                        navBar_personeltanim.IsEnabled = item.EnabledState;
                    }
                    if (item.CompenetName == "navBar_musteritanim")
                    {
                        navBar_musteritanim.IsEnabled = item.EnabledState;
                    }
                    if (item.CompenetName == "navBar_urunList")
                    {
                        navBar_urunList.IsEnabled = item.EnabledState;
                    }
                    if (item.CompenetName == "Ribbonpage_AlimSatim")
                    {
                        Ribbonpage_AlimSatim.IsEnabled = item.EnabledState;
                    }
                }
            });          
        }
    }
}
