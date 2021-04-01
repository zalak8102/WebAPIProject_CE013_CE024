using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TenantFinderAPI.Models
{
    public class House
    {
        [Key]
        public int hid { get; set; }

        [Required]
        public int no { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string area { get; set; }

        [Required]
        public string city { get; set; }

        [Required]
        public string category { get; set; }

        [Required]
        public float rent { get; set; }

        [Required]
        public string reqtenant { get; set; }

    }
}
