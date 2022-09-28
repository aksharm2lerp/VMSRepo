using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Entities.VisitorDashboard;
using Business.Interface;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using Business.SQL;

namespace Business.Service
{

    public class VisitorDashboardService
    {

        private IConfiguration _config { get; set; }
        private string connection = string.Empty;

        public VisitorDashboardService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }


        public async Task<DashbaordCount> GetDashboardCounts(int userid)
        {
            DashbaordCount result = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@UserID", userid) };
                DataSet ds = await SqlHelper.ExecuteDatasetAsync(connection, CommandType.StoredProcedure, "Usp_GetAll_GetVisitorDashboardCount", param);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            result = dr.ToPagedDataTableList<DashbaordCount>();
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
