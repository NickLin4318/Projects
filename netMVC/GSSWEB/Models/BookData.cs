using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GSSWEB.Models
{
    public class BookData
    {
        public string book_class_name { get; set; }
        public string book_name { get; set; }
        public DateTime? book_bought_date { get; set; }
        public string book_status { get; set; }
        public string user_ename { get; set; }
        public int? book_id { get; set; }
    }
}