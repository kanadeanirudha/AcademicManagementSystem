using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IFishItemLicenseAllocationDataProvider
    {
        IBaseEntityResponse<FishItemLicenseAllocation> InsertFishItemLicenseAllocation(FishItemLicenseAllocation item);
        IBaseEntityResponse<FishItemLicenseAllocation> UpdateFishItemLicenseAllocation(FishItemLicenseAllocation item);
        IBaseEntityResponse<FishItemLicenseAllocation> DeleteFishItemLicenseAllocation(FishItemLicenseAllocation item);
        IBaseEntityCollectionResponse<FishItemLicenseAllocation> GetFishItemLicenseAllocationBySearch(FishItemLicenseAllocationSearchRequest searchRequest);
        IBaseEntityResponse<FishItemLicenseAllocation> GetFishItemLicenseAllocationByID(FishItemLicenseAllocation item);
    }
}
