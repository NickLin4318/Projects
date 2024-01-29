using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using GSSWEB.Data;
using GSSWEB.Models;
using NPOI.SS.Formula.Functions;
using Dapper;
using System.Configuration;

namespace GSSWEB.Services
{
    public class DbManager
    {
        private readonly GSSWEBEntities _context = new GSSWEBEntities();
        private readonly string connStr = ConfigurationManager.ConnectionStrings["GSSWEBConnectionString"].ConnectionString;

        public IEnumerable<BOOK_CLASS> getBookClass()
        {
            return _context.BOOK_CLASS.AsEnumerable();
        }

        public IEnumerable<MEMBER_M> getMembers()
        {
            return _context.MEMBER_M.AsEnumerable();
        }

        public IEnumerable<BOOK_CODE> getBookCode()
        {
            return _context.BOOK_CODE.AsEnumerable();
        }

        public IEnumerable<BookData> getBookInfo(BookData model = null)
        {
            //var linq = (from b in _context.BOOK_DATA
            //            from c in _context.BOOK_CLASS.Where(bc => bc.BOOK_CLASS_ID == b.BOOK_CLASS_ID).DefaultIfEmpty()
            //            from e in _context.BOOK_CODE.Where(cd => cd.CODE_ID == b.BOOK_STATUS).DefaultIfEmpty()
            //            from m in _context.MEMBER_M.Where(mm => mm.USER_ID == b.BOOK_KEEPER).DefaultIfEmpty()
            //             where e.CODE_TYPE == "BOOK_STATUS"
            //            select new
            //            {
            //                book_class_name = c.BOOK_CLASS_NAME,
            //                book_name = b.BOOK_NAME,
            //                book_bought_date = b.BOOK_BOUGHT_DATE,
            //                book_status = e.CODE_NAME,
            //                user_ename = m.USER_ENAME
            //            }).AsEnumerable();

            //var result = new List<BookData>();

            //foreach (var o in linq)
            //{
            //    var item = new BookData
            //    {
            //        book_bought_date = Convert.ToDateTime(o.book_bought_date),
            //        book_class_name = o.book_class_name,
            //        book_name = o.book_name,
            //        book_status = o.book_status,
            //        user_ename = o.user_ename
            //    };
            //    result.Add(item);
            //}

            //var lambda = _context.BOOK_DATA.Join(
            //    _context.BOOK_CLASS,
            //    o => o.BOOK_CLASS_ID,
            //    x => x.BOOK_CLASS_ID,
            //    (o, x) => new { o = o, x = x }).Select(a =>
            //    new
            //    {
            //        qwer = a.o.BOOK_AMOUNT,
            //        asdf = a.x.BOOK_CLASS_NAME
            //    });

            var infoList = _context.Database.SqlQuery<BookData>("getBookInfo").AsEnumerable();
            if(model != null)
            {
                if (!String.IsNullOrEmpty(model.user_ename))
                {
                    infoList = infoList.Where(o => o.user_ename == model.user_ename);
                }
                if (!String.IsNullOrEmpty(model.book_class_name))
                {
                    infoList = infoList.Where(o => o.book_class_name == model.book_class_name);
                }
                if (!String.IsNullOrEmpty(model.book_status))
                {
                    infoList = infoList.Where(o => o.book_status == model.book_status);
                }
                if (!String.IsNullOrEmpty(model.book_name))
                {
                    infoList = infoList.Where(o => o.book_name.Contains(model.book_name));
                }
            }

            return infoList;
        }

        public IEnumerable<BookBorrowRecord> getBookBorrowRecord(int book_id)
        {
            //using (var _conn = new SqlConnection(connStr))
            //{
            //    DynamicParameters param = new DynamicParameters();
            //    var sql = "exec getTargetBookRecord @book_id";
            //    param.Add("@book_id", book_id);

            //    return _conn.Query<BookBorrowRecord>(sql, param).AsEnumerable();
            //}
            var _data = _context.BOOK_LEND_RECORD.Where(o => o.BOOK_ID == book_id)
                .Join(_context.MEMBER_M, blr => blr.KEEPER_ID, mm => mm.USER_ID,
                (blr, mm) => new { blr = blr, mm = mm }).Select(o => new BookBorrowRecord { 
                    lend_date = o.blr.LEND_DATE,
                    user_id = o.mm.USER_ID,
                    user_cname = o.mm.USER_CNAME,
                    user_ename = o.mm.USER_ENAME
                });

            //List<BookBorrowRecord> records = new List<BookBorrowRecord>();

            //if (_data.Count() > 0)
            //{
            //    foreach (var item in _data)
            //    {
            //        var rec = new BookBorrowRecord
            //        {
            //            lend_date = item.lend_date,
            //            user_id = item.user_id,
            //            user_cname = item.user_cname,
            //            user_ename = item.user_ename
            //        };
            //    }
            //}

            return _data;
        }

        public string addBook(BookInfo bookInfo)
        {
            var result = string.Empty;

            var target = _context.BOOK_DATA.Where(o =>
                o.BOOK_PUBLISHER == bookInfo.publisher &&
                o.BOOK_NAME == bookInfo.book_name &&
                o.BOOK_AUTHOR == bookInfo.author &&
                o.BOOK_BOUGHT_DATE == bookInfo.bought_date &&
                o.BOOK_CLASS_ID == bookInfo.book_class).FirstOrDefault();

            if(target != null)
            {
                result = "This book is exist.";
            }
            else
            {
                BOOK_DATA data = new BOOK_DATA
                {
                    BOOK_NAME = bookInfo.book_name,
                    BOOK_AUTHOR = bookInfo.author,
                    BOOK_PUBLISHER = bookInfo.publisher,
                    BOOK_NOTE = bookInfo.description,
                    BOOK_BOUGHT_DATE = bookInfo.bought_date,
                    BOOK_CLASS_ID = bookInfo.book_class,
                    BOOK_STATUS = bookInfo.book_status,
                    BOOK_KEEPER = bookInfo.book_keeper
                };
                _context.BOOK_DATA.Add(data);
                _context.SaveChanges();
            }

            return result;
        }
    }
}