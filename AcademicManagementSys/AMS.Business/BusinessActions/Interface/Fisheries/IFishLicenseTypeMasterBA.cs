using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessAction
{
    public interface IFishLicenseTypeBA
    {
        IBaseEntityResponse<FishLicenseType> InsertFishLicenseType(FishLicenseType item);
        IBaseEntityResponse<FishLicenseType> UpdateFishLicenseType(FishLicenseType item);
        IBaseEntityResponse<FishLicenseType> DeleteFishLicenseType(FishLicenseType item);
        IBaseEntityCollectionResponse<FishLicenseType> GetBySearch(FishLicenseTypeSearchRequest searchRequest);
        IBaseEntityResponse<FishLicenseType> SelectByID(FishLicenseType item);

        IBaseEntityCollectionResponse<FishLicenseType> GetBySearchList(FishLicenseTypeSearchRequest searchRequest);
    }
}
