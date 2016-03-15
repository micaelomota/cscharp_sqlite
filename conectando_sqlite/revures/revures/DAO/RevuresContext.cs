using revures.model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace revures.DAO
{
    class RevuresContext : DbContext
    {
        public RevuresContext()	: base("name=DefaultConnection")
		{
        }

        public DbSet<Users> Users { get; set; }

    }
}
