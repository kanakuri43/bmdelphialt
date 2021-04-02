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
using System.Data;
using MahApps.Metro.Controls;

namespace MainMenu
{
    /// <summary>
    /// Login.xaml の相互作用ロジック
    /// </summary>
    public partial class Login : MetroWindow
    {
        public Login()
        {
            InitializeComponent();
        }

        private bool TryLogin(string staffId, String password)
        {
            DataTable dt = new DataTable();

            var dc = new DatabaseController();
            dc.SQL = "SELECT * FROM M入力者 "
                    + "WHERE "
                    + " 削除区分 = 0 "
                    + " AND 入力者コード = '" + staffId + "'"
                    + " AND パスワード = '" + password + "'";
            dt = dc.ReadAsDataTable();

            if (dt.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.message.Text = "";

            if (this.userIdTextBox.Text == "")
            {
                this.userIdTextBox.Focus();
                this.message.Text = "User ID を入力してください。";
                return;
            }

            if (TryLogin(this.userIdTextBox.Text, this.passwordTextbox.Password))
            {
                var f = new MainWindow(int.Parse(this.userIdTextBox.Text));
                f.Show();
                this.Close();
            }
            else
            {
                this.message.Text = "User ID または Password が違います。";
            }


        }

        private void passwordTextbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.userIdTextBox.Text != "" & this.passwordTextbox.Password != "")
            {
                this.loginButton.IsEnabled = true;
            }
            else
            {
                this.loginButton.IsEnabled = false;
            }
        }
    }
}
