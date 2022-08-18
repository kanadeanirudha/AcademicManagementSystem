using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class EntranceExamValidationParameterApplicableServiceAccess : IEntranceExamValidationParameterApplicableServiceAccess
    {
        IEntranceExamValidationParameterApplicableBA _EntranceExamValidationParameterApplicableBA = null;
        public EntranceExamValidationParameterApplicableServiceAccess()
        {
            _EntranceExamValidationParameterApplicableBA = new EntranceExamValidationParameterApplicableBA();
        }
        public IBaseEntityResponse<EntranceExamValidationParameterApplicable> InsertEntranceExamValidationParameterApplicable(EntranceExamValidationParameterApplicable item)
        {
            return _EntranceExamValidationParameterApplicableBA.InsertEntranceExamValidationParameterApplicable(item);
        }
        public IBaseEntityResponse<EntranceExamValidationParameterApplicable> UpdateEntranceExamValidationParameterApplicable(EntranceExamValidationParameterApplicable item)
        {
            return _EntranceExamValidationParameterApplicableBA.UpdateEntranceExamValidationParameterApplicable(item);
        }
        public IBaseEntityResponse<EntranceExamValidationParameterApplicable> DeleteEntranceExamValidationParameterApplicable(EntranceExamValidationParameterApplicable item)
        {
            return _EntranceExamValidationParameterApplicableBA.DeleteEntranceExamValidationParameterApplicable(item);
        }
        public IBaseEntityCollectionResponse<EntranceExamValidationParameterApplicable> GetBySearch(EntranceExamValidationParameterApplicableSearchRequest searchRequest)
        {
            return _EntranceExamValidationParameterApplicableBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<EntranceExamValidationParameterApplicable> GetEntranceExamValidationParameterApplicableList(EntranceExamValidationParameterApplicableSearchRequest searchRequest)
        {
            return _EntranceExamValidationParameterApplicableBA.GetEntranceExamValidationParameterApplicableList(searchRequest);
        }
        public IBaseEntityResponse<EntranceExamValidationParameterApplicable> SelectByID(EntranceExamValidationParameterApplicable item)
        {
            return _EntranceExamValidationParameterApplicableBA.SelectByID(item);
        }
    }
}
