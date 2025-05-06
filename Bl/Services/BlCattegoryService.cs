using BL.Api;
using BL.Models;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BlCattegoryService : IBlCattegory
    {
        IDal dal;
        public BlCattegoryService(IDal dal)
        {
            this.dal = dal;
        }

        public List<BlCattegory> Get()
        {
            var pList = dal.Cattegory.Get();
            List<BlCattegory> list = new();
            pList.ForEach(p => list.Add(new BlCattegory()
            { Id = p.Id, Name = p.Name}));
            return list;
        }


    }
}
