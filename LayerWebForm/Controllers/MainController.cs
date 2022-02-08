using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LayerWebForm.Models;

namespace LayerWebForm.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            using (var db = new SQLModelEntities())
            {
                ViewBag.ClsInfo = db.ClsInfo.ToList();
            }
            return View();
        }
        public ActionResult AddData(string school, string sex, string cls, string phone, string date, string job)
        {
            using (var db = new SQLModelEntities())
            {
                var model = new Models.StuInfo();
                model.Sschool = school;
                model.Ssex = int.Parse(sex);
                model.Scid = int.Parse(cls);
                model.Sphone = phone;
                model.Addtime = DateTime.Parse(date);
                model.Sjobname = job;
                db.StuInfo.Add(model);
                if (db.SaveChanges() > 0)
                {
                    return Content("OK");
                }
                else
                {
                    return Content("Error");
                }
            }
        }
        public ActionResult AddUserData()
        {
            return View();
        }
        public ActionResult AddUserNewData(string uname,string upwd,string urlname)
        {
            using (var db = new SQLModelEntities())
            {
                var model = new Models.LoginInfo();
                model.Lusername = uname;
                model.Luserpwd = upwd;
                model.Lrealname = urlname;
                db.LoginInfo.Add(model);
                if (db.SaveChanges() > 0)
                {
                    return Content("OK");
                }
                else
                {
                    return Content("Error");
                }
            }
        }
        public ActionResult AddOrEdit()
        {
            using (var db = new SQLModelEntities())
            {
                ViewBag.ClsInfo = db.ClsInfo.ToList();
            }
            return View();
        }
        public ActionResult DelData(string ids)
        {            
            using (var db = new SQLModelEntities())
            {
                string[] Nids = ids.Split(',');
                foreach (var item in Nids)
                {
                    int id = int.Parse(item);
                    var model = db.StuInfo.Find(id);
                    db.StuInfo.Remove(model);
                }
                if (db.SaveChanges() > 0)
                {
                    return Content("OK");
                }
                else
                {
                    return Content("Error");
                }
            }
        }
        public ActionResult Table(int page,int limit,string school,string cls,string sex)
        {
            using (var db = new SQLModelEntities())
            {
                var query = (from a in db.StuInfo
                             join b in db.ClsInfo
                             on a.Scid equals b.Cid
                             select new ViewModel.ModelData
                             {
                                 Sid = a.Sid,
                                 Ssex = a.Ssex,
                                 Sschool = a.Sschool,
                                 Sjobname = a.Sjobname,
                                 Sphone = a.Sphone,
                                 Addtime = a.Addtime,
                                 Scid = a.Scid,
                                 Cname = b.Cname
                             });
                if (!String.IsNullOrWhiteSpace(school))
                {
                    query = query.Where(u => u.Sschool.Contains(school));
                }
                if (!String.IsNullOrWhiteSpace(cls))
                {
                    var Ncls = int.Parse(cls);
                    query = query.Where(u => u.Scid == Ncls);
                }
                if (!String.IsNullOrWhiteSpace(sex))
                {
                    var Nsex = int.Parse(sex);
                    query = query.Where(u => u.Ssex == Nsex);
                }
                var list = query.OrderBy(u => u.Sid).Skip((page - 1) * limit).Take(limit);
                return Json(new {code = 0,msg = "",count = list.Count(),data = query.ToList()},JsonRequestBehavior.AllowGet);
            }
        }
    }
}