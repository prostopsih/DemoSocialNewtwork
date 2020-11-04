using DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : BaseGenericRepository<User>
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
    }
}
