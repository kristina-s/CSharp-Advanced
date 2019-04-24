using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_shop.Models
{
    public class User
    {
        public string Name { get; set; }

        public Order ListOrder { get; set; } = new Order();

        public User(string name)
        {
            Name = name;
        }

    }
}
