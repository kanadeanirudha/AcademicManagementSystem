using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;
namespace AMS.ServiceAccess
{
	public class FeeStructureApplicableServiceAccess : IFeeStructureApplicableServiceAccess
	{
		IFeeStructureApplicableBA _FeeStructureApplicableBA = null;
		public FeeStructureApplicableServiceAccess()
		{
			_FeeStructureApplicableBA = new FeeStructureApplicableBA();
		}
		public IBaseEntityResponse<FeeStructureApplicable> InsertFeeStructureApplicable(FeeStructureApplicable item)
		{
			return _FeeStructureApplicableBA.InsertFeeStructureApplicable(item);
		}
		public IBaseEntityResponse<FeeStructureApplicable> UpdateFeeStructureApplicable(FeeStructureApplicable item)
		{
			return _FeeStructureApplicableBA.UpdateFeeStructureApplicable(item);
		}
		public IBaseEntityResponse<FeeStructureApplicable> DeleteFeeStructureApplicable(FeeStructureApplicable item)
		{
			return _FeeStructureApplicableBA.DeleteFeeStructureApplicable(item);
		}
		public IBaseEntityCollectionResponse<FeeStructureApplicable> GetBySearch(FeeStructureApplicableSearchRequest searchRequest)
		{
			return _FeeStructureApplicableBA.GetBySearch(searchRequest);
		}
        public IBaseEntityCollectionResponse<FeeStructureApplicable> GetStudentListAccordingToFeeStructure(FeeStructureApplicableSearchRequest searchRequest)
		{
            return _FeeStructureApplicableBA.GetStudentListAccordingToFeeStructure(searchRequest);
		}
		public IBaseEntityResponse<FeeStructureApplicable> SelectByID(FeeStructureApplicable item)
		{
			return _FeeStructureApplicableBA.SelectByID(item);
		}
        public IBaseEntityCollectionResponse<FeeStructureApplicable>GetFeeStructureCriteriaApprovalList(FeeStructureApplicableSearchRequest searchRequest)
        {
            return _FeeStructureApplicableBA.GetFeeStructureCriteriaApprovalList(searchRequest);
        }

        public IBaseEntityResponse<FeeStructureApplicable> CreateFeeStructureRequestApproval(FeeStructureApplicable item)
        {
            return _FeeStructureApplicableBA.CreateFeeStructureRequestApproval(item);
        }
        //for fee structure not applicable student list
        public IBaseEntityCollectionResponse<FeeStructureApplicable> GetFeeStructureNotApplicableStudentList(FeeStructureApplicableSearchRequest searchRequest)
        {
            return _FeeStructureApplicableBA.GetFeeStructureNotApplicableStudentList(searchRequest);
        }
	}
}
