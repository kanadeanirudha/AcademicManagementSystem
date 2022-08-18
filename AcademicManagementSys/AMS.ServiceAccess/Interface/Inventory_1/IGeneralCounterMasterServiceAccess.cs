using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IGeneralCounterMasterServiceAccess
    {
        IBaseEntityResponse<GeneralCounterMaster> InsertGeneralCounterMaster(GeneralCounterMaster item);
        IBaseEntityResponse<GeneralCounterMaster> UpdateGeneralCounterMaster(GeneralCounterMaster item);
        IBaseEntityResponse<GeneralCounterMaster> DeleteGeneralCounterMaster(GeneralCounterMaster item);
        IBaseEntityCollectionResponse<GeneralCounterMaster> GetBySearch(GeneralCounterMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralCounterMaster> SelectByID(GeneralCounterMaster item);
        IBaseEntityCollectionResponse<GeneralCounterMaster> GetGeneralCounterMasterSearchList(GeneralCounterMasterSearchRequest searchRequest);
    }
}
