using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;
using AtosMVC.Models;

namespace AtosMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string acc,string birthday, string sex)
        {
            AccountModel accountModels = new AccountModel();
            accountModels.acc = acc;
            accountModels.birthday = birthday;
            accountModels.sex = sex;

            return RedirectToAction("Index");
        }
        public ActionResult Create2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create2(string acc, string birthday, string sex)
        {
            AccountModel accountModels = new AccountModel();
            accountModels.acc = acc;
            accountModels.birthday = birthday;
            accountModels.sex = sex;

            return View();
        }

        public ActionResult GetName()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetName( string userName)
        {
            if (userName == "FrogJump")
            {
                ViewBag.acc = userName + "此帳號已經被註冊過了";
                return View();
            }
            else
            {
                ViewBag.acc = userName + "可以使用";
                //ViewData.Model = userName + "可以使用";
                return View();
            }            
        }
        public string checkAcc(string acc)
        {
            string str = "FrogJump";
            if (acc == str)
            {
                return "duplicate";
            }
            return "OK";
        }
        public string upload(HttpPostedFileBase file)
        {
            if (file.ContentLength == 0)
            {
                return "error";
            }
            string name = Path.GetFileName(file.FileName);
            var path = Path.Combine(Server.MapPath("~/Content/File") , name);
            file.SaveAs(path);
            return "success";
        }
    }
}
