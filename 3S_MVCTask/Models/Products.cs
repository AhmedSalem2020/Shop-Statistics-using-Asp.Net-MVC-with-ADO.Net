using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _3S_MVCTask.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Please enter the Product name")]
        //[Range(3, 20, ErrorMessage = "Name must be between 3 and 20 characters.")]
        public string pro_Name { get; set; }

        [DisplayName("Quantity")]
        public int quantityPerUnit { get; set; }

        public int reorderLevel { get; set; }

        [DisplayName("Price")]
        public decimal unitPrice { get; set; }

        public int unitsInStock { get; set; }

        public int unitsOnOrder { get; set; }
    }
}