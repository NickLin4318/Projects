using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GSSWEB.Models
{
    public class BookBorrowRecord
    {
        public DateTime? lend_date { get; set; }
        public string user_id { get; set; }
        public string user_cname { get; set; }
        public string user_ename { get; set; }
    }
}