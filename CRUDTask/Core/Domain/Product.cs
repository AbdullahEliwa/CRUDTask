using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDTask.Core.Domain
{
    public class Product
    {
        public int ID { get; set; }

        [Required]
        [StringLength(150, MinimumLength =5)]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be bigger than 1!")]
        public int Quantity { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Price must be bigger than 1!")]
        public float UnitPrice { get; set; }

        public int CategoryID { get; set; }
        public Category Category{ get; set; }



    }
}