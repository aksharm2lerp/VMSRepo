using Business.Entities;
using Business.Interface;
using Business.SQL;

using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Business.Service
{
    public class CompanyService : ISiteCompanyRepository
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public CompanyService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }
        public async Task<PagedDataTable<CompanyMasterMetadata>> GetAllCompanyAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "CompanyName", string sortBy = "ASC")
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<CompanyMasterMetadata> lst = null;
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",pageNo)
                        ,new SqlParameter("@PageSize",pageSize)
                        ,new SqlParameter("@SearchString",searchString)
                        ,new SqlParameter("@OrderBy",orderBy)
                        ,new SqlParameter("@SortBy",sortBy=="ASC"?0:1)

                        };
                using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_CompanyMaster",param))
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
                    lst = table.ToPagedDataTableList<CompanyMasterMetadata>(pageNo,pageSize,totalItemCount);
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
       
        public async Task<int> CreateOrUpdateCompanyAsync(CompanyMasterMetadata compnay)
        {
            try
            {
                SqlParameter[] param = {
                new SqlParameter("@CompanyID", compnay.CompanyID)
                ,new SqlParameter("@CompanyCode", compnay.CompanyCode)
                ,new SqlParameter("@CompanyName", compnay.CompanyName)
                ,new SqlParameter("@IsActive", compnay.IsActive)
                ,new SqlParameter("@CompanyWebsiteText", compnay.CompanyWebsiteText)
                ,new SqlParameter("@CompanyLogoName", compnay.CompanyLogoName)
                ,new SqlParameter("@CompanyLogoImagePath", compnay.CompanyLogoImagePath)
                ,new SqlParameter("@CompanyLogoImage", compnay.CompanyLogoImage)
                ,new SqlParameter("@CompanyGroupName", compnay.CompanyGroupName)
                ,new SqlParameter("@UnitName", compnay.UnitName)
                ,new SqlParameter("@IndustryTypeID", compnay.IndustryTypeID)
                ,new SqlParameter("@BusinessTypeID", compnay.BusinessTypeID)
                ,new SqlParameter("@CreatedBy", compnay.CreatedBy)
                };

                var obj = await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_IU_CompanyMaster", param);

                return obj != null ? Convert.ToInt32(obj) : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
                
        public async Task<CompanyMasterMetadata> GetCompnayAsync(string companyID)
        {
            CompanyMasterMetadata result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@CompanyID", companyID) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_Get_CompanyMaster", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<CompanyMasterMetadata>();
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
