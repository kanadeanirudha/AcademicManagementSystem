using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AMS.ServiceAccess
{
    public interface IFishLicenseRuleMasterServiceAccess
    {
        IBaseEntityResponse<FishLicenseRuleMaster> InsertFishLicenseRuleMaster(FishLicenseRuleMaster item);
        IBaseEntityResponse<FishLicenseRuleMaster> UpdateFishLicenseRuleMaster(FishLicenseRuleMaster item);
        IBaseEntityResponse<FishLicenseRuleMaster> DeleteFishLicenseRuleMaster(FishLicenseRuleMaster item);        
        IBaseEntityResponse<FishLicenseRuleMaster> SelectByID(FishLicenseRuleMaster item);
        IBaseEntityCollectionResponse<FishLicenseRuleMaster> GetBySearch(FishLicenseRuleMasterSearchRequest searchRequest);
    }
}
