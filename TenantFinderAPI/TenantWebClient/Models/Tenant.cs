using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TenantFinderAPI.Models
{
    public class Tenant
    {
        [Key]
        public int tid { get; set; }
        [Required]
        public string tname { get; set; }

        [Required]
        public int phone { get; set; }

        [Required]
        public string catg { get; set; }

        [Required]
        public string reqhouse { get; set; }
    }
}
