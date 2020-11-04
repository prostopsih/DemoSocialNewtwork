using DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AvatarRepository : BaseGenericRepository<Avatar>
    {
        public AvatarRepository(DbContext context) : base(context)
        {

        }
    }
}
