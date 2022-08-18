using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class FeeStructureMasterAndDetailsServiceAccess : IFeeStructureMasterAndDetailsServiceAccess
    {
        IFeeStructureMasterAndDetailsBA _FeeStructureMasterAndDetailsBA = null;
        public FeeStructureMasterAndDetailsServiceAccess()
        {
            _FeeStructureMasterAndDetailsBA = new FeeStructureMasterAndDetailsBA();
        }
        public IBaseEntityResponse<FeeStructureMasterAndDetails> InsertFeeStructureMasterAndDetails(FeeStructureMasterAndDetails item)
        {
            return _FeeStructureMasterAndDetailsBA.InsertFeeStructureMasterAndDetails(item);
        }
        public IBaseEntityResponse<FeeStructureMasterAndDetails> UpdateFeeStructureMasterAndDetails(FeeStructureMasterAndDetails item)
        {
            return _FeeStructureMasterAndDetailsBA.UpdateFeeStructureMasterAndDetails(item);
        }
        public IBaseEntityResponse<FeeStructureMasterAndDetails> DeleteFeeStructureMasterAndDetails(FeeStructureMasterAndDetails item)
        {
            return _FeeStructureMasterAndDetailsBA.DeleteFeeStructureMasterAndDetails(item);
        }
        public IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> GetBySearch(FeeStructureMasterAndDetailsSearchRequest searchRequest)
        {
            return _FeeStructureMasterAndDetailsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> GetFeeSubTypeList(FeeStructureMasterAndDetailsSearchRequest searchRequest)
        {
            return _FeeStructureMasterAndDetailsBA.GetFeeSubTypeList(searchRequest);
        }
        public IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> GetFeeStructureDetails(FeeStructureMasterAndDetailsSearchRequest searchRequest)
        {
            return _FeeStructureMasterAndDetailsBA.GetFeeStructureDetails(searchRequest);
        }
        public IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> GetFeeStructureInstallmentList(FeeStructureMasterAndDetailsSearchRequest searchRequest)
        {
            return _FeeStructureMasterAndDetailsBA.GetFeeStructureInstallmentList(searchRequest);
        }   
        public IBaseEntityResponse<FeeStructureMasterAndDetails> SelectByID(FeeStructureMasterAndDetails item)
        {
            return _FeeStructureMasterAndDetailsBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> GetFeeStructureMasterAndDetailsByFeeStructureMasterID(FeeStructureMasterAndDetailsSearchRequest searchRequest)
        {
            return _FeeStructureMasterAndDetailsBA.GetFeeStructureMasterAndDetailsByFeeStructureMasterID(searchRequest);
        }

        public IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> GetFeeAccountTypeAndSubTypeList(FeeStructureMasterAndDetailsSearchRequest searchRequest)
        {
            return _FeeStructureMasterAndDetailsBA.GetFeeAccountTypeAndSubTypeList(searchRequest);
        }
    }
}
