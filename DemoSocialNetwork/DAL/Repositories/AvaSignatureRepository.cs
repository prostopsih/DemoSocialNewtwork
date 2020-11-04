using DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AvaSignatureRepository : BaseGenericRepository<AvaSignature>
    {
        public AvaSignatureRepository(DbContext context) : base(context)
        {
        }
    }
}
