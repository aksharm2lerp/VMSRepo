using Business.Entities;
using Business.Entities.Employee;
using Business.SQL;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IEmployeeService
    {
        Task<PagedDataTable<EmployeeMaster>> GetAllEmployeesAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "EmployeeID", string sortBy = "ASC");
        Task<AddUpdateEmployee> GetEmployeeAsync(int employeeId);
        Task<int> AddUpdateEmployee(AddUpdateEmployee addUpdateEmployee);
        Task<int> UpdateEmployeeProfilePhoto(EmployeeProfileImage employeeProfileImage);
    }
}
