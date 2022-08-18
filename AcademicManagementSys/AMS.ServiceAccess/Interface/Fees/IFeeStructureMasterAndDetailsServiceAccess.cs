using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IFeeStructureMasterAndDetailsServiceAccess
    {
        IBaseEntityResponse<FeeStructureMasterAndDetails> InsertFeeStructureMasterAndDetails(FeeStructureMasterAndDetails item);
        IBaseEntityResponse<FeeStructureMasterAndDetails> UpdateFeeStructureMasterAndDetails(FeeStructureMasterAndDetails item);
        IBaseEntityResponse<FeeStructureMasterAndDetails> DeleteFeeStructureMasterAndDetails(FeeStructureMasterAndDetails item);
        IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> GetBySearch(FeeStructureMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> GetFeeSubTypeList(FeeStructureMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> GetFeeStructureDetails(FeeStructureMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> GetFeeStructureInstallmentList(FeeStructureMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<FeeStructureMasterAndDetails> SelectByID(FeeStructureMasterAndDetails item);
        IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> GetFeeStructureMasterAndDetailsByFeeStructureMasterID(FeeStructureMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> GetFeeAccountTypeAndSubTypeList(FeeStructureMasterAndDetailsSearchRequest searchRequest);
    }
}
