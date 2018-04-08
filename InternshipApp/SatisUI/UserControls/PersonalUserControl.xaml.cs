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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DAL;
using BL;
using DevExpress.Xpf.Core;
using System.Security.Cryptography;

namespace SatisUI.Views
{
    /// <summary>
    /// Interaction logic for personalUserControl.xaml
    /// </summary>
    public partial class PersonalUserControl : UserControl
    {

        PersonelEntity personelEntity;

        public PersonalUserControl()
        {
            InitializeComponent();
            GetPersonelList();
           
        }

        private void Per_pic_upload_Click(object sender, RoutedEventArgs e)
        {
            ExceptionCatcher.ExceptionFinder(() =>
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.DefaultExt = ".txt";
                //dlg.Filter = "Pic Documents (.jpg)|*.jpg*";
                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {
                    string filename = dlg.FileName;
                    Per_pic_url.Text = filename;
                }

            });         
        }

        private void GetPersonelList()
        {
            ExceptionCatcher.ExceptionFinder(() => {
                DAL.DAL dal = new DAL.DAL();
                List<PersonelEntity> list = dal.GetPersoneList();
                gridcontrol_personel.ItemsSource = list;
            });
        }

        public void NewRecord()
        {
            ExceptionCatcher.ExceptionFinder(() => {
                if (gridPersonelForm.Visibility == Visibility.Collapsed)
                {
                    personelEntity = null;
                    gridPersonelForm.Visibility = Visibility.Visible;
                }
            });         
        }

        public void AddNewItem()
        {
            ExceptionCatcher.ExceptionFinder(() => {

                using (SDB sdbContext = new SDB())
                {
                    if (personelEntity == null)
                    {


                        Personel personel = new Personel();
                        personel.PersonelAd = personalName.Text;
                        personel.PersonelSoyad = personelLastname.Text;
                        personel.PersonelRoleID = chkboxAdmin.IsChecked.Value == true ? int.Parse(chkboxAdmin.Tag.ToString()) : chkboxUser.IsChecked.Value == true ? int.Parse(chkboxUser.Tag.ToString()) : int.Parse(chkboxUser2.Tag.ToString());
                        personel.PersonelUsername = personelUsername.Text;
                        personel.PersonelPassword = HashingHelper.HashingPassword(personelPassword.Text);

                        personel.PersonelPic = ImageHelper.ConvertImageToByte(Per_pic_url.Text);
                        DAL.DAL dal = new DAL.DAL();
                        dal.NewRecordPer(personel);

                        gridPersonelForm.Visibility = Visibility.Collapsed;
                        gridcontrol_personel.ItemsSource = null;
                        GetPersonelList();
                    }
                    else
                    {
                        Personel personel = new Personel();
                        personel.PersonelID = personelEntity.PersonelID;
                        personel.PersonelAd = personalName.Text;
                        personel.PersonelSoyad = personelLastname.Text;
                        personel.PersonelRoleID = chkboxAdmin.IsChecked.Value == true ? int.Parse(chkboxAdmin.Tag.ToString()) : chkboxUser.IsChecked.Value == true ? int.Parse(chkboxUser.Tag.ToString()) : int.Parse(chkboxUser2.Tag.ToString());
                        personel.PersonelUsername = personelUsername.Text;
                        personel.PersonelPassword = HashingHelper.HashingPassword(personelPassword.Text);
                        if (personelEntity.PersonelPic != null)
                        {
                            personel.PersonelPic = personelEntity.PersonelPic;
                        }


                        DAL.DAL dal = new DAL.DAL();
                        dal.UpdateRecordPer(personel);
                        MainWindow window = (MainWindow)Window.GetWindow(this);
                        window.RibbonController();
                        gridPersonelForm.Visibility = Visibility.Collapsed;
                        gridcontrol_personel.ItemsSource = null;
                        GetPersonelList();
                        ClearForm();
                    }
                }
            });            
        }

        public void EditItem()
        {
            ExceptionCatcher.ExceptionFinder(() => {
                gridPersonelForm.Visibility = Visibility.Visible;
                personalName.Text = personelEntity.PersonelAd;
                personelLastname.Text = personelEntity.PersonelSoyad;
                personelUsername.Text = personelEntity.PersonelUsername;
                personelPassword.Text = personelEntity.PersonelPassword;
                if (personelEntity.PersonelRoleID == int.Parse(chkboxAdmin.Tag.ToString()))
                {
                    chkboxAdmin.IsChecked = true;
                }
                if (personelEntity.PersonelRoleID == int.Parse(chkboxUser.Tag.ToString()))
                {
                    chkboxUser.IsChecked = true;
                }
                if (personelEntity.PersonelRoleID == int.Parse(chkboxUser2.Tag.ToString()))
                {
                    chkboxUser2.IsChecked = true;
                }

                per_image.Source = BL.ImageHelper.ConvertByteToImage(personelEntity.PersonelPic);
            });             
        }

        public void DeleteItem()
        {
            ExceptionCatcher.ExceptionFinder(() => {
                using (SDB sdb = new SDB())
                {
                    var personel = new Personel { PersonelID = personelEntity.PersonelID };
                    DAL.DAL dal = new DAL.DAL();
                    MessageBoxResult result = DXMessageBox.Show("Çalışan Silinecek Onaylıyor Musunuz?", "Uyarı", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes, MessageBoxOptions.None);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            dal.DeleteRecordPer(personel);
                            MessageBox.Show("Personel Silindi!");
                            gridcontrol_personel.ItemsSource = null;
                            GetPersonelList();
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
                gridPersonelForm.Visibility = Visibility.Collapsed;
                personalName.Text = null;
                personelLastname.Text = null;
                Per_pic_url.Text = null;
                personelUsername.Text = null;
                personelPassword.Text = null;
            });          
        }

        private void GridControl_SelectedItemChanged(object sender, DevExpress.Xpf.Grid.SelectedItemChangedEventArgs e)
        {
            personelEntity = (PersonelEntity)gridcontrol_personel.SelectedItem;
        }

        private void ClearForm()
        {
            ExceptionCatcher.ExceptionFinder(() => {
                personelEntity = null;
                personalName.Text = null;
                personelLastname.Text = null;
                Per_pic_url.Text = null;
                per_image.Source = null;
            });           
        }

        private void chkboxAdmin_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {

            if ((bool)e.NewValue == true)
            {
                chkboxUser.IsChecked = false;
                chkboxUser2.IsChecked = false;
            }
            else
            {
                chkboxAdmin.IsChecked = false;
            }
        }

        private void chkboxUser_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            if ((bool)e.NewValue == true)
            {
                chkboxAdmin.IsChecked = false;
                chkboxUser2.IsChecked = false;
            }
            else
            {
                chkboxAdmin.IsChecked = false;
            }
        }

        private void chkboxUser2_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            if ((bool)e.NewValue == true)
            {
                chkboxAdmin.IsChecked = false;
                chkboxUser.IsChecked = false;
            }
            else
            {
                chkboxUser2.IsChecked = false;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            window.RibbonController();
        }

        
    }
}
