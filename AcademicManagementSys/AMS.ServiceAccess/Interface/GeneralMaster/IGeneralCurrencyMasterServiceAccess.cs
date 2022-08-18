using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IGeneralCurrencyMasterServiceAccess
    {
        IBaseEntityResponse<GeneralCurrencyMaster> InsertGeneralCurrencyMaster(GeneralCurrencyMaster item);
        IBaseEntityResponse<GeneralCurrencyMaster> UpdateGeneralCurrencyMaster(GeneralCurrencyMaster item);
        IBaseEntityResponse<GeneralCurrencyMaster> DeleteGeneralCurrencyMaster(GeneralCurrencyMaster item);
        IBaseEntityCollectionResponse<GeneralCurrencyMaster> GetBySearch(GeneralCurrencyMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralCurrencyMaster> SelectByID(GeneralCurrencyMaster item);
        IBaseEntityCollectionResponse<GeneralCurrencyMaster> GetGeneralCurrencyMasterList(GeneralCurrencyMasterSearchRequest searchRequest);
    }
}
