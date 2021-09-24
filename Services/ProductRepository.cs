using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week12ProductsProject.Models;

namespace Week12ProductsProject.Services
{
    public class ProductRepository : IProductRepository
    {
        //here we are creating a list to use internally
        private List<Product> _plist;
        public ProductRepository()
        {//constructor will be called only one if using singleton
            _plist = new List<Product>()
            {/*initiazing the elist here------------ tprd data to work with*/
                new Product() {ProductId=1001,ProductName="Azure",Description="Cloud Services",ProductStock=5,ProductType = ProdType.Cloud},
                new Product() {ProductId=1002,ProductName="Bing",Description="Search Engine",ProductStock=8,ProductType = ProdType.Engine},
                new Product() {ProductId=1003,ProductName="Microsoft Office",Description="Office tools",ProductStock=50,ProductType = ProdType.Software},
                new Product() {ProductId=1004,ProductName="WindowsXP",Description="Windows",ProductStock=25,ProductType = ProdType.Software},
                new Product() {ProductId=1005,ProductName="Xbox360",Description="Game",ProductStock=2,ProductType = ProdType.Game},
            };
        }
        public Product AddProduct(Product p)
        {
            p.ProductId = _plist.Max(p => p.ProductId) + 1;
            _plist.Add(p);
            return p;
        }

        public Product DeleteProduct(int id)
        {
            Product prodchanges = _plist.FirstOrDefault(p => p.ProductId == id);
            if (prodchanges != null)
            {
                _plist.Remove(prodchanges);
            }
            return prodchanges;
        }
        
        public Product GetProduct(int id)
        {//searching and then getiing Product by id
            return _plist.FirstOrDefault(p => p.ProductId == id);
        }

        public IEnumerable<Product> GetProduct()
        {
            return _plist;//returning the _elist 

        }

        public Product UpdateProduct(Product prodchanges)
        {
            Product prd = _plist.FirstOrDefault(p => p.ProductId == prodchanges.ProductId);//selecting the Product tthat we updating by both id
            if (prd != null)
            {//assigning what is in the prodchanges to the current prd
                prd.ProductName = prodchanges.ProductName;
                prd.Description = prodchanges.Description;
                prd.ProductStock = prodchanges.ProductStock;
                prd.ProductType = prodchanges.ProductType;
            
            }
            return prodchanges;
        }
    }
}
