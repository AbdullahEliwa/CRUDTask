using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDTask.Core.Domain
{
    public class Report
    {
        public Report()
        {
            Products = new HashSet<Product>();
        }
        public int ID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(500)]
        public string Notes { get; set; }


        public ICollection<Product> Products { get; set; }
    }
}