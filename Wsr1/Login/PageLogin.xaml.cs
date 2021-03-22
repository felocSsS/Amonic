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
using Wsr1.BD;
using Wsr1.User;

namespace Wsr1.Login
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        private void btnSingIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var Info = DB.database.Users.FirstOrDefault(
                    x => x.Email == tbLogin.Text && x.Password == pbPassword.Password);
                if(Info != null)
                {
                    //Activity userTimeInfo = new Activity()
                    //{
                    //    UserID = Info.ID,
                    //   Date = DateTime.Today,
                    //    TimeLogin = TimeSpan.now,
                    //};
                    switch (Info.RoleID)
                    {
                        case 1:
                            SupClass.frm.Navigate(new PageAdmin());
                            break;
                        case 2:
                            SupClass.frm.Navigate(new PageUser());
                            break;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
