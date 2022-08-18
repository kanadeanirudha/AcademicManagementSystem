using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class EntranceExamValidationParameterServiceAccess : IEntranceExamValidationParameterServiceAccess
    {
        IEntranceExamValidationParameterBA _EntranceExamValidationParameterBA = null;
        public EntranceExamValidationParameterServiceAccess()
        {
            _EntranceExamValidationParameterBA = new EntranceExamValidationParameterBA();
        }
        public IBaseEntityResponse<EntranceExamValidationParameter> InsertEntranceExamValidationParameter(EntranceExamValidationParameter item)
        {
            return _EntranceExamValidationParameterBA.InsertEntranceExamValidationParameter(item);
        }
        public IBaseEntityResponse<EntranceExamValidationParameter> UpdateEntranceExamValidationParameter(EntranceExamValidationParameter item)
        {
            return _EntranceExamValidationParameterBA.UpdateEntranceExamValidationParameter(item);
        }
        public IBaseEntityResponse<EntranceExamValidationParameter> DeleteEntranceExamValidationParameter(EntranceExamValidationParameter item)
        {
            return _EntranceExamValidationParameterBA.DeleteEntranceExamValidationParameter(item);
        }
        public IBaseEntityCollectionResponse<EntranceExamValidationParameter> GetBySearch(EntranceExamValidationParameterSearchRequest searchRequest)
        {
            return _EntranceExamValidationParameterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<EntranceExamValidationParameter> GetEntranceExamValidationParameterList(EntranceExamValidationParameterSearchRequest searchRequest)
        {
            return _EntranceExamValidationParameterBA.GetEntranceExamValidationParameterList(searchRequest);
        }
        public IBaseEntityResponse<EntranceExamValidationParameter> SelectByID(EntranceExamValidationParameter item)
        {
            return _EntranceExamValidationParameterBA.SelectByID(item);
        }
    }
}
