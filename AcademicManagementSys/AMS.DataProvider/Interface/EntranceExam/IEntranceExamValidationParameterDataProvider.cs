using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IEntranceExamValidationParameterDataProvider
    {
        IBaseEntityResponse<EntranceExamValidationParameter> InsertEntranceExamValidationParameter(EntranceExamValidationParameter item);
        IBaseEntityResponse<EntranceExamValidationParameter> UpdateEntranceExamValidationParameter(EntranceExamValidationParameter item);
        IBaseEntityResponse<EntranceExamValidationParameter> DeleteEntranceExamValidationParameter(EntranceExamValidationParameter item);
        IBaseEntityCollectionResponse<EntranceExamValidationParameter> GetEntranceExamValidationParameterBySearch(EntranceExamValidationParameterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EntranceExamValidationParameter> GetEntranceExamValidationParameterList(EntranceExamValidationParameterSearchRequest searchRequest);
        IBaseEntityResponse<EntranceExamValidationParameter> GetEntranceExamValidationParameterByID(EntranceExamValidationParameter item);
    }
}
