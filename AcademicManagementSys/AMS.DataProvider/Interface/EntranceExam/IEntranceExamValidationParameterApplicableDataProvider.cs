using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IEntranceExamValidationParameterApplicableDataProvider
    {
        IBaseEntityResponse<EntranceExamValidationParameterApplicable> InsertEntranceExamValidationParameterApplicable(EntranceExamValidationParameterApplicable item);
        IBaseEntityResponse<EntranceExamValidationParameterApplicable> UpdateEntranceExamValidationParameterApplicable(EntranceExamValidationParameterApplicable item);
        IBaseEntityResponse<EntranceExamValidationParameterApplicable> DeleteEntranceExamValidationParameterApplicable(EntranceExamValidationParameterApplicable item);
        IBaseEntityCollectionResponse<EntranceExamValidationParameterApplicable> GetEntranceExamValidationParameterApplicableBySearch(EntranceExamValidationParameterApplicableSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EntranceExamValidationParameterApplicable> GetEntranceExamValidationParameterApplicableList(EntranceExamValidationParameterApplicableSearchRequest searchRequest);
        IBaseEntityResponse<EntranceExamValidationParameterApplicable> GetEntranceExamValidationParameterApplicableByID(EntranceExamValidationParameterApplicable item);
    }
}
