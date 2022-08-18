using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface ILeaveSummaryServiceAccess
    {
        IBaseEntityResponse<LeaveSummary> InsertLeaveSummary(LeaveSummary item);
        IBaseEntityResponse<LeaveSummary> UpdateLeaveSummary(LeaveSummary item);
        IBaseEntityResponse<LeaveSummary> DeleteLeaveSummary(LeaveSummary item);
        IBaseEntityCollectionResponse<LeaveSummary> GetBySearch(LeaveSummarySearchRequest searchRequest);
        IBaseEntityResponse<LeaveSummary> SelectByID(LeaveSummary item);
    }
}
