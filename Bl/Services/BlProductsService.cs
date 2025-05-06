using Bl;
using BL.Api;
using BL.Models;
using Dal.Api;
using Dal.Models;


namespace BL.Services
{
    public class BlProductsService : IBlProducts
    {
        IDal dal;

        IBlProductsMain pm;
        public BlProductsService(IDal dal,IBlProductsMain pm)
        {
            this.dal = dal;
            this.pm = pm;
        }
        public void Update(BlProduct p)
        {
            dal.Products.Update(BlProdtoProdItem(p));
        }
        public void Create(BlProduct p)
        {
            Product o = new Product()
            {
                Name = p.Name,
                Details = p.Details,
                Url = p.Name,
                IdCattegory= (int)p.IdCattegory
            };
            dal.Products.Create(o);
        }

        public List<BlProduct> Get()
        {
            var pList = dal.Products.Get();
            List<BlProduct> list = new();
            pList.ForEach(async p => list.Add(new BlProduct()
            { Id = p.Id, Name = p.Name, IdCattegory = p.IdCattegory, Details = p.Details, ProductsMains = await ((BlProductsMainService)pm).prodtoBlProdAsync(p.ProductsMains.ToList()),IdCattegoryNavigation= cattToBlCatt(p.IdCattegoryNavigation),Url=p.Url }));
            return list;
        }
       
           
        


        public List<BlProduct> GetByCattegory(int cat)
        {
            var pList = dal.Products.GetByCattegory(cat);
            List<BlProduct> list = new();
            pList.ForEach(p => list.Add(new BlProduct()
            { Id = p.Id, Name = p.Name, IdCattegory = p.IdCattegory,Url=p.Url,Details=p.Details, IdCattegoryNavigation = cattToBlCatt(p.IdCattegoryNavigation) }));
            return list;
        }

        public BlProduct GetById(int id)
        {
            var p = dal.Products.GetById(id);
           BlProduct p1 = new()
           { Id=p.Id, Name = p.Name, IdCattegory = p.IdCattegory,ProductsMains = ((BlProductsMainService)pm).prodtoBlProd(p.ProductsMains.ToList())};
            return p1;
        }

        public Product BlProdtoProdItem(BlProduct item)
        {

            Product itm = new() 
            { Id = item.Id, IdCattegory=item.IdCattegory,Name=item.Name,Details=item.Details };

            return itm;
        }
        public BlCattegory cattToBlCatt(Cattegory item)
        {

            BlCattegory itm = new()
            { Id = item.Id, Name = item.Name };

            return itm;
        }
    }
}
