using System;

namespace Business.Entities.Designation
{
    public class DesignationMaster
    {
        public int DesignationID { get; set; }
        public string DesignationText { get; set; }
        public string Description { get; set; }
        public string DesignationLevel { get; set; }
        public int DesignationGroupID { get; set; }
        public int CreatedOrModifiedBy { get; set; }
        public DateTime CreatedOrModifiedDateTime { get; set; }

    }
}
