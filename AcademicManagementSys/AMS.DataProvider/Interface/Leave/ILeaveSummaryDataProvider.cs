using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface ILeaveSummaryDataProvider
    {
        IBaseEntityResponse<LeaveSummary> InsertLeaveSummary(LeaveSummary item);
        IBaseEntityResponse<LeaveSummary> UpdateLeaveSummary(LeaveSummary item);
        IBaseEntityResponse<LeaveSummary> DeleteLeaveSummary(LeaveSummary item);
        IBaseEntityCollectionResponse<LeaveSummary> GetLeaveSummaryBySearch(LeaveSummarySearchRequest searchRequest);
        IBaseEntityResponse<LeaveSummary> GetLeaveSummaryByID(LeaveSummary item);
    }
}
