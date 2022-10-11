using Business.Entities;
using Business.Entities.Department;
using Business.Entities.Designation;
using Business.Entities.Employee;
using Business.Entities.Gender;
using Business.Entities.Master;
using Business.Entities.SecurityOfficer;
using Business.Entities.User;
using Business.Interface;
using Business.SQL;
using MailKit.Search;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

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

        #region Multiple record select
        public PagedDataTable<Department> GetAllDepartments()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<Department> lst = new PagedDataTable<Department>();
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",1)
                        ,new SqlParameter("@PageSize","0")
                        ,new SqlParameter("@SearchString","")
                        ,new SqlParameter("@OrderBy","")
                        ,new SqlParameter("@SortBy","")
                        };
                using (DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "Usp_GetAll_DepartmentMaster", param))
        public PagedDataTable<DesignationGroup> GetDesignationGroupMasterAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<DesignationGroup> lst = new PagedDataTable<DesignationGroup>();
            try
            {
                using (DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "Usp_GetAll_DesignationGroupMaster"))
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
                    lst = table.ToPagedDataTableList<Department>();
                    lst = table.ToPagedDataTableList<DesignationGroup>
                       (1, 20, totalItemCount, null, "DesignationGroupText", "ASC");
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


        public PagedDataTable<PartyTypeMaster> GetPartyTypeMasterAsync()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<PartyTypeMaster> lst = new PagedDataTable<PartyTypeMaster>();
            try
            {
                using (DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "Usp_GetAll_PartyTypeMaster"))

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

                    lst = table.ToPagedDataTableList<PartyTypeMaster>
                       (1, 20, totalItemCount, null, "PartyTypeText", "ASC");

                    lst = table.ToPagedDataTableList<DesignationMaster>();

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


        public PagedDataTable<EmployeeMaster> GetAllEmployees()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<EmployeeMaster> lst = new PagedDataTable<EmployeeMaster>();
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",1)
                        ,new SqlParameter("@PageSize","0")
                        ,new SqlParameter("@SearchString","")
                        ,new SqlParameter("@OrderBy","")
                        ,new SqlParameter("@SortBy","")
                        };
                using (DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "Usp_GetAll_EmployeeMaster", param))
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
                    lst = table.ToPagedDataTableList<EmployeeMaster>();
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

        public PagedDataTable<GenderMaster> GetAllGenders()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<GenderMaster> lst = new PagedDataTable<GenderMaster>();
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@PageNo", 0),
                    new SqlParameter("@PageSize", "5"),
                };
                using (DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "Usp_GetAll_GenderMaster", param))
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
                    lst = table.ToPagedDataTableList<GenderMaster>();
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
        public PagedDataTable<EmailGroupMaster> GetAllEmailGroupMaster()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<EmailGroupMaster> lst = new PagedDataTable<EmailGroupMaster>();
            try
            {
                using (DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "Usp_GetAll_EmailGroupMaster"))
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
                    lst = table.ToPagedDataTableList<EmailGroupMaster>();
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

        public PagedDataTable<SecurityOfficerMaster> GetAllSecurityOfficers()
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<SecurityOfficerMaster> lst = new PagedDataTable<SecurityOfficerMaster>();
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",1)
                        ,new SqlParameter("@PageSize","0")
                        ,new SqlParameter("@SearchString","")
                        ,new SqlParameter("@OrderBy","")
                        ,new SqlParameter("@SortBy","")
                        };
                using (DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "Usp_GetAll_SecurityOfficer", param))
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
                    lst = table.ToPagedDataTableList<SecurityOfficerMaster>();
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
        #endregion Multiple record select


        #region Single record select

        public PagedDataTable<Department> GetDepartment(int departmentId)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<Department> lst = new PagedDataTable<Department>();
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",1)
                        ,new SqlParameter("@PageSize","0")
                        ,new SqlParameter("@SearchString","")
                        ,new SqlParameter("@OrderBy","")
                        ,new SqlParameter("@SortBy","")
                        };
                using (DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "Usp_GetAll_DepartmentMaster", param))
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
                    lst = table.ToPagedDataTableList<Department>();
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

        public PagedDataTable<DesignationMaster> GetDesignation(int designationID)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<DesignationMaster> lst = new PagedDataTable<DesignationMaster>();
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@PageNo", 1),
                    new SqlParameter("@PageSize", "0"),
                };
                using (DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "Usp_GetAll_DesignationMaster", param))
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
                    lst = table.ToPagedDataTableList<DesignationMaster>();
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

        public PagedDataTable<EmployeeMaster> GetEmployee(int employeeID)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<EmployeeMaster> lst = new PagedDataTable<EmployeeMaster>();
            try
            {
                SqlParameter[] param = {
                        new SqlParameter("@PageNo",1)
                        ,new SqlParameter("@PageSize","0")
                        ,new SqlParameter("@SearchString","")
                        ,new SqlParameter("@OrderBy","")
                        ,new SqlParameter("@SortBy","")
                        };
                using (DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "Usp_GetAll_EmployeeMaster", param))
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
                    lst = table.ToPagedDataTableList<EmployeeMaster>();
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

        public PagedDataTable<GenderMaster> GetGender(int genderID)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<GenderMaster> lst = new PagedDataTable<GenderMaster>();
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@PageNo", 0),
                    new SqlParameter("@PageSize", "5"),
                };
                using (DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "Usp_GetAll_GenderMaster", param))
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
                    lst = table.ToPagedDataTableList<GenderMaster>();
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
        public PagedDataTable<EmailGroupMaster> GetEmailGroupMaster(int emailGroupID)
        {
            DataTable table = new DataTable();
            int totalItemCount = 0;
            PagedDataTable<EmailGroupMaster> lst = new PagedDataTable<EmailGroupMaster>();
            try
            {
                using (DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "Usp_GetAll_EmailGroupMaster"))
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
                    lst = table.ToPagedDataTableList<EmailGroupMaster>();
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

        #endregion Single record select

    }
}
