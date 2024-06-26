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

namespace eTABUApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Add your code here
        }

        private void txtpassword_textchanged(object sender, TextChangedEventArgs e)
        {
            // Add your code here
        }

        private void loginbutton_click(object sender, RoutedEventArgs e)
        {
            // Add your code here
        }

        private void registerbutton_click(object sender, RoutedEventArgs e)
        {
            // Add your code here
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            // window1.Show(); // Win10 tablet in tablet mode, use this, when sub Window is closed, the main window will be covered by the Start menu.
            window2.Show();
            this.Close();
        }
    }
}