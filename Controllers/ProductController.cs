using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week12ProductsProject.Services;
using Week12ProductsProject.Models;

namespace Week12ProductsProject.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository _productRepository;//initialize the interface
        public ProductController(IProductRepository repository)
        {
            _productRepository = repository;
        }
        public IActionResult ProductList()
        {//this will show you all Products in table format
            var model = _productRepository.GetProduct();
            return View(model);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product obj)
        {
            if (ModelState.IsValid)
            {
                Product newproduct = _productRepository.AddProduct(obj);
                return RedirectToAction("ProductList");
            }
            return View();
        }
        [HttpGet]
        public ViewResult Update(int id)
        {
            Product prodchanges = _productRepository.GetProduct(id);//getting selected product by id 
            return View(prodchanges);//then sending that object of product to the view with the properties in the text boxes
        }
        [HttpPost]
        public ViewResult Update(Product obj,int id)
        {
            //this will show you all Products in table format 
            obj.ProductId = id;
            Product prodchanges = _productRepository.UpdateProduct(obj);
            var model = _productRepository.GetProduct();//need to pass model == new list 
            return View("ProductList", model);
        }
        public IActionResult Delete(int id)
        {
            _productRepository.DeleteProduct(id); //sending obj with specific id to delete method and then returning to product list to show changes 
            return RedirectToAction("ProductList");
        }



        public IActionResult DisplayAll()
        {
            //creating array of products here HARD coded ,used to print out the products
            ViewBag.Productlist = new string[] { "Azure", "Bing", "MicrosoftOffice", "WindowsXP", "Xbox360" };
            //ViewBag.Productlist = _productRepository.GetProduct();
            return View("AllProducts");
        }
        public IActionResult Details(string prodname)
        {
            //selecting the product by product name that was clicked to show the product details
            ViewBag.selectedproduct = prodname;
            return View();
        }
        public IActionResult GetImage(string prodname)
        {
            //returns browers wtth the images//method tht return img
            return File($@"\images\{prodname.ToLower()}.jpg", "image/jpg"); 
        }
    }
}
