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

namespace Wsr1
{
    /// <summary>
    /// Логика взаимодействия для PageAdmin.xaml
    /// </summary>
    public partial class PageAdmin : Page
    {
        public PageAdmin()
        {
            InitializeComponent();
            AdminDataGrid.ItemsSource = BD.DB.database.Users.ToList();
        }

        private void cmbOffice_DropDownOpened(object sender, EventArgs e)
        {
            cmbOffice.Items.Clear();
            var Oficces = BD.DB.database.Offices.ToList();
            foreach(BD.Offices office in Oficces)
            {
                cmbOffice.Items.Add(office.Title);
            }
        }

        private void cmbOffice_DropDownClosed(object sender, EventArgs e)
        {
            AdminDataGrid.ItemsSource = BD.DB.database.Users.Where(x => x.Offices.Title == cmbOffice.Text).ToList();
        }
    }
}
