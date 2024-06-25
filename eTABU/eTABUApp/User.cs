using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTABUApp
{
    public class User
    {
        public User(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }
        public int Score { get; set; }

    }
}
