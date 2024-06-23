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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        private List<eTABU> TabuList { get; set; }
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<string> Words { get; set; }
        public string MainWord { get; set; }
        public Window3(List<User> users)
        {

            InitializeComponent();
            Users = new ObservableCollection<User>(users);
            lstUsers.ItemsSource = Users;
            Init();
        }

        private async Task Init()
        {
            eTABUDataSource dataSource = new eTABUDataSource();
            TabuList = await dataSource.GetTABUs();
            NextTabu();
        }

        private void NextTabu()
        {
            Random rand = new Random();
            eTABU tmp = TabuList[rand.Next(TabuList.Count)];
            MainWord = tmp.Mainword;
            Words = new ObservableCollection<string>(new List<string> { tmp.Synonim1, tmp.Synonim2, tmp.Synonim3, tmp.Synonim4, tmp.Synonim5 }) ;


        }
    }
}
