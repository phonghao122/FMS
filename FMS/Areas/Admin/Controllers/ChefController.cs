using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FMS.Models;
using System.Web.Security;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace FMS.Areas.Admin.Controllers
{
    public class ChefController : Controller
    {
        // GET: Admin/Chef
        db_FMSEntities db = new db_FMSEntities();
        //Manage menu
        public ActionResult ManageMenu()
        {
            return View(db.MENU.ToList());
        }
        public ActionResult Addfood()
        {
            return View(new FoodValidate());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Addfood(FoodValidate fv)
        {
            var checkfd = db.MENU.Any(x => x.C_Food_id == fv.FoodID);
            if (checkfd == false)
            {
                MENU adfd = new MENU();
                adfd.C_Food_id = fv.FoodID;
                adfd.C_Food_name = fv.FoodName;
                adfd.C_Description = fv.FoodDescrip;
                db.MENU.Add(adfd);
                db.SaveChanges();
                return Redirect("~/admin/Chef/ManageMenu");
            }
            else
            {
                ViewBag.err = "Food already exist";
                return View(fv);
            }
        }
        public ActionResult Deletefood(String id)
        {
            var fd = db.MENU.Where(n => n.C_Food_id == id).FirstOrDefault();
            if (fd != null)
            {
                db.MENU.Remove(fd);
                db.SaveChanges();
                return Redirect("~/admin/Chef/ManageMenu");
            }
            return Redirect("~/admin/Chef/ManageMenu");
        }
        //Manage supplier
        public ActionResult ManageSupp()
        {
            return View(db.SUPPLIER.ToList());
        }
        public ActionResult Addsupplier()
        {
            return View(new SupplierValidate());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Addsupplier(SupplierValidate sp)
        {
            var checksp = db.SUPPLIER.Any(x => x.C_Supplier_id == sp.SupplierID);
            if (checksp == false)
            {
                SUPPLIER spadd = new SUPPLIER();
                spadd.C_Supplier_id = sp.SupplierID;
                spadd.C_Supplier_name = sp.SupplierName;
                spadd.C_Supplier_phone = sp.SupplierPhone;
                spadd.C_Supplier_address = sp.SupplierAddress;
                db.SUPPLIER.Add(spadd);
                db.SaveChanges();
                return Redirect("~/admin/Chef/ManageSupp");
            }
            else
            {
                ViewBag.err = "Supplier already exist";
                return View(sp);
            }
        }
        public ActionResult Updatefood(String id)
        {
            var checksp = db.MENU.Where(n => n.C_Food_id == id).FirstOrDefault();
            FoodValidate sp = new FoodValidate();
            sp.FoodID = checksp.C_Food_id;
            sp.FoodName = checksp.C_Food_name;
            sp.FoodDescrip = checksp.C_Description;
            return View(sp);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Updatefood(FoodValidate sp)
        {
            var checksp = db.MENU.Where(x => x.C_Food_id == sp.FoodID).FirstOrDefault();
            if (checksp != null)
            {
                checksp.C_Food_name = sp.FoodName;
                checksp.C_Description = sp.FoodDescrip;
                db.SaveChanges();
                return Redirect("~/admin/Chef/ManageMenu");
            }
            else
            {
                ViewBag.err = "Food do not exist";
                return View(sp);
            }
        }
        public ActionResult Updatesupplier(String id)
        {
            var checksp = db.SUPPLIER.Where(n => n.C_Supplier_id == id).FirstOrDefault();
            SupplierValidate sp = new SupplierValidate();
            sp.SupplierID = checksp.C_Supplier_id;
            sp.SupplierName = checksp.C_Supplier_name;
            sp.SupplierPhone = checksp.C_Supplier_phone;
            sp.SupplierAddress = checksp.C_Supplier_address;
            return View(sp);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Updatesupplier(SupplierValidate sp)
        {
            var checksp = db.SUPPLIER.Where(x => x.C_Supplier_id == sp.SupplierID).FirstOrDefault();
            if (checksp != null)
            {
                checksp.C_Supplier_id = sp.SupplierID;
                checksp.C_Supplier_name = sp.SupplierName;
                checksp.C_Supplier_phone = sp.SupplierPhone;
                checksp.C_Supplier_address = sp.SupplierAddress;
                db.SaveChanges();
                return Redirect("~/admin/Chef/ManageSupp");
            }
            else
            {
                ViewBag.err = "Supplier do not exist";
                return View(sp);
            }
        }
        public ActionResult DeleteSupp(String id)
        {
            var fd = db.SUPPLIER.Where(n => n.C_Supplier_id == id).FirstOrDefault();
            if (fd != null)
            {
                db.SUPPLIER.Remove(fd);
                db.SaveChanges();
                return Redirect("~/admin/Chef/ManageSupp");
            }
            return Redirect("~/admin/Chef/ManageSupp");
        }
        //Manage Material
        public ActionResult ManageMaterial()
        {
            return View(db.INGREDIENT.ToList());
        }
        public ActionResult Addmaterial()
        {
            return View(new MaterialValidate());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Addmaterial(MaterialValidate mr)
        {
            var checkma = db.INGREDIENT.Any(x => x.C_Material_id == mr.MaterialID);
            if (checkma == false)
            {
                INGREDIENT mrAdd = new INGREDIENT();
                mrAdd.C_Material_id = mr.MaterialID;
                mrAdd.C_Material_name = mr.MaterialName;
                mrAdd.C_Quantity_I = mr.MaterialQT;
                mrAdd.C_Unit = mr.MaterialUnit;
                db.INGREDIENT.Add(mrAdd);
                db.SaveChanges();
                return Redirect("~/Admin/Chef/ManageMaterial");
            }
            else
            {
                ViewBag.err = "Material already exist";
                return View(mr);
            }
        }
        public ActionResult Updatematerial(String id)
        {
            var checkmt = db.INGREDIENT.Where(n => n.C_Material_id == id).FirstOrDefault();
            MaterialValidate mt = new MaterialValidate();
            mt.MaterialID = checkmt.C_Material_id;
            mt.MaterialName = checkmt.C_Material_name;
            mt.MaterialQT = checkmt.C_Quantity_I;
            mt.MaterialUnit = checkmt.C_Unit;
            return View(mt);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Updatematerial(MaterialValidate mr)
        {
            var checkmr = db.INGREDIENT.Where(n => n.C_Material_id == mr.MaterialID).FirstOrDefault();
            if (checkmr != null)
            {
                checkmr.C_Material_id = mr.MaterialID;
                checkmr.C_Material_name = mr.MaterialName;
                checkmr.C_Quantity_I = mr.MaterialQT;
                checkmr.C_Unit = mr.MaterialUnit;
                db.SaveChanges();
                return Redirect("~/Admin/Chef/ManageMaterial");
            }
            else
            {
                ViewBag.err = "Material ID does not exist";
                return View(mr);
            }
        }
        public ActionResult Deletematerial(String id)
        {
            var mr = db.INGREDIENT.Where(n => n.C_Material_id == id).FirstOrDefault();
            if (mr != null)
            {
                db.INGREDIENT.Remove(mr);
                db.SaveChanges();
                return Redirect("~/Admin/Chef/ManageMaterial");
            }
            return Redirect("~/Admin/Chef/ManageMaterial");
        }
        //View Registration
        public ActionResult ViewRegis()
        {
            return View();
        }
    }
}