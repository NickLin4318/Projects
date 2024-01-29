using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GSSWEB.Models
{
    public class BookInfo
    {
        public string book_name { get; set; }
        public string author { get; set; }
        public string publisher { get; set; }
        public string description { get; set; }
        public DateTime? bought_date { get; set; }
        public string book_class { get; set; }
        public string book_status { get; set; }
        public string book_keeper { get; set; }
    }
}