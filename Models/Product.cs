using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //need this to add annotations

namespace Week12ProductsProject.Models
{//validations are done here
    public enum ProdType
    {
        Engine,
        Software,
        Game,
        Cloud
    }
    public class Product
    {
        [Display(Name = "Product Id")]
        [Required]
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot be longer then 50 characters")]
        [Display(Name = "Name")]
        public string ProductName { get; set; }
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "Product Stock")]
        public int ProductStock { get; set; }
        [Display(Name = "Product type")]
        public ProdType ProductType { get; set; }
    }
}
