using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessAction
{
    public interface IFishItemLicenseRateBA
    {
        IBaseEntityResponse<FishItemLicenseRate> InsertFishItemLicenseRate(FishItemLicenseRate item);
        IBaseEntityResponse<FishItemLicenseRate> UpdateFishItemLicenseRate(FishItemLicenseRate item);
        IBaseEntityResponse<FishItemLicenseRate> DeleteFishItemLicenseRate(FishItemLicenseRate item);
        IBaseEntityCollectionResponse<FishItemLicenseRate> GetBySearch(FishItemLicenseRateSearchRequest searchRequest);
        IBaseEntityResponse<FishItemLicenseRate> SelectByID(FishItemLicenseRate item);

        //For Serach Text
        IBaseEntityCollectionResponse<FishItemLicenseRate> GetItemNameCentrewiseSearchList(FishItemLicenseRateSearchRequest searchRequest);
    }
}
