using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IGeneralTransactionMasterBA
    {
        IBaseEntityResponse<GeneralTransactionMaster> InsertGeneralTransactionMaster(GeneralTransactionMaster item);
        IBaseEntityResponse<GeneralTransactionMaster> UpdateGeneralTransactionMaster(GeneralTransactionMaster item);
        IBaseEntityResponse<GeneralTransactionMaster> DeleteGeneralTransactionMaster(GeneralTransactionMaster item);
        IBaseEntityCollectionResponse<GeneralTransactionMaster> GetBySearch(GeneralTransactionMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralTransactionMaster> GetGeneralTransactionMasterSearchList(GeneralTransactionMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralTransactionMaster> SelectByID(GeneralTransactionMaster item);
    }
}

