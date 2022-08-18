using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class OrganisationStudyCentrePrintingFormatServiceAccess : IOrganisationStudyCentrePrintingFormatServiceAccess
    {
        IOrganisationStudyCentrePrintingFormatBA _organisationStudyCentrePrintingFormatBA = null;
        public OrganisationStudyCentrePrintingFormatServiceAccess()
        {
            _organisationStudyCentrePrintingFormatBA = new OrganisationStudyCentrePrintingFormatBA();
        }
        public IBaseEntityResponse<OrganisationStudyCentrePrintingFormat> InsertOrganisationStudyCentrePrintingFormat(OrganisationStudyCentrePrintingFormat item)
        {
            return _organisationStudyCentrePrintingFormatBA.InsertOrganisationStudyCentrePrintingFormat(item);
        }
        public IBaseEntityResponse<OrganisationStudyCentrePrintingFormat> UpdateOrganisationStudyCentrePrintingFormat(OrganisationStudyCentrePrintingFormat item)
        {
            return _organisationStudyCentrePrintingFormatBA.UpdateOrganisationStudyCentrePrintingFormat(item);
        }
        public IBaseEntityResponse<OrganisationStudyCentrePrintingFormat> DeleteOrganisationStudyCentrePrintingFormat(OrganisationStudyCentrePrintingFormat item)
        {
            return _organisationStudyCentrePrintingFormatBA.DeleteOrganisationStudyCentrePrintingFormat(item);
        }
        public IBaseEntityCollectionResponse<OrganisationStudyCentrePrintingFormat> GetBySearch(OrganisationStudyCentrePrintingFormatSearchRequest searchRequest)
        {
            return _organisationStudyCentrePrintingFormatBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<OrganisationStudyCentrePrintingFormat> SelectByID(OrganisationStudyCentrePrintingFormat item)
        {
            return _organisationStudyCentrePrintingFormatBA.SelectByID(item);
        }
    }
}
