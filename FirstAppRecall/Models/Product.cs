using FirstAppRecall.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstAppRecall.Models
{
    public class Product
    {
        [Key]
        [Display(Name = "Product ID")]
        [Required]
        public long ProductID { get; set; }


        [Required(ErrorMessage ="Please Enter Product Name")]
        [RegularExpression(@"^[A-Za-z 0-9]*$",ErrorMessage ="Alphabets and number only")]
        [MaxLength(40,ErrorMessage ="Maximum 20 characters")]
        public string ProductName { get; set; }


        [Required(ErrorMessage ="Please enter Price")]
        [Range(0,10000,ErrorMessage ="Price must be betweem 0 to 10000")]
        [DivisibleBy10(ErrorMessage ="Price must be in multiple of 10")]
        public Nullable<decimal> Price { get; set; }
        
        public Nullable<System.DateTime> DateOfPurchase { get; set; }
        [Required(ErrorMessage = "Please enter Availability Status")]
        public string AvailabilityStatus { get; set; }
        [Required(ErrorMessage = "Please Select Category")]
        public Nullable<long> CategoryID { get; set; }
        [Required(ErrorMessage = "Please Select Brand")]
        public Nullable<long> BrandID { get; set; }
        public Nullable<bool> Active { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}