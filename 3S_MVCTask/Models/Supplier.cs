using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _3S_MVCTask.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

       
        [DisplayName(" Name")]
        [Required(ErrorMessage = "Please enter the Supplier name")]
        //[Range(3, 20, ErrorMessage = "Name must be between 3 and 20 characters.")]
        public String Name { get; set; }

    }
}