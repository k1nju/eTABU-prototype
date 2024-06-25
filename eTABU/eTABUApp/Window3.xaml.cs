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
    public partial class Window3 : Window
    {
        MainViewModel vm;
        public Window3()
        {
            vm = new MainViewModel(new List<User>() { new User("Tom"), new User("Bob") , new User("Alice") , new User("Roman") });
            InitializeComponent();
            DataContext = vm;
        }

    }

    
}
