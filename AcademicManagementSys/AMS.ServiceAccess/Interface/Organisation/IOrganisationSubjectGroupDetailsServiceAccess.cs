using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IOrganisationSubjectGroupDetailsServiceAccess
    {
        IBaseEntityResponse<OrganisationSubjectGroupDetails> InsertOrganisationSubjectGroupDetails(OrganisationSubjectGroupDetails item);
        IBaseEntityResponse<OrganisationSubjectGroupDetails> UpdateOrganisationSubjectGroupDetails(OrganisationSubjectGroupDetails item);
        IBaseEntityResponse<OrganisationSubjectGroupDetails> DeleteOrganisationSubjectGroupDetails(OrganisationSubjectGroupDetails item);
        IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> GetBySearch(OrganisationSubjectGroupDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> GetBySubjectTypeMaterList(OrganisationSubjectGroupDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> GetByElectiveGroupSearchList(OrganisationSubjectGroupDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> GetBySubElectiveGroupSearchList(OrganisationSubjectGroupDetailsSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationSubjectGroupDetails> SelectByID(OrganisationSubjectGroupDetails item);
       //used for OnlineExamStaff Allocation
        IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> GetByDescriptionList(OrganisationSubjectGroupDetailsSearchRequest searchRequest);
    }
}
