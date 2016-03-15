using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace revures.model
{
    class Users
    {
        public int    id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public virtual List<Users> users { get; set; }
    }
}
