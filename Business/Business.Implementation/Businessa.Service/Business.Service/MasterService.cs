using Business.Entities;
using Business.Entities.Department;
using Business.Entities.Master;
using Business.Entities.User;
using Business.Interface;
using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Service
{
    public class MasterService : IMasterService
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public MasterService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }

        public PagedDataTable<IdentityProofTypeMetaData> GetIdentityProofTypeAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<IdentityProofTypeMetaData> lst = new PagedDataTable<IdentityProofTypeMetaData>();
            try
            {
                using (DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "Usp_GetAll_IdentityProofTypeMasterData"))
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
                    lst = table.ToPagedDataTableList<IdentityProofTypeMetaData>
                       (1, 20, totalItemCount, null, "IdentityProofTypeText", "ASC");
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
            return lst;
        }

        public PagedDataTable<VehicleTypeMasterMetaData> GetVehicleTypeAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<VehicleTypeMasterMetaData> lst = new PagedDataTable<VehicleTypeMasterMetaData>();
            try
            {
                using (DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "Usp_GetAll_VehicleTypeMasterData"))
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
                    lst = table.ToPagedDataTableList<VehicleTypeMasterMetaData>
                       (1, 20, totalItemCount, null, "VehicleTypeText", "ASC");
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
            return lst;
        }

        public PagedDataTable<ZipCodeMaster> GetZipCodeAsync(string search)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<ZipCodeMaster> lst = new PagedDataTable<ZipCodeMaster>();
            try
            {
                SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@SearchString", search) };
                using (DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "Usp_GetAll_ZipCodeMaster", sp))
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
                    lst = table.ToPagedDataTableList<ZipCodeMaster>
                       (1, 20, totalItemCount, null, "ZipCode", "ASC");
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
            return lst;
        }

        public PagedDataTable<FeedbackQuestionMasterMetaData> GetFeedbackQuestions()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<FeedbackQuestionMasterMetaData> lst = new PagedDataTable<FeedbackQuestionMasterMetaData>();
            try
            {
                using (DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "Usp_GetAll_FeedbackQuestionMaster"))
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
                    lst = table.ToPagedDataTableList<FeedbackQuestionMasterMetaData>
                       (1, 20, totalItemCount, null, "FeedbackQuestionID", "ASC");
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
            return lst;
        }

        public PagedDataTable<IndustryTypeMaster> GetIndustryTypeMasterAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<IndustryTypeMaster> lst = new PagedDataTable<IndustryTypeMaster>();
            try
            {
                using (DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "Usp_GetAll_IndustryTypeMaster"))
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
                    lst = table.ToPagedDataTableList<IndustryTypeMaster>
                       (1, 20, totalItemCount, null, "IndustryTypeText", "ASC");
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
            return lst;
        }
        public PagedDataTable<BusinessTypeMaster> GetBusinessTypeMasterAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<BusinessTypeMaster> lst = new PagedDataTable<BusinessTypeMaster>();
            try
            {
                using (DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "Usp_GetAll_BusinessTypeMaster"))
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
                    lst = table.ToPagedDataTableList<BusinessTypeMaster>
                       (1, 20, totalItemCount, null, "BusinessTypeText", "ASC");
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
            return lst;
        }


        public PagedDataTable<UserRoleMaster> GetUserRoleMasterAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<UserRoleMaster> lst = new PagedDataTable<UserRoleMaster>();
            try
            {
                using (DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "Usp_GetAll_RoleMaster"))
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
                    lst = table.ToPagedDataTableList<UserRoleMaster>
                       (1, 20, totalItemCount, null, "RoleName", "ASC");
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
            return lst;
        }
        public PagedDataTable<DepartmentGroup> GetDepartmentGroupsMasterAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<DepartmentGroup> lst = new PagedDataTable<DepartmentGroup>();
            try
            {
                using (DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "Usp_GetAll_DepartmentGroupMaster"))
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
                    lst = table.ToPagedDataTableList<DepartmentGroup>
                       (1, 20, totalItemCount, null, "DepartmentGroupText", "ASC");
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
            return lst;
        }

    }
}
