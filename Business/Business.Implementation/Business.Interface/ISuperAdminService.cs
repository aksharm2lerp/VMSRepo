using Business.Entities;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface ISuperAdminService
    {
        Task AddPermission(PermissionMasterMetadata item);
        Task<PagedDataTable<PermissionMasterMetadata>> GetAllPermission(int roleid);
    }
}
