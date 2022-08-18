using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IEntranceExamValidationParameterApplicableBA
    {
        IBaseEntityResponse<EntranceExamValidationParameterApplicable> InsertEntranceExamValidationParameterApplicable(EntranceExamValidationParameterApplicable item);
        IBaseEntityResponse<EntranceExamValidationParameterApplicable> UpdateEntranceExamValidationParameterApplicable(EntranceExamValidationParameterApplicable item);
        IBaseEntityResponse<EntranceExamValidationParameterApplicable> DeleteEntranceExamValidationParameterApplicable(EntranceExamValidationParameterApplicable item);
        IBaseEntityCollectionResponse<EntranceExamValidationParameterApplicable> GetBySearch(EntranceExamValidationParameterApplicableSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EntranceExamValidationParameterApplicable> GetEntranceExamValidationParameterApplicableList(EntranceExamValidationParameterApplicableSearchRequest searchRequest);
        IBaseEntityResponse<EntranceExamValidationParameterApplicable> SelectByID(EntranceExamValidationParameterApplicable item);
    }
}

