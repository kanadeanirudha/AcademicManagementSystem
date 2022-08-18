using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IGeneralCounterPOSApllicableBA
    {
        IBaseEntityCollectionResponse<GeneralCounterPOSApllicable> GetGeneralCounterPOSApllicable(GeneralCounterPOSApllicableSearchRequest searchRequest);
        IBaseEntityResponse<GeneralCounterPOSApllicable> PostPOSSelfAssignData(GeneralCounterPOSApllicable item);

        IBaseEntityResponse<GeneralCounterPOSApllicable> CheckPOSSelfAssignDataCount(GeneralCounterPOSApllicable item);
    }
}
