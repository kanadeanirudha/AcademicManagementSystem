using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IOrganisationStudyCentrePrintingFormatServiceAccess
    {
        IBaseEntityResponse<OrganisationStudyCentrePrintingFormat> InsertOrganisationStudyCentrePrintingFormat(OrganisationStudyCentrePrintingFormat item);
        IBaseEntityResponse<OrganisationStudyCentrePrintingFormat> UpdateOrganisationStudyCentrePrintingFormat(OrganisationStudyCentrePrintingFormat item);
        IBaseEntityResponse<OrganisationStudyCentrePrintingFormat> DeleteOrganisationStudyCentrePrintingFormat(OrganisationStudyCentrePrintingFormat item);
        IBaseEntityCollectionResponse<OrganisationStudyCentrePrintingFormat> GetBySearch(OrganisationStudyCentrePrintingFormatSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationStudyCentrePrintingFormat> SelectByID(OrganisationStudyCentrePrintingFormat item);
    }
}
