using Microsoft.Extensions.Configuration;
using Business.Interface;
using Business.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Business.Entities.Department;

namespace Business.Service
{
    public class DepartmentGroupService: IDepartmentGroupService
    {

        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public DepartmentGroupService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        /*Create New Department Group*/
        public async Task<int> CreateDepartmentGroupAsync(DepartmentGroup departmentGroup)
        {
            try
            {
                SqlParameter[] param = {
                new SqlParameter("@DepartmentGroupID", departmentGroup.DepartmentGroupID)
                ,new SqlParameter("@DepartmentGroupText", departmentGroup.DepartmentGroupText)
                ,new SqlParameter("@Remark", departmentGroup.Remark)
                ,new SqlParameter("@IsActive", departmentGroup.IsActive)
                ,new SqlParameter("@CreatedOrModifiedBy", departmentGroup.CreatedOrModifiedBy)
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_DepartmentGroupMaster", param);

                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*Create New Department Group*/


    }
}
