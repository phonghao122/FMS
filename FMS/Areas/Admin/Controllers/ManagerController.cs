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
    public class ManagerController : Controller
    {
        // GET: Admin/Manager
        db_FMSEntities db = new db_FMSEntities();
        public ActionResult ManagePro()
        {
            return View(db.STAFF.ToList());
        }
        //Manage Workshift
        public ActionResult ManageWorkshift()
        {
            return View();
        }
        public ActionResult CreateShift()
        {
            return View();
        }

        public ActionResult MoreShift()
        {
            return View(db.SPLIT_TIME.ToList());
        }

        public ActionResult Change()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Change(WorkShiftValidate ws)
        {
            var checkwo = db.SPLIT_TIME.Where(n => n.C_Shift_id == ws.IDShift).FirstOrDefault();
            if (checkwo != null)
            {
                checkwo.C_Shift_id = ws.IDShift;
                checkwo.C_Shift_name = ws.ShiftName;
                checkwo.C_Time_in = ws.ShiftStartTime;
                checkwo.C_Time_out = ws.ShiftEndTime;
                db.SaveChanges();
                return Redirect("~/Admin/Manager/MoreShift");
            }
            else
            {
                ViewBag.err = "ID Shift does not exist";
                return View(ws);
            }
        }
        public ActionResult DeleteWorkShift(String id)
        {
            var ds = db.SPLIT_TIME.Where(n => n.C_Shift_id == id).FirstOrDefault();
            if (ds != null)
            {
                db.SPLIT_TIME.Remove(ds);
                db.SaveChanges();
                return Redirect("~/Admin/Manager/ManageWorkshift");
            }
            return Redirect("~/Admin/Manager/ManageWorkshift");
        }

        // TimeKeeping
        public ActionResult TimeKeeping()
        {
            return View();
        }
        //ReportStatis
        public ActionResult ReportStatis()
        {
            return View();
        }
    }
}