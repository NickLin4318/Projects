using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace AtosProject.Models
{
    public class Member
    {
        [Required(ErrorMessage = "You must input this ID")]
        [Range(1, 100, ErrorMessage ="You must input the number in 1~100")]
        public int Id { get; set; }
        [Required(ErrorMessage = "You must to input this Name")]
        [StringLength(20, ErrorMessage = "This length must in 20 words")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You must to input this Gender")]
        public string Gender { get; set; }
    }
}