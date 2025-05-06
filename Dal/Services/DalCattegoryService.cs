using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class DalCattegoryService : IDalCattegory
    {

        dbcontext dbcontext;
        public DalCattegoryService(dbcontext data)
        {
            dbcontext = data;
        }
        public List<Cattegory> Get()
        {
            return dbcontext.Cattegories.ToList();
        }

        
    }
}
