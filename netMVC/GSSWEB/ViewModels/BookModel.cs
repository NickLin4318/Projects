using GSSWEB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GSSWEB.Models;

namespace GSSWEB.ViewModels
{
    public class BookModel
    {
        public BookData bookData { get; set; }
        public IEnumerable<BOOK_CLASS> BookClass { get; set; }
        public IEnumerable<MEMBER_M> Members { get; set; }
        public IEnumerable<BOOK_CODE> BookCode { get; set; }
        public IEnumerable<BookData> BookInfo { get; set; }
    }
}