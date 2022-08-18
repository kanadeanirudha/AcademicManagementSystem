using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IGeneralTransactionMasterDataProvider
    {
        IBaseEntityResponse<GeneralTransactionMaster> InsertGeneralTransactionMaster(GeneralTransactionMaster item);
        IBaseEntityResponse<GeneralTransactionMaster> UpdateGeneralTransactionMaster(GeneralTransactionMaster item);
        IBaseEntityResponse<GeneralTransactionMaster> DeleteGeneralTransactionMaster(GeneralTransactionMaster item);
        IBaseEntityCollectionResponse<GeneralTransactionMaster> GetGeneralTransactionMasterBySearch(GeneralTransactionMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralTransactionMaster> GetGeneralTransactionMasterSearchList(GeneralTransactionMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralTransactionMaster> GetGeneralTransactionMasterByID(GeneralTransactionMaster item);
    }
}
