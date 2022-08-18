using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IGeneralTransactionMasterServiceAccess
    {
        IBaseEntityResponse<GeneralTransactionMaster> InsertGeneralTransactionMaster(GeneralTransactionMaster item);
        IBaseEntityResponse<GeneralTransactionMaster> UpdateGeneralTransactionMaster(GeneralTransactionMaster item);
        IBaseEntityResponse<GeneralTransactionMaster> DeleteGeneralTransactionMaster(GeneralTransactionMaster item);
        IBaseEntityCollectionResponse<GeneralTransactionMaster> GetBySearch(GeneralTransactionMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralTransactionMaster> SelectByID(GeneralTransactionMaster item);
        IBaseEntityCollectionResponse<GeneralTransactionMaster> GetGeneralTransactionMasterSearchList(GeneralTransactionMasterSearchRequest searchRequest);
    }
}
