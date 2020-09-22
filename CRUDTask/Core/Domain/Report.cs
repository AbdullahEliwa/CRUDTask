using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }


        public ICollection<Product> Products { get; set; }
    }
}