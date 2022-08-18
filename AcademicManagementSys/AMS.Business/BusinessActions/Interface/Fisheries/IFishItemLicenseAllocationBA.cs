using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessAction
{
    public interface IFishItemLicenseAllocationBA
    {
        IBaseEntityResponse<FishItemLicenseAllocation> InsertFishItemLicenseAllocation(FishItemLicenseAllocation item);
        IBaseEntityResponse<FishItemLicenseAllocation> UpdateFishItemLicenseAllocation(FishItemLicenseAllocation item);
        IBaseEntityResponse<FishItemLicenseAllocation> DeleteFishItemLicenseAllocation(FishItemLicenseAllocation item);
        IBaseEntityCollectionResponse<FishItemLicenseAllocation> GetBySearch(FishItemLicenseAllocationSearchRequest searchRequest);
        IBaseEntityResponse<FishItemLicenseAllocation> SelectByID(FishItemLicenseAllocation item);
    }
}
