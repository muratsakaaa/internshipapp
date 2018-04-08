using DAL.cs;
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
using System.Windows.Navigation;

namespace InternshipApp
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        Personel model = new Personel();
       

        public Login()
        {
            InitializeComponent();
        }

      

        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
           
           model.PersonelUsername = LoginUsername.Text;
           model.PersonelPassword = LoginPassword.Password;
           
            using (SDB sdbContext =new SDB())
            {
                foreach (var person in sdbContext.Personels)

                {
                    if ( person.PersonelUsername.Trim() == LoginUsername.Text  && person.PersonelPassword.Trim() == LoginPassword.Password)
                    {

                        Mainpage mainpage = new Mainpage();
                        mainpage.Show();
                        this.Close();

                      //  MessageBox.Show("Kullanıcı Girişi Başarılı");
                       
                    }
                    else
                    { 

                       // MessageBox.Show("Başarısız!");
                    }
                }
            }
        }
    }
}
