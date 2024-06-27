using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace eTABUApp
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2: Window
    {
        private int counter = 0;
        public ObservableCollection<User> Users { get; set; }
        public Window2()
        {
            InitializeComponent();
            Users = new ObservableCollection<User>();
            lstUsers.ItemsSource = Users;
        }
        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            if (!string.IsNullOrWhiteSpace(username))
            {
                Users.Add(new User(counter,username));
                counter++;
                txtUsername.Text = "";
            }
        }

        private void lstUsers_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lstUsers.SelectedItem != null)
            {
                btnDeleteUser.Visibility = Visibility.Visible;
            }
            else
            {
                btnDeleteUser.Visibility = Visibility.Collapsed;
            }
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = lstUsers.SelectedItem as User;
            Users.Remove(selectedUser);
            btnDeleteUser.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window3 window3 = new Window3(Users.ToList());
            // window1.Show(); // Win10 tablet in tablet mode, use this, when sub Window is closed, the main window will be covered by the Start menu.
            window3.Show();
            this.Close();
        }
    }

}

