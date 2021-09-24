using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week12ProductsProject.Models;

namespace Week12ProductsProject.Services
{
    public interface IProductRepository
    {
        public Product GetProduct(int id);//returns 1 Product found with id
        public IEnumerable<Product> GetProduct();//this give you list of all meployees
        public Product AddProduct(Product p);//adding an Product
        public Product UpdateProduct(Product prodchanges);//any changes you made will be reflected
        public Product DeleteProduct(int id);//want to have a reference to show the user to what Product you deleted but might not use this returned Product
        // still performing the function of deleting a Product
    }
}
