using GSSWEB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GSSWEB.ViewModels
{
    public class AddModel
    {
        public IEnumerable<BOOK_CLASS> BookClass { get; set; }
    }
}