using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public class DepartmentGroupService
    {

        private IConfiguration _config { get; set; }
        private string connection = string.Empty;
        public DepartmentGroupService(IConfiguration config)
        {
            _config = config;
            connection = _config.GetConnectionString("DefaultConnection");
        }
    }
}
