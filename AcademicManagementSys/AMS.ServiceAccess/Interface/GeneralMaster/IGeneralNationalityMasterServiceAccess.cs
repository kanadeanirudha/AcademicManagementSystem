using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IGeneralNationalityMasterServiceAccess
    {
        IBaseEntityResponse<GeneralNationalityMaster> InsertGeneralNationalityMaster(GeneralNationalityMaster item);

        IBaseEntityResponse<GeneralNationalityMaster> UpdateGeneralNationalityMaster(GeneralNationalityMaster item);

        IBaseEntityResponse<GeneralNationalityMaster> DeleteGeneralNationalityMaster(GeneralNationalityMaster item);

        IBaseEntityCollectionResponse<GeneralNationalityMaster> GetBySearch(GeneralNationalityMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<GeneralNationalityMaster> GetBySearchList(GeneralNationalityMasterSearchRequest searchRequest);

        IBaseEntityResponse<GeneralNationalityMaster> SelectByID(GeneralNationalityMaster item);
    }
}
