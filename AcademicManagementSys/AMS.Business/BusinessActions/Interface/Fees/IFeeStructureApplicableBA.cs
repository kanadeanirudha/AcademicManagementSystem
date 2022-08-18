using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessActions
{
	public interface IFeeStructureApplicableBA
	{
		IBaseEntityResponse<FeeStructureApplicable> InsertFeeStructureApplicable(FeeStructureApplicable item);
		IBaseEntityResponse<FeeStructureApplicable> UpdateFeeStructureApplicable(FeeStructureApplicable item);
		IBaseEntityResponse<FeeStructureApplicable> DeleteFeeStructureApplicable(FeeStructureApplicable item);
		IBaseEntityCollectionResponse<FeeStructureApplicable> GetBySearch(FeeStructureApplicableSearchRequest searchRequest);
        IBaseEntityCollectionResponse<FeeStructureApplicable> GetStudentListAccordingToFeeStructure(FeeStructureApplicableSearchRequest searchRequest);
		IBaseEntityResponse<FeeStructureApplicable> SelectByID(FeeStructureApplicable item);
        IBaseEntityCollectionResponse<FeeStructureApplicable> GetFeeStructureCriteriaApprovalList(FeeStructureApplicableSearchRequest searchRequest);

        IBaseEntityResponse<FeeStructureApplicable> CreateFeeStructureRequestApproval(FeeStructureApplicable item);
        //for fee structure not applicable student list
        IBaseEntityCollectionResponse<FeeStructureApplicable> GetFeeStructureNotApplicableStudentList(FeeStructureApplicableSearchRequest searchRequest);
	}
}
