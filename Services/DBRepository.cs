using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week12ProductsProject.Models;

namespace Week12ProductsProject.Services
{
    public class DBRepository : IProductRepository
    {
            private ProductContext ProductContext; //variable of Database
            public DBRepository(ProductContext context)
            {//initialize prdloyecontext when this is called
                ProductContext = context;
            }
            public Product AddProduct(Product p)
            {//adding Product to elist
                p.ProductId = ProductContext.Products.Max(p => p.ProductId) + 1;//adding the new prd to the next id (autoincrement logic)
                ProductContext.Products.Add(p);
                ProductContext.SaveChanges();
                return p;
            }

            public Product DeleteProduct(int id)
            {
                Product prd = ProductContext.Products.FirstOrDefault(e => e.ProductId == id); //selecting the Product tthat we selecting
                if (prd != null)
                {//if its not null then remove from list
                    ProductContext.Products.Remove(prd);
                    ProductContext.SaveChanges();
                }
                return prd;
            }

            public Product GetProduct(int id)
            {//searching and then getiing Product by id
                return ProductContext.Products.FirstOrDefault(p => p.ProductId == id); //selecting the Product tthat we selecting/getting reference then returning it back 
            }
            public IEnumerable<Product> GetProduct()
            {
            return ProductContext.Products.ToList(); //returning the Products so need to get it as a list
            }

            public Product UpdateProduct(Product prodchanges)
            {
                Product prd = ProductContext.Products.FirstOrDefault(e => e.ProductId == prodchanges.ProductId); //selecting the Product tthat we updating by both id
                if (prd != null)
                {//assigning what is in the prodchanges to the current prd
                    prd.ProductName = prodchanges.ProductName;
                    prd.Description = prodchanges.Description;
                    prd.ProductStock = prodchanges.ProductStock;
                    prd.ProductType = prodchanges.ProductType;
                
                    ProductContext.SaveChanges();

                }
                return prd;
            }



    }
}
