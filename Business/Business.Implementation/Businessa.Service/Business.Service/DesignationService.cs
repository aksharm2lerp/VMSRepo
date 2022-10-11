using Business.Entities.Designation;
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
    public class DesignationService : IDesignationService
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public DesignationService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        /*Designation List*/
        public async Task<PagedDataTable<DesignationMaster>> GetAllDesignationAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "DesignationText", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<DesignationMaster> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_DesignationMaster", param))
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
                    lst = table.ToPagedDataTableList<DesignationMaster>(pageNo, pageSize, totalItemCount);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (table != null)
                    table.Dispose();
            }
        }
        /*Designation List*/

        /*Create New Designation Level*/
        public async Task<int> CreateDesignationGroupAsync(DesignationGroup designationGroupMaster)
        {
            try
            {
                SqlParameter[] param = {
                 new SqlParameter("@DesignationGroupID", designationGroupMaster.DesignationGroupID)
                ,new SqlParameter("@DesignationGroupText", designationGroupMaster.DesignationGroupText)
                ,new SqlParameter("@Remark", designationGroupMaster.Remark)
                ,new SqlParameter("@IsActive", designationGroupMaster.IsActive)
                ,new SqlParameter("@CreatedOrModifiedBy", designationGroupMaster.CreatedOrModifiedBy)
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_DesignationGroupMaster", param);

                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*Create New Designation Level*/


        /*Register Designation start*/
        public async Task<int> DesignationRegisterAsync(DesignationMaster designationMaster)
        {
            try
            {
                SqlParameter[] param = {
                new SqlParameter("@DesignationID", designationMaster.DesignationID)
                ,new SqlParameter("@DesignationText", designationMaster.DesignationText)
                ,new SqlParameter("@Description", designationMaster.Description)
                ,new SqlParameter("@DesignationLevel", designationMaster.DesignationLevel)
                ,new SqlParameter("@DesignationGroupID", designationMaster.DesignationGroupID)
                ,new SqlParameter("@IsActive", designationMaster.IsActive)
                ,new SqlParameter("@CreatedOrModifiedBy", designationMaster.CreatedOrModifiedBy)
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_DesignationMaster", param);

                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*Register Designation end*/

        public async Task<DesignationMaster> GetDesignationAsync(string DesignationtID)
        {
            DesignationMaster result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@DesignationID",  DesignationtID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_DesignationMaster", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<DesignationMaster>();
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

