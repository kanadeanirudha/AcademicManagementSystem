using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessAction
{
    public interface IFishLicenseRuleMasterBA
    {
        IBaseEntityResponse<FishLicenseRuleMaster> InsertFishLicenseRuleMaster(FishLicenseRuleMaster item);
        IBaseEntityResponse<FishLicenseRuleMaster> UpdateFishLicenseRuleMaster(FishLicenseRuleMaster item);
        IBaseEntityResponse<FishLicenseRuleMaster> DeleteFishLicenseRuleMaster(FishLicenseRuleMaster item);
        IBaseEntityCollectionResponse<FishLicenseRuleMaster> GetBySearch(FishLicenseRuleMasterSearchRequest searchRequest);
        IBaseEntityResponse<FishLicenseRuleMaster> SelectByID(FishLicenseRuleMaster item);
    }
}
