using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Moi nhap email")]
        public string userEmail { set; get; }

        [Required(ErrorMessage = "Moi nhap password")]
        public string userPassword { set; get; }

        public bool remeberMe { set; get; }
    }
}