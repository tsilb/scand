using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace shanuMVCUserRoles.Models
{
    public class ScannedViewModel
    {
        public int ID { get; set; }
        [DisplayName("UserName")]
        public string UserName { get; set; }
        public string Room { get; set; }
        public string Time { get; set; }
    }
}