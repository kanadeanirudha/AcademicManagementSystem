using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IFishItemLicenseRateDataProvider
    {
        IBaseEntityResponse<FishItemLicenseRate> InsertFishItemLicenseRate(FishItemLicenseRate item);
        IBaseEntityResponse<FishItemLicenseRate> UpdateFishItemLicenseRate(FishItemLicenseRate item);
        IBaseEntityResponse<FishItemLicenseRate> DeleteFishItemLicenseRate(FishItemLicenseRate item);
        IBaseEntityCollectionResponse<FishItemLicenseRate> GetFishItemLicenseRateBySearch(FishItemLicenseRateSearchRequest searchRequest);
        IBaseEntityResponse<FishItemLicenseRate> GetFishItemLicenseRateByID(FishItemLicenseRate item);

        //Search item name
        IBaseEntityCollectionResponse<FishItemLicenseRate> GetItemNameCentrewiseSearchList(FishItemLicenseRateSearchRequest searchRequest);
    }
}
