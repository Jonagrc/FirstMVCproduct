using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Week12ProductsProject.Models
{
    public class ProductContext:DbContext
    {
        //calling Dbcontext constructor with options / DBcontextneeds to understand what we are connecting to DB in this case ProductContext
        //other words HEY use this prdloyecontext class
        //ProductContext wont behave like a DBcontext(database) if you dont inhereit from it /so you must inherit and keep the options
        public ProductContext(DbContextOptions<ProductContext> options)
            :base(options)//this is calling the constructor of the base class(dbcontext)
        {

        }

        public DbSet<Product> Products { get; set; } //THIS IS THE TABLE

        //ModelBuilder helps build a new table / overriden so we can make a new table
        //creates columns and rows ----------- properties == columns
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {//making a model 
                    ProductId = 1,
                    ProductName = "Azure",
                    ProductStock = 5,
                    ProductType = ProdType.Cloud,

                },
                new Product
                {//making a model 
                        ProductId = 2,
                        ProductName = "Bing",
                        ProductStock = 25,
                        ProductType = ProdType.Engine,

                }
                );
        }

    }
}
