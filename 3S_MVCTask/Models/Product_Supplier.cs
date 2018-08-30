using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _3S_MVCTask.Models
{
    public class Product_Supplier
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Products")]
        public int product_Id { get; set; }
        public virtual Products products { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Supplier")]
        public int supplier_Id { get; set; }
        public virtual Supplier supplier { get; set; }
    }
}