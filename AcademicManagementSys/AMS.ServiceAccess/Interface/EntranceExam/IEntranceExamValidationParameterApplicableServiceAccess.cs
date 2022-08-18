using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IEntranceExamValidationParameterApplicableServiceAccess
    {
        IBaseEntityResponse<EntranceExamValidationParameterApplicable> InsertEntranceExamValidationParameterApplicable(EntranceExamValidationParameterApplicable item);
        IBaseEntityResponse<EntranceExamValidationParameterApplicable> UpdateEntranceExamValidationParameterApplicable(EntranceExamValidationParameterApplicable item);
        IBaseEntityResponse<EntranceExamValidationParameterApplicable> DeleteEntranceExamValidationParameterApplicable(EntranceExamValidationParameterApplicable item);
        IBaseEntityCollectionResponse<EntranceExamValidationParameterApplicable> GetBySearch(EntranceExamValidationParameterApplicableSearchRequest searchRequest);
        IBaseEntityResponse<EntranceExamValidationParameterApplicable> SelectByID(EntranceExamValidationParameterApplicable item);
        IBaseEntityCollectionResponse<EntranceExamValidationParameterApplicable> GetEntranceExamValidationParameterApplicableList(EntranceExamValidationParameterApplicableSearchRequest searchRequest);
    }
}
