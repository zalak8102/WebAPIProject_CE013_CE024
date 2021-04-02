using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TenantWebClient.ViewModels
{
    public class ULogin
    {
        [Required]
        public string uname { get; set; }

        [Required]
        public string pass { get; set; }

    }
}
