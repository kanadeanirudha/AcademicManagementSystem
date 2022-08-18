using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IOrganisationSectionDetailsServiceAccess
    {
        IBaseEntityResponse<OrganisationSectionDetails> InsertOrganisationSectionDetails(OrganisationSectionDetails item);
        IBaseEntityResponse<OrganisationSectionDetails> UpdateOrganisationSectionDetails(OrganisationSectionDetails item);

        IBaseEntityResponse<OrganisationSectionDetails> UpdateOrganisationSectionDetailsAdd(OrganisationSectionDetails item);
        IBaseEntityResponse<OrganisationSectionDetails> DeleteOrganisationSectionDetails(OrganisationSectionDetails item);
        IBaseEntityCollectionResponse<OrganisationSectionDetails> GetBySearch(OrganisationSectionDetailsSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationSectionDetails> SelectByID(OrganisationSectionDetails item);
        IBaseEntityCollectionResponse<OrganisationSectionDetails> SelectByBranchDetID(OrganisationSectionDetailsSearchRequest searchRequest);

        IBaseEntityCollectionResponse<OrganisationSectionDetails> GetBySearchForSectionDetailsAdd(OrganisationSectionDetailsSearchRequest searchRequest);

        IBaseEntityResponse<OrganisationSectionDetails> SelectByID_OR_CourseYearID(OrganisationSectionDetails item);

        IBaseEntityCollectionResponse<OrganisationSectionDetails> GetSectionDetailsRoleWise(OrganisationSectionDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationSectionDetails> GetSectionDetailsForPromotion(OrganisationSectionDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationSectionDetails> GetSectionDetailsRole_CentreCode_UniversityWise(OrganisationSectionDetailsSearchRequest searchRequest);
    }
}
