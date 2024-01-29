using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GSSWEB.Models;
using GSSWEB.Services;
using GSSWEB.ViewModels;

namespace GSSWEB.Controllers
{
    public class PopupController : Controller
    {
        private DbManager mgr;

        public PopupController()
        {
            mgr = new DbManager();
        }

        // GET: Popup
        public ActionResult Add()
        {
            return PartialView();
        }

        public ActionResult BorrowRecord(int id)
        {
            BorrowRecordModel m = new BorrowRecordModel();
            m.BookBorrowRecord = mgr.getBookBorrowRecord(id);
            return PartialView(m);
        }
    }
}