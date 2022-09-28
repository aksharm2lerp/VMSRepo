using Business.Entities;
using Business.SQL;

using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface ISiteCompanyRepository
    {
        Task<int> CreateOrUpdateCompanyAsync(CompanyMasterMetadata compnay);
        Task<CompanyMasterMetadata> GetCompnayAsync(string companyID);
        Task<PagedDataTable<CompanyMasterMetadata>> GetAllCompanyAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "CompanyName", string sortBy = "ASC");


       

    }
}
