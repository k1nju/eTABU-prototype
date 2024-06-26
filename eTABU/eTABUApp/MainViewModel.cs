using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTABUApp.Core;
using NuGet.Packaging.Signing;

namespace eTABUApp
{
    public class Synonim
    {
        public Synonim(string synonim1)
        {
            Title = synonim1;
        }

        public string Title { get; set; }
    }
    public class MainViewModel : ObservableObject
    {
        private List<eTABU> TabuList { get; set; }
        private ObservableCollection<User> _users;
        private string _word;
        private ObservableCollection<Synonim> _synonims;
        public ObservableCollection<User> Users { get => _users; set { _users = value; OnPropertyChanged("Users"); } }
        public ObservableCollection<Synonim> Words { get => _synonims; set { _synonims = value; OnPropertyChanged("Words"); } }
        public string MainWord { get =>_word; set { _word = value; OnPropertyChanged("MainWord"); } }

        private User _selectedPlayer;
        public User SelectedPlayer { get => _selectedPlayer; set { _selectedPlayer = value; OnPropertyChanged("SelectedPlayer"); } }

        public MainViewModel(List<User> users)
        {
            Users = new ObservableCollection<User>(users);
            Task.Run(() => Init()).Wait();
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
            Words = new ObservableCollection<Synonim>(new List<Synonim> { new Synonim(tmp.Synonim1), new Synonim(tmp.Synonim2), new Synonim(tmp.Synonim3), new Synonim(tmp.Synonim4), new Synonim(tmp.Synonim5) });
        }

        private RelayCommand _testCommand;
        public RelayCommand TestCommand
        {
            get
            {
                return _testCommand ??
                  (_testCommand = new RelayCommand(obj =>
                  {
                      NextTabu();
                  }));
            }
        }
        private RelayCommand _nextCommand;
        public RelayCommand NextTabuCommand
        {
            get
            {
                return _nextCommand ??
                  (_nextCommand = new RelayCommand(obj =>
                  {
                      NextTabu();
                  }));
            }
        }

        private RelayCommand _addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??
                  (_addCommand = new RelayCommand(obj =>
                  {
                      List<User> tmp = Users.Select(x=>x).ToList();
                      int ind = Users.ToList().FindIndex(x => x.Id == SelectedPlayer.Id);
                      tmp[ind].Score++;
                      Users = new ObservableCollection<User>( tmp);
                  }));
            }
        }
    }
}
