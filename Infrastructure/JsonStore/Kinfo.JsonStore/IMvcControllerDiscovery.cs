using Business.Entities;
using System.Collections.Generic;

namespace Kinfo.JsonStore
{
    public interface IMvcControllerDiscovery
    {
        IList<MvcControllerInfo> GetControllers();
    }
}