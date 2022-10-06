using Business.Entities.Department;
using Business.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IDepartmentService
    {
        Task<PagedDataTable<Department>> GetAllDepartmentAsync(int pageNo , int pageSize, string searchString = "", string orderBy = "DepartmentID", string sortBy = "ASC");

        Task<int> CreateAsync(Department department);
        Task<Department> GetDepartmentAsync(string departmentID);
        Task<int> CreateOrUpdateDepartmentAsync(Department departmet);
    }
}
