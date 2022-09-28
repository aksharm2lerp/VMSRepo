using Business.Entities.User;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities
{
    public class UserMasterMetadata : BaseEntity
    {
        /// <summary>
        /// User identifier. No longer using Guids as uneeded memory is consumed in creation
        /// </summary>
        public int CompanyID { get; set; }
        public int UserID { get; set; }

        public string DisplayName { get; set; }

        /// <summary>
        /// Typically their email
        /// </summary>
        public string Username { get; set; }

        public string NormalizedUserName { get; set; }

        public string Email { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public string NormalizedEmail { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Mobile { get; set; }
        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string Instagram { get; set; }

        public string Website { get; set; }

        public string SecurityStamp { get; set; }

        public string CompanyLogoName { get; set; }
        public string CompanyLogoImagePath { get; set; }
        public string CompanyName { get; set; }
        public bool IsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int RoleID { get; set; }
        public int SrNo { get; set; }
    }
}
