using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class GeneralCounterPOSApllicableServiceAccess : IGeneralCounterPOSApllicableServiceAccess
    {
        IGeneralCounterPOSApllicableBA _generalCounterPOSApllicableBA = null;
        public GeneralCounterPOSApllicableServiceAccess()
        {
            _generalCounterPOSApllicableBA = new GeneralCounterPOSApllicableBA();
        }
        public IBaseEntityCollectionResponse<GeneralCounterPOSApllicable> GetGeneralCounterPOSApllicable(GeneralCounterPOSApllicableSearchRequest searchRequest)
        {
            return _generalCounterPOSApllicableBA.GetGeneralCounterPOSApllicable(searchRequest);
        }
        public IBaseEntityResponse<GeneralCounterPOSApllicable> PostPOSSelfAssignData(GeneralCounterPOSApllicable searchRequest)
        {
            return _generalCounterPOSApllicableBA.PostPOSSelfAssignData(searchRequest);
        }
        public IBaseEntityResponse<GeneralCounterPOSApllicable> CheckPOSSelfAssignDataCount(GeneralCounterPOSApllicable searchRequest)
        {
            return _generalCounterPOSApllicableBA.CheckPOSSelfAssignDataCount(searchRequest);
        }
    }
}
