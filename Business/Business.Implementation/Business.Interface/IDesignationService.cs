using Business.Entities;
using Business.Entities.Designation;
using Business.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IDesignationService
    {
        Task<PagedDataTable<DesignationMaster>> GetAllDesignationAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "DesignationText", string sortBy = "ASC");
        Task<int> CreateDesignationGroupAsync(DesignationGroup designationGroupMaster);
        Task<int> DesignationRegisterAsync(DesignationMaster model);
        Task<DesignationMaster> GetDesignationAsync(string designationtID);

    }
}
