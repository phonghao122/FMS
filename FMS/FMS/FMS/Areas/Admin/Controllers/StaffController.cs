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
    public class StaffController : Controller
    {
        // GET: Admin/Staff
        db_FMSEntities db = new db_FMSEntities();
        public ActionResult Order()
        {
            return View(db.MENU.ToList());
        }

        public ActionResult Orderfood(string id)
        {
            var ord = db.MENU.Where(s => s.C_Food_id == id).FirstOrDefault();
            if (ord != null)
            {
                FoodValidate fv = new FoodValidate();
                fv.FoodID = ord.C_Food_id;
                fv.FoodName = ord.C_Food_name;
                fv.FoodDescrip = ord.C_Description;
                return View(fv);
            }
            return Redirect("~/Admin/Staff/Order");
        }

        [HttpPost]
        public ActionResult Orderfood(FoodValidate fv)
        {
            var id = Session["C_Staff_id"] as String;
            var checkst = db.ORDERS.Any(s => s.C_Order_id == fv.Orderid);
            if (checkst)
            {
                ViewBag.err = "Order ID already exist"; 
                return View(fv);
            }
            else
            {
                ORDERS Addor = new ORDERS();
                Addor.C_Order_id = fv.Orderid;
                Addor.C_Food_id = fv.FoodID;
                Addor.C_Staff_id = id;
                Addor.C_Shift_id = fv.Shiftid;
                Addor.C_Order_date = DateTime.Today;

                db.ORDERS.Add(Addor);
                db.SaveChanges();
                return Redirect("~/Admin/Staff/Order");
            }
            
        }

        public ActionResult PersonalPro(){
            var id = Session["C_Staff_id"] as String;
            var empl = db.STAFF.Where(n => n.C_Staff_id == id).FirstOrDefault();
            if (empl != null)
            {
                UserValidate us = new UserValidate();
                us.StaffName = empl.C_Staff_name;
                us.Birthday = (DateTime)empl.C_Birthday;
                us.Gender = (bool)empl.C_Gender;
                us.Image = empl.C_Image;
                us.PhoneNumber = empl.C_phone_number;
                us.Position = empl.C_Position;
                us.IdentityCard = empl.C_Identity_card;
                us.Ward = empl.C_Ward;
                us.District = empl.C_District;
                us.Ethnic = empl.C_Ethnic;
                us.City = empl.C_City;
                us.DepartmentID = empl.C_Department_id;
                return View(us);
            }
            else
            {
                return Redirect("~/Admin/Staff/PersonalPro");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PersonalPro(UserValidate us, HttpPostedFileBase Image){
            var id = Session["C_Staff_id"] as String;
            var checkst = db.STAFF.Where(n => n.C_Staff_id == id).FirstOrDefault();
            if (checkst != null)
            {
                checkst.C_Staff_name = us.StaffName;
                checkst.C_Birthday = us.Birthday;
                checkst.C_Gender = us.Gender;
                checkst.C_phone_number = us.PhoneNumber;
                checkst.C_Identity_card = us.IdentityCard;
                checkst.C_Position = us.Position;
                checkst.C_Ward = us.Ward;
                checkst.C_District = us.District;
                checkst.C_City = us.City;
                checkst.C_Ethnic = us.Ethnic;
                checkst.C_Department_id = us.DepartmentID;
                if (Image != null && Image.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(Image.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Content/image"), _FileName);
                    Image.SaveAs(_path);
                    /*Image.SaveAs(HttpContext.Server.MapPath("~/Content/images/") + Image.FileName);*/
                    checkst.C_Image = Image.FileName;
                    us.Image = Image.FileName;
                }
                else
                {
                    us.Image = checkst.C_Image;
                }

                db.SaveChanges();
                return Redirect("~/Admin/Staff/PersonalPro");
            }
            else
            {
                ViewBag.err = "Staff ID does not exist";
                return View(us);
            }
        }

        public ActionResult DeleteOrd(int id)
        {
            var order = db.ORDERS.Where(n => n.C_Order_id == id).FirstOrDefault();
            if (order != null)
            {
                db.ORDERS.Remove(order);
                db.SaveChanges();
                return Redirect("~/StaffS/StaffS/Order");
            }
            return Redirect("~/StaffS/StaffS/Order");
        }
    }
}