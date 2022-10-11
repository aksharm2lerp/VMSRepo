using Business.Entities.Department;
using Business.Entities.Employee;
using Business.Interface;
using Business.SQL;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Threading.Tasks;
using Business.Entities;

namespace Business.Service
{
    public class EmployeeService : IEmployeeService
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public EmployeeService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }
        public async Task<PagedDataTable<EmployeeMaster>> GetAllEmployeesAsync(int pageNo = 1, int pageSize = 10, string searchString = "", string orderBy = "EmployeeID", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)
                        };

                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_EmployeeMaster", param))
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            if (table.ContainColumn("TotalCount"))
                                totalItemCount = Convert.ToInt32(table.Rows[0]["TotalCount"]);
                            else
                                totalItemCount = table.Rows.Count;
                        }
                    }
                    PagedDataTable<EmployeeMaster> lst = table.ToPagedDataTableList<EmployeeMaster>
                        (pageNo, pageSize, totalItemCount, searchString, orderBy, sortBy);
                    return lst;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }

        public async Task<int> AddUpdateEmployee(AddUpdateEmployee addUpdateEmployee)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@EmployeeID",addUpdateEmployee.EmployeeID),
                new SqlParameter("@EmployeeCode", addUpdateEmployee.EmployeeCode ),
                new SqlParameter("@PrefixName", addUpdateEmployee.PrefixName ),
                new SqlParameter("@FirstName", addUpdateEmployee.FirstName ),
                new SqlParameter("@MiddleName", addUpdateEmployee.MiddleName ),
                new SqlParameter("@LastName", addUpdateEmployee.LastName ),
                new SqlParameter("@GenderID", addUpdateEmployee.GenderID ),
                //new SqlParameter("@IsActive", addUpdateEmployee.IsActive ),
                new SqlParameter("@CreatedOrModifiedBy", addUpdateEmployee.CreatedOrModifiedBy ),
                new SqlParameter("@CompanyID", addUpdateEmployee.CompanyID ),
                new SqlParameter("@JobTitle", addUpdateEmployee.JobTitle ),
                new SqlParameter("@DepartmentID", addUpdateEmployee.DepartmentID ),
                new SqlParameter("@DesignationID", addUpdateEmployee.DesignationID ),
                new SqlParameter("@ReportingTo", addUpdateEmployee.ReportingTo),
                new SqlParameter("@PersonalMobileNo", addUpdateEmployee.PersonalMobileNo ),
                new SqlParameter("@OfficeMobileNo", addUpdateEmployee.OfficeMobileNo ),
                new SqlParameter("@AlternativeMobileNo", addUpdateEmployee.AlternativeMobileNo ),
                new SqlParameter("@IsResigned", addUpdateEmployee.IsResigned ),
                new SqlParameter("@Note", addUpdateEmployee.Note ),
                new SqlParameter("@EmailGroupID", addUpdateEmployee.EmailGroupID ),
                new SqlParameter("@PersonalEmail", addUpdateEmployee.PersonalEmail ),
                new SqlParameter("@OfficeEmail", addUpdateEmployee.OfficeEmail ),
                new SqlParameter("@BirthDate", addUpdateEmployee.BirthDate ),
                new SqlParameter("@Religion", addUpdateEmployee.Religion ),
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_EmployeeMaster", param);

                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateEmployeeProfilePhoto(EmployeeProfileImage employeeProfileImage)
        {
            try
            {
                SqlParameter[] param = {
                new SqlParameter("@EmployeeID", employeeProfileImage.EmployeeID),
                new SqlParameter("@ImageName", employeeProfileImage.ImageName),
                new SqlParameter("@ImagePath", employeeProfileImage.ImagePath),
                new SqlParameter("@IsActive", employeeProfileImage.IsActive),
                new SqlParameter("@CreatedOrModifiedBy", employeeProfileImage.CreatedOrModifiedBy ),

                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_EmployeeProfileImage", param);

                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AddUpdateEmployee> GetEmployeeAsync(int employeeId)
        {
            AddUpdateEmployee result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@EmployeeID", employeeId) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_EmployeeMaster", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<AddUpdateEmployee>();
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
