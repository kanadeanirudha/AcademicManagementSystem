using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IGeneralUnitMasterServiceAccess
    {
        IBaseEntityResponse<GeneralUnitMaster> InsertGeneralUnitMaster(GeneralUnitMaster item);
        IBaseEntityResponse<GeneralUnitMaster> UpdateGeneralUnitMaster(GeneralUnitMaster item);
        IBaseEntityResponse<GeneralUnitMaster> DeleteGeneralUnitMaster(GeneralUnitMaster item);
        IBaseEntityCollectionResponse<GeneralUnitMaster> GetBySearch(GeneralUnitMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralUnitMaster> GetBySearchList(GeneralUnitMasterSearchRequest searchRequest);

        IBaseEntityResponse<GeneralUnitMaster> SelectByID(GeneralUnitMaster item);
    }
}
