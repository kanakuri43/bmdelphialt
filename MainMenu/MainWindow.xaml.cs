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
using System.Data;
using MahApps.Metro.Controls;

namespace MainMenu
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow(int staffId)
        {
            InitializeComponent();

            Staff staff = new Staff(staffId);
            this.StaffNameTextBlock.Text = "Operator : " + staff.StaffName;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var f = new Login();
            f.Show();
            this.Close();
        }

        private void CustoemrsEditButton_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
