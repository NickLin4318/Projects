using GSSWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GSSWEB.ViewModels
{
    public class BorrowRecordModel
    {
        public IEnumerable<BookBorrowRecord> BookBorrowRecord { get; set; }
    }
}