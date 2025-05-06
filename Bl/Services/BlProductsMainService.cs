using Bl;
using BL.Api;
using BL.Models;
using Dal.Api;
using Dal.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace BL.Services
{
    public class BlProductsMainService : IBlProductsMain
    {
        IDal dal;
        public BlProductsMainService(IDal dal)
        {
            this.dal = dal;
        }

        //public void Create(BlProductsMain p)
        //{
        //    ProductsMain o = new ProductsMain()
        //    {
        //        Id = p.Id,
        //        IdSnif = p.IdSnif,
        //        Price = p.Price,
        //        Available = p.Available,
        //        IdProduct = p.IdProduct,
        //        CanBeUsed = p.CanBeUsed

        //    };
        //    dal.ProductsMain.Create(o);
        //}

        public async Task CreateAsync(BlProductsMain p)
        {
            ProductsMain o = new ProductsMain()
            {
                Id = p.Id,
                IdSnif = p.IdSnif,
                Price = p.Price,
                Available = p.Available,
                IdProduct = p.IdProduct,
                CanBeUsed = p.CanBeUsed

            };


            await dal.ProductsMain.CreateAsync(o);
        }

        public void Update(int p)
        {
            dal.ProductsMain.Update(p);
        }
        public BlSniffim sniftoBlSnif(Snif item)
        {
            if (item!=null) { 
            BlSniffim itm = new()
            { Id = item.Id, Name = item.Name, Address = item.Address, Telephone = item.Telephone };

            return itm;}
            return null;

        }
        public BlProduct prodtoBlProd1(Product p)
        {
            if(p!=null) { 

            BlProduct newp = new BlProduct()
            { Id = p.Id,Details=p.Details,IdCattegory=p.IdCattegory,Name=p.Name,Url=p.Url };
            return newp;}
            return null;
        }
        public async Task<List<BlProductsMain>> prodtoBlProdAsync(List<ProductsMain> products)
        {
            List<BlProductsMain> list = new();
            products.ForEach(p => list.Add(new BlProductsMain()
            { Id = p.Id, IdProduct = (int)p.IdProduct, IdSnif = p.IdSnif, Available = p.Available, Price = p.Price, DayTaken = p.DayTaken, CanBeUsed = (bool)p.CanBeUsed, IdSnifNavigation = sniftoBlSnif(p.IdSnifNavigation), IdProductNavigation = prodtoBlProd1(p.IdProductNavigation) }));
            return list;
        }
        public List<BlProductsMain> prodtoBlProd(List<ProductsMain> lst)
        {

            List<BlProductsMain> list = new();
            lst.ForEach(p => list.Add(new BlProductsMain()
            { Id = p.Id, IdProduct = (int)p.IdProduct, IdSnif = p.IdSnif, Available = p.Available, Price = p.Price, DayTaken = p.DayTaken, CanBeUsed = (bool)p.CanBeUsed, IdSnifNavigation = sniftoBlSnif(p.IdSnifNavigation), IdProductNavigation = prodtoBlProd1(p.IdProductNavigation) }));
            return list;
        }
        public List<ProductsMain> BlProdtoProd(List<BlProductsMain> lst)
        {
            List<ProductsMain> list = new();
            lst.ForEach(p => list.Add(new ProductsMain()
            { Id = p.Id, IdProduct = p.IdProduct, IdSnif = p.IdSnif, Available = p.Available, Price = p.Price,DayTaken=p.DayTaken }));
            return list;
        }
        public ProductsMain BlProdtoProdItem(BlProductsMain item)
        {
            ProductsMain itm = new() { Id = item.Id, IdProduct = item.IdProduct, IdSnif = item.IdSnif, Available = item.Available, Price = item.Price,DayTaken = item.DayTaken};
            return itm;
        }

        public List<BlProductsMain> GetByIdProduct(int id)
        {
            return prodtoBlProd(dal.ProductsMain.GetByIdProduct(id));
        }

      

        public List<BlProductsMain> Get()
        {
            var pList = dal.ProductsMain.Get();
            List<BlProductsMain> list = prodtoBlProd(pList);
            return list;
        }

        public void notUse(int p)
        {
            dal.ProductsMain.notUse(p);
        }
    }
}
