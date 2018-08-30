using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _3S_MVCTask.Models;
using _3S_MVCTask.Repository;

namespace _3S_MVCTask.Controllers
{
    /// <summary>
    /// With this Controller you can make several Operations like show the Suppliers and also
    /// Add , Edit and delete products 
    /// One of the features in this controller is to get Products which the stock need to reorder them
    /// and also The product with minimum orders to stop order it from suppliers
    /// </summary>
    
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        //Get All Products 
        public ActionResult GetAllProDetails()
        {
            try
            {
                ProductsRepository ProRepo = new ProductsRepository();
                ModelState.Clear();
                return View(ProRepo.GetAllProducts());
            }
            catch (Exception ex)
            {
                LogError.Error(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        [HttpGet]
        public PartialViewResult Delete(int Id)
        {
            try
            {
                ProductsRepository proRepo = new ProductsRepository();
                ModelState.Clear();
                Products products = proRepo.GetProduct(Id);

                return PartialView(products);
            }
            catch (Exception ex)
            {
                LogError.Error(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                return PartialView("ErrorPage", "Home");
            }
        }

        //Delete Product
        [HttpPost]
        public ActionResult Delete(Products products)
        {
            try
            {
                ProductsRepository proRepo = new ProductsRepository();
                ModelState.Clear();
                int deleted = proRepo.DeleteProduct(products.Id);
                return RedirectToAction("GetAllProDetails", "Products");
            }
            catch (Exception ex)
            {
                LogError.Error(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                return RedirectToAction("ErrorPage", "Home");
            }
        }


        [HttpGet]
        public PartialViewResult Edit(int Id)
        {
            try
            {
                ProductsRepository proRepo = new ProductsRepository();
                ModelState.Clear();
                Products products = proRepo.GetProduct(Id);

                return PartialView(products);
            }
            catch (Exception ex)
            {
                LogError.Error(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                return PartialView("ErrorPage", "Home");
            }
        }

        //Edit Product
        [HttpPost]
        public ActionResult Edit(Products Product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductsRepository proRepo = new ProductsRepository();
                    ModelState.Clear();
                    int edite = proRepo.EditeProduct(Product);
                    return RedirectToAction("GetAllProDetails", "Products");
                }
                return View("GetAllProDetails");
            }
            catch (Exception ex)
            {
                LogError.Error(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                return RedirectToAction("ErrorPage", "Home");
            }
        }


        [HttpGet]
        public PartialViewResult Add()
        {

            return PartialView();

        }

        //Add Product
        [HttpPost]
        public ActionResult Add(Products product)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    ProductsRepository proRepo = new ProductsRepository();
                    ModelState.Clear();
                    int edite = proRepo.AddProduct(product);
                    return RedirectToAction("GetAllProDetails", "Products");
                }
                return View("GetAllProDetails");
            }
            catch (Exception ex)
            {
                LogError.Error(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        //search in products 
        public ActionResult Search()
        {
            try
            {
                ProductsRepository ProRepo = new ProductsRepository();
                ModelState.Clear();
                return View(ProRepo.GetAllProducts());
            }
            catch (Exception ex)
            {
                LogError.Error(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        //Products which the stock need to reorder them
        public ActionResult proReOrderLevel()
        {
            try
            {
                ProductsRepository ProRepo = new ProductsRepository();
                ModelState.Clear();
                return View(ProRepo.proReOrderLevel());
            }
            catch (Exception ex)
            {
                LogError.Error(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                return RedirectToAction("ErrorPage", "Home");
            }
        }


        //The product with minimum orders to stop order it from suppliers
        [HttpGet]
        public ActionResult proWithMinOrder()
        {
            try
            {
                ProductsRepository ProRepo = new ProductsRepository();
                ModelState.Clear();
                return View(ProRepo.proWithMinOrder());
            }
            catch (Exception ex)
            {
                LogError.Error(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                return RedirectToAction("ErrorPage", "Home");
            }
        }

    }
}