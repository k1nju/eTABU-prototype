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
        public ObservableCollection<User> Users { get => Users; set { Users = value; OnPropertyChanged("Users"); } }
        public ObservableCollection<Synonim> Words { get => Words; set { Words = value; OnPropertyChanged("Words"); } }
        public string MainWord { get; set; }
        public Window3()
        {

            InitializeComponent();
            Users = new ObservableCollection<User>(new List<User> {
                new User()
        {
            Id = 1,
            Login = "zxc",
            Password = "qwe"
        },      new User()
        {
            Id = 1,
            Login = "zxc",
            Password = "qwe"
        },      new User()
        {
            Id = 1,
            Login = "zxc",
            Password = "qwe"
        },      new User()
        {
            Id = 1,
            Login = "zxc",
            Password = "qwe"
        }

        });
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
            Words = new ObservableCollection<Synonim>(new List<Synonim> { new Synonim(tmp.Synonim1), new Synonim(tmp.Synonim1), new Synonim(tmp.Synonim1), new Synonim(tmp.Synonim1), new Synonim(tmp.Synonim1)  }) ;
        }

    }

    public class Synonim
    {
        public Synonim(string synonim1)
        {
            Title = synonim1;
        }

        public string Title{ get; set; }
    }
}
