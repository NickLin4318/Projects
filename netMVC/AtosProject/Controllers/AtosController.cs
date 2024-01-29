using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AtosProject.Service;
using AtosProject.Models;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace AtosProject.Controllers
{
    public class AtosController : Controller
    {
        private DBManager mgr = new DBManager();

        public class test
        {
            public string ddd { get; set; }
            public string aaa { get; set; }
        }
        // GET: Atos
        public ActionResult Index()
        {
            test a = new test();
            a.ddd = "ddd";
            a.aaa = "aaa";

            var rsXml = doXml(a);
            ViewBag.xml = rsXml;
            return View(mgr.GetMembers());
        }
        [HttpPost]
        public ActionResult Add(Member req)
        {
            if (mgr.AddMember(req))
            {

            }

            return RedirectToAction("Index", "Atos");
        }

        private string doXml(object obj)
        {
            var result = "";
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(test));

            using (var sw = new StringWriter())
            {
                using (XmlWriter xw = XmlWriter.Create(sw))
                {
                    xmlSerializer.Serialize(xw, obj);
                    result = sw.ToString();
                }
            }

            return result;
        }
    }
}