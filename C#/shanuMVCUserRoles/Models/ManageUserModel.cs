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
    public class ManageUserModel
    {
        public string Id { get; set; }
        [DisplayName("UserName")]
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}