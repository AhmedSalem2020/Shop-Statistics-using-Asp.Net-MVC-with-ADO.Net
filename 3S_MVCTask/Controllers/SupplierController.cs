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
    /// Add , Edit and delete suppliers 
    /// One of the features in this controller is to get the largest Supplier 
    /// </summary>

    public class SupplierController : Controller
    {
        // GET: Supplier
        public ActionResult Index()
        {
            return View();
        }

        //Get All Suppliers 
        public ActionResult GetAllSupplierDetails()
        {
            try
            {
                SupplierRepository SubRepo = new SupplierRepository();
                ModelState.Clear();
                return View(SubRepo.GetAllSuppliers());
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
                SupplierRepository SubRepo = new SupplierRepository();
                ModelState.Clear();
                Supplier supplier = SubRepo.GetSupplier(Id);

                return PartialView(supplier);
            }
            catch (Exception ex)
            {
                LogError.Error(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                return PartialView("ErrorPage", "Home");
            }
        }

        // Delete Supplier
        [HttpPost]
        public ActionResult Delete(Supplier supplier)
        {
            try
            {
                SupplierRepository SubRepo = new SupplierRepository();
                ModelState.Clear();
                int deleted = SubRepo.DeleteSupplier(supplier.Id);
                return RedirectToAction("GetAllSupplierDetails", "Supplier");
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
                SupplierRepository subRepo = new SupplierRepository();
                ModelState.Clear();
                Supplier supplier = subRepo.GetSupplier(Id);
                return PartialView(supplier);
            }
            catch (Exception ex)
            {
                LogError.Error(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                return PartialView("ErrorPage", "Home");
            }
        }

        // Edit Supplier
        [HttpPost]
        public ActionResult Edit(Supplier supplier)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SupplierRepository subRepo = new SupplierRepository();
                    ModelState.Clear();
                    int edite = subRepo.EditeSupplier(supplier);
                    return RedirectToAction("GetAllSupplierDetails", "Supplier");
                }
                return View();
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

        // Add a New Supplier
        [HttpPost]
        public ActionResult Add(Supplier supplier)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SupplierRepository subRepo = new SupplierRepository();
                    ModelState.Clear();
                    int edite = subRepo.AddSupplier(supplier);
                    return RedirectToAction("GetAllSupplierDetails", "Supplier");
                }
                return View("GetAllSupplierDetails");
            }
            catch (Exception ex)
            {
                LogError.Error(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        //The largest supplier of store
        public ActionResult largestSupplier()
        {
            try
            {
                SupplierRepository subRepo = new SupplierRepository();
                ModelState.Clear();
                return View(subRepo.largestSupplier());
            }
            catch (Exception ex)
            {
                LogError.Error(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        

    }
}