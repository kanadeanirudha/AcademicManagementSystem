using System;
using System.Collections.Generic;
using System.Linq;
using AMS.Base.DTO;
using AMS.DTO;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessActions
{
    public interface IArticlesAvailabilityReportServiceAccess
    {
        IBaseEntityCollectionResponse<ArticlesAvailabilityReport> GetArticlesAvailabilityReportBySociety(ArticlesAvailabilityReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<ArticlesAvailabilityReport> GetArticlesAvailabilityReportByCentre(ArticlesAvailabilityReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<ArticlesAvailabilityReport> GetArticlesAvailabilityReportByStore(ArticlesAvailabilityReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<ArticlesAvailabilityReport> GetArticlesAvailabilityReportByVendor(ArticlesAvailabilityReportSearchRequest searchRequest);

    }
}
