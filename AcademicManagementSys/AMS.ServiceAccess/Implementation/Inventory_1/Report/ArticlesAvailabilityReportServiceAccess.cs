using System;
using System.Collections.Generic;
using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class ArticlesAvailabilityReportServiceAccess : IArticlesAvailabilityReportServiceAccess
    {
        IArticlesAvailabilityReportBA _ArticlesAvailabilityReportBA = null;
        public ArticlesAvailabilityReportServiceAccess()
        {
            _ArticlesAvailabilityReportBA = new ArticlesAvailabilityReportBA();
        }

        public IBaseEntityCollectionResponse<ArticlesAvailabilityReport> GetArticlesAvailabilityReportBySociety(ArticlesAvailabilityReportSearchRequest searchRequest)
        {
            return _ArticlesAvailabilityReportBA.GetArticlesAvailabilityReportBySociety(searchRequest);
        }

        public IBaseEntityCollectionResponse<ArticlesAvailabilityReport> GetArticlesAvailabilityReportByCentre(ArticlesAvailabilityReportSearchRequest searchRequest)
        {
            return _ArticlesAvailabilityReportBA.GetArticlesAvailabilityReportByCentre(searchRequest);
        }
        public IBaseEntityCollectionResponse<ArticlesAvailabilityReport> GetArticlesAvailabilityReportByStore(ArticlesAvailabilityReportSearchRequest searchRequest)
        {
            return _ArticlesAvailabilityReportBA.GetArticlesAvailabilityReportByStore(searchRequest);
        }
        public IBaseEntityCollectionResponse<ArticlesAvailabilityReport> GetArticlesAvailabilityReportByVendor(ArticlesAvailabilityReportSearchRequest searchRequest)
        {
            return _ArticlesAvailabilityReportBA.GetArticlesAvailabilityReportByVendor(searchRequest);
        }
    }
}
