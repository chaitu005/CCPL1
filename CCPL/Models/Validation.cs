using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CCPL.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CCPL.Models
{
    public class Validation
    {
                
    }
    public class Stock
    {
        [Required(ErrorMessage="Please select Vendor Name")]
        [Display(Name="Vendor :")]
        public int? vendorCode { get; set; }
        public IEnumerable<SelectListItem> VenodorList { get; set; }
        
        [Required(ErrorMessage = "Please enter Reference Number")]
        [Display(Name = "Reference NO :")]
        public string  refNo{ get; set; }
        
        [Required(ErrorMessage = "Please select Instrument Code")]
        [Display(Name = "Instrument Code :")]
        public int? instrumentCode { get; set; }
        public IEnumerable<SelectListItem> instrumentCodeList { get; set; }
        
        [Required(ErrorMessage = "Please enter Date")]
        [Display(Name = "Date :")]
        public string date { get; set; }
        
        [Required(ErrorMessage = "Please select Book Size")]
        [Display(Name = "Book Size :")]
        public int? size { get; set; }
        public IEnumerable<SelectListItem> BookSizeList { get; set; }
        
        [Required(ErrorMessage = "Please enter No Of Books")]
        [Display(Name = "No Of Books :")]
        public string noOfBooks { get; set; }
        
        [Required(ErrorMessage = "Please enter From Number")]
        [Display(Name = "From NO :")]
        public string fromNo { get; set; }
        
        [Required(ErrorMessage = "Please enter To Number")]
        [Display(Name = "To NO :")]
        public string toNo { get; set; }
    }

}