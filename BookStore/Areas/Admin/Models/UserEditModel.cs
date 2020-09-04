using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Areas.Admin.Models
{
    public class UserEditModel
    {
        public string email { get; set; }
        public int level { get; set; }
        public int active { get; set; }
    }
}