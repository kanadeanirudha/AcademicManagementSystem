using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IFishLicenseTypeDataProvider
    {
        IBaseEntityResponse<FishLicenseType> InsertFishLicenseType(FishLicenseType item);
        IBaseEntityResponse<FishLicenseType> UpdateFishLicenseType(FishLicenseType item);
        IBaseEntityResponse<FishLicenseType> DeleteFishLicenseType(FishLicenseType item);
        IBaseEntityCollectionResponse<FishLicenseType> GetFishLicenseTypeBySearch(FishLicenseTypeSearchRequest searchRequest);
        IBaseEntityResponse<FishLicenseType> GetFishLicenseTypeByID(FishLicenseType item);

        IBaseEntityCollectionResponse<FishLicenseType> GetFishLicenseTypeBySearchList(FishLicenseTypeSearchRequest searchRequest);
    }
}
