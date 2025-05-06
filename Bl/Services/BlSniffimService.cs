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
    public class BlSniffimService : IBlSniffim
    {
        IDal dal;
        public BlSniffimService(IDal dal)
        {
            this.dal = dal;
        }

        public List<BlSniffim> Get()
        {
            var pList = dal.Sniffim.Get();
            List<BlSniffim> list = new();
            pList.ForEach(p => list.Add(new BlSniffim()
            { Id = p.Id, Name = p.Name, Address = p.Address,Telephone=p.Telephone }));
            return list;
        }
        public void Create(BlSniffim s)
        {
            Snif o = new Snif()
            {
                //Id = s.Id,
                Name = s.Name,
                Address = s.Address,
                Telephone =s.Telephone,
              
            };
            dal.Sniffim.Create(o);
        }
        public void Update(BlSniffim s)
        {
            Snif o = new Snif()
            {
                Id = s.Id,
                Name = s.Name,
                Address = s.Address,
                Telephone = s.Telephone,

            };
            dal.Sniffim.Update((o));
        }


    }
}
