using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities.Department
{
    public class DepartmentGroup

    {
        public int DepartmentGroupID { get; set; }
        public string DepartmentGroupText { get; set; }
        public string Remark { get; set; }  
        public bool IsActive { get; set; } = true;
        public int CreatedOrModifiedBy { get; set; }
    }
}
