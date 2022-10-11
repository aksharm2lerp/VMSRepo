using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Party Type Model */
namespace Business.Entities.PartyType
{
    public class PartyType
    {
        public int PartyTypeID { get; set; }

        public string PartyTypeText{ get; set; }

        public string Remark { get; set; }

        public bool IsActive { get; set; } = true;

        public int CreatedOrModifiedBy { get; set; }
        public object SrNo { get; set; }
    }
}