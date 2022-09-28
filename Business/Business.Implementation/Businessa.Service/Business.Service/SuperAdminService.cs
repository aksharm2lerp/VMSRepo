using Business.Entities;
using Business.Interface;
using Business.SQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Business.Service
{
    public class SuperAdminService : ISuperAdminService
    {
        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public SuperAdminService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }


        public async Task AddPermission(PermissionMasterMetadata item)
        {
            try
            {
                SqlParameter[] param = { new SqlParameter("@PermissionDesc", item.PermissionDesc)
                        , new SqlParameter("@Controller", item.Controller)
                        , new SqlParameter("@Action", item.Action)
                        , new SqlParameter("@Area", item.Area)

                };
                await SqlHelper.ExecuteScalarAsync(connection, CommandType.StoredProcedure, "Usp_I_PermissionMaster", param);
            }
            catch
            {
                throw;
            }
        }
        public async Task<PagedDataTable<PermissionMasterMetadata>> GetAllPermission(int roleid)
        {
            try
            {
                DataTable table = new DataTable();
                int totalItemCount = 0;
                PagedDataTable<PermissionMasterMetadata> lst = null;
                try
                {
                    SqlParameter[] param = { new SqlParameter("@RoleID", roleid) };
                    using (DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_PermisisonMaster",param))
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
                        lst = table.ToPagedDataTableList<PermissionMasterMetadata>(1, 0, totalItemCount);
                        return lst;
                    }
                }
                catch 
                {
                    throw ;
                }
                finally
                {
                    if (table != null)
                        table.Dispose();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
