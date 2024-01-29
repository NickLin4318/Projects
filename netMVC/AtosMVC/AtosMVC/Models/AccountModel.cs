using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AtosMVC.Models
{
    public class AccountModel
    {
        [DisplayName("帳號:")]
        [Required(ErrorMessage = "帳號欄位是必要項")]        
        public string acc { get; set; }

        [DisplayName("生日:")]
        [RegularExpression("^((19|20)?[0-9]{2}[- /.](0?[1-9]|1[012])[- /.](0?[1-9]|[12][0-9]|3[01]))*$", ErrorMessage = "生日欄位是日期格式(yyyy/MM/dd)")]
        public string birthday { get; set; }

        [DisplayName("性別:")]
        [RegularExpression("^[F]|[M]$", ErrorMessage = "性別只能是M或F")]
        public string sex { get; set; }
    }
}