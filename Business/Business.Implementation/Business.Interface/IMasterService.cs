﻿using Business.Entities;
using Business.Entities.Master;
using Business.Entities.User;
using Business.Entities.Department;
using Business.Entities.Designation;
using Business.SQL;

namespace Business.Interface
{
    public interface IMasterService
    {
        PagedDataTable<IdentityProofTypeMetaData> GetIdentityProofTypeAsync();

        PagedDataTable<VehicleTypeMasterMetaData> GetVehicleTypeAsync();

        PagedDataTable<ZipCodeMaster> GetZipCodeAsync(string search);

        PagedDataTable<FeedbackQuestionMasterMetaData> GetFeedbackQuestions();
        PagedDataTable<IndustryTypeMaster> GetIndustryTypeMasterAsync();
        PagedDataTable<BusinessTypeMaster> GetBusinessTypeMasterAsync();
        PagedDataTable<UserRoleMaster> GetUserRoleMasterAsync();
        PagedDataTable<DepartmentGroup> GetDepartmentGroupsMasterAsync();
        PagedDataTable<DesignationGroup> GetDesignationGroupMasterAsync();
        PagedDataTable<PartyTypeMaster> GetPartyTypeMasterAsync();
    }
}
