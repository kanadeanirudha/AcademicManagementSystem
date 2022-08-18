using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IFishLicenseRuleMasterDataProvider
    {
        IBaseEntityResponse<FishLicenseRuleMaster> InsertFishLicenseRuleMaster(FishLicenseRuleMaster item);
        IBaseEntityResponse<FishLicenseRuleMaster> UpdateFishLicenseRuleMaster(FishLicenseRuleMaster item);
        IBaseEntityResponse<FishLicenseRuleMaster> DeleteFishLicenseRuleMaster(FishLicenseRuleMaster item);
        IBaseEntityCollectionResponse<FishLicenseRuleMaster> GetFishLicenseRuleMasterBySearch(FishLicenseRuleMasterSearchRequest searchRequest);
        IBaseEntityResponse<FishLicenseRuleMaster> GetFishLicenseRuleMasterByID(FishLicenseRuleMaster item);
    }
}
