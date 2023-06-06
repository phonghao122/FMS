using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FMS.Models;
using System.Text;
using System.Security.Cryptography;
using System.Web.UI.WebControls;

namespace FMS.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        db_FMSEntities objModel = new db_FMSEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LOGIN login)
        {
            if (ModelState.IsValid)
            {
                var password = GetMD5(login.C_Password);
                var staffid = objModel.LOGIN.Where(s => s.C_Username == login.C_Username && s.C_Password == password).FirstOrDefault();
                var checkadmin = objModel.LOGIN.Any(s => s.C_Username == login.C_Username && s.C_Password == password && s.C_Role == 1);
                var checkmanage = objModel.LOGIN.Any(s => s.C_Username == login.C_Username && s.C_Password == password && s.C_Role == 2);
                var checkchef = objModel.LOGIN.Any(s => s.C_Username == login.C_Username && s.C_Password == password && s.C_Role == 3);
                var checkstaff = objModel.LOGIN.Any(s => s.C_Username == login.C_Username && s.C_Password == password && s.C_Role == 4);

                if (password == null)
                {
                    ViewBag.error = "Login failed";
                    return View(login);
                }

                if (checkadmin)
                {
                    Session["C_Staff_id"] = staffid.C_Staff_id;
                    Session["checkadmin"] = "ok" ;
                    return Redirect("~/admin/Admin/Index");
                    //return View();
                }
                if (checkmanage)
                {
                    Session["C_Staff_id"] = staffid.C_Staff_id;
                    return Redirect("~/Manage/ManagerS/ManagePro");
                }
                if (checkchef)
                {
                    Session["C_Staff_id"] = staffid.C_Staff_id;
                    return Redirect("~/Chef/ChefS/ManageMenu");
                }
                if (checkstaff)
                {
                    Session["C_Staff_id"] = staffid.C_Staff_id;
                    return Redirect("~/StaffS/StaffS/PersonalPro");
                }

                ViewBag.error = "Login failed";
                return View(login);
            }
            else
            {
                ViewBag.error = "Login failed";
                return View(login);
            }
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }
}