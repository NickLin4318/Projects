using GSSWEB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GSSWEB.ViewModels;
using GSSWEB.Models;
using System.Text;
using NPOI;
using System.IO;

namespace GSSWEB.Controllers
{
    public class LibraryController : Controller
    {
        private DbManager mgr = new DbManager();
        // GET: Library
        public ActionResult Index(string submit = null, BookData req = null)
        {
            BookModel m = new BookModel();
            m.BookClass = mgr.getBookClass();
            m.Members = mgr.getMembers();
            m.BookCode = mgr.getBookCode();
            m.BookInfo = mgr.getBookInfo(req);
            m.bookData = req;

            return View(m);
        }
        [HttpPost]
        public ActionResult IndexQry(BookData request)
        {
            return RedirectToAction("Index", "Library", request);
            //return Json(new { data = mgr.getBookInfo(request) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add()
        {
            AddModel m = new AddModel();
            m.BookClass = mgr.getBookClass();

            return View(m);
        }
        [HttpPost]
        public ActionResult Add(BookInfo bi)
        {
            string msg = mgr.addBook(bi);

            return RedirectToAction("Index", "Library");
        }
        [HttpPost]
        public FileResult Export()
        {
            var data = mgr.getBookInfo();

            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");

            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
            row1.CreateCell(0).SetCellValue("book_id");
            row1.CreateCell(1).SetCellValue("book_name");
            row1.CreateCell(2).SetCellValue("book_class_name");
            row1.CreateCell(3).SetCellValue("book_bought_date");
            row1.CreateCell(4).SetCellValue("book_status");
            row1.CreateCell(5).SetCellValue("user_ename");

            int count = 0;
            foreach (var item in data)
            {
                count++;
                NPOI.SS.UserModel.IRow row = sheet1.CreateRow(count);
                row.CreateCell(0).SetCellValue(item.book_id.ToString());
                row.CreateCell(1).SetCellValue(item.book_name);
                row.CreateCell(2).SetCellValue(item.book_class_name);
                row.CreateCell(3).SetCellValue(item.book_bought_date.ToString());
                row.CreateCell(4).SetCellValue(item.book_status);
                row.CreateCell(5).SetCellValue(item.user_ename);
            }

            MemoryStream ms = new MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);

            return File(ms, "application/vnd.ms-excel", DateTime.Now.ToString("yyyyMMdd") + "_BookInfo.xls");
        }
    }
}