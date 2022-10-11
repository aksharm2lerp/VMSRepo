using Business.Entities.Department;
using Microsoft.AspNetCore.Http;
using System;
using System.Data;

namespace Business.Entities.Employee
{
    public class AddUpdateEmployee
    {
        public int EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public string PrefixName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int GenderID { get; set; }
        public bool IsActive { get; set; }
        public string JobTitle { get; set; }
        public int DepartmentID { get; set; }
        public int DesignationID { get; set; }
        public int ReportingTo { get; set; }
        public string PersonalMobileNo { get; set; }
        public string OfficeMobileNo { get; set; }
        public string AlternativeMobileNo { get; set; }
        public bool IsResigned { get; set; }
        public string Note { get; set; }
        public int EmailGroupID { get; set; }
        public string PersonalEmail { get; set; }
        public string OfficeEmail { get; set; }
        public DateTime BirthDate { get; set; }
        public string Religion { get; set; }
        public int CompanyID { get; set; }
        public int CreatedOrModifiedBy { get; set; }
        public IFormFile ProfilePhoto { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }

    }
}
