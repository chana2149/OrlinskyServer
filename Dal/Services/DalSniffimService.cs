using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal.Models;
using System.Threading.Tasks;
using Dal.Api;
using Microsoft.EntityFrameworkCore;

namespace Dal.Services
{
    public class DalSniffimService:IDalSniffim
    {
        dbcontext dbcontext;
        public DalSniffimService(dbcontext data)
        {
            dbcontext = data;
        }
        public List<Snif> Get()
        {
            return dbcontext.Snifs.ToList();
     
        }


        public void Create(Snif s)
        {
            dbcontext.Snifs.Add(s);
            dbcontext.SaveChanges();
        }
       


        public void Update(Snif snif1)
        {
            Console.WriteLine(snif1.Name);
            Snif? snif2 = Get().Find(s => s.Id == snif1.Id);
            if (snif2 != null)
            {
                snif2.Address = snif1.Address;
                snif2.Telephone = snif1.Telephone; 
                snif2.Name = snif1.Name;
            }
            Console.WriteLine(snif2.Name);
            dbcontext.SaveChanges();
        }
    }
}
