using Business.Entities.Department;
using Business.Interface;
using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public class DepartmentService : IDepartmentService
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public DepartmentService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }


        public async Task<PagedDataTable<Department>> GetAllDepartmentAsync(int pageNo = 1, int pageSize = 5, string searchString = "" , string orderBy = "DepartmentID", string sortBy = "ASC")
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

                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_DepartmentMaster", param))
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
                    PagedDataTable<Department> lst = table.ToPagedDataTableList<Department>
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


        public async Task<int> CreateAsync(Department department)
        {
            try
            {
                SqlParameter[] param = {
                new SqlParameter("@DepartmentID", department.DepartmentID)
                ,new SqlParameter("@DepartmentName", department.DepartmentName)
                ,new SqlParameter("@Description", department.Description)
                ,new SqlParameter("@DepartmentGroupID", department.DepartmentGroupID)
                ,new SqlParameter("@IsActive", department.IsActive)
                ,new SqlParameter("@CreatedOrModifiedBy", department.CreatedOrModifiedBy)
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_DepartmentMaster", param);

                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Department> GetDepartmentAsync(string departmentID)
        {
            Department result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@DepartmentID", departmentID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_DepartmentMaster", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<Department>();
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

        public async Task<int> CreateOrUpdateDepartmentAsync(Department department)
        {
            try
            {
                SqlParameter[] param = {
                new SqlParameter("@DepartmentID", department.DepartmentID)
                ,new SqlParameter("@DepartmentName", department.DepartmentName)
                ,new SqlParameter("@Description", department.Description)
                ,new SqlParameter("@DepartmentGroupID", department.DepartmentGroupID)
                ,new SqlParameter("@IsActive", department.IsActive)
                ,new SqlParameter("@CreatedOrModifiedBy", department.CreatedOrModifiedBy)
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_DepartmentMaster", param);

                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
