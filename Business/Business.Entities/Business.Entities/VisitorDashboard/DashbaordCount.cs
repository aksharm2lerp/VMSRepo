using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities.VisitorDashboard
{
    public class DashbaordCount
    {
        public int TotalVisitor { get; set; }
        public int TodayUpcommingVisitor { get; set; }
        public int TodayVisitCompleted { get; set; }
        public int UpcommingVisitor { get; set; }
        public int TotalRejected { get; set; }
    }
}
