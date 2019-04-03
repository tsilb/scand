using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace shanuMVCUserRoles.Models
{
    public class ScannedViewModel
    {
        public string UserName { get; set; }
        public string Room { get; set; }
        public string Time { get; set; }
    }
}