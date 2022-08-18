using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Base.DTO;
using AMS.DTO;

namespace AMS.DataProvider
{
    public interface IGeneralNationalityMasterDataProvider
    {
        IBaseEntityCollectionResponse<GeneralNationalityMaster> GetGeneralNationalityMasterBySearch(GeneralNationalityMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<GeneralNationalityMaster> GetGeneralNationalityMasterGetBySearchList(GeneralNationalityMasterSearchRequest searchRequest);

        IBaseEntityResponse<GeneralNationalityMaster> GetGeneralNationalityMasterByID(GeneralNationalityMaster item);

        IBaseEntityResponse<GeneralNationalityMaster> InsertGeneralNationalityMaster(GeneralNationalityMaster item);

        IBaseEntityResponse<GeneralNationalityMaster> UpdateGeneralNationalityMaster(GeneralNationalityMaster item);

        IBaseEntityResponse<GeneralNationalityMaster> DeleteGeneralNationalityMaster(GeneralNationalityMaster item);
    }
}
