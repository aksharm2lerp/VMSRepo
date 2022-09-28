using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Entities
{
    public class CompanyMasterMetadata
    {
        public int SrNo { get; set; }
        public int CompanyLogoID { get; set; }
        public int CompanyID { get; set; }
        public string CompanyCode { get; set; }

        [Required(ErrorMessage = "Please enter company name")]
        public string CompanyName { get; set; }

        
        public string CompanyWebsiteText { get; set; }


        public bool IsActive { get; set; } = true;



        [Required(ErrorMessage = "Please choose company logo")]
        public IFormFile ImageFile { get; set; }
        [Required(ErrorMessage = "Please choose company logo")]
        [NotMapped]
        [Display(Name = "Upload File")]


        public string CompanyLogoImagePath{get; set; }


        public byte CompanyLogoImage { get; set; }

        [Required(ErrorMessage = "Please select the logo")]
        public string CompanyLogoName { get; set; }


        [Required(ErrorMessage = "Please enter email address")]
        public string CompanyEmail { get; set; }
        

        [Required(ErrorMessage = "Please enter mobile number")]
        public string CompanyMobile { get; set; }
        
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]

        [Required(ErrorMessage = "Please Select Industry Type")]
        public int IndustryTypeID { get; set; }
       /* [Required(ErrorMessage = "Please Select Industry Type")]*/
       
        [Required(ErrorMessage = "Please enter Business Type")]
        public int BusinessTypeID { get; set; }


        [Required(ErrorMessage = "Please enter company unit number or name")]
        public string UnitName { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        [Required(ErrorMessage = "Please enter company group name")]
        public string CompanyGroupName { get; set; }
        
    }
}
