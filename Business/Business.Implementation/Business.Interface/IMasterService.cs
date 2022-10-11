using Business.Entities;
using Business.Entities.Master;
using Business.Entities.User;
using Business.Entities.Department;
using Business.Entities.Designation;
using Business.SQL;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Business.Entities.Designation;
using Business.Entities.Employee;
using Business.Entities.Gender;
using Business.Entities.SecurityOfficer;

namespace Business.Interface
{
    public interface IMasterService
    {
        PagedDataTable<IdentityProofTypeMetaData> GetIdentityProofTypeAsync();

        PagedDataTable<VehicleTypeMasterMetaData> GetVehicleTypeAsync();

        PagedDataTable<ZipCodeMaster> GetZipCodeAsync(string search);

        PagedDataTable<FeedbackQuestionMasterMetaData> GetFeedbackQuestions();
        PagedDataTable<IndustryTypeMaster> GetIndustryTypeMasterAsync();
        PagedDataTable<BusinessTypeMaster> GetBusinessTypeMasterAsync();
        PagedDataTable<UserRoleMaster> GetUserRoleMasterAsync();
        PagedDataTable<DepartmentGroup> GetDepartmentGroupsMasterAsync();
        PagedDataTable<Department> GetAllDepartments();
        PagedDataTable<DesignationMaster> GetAllDesignations();
        PagedDataTable<EmployeeMaster> GetAllEmployees();
        PagedDataTable<GenderMaster> GetAllGenders();
        PagedDataTable<EmailGroupMaster> GetAllEmailGroupMaster();
        PagedDataTable<Department> GetDepartment(int departmentId);
        PagedDataTable<DesignationMaster> GetDesignation(int designationID);
        PagedDataTable<EmployeeMaster> GetEmployee(int employeeID);
        PagedDataTable<GenderMaster> GetGender(int genderID);
        PagedDataTable<EmailGroupMaster> GetEmailGroupMaster(int emailGroupID);
        PagedDataTable<SecurityOfficerMaster> GetAllSecurityOfficers();
        PagedDataTable<DesignationGroup> GetDesignationGroupMasterAsync();
    }
}
