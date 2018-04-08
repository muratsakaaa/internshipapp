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
using System.Windows.Shapes;
using DAL;
using BL;
using Logging;

namespace SatisUI.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();           
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            ExceptionCatcher.ExceptionFinder(() => {
                if (txtedit_username.Text.Length == 0 || txtbox_password.Text.Length == 0)
                {
                    MessageBox.Show("Lütfen Kullanıcı Adı ve Şifre Giriniz!");
                }
                else
                {
                    using (SDB sdb = new SDB())
                    {
                        var hashpassword = HashingHelper.HashingPassword(txtbox_password.Text);
                        Personel personel = (from p in sdb.Personels where p.PersonelUsername == txtedit_username.Text && p.PersonelPassword == hashpassword select p).Single();

                        if (personel != null)
                        {
                            BL.AuthenticateHelperr.LoginUser.Add(personel);
                            AuthenticateHelperr.LoginUser.Add(new Personel
                            {
                                PersonelID = personel.PersonelID,
                                PersonelAd = personel.PersonelAd,
                                PersonelSoyad = personel.PersonelSoyad,
                                PersonelRoleID = personel.PersonelRoleID
                            });
                            NLogger.GetLogItems(null,InfoLogTypes.LoginLogout,DateTime.UtcNow,UserAuthenticationStatus.Login,$"{personel.PersonelAd} {personel.PersonelSoyad}");
                            MainWindow mainWindow = new MainWindow();
                            this.Close();
                            mainWindow.Show();

                        }
                        else
                        {
                            MessageBox.Show("KullanıcıAdı veya Şifre Hatalı!");
                        }

                    }
                }
            });                                 
        }
    }
}
