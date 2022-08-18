using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessAction
{
    public interface IPOSCounterBA
    {
        IBaseEntityCollectionResponse<POSCounter> GeneralCounterPOSApplicableGetOnline(POSCounterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<POSCounter> UserMasterGetOnlineForPOS(POSCounterSearchRequest searchRequest);
        IBaseEntityResponse<POSCounter> InventoryPOSSelfAssignPostOnline(POSCounter item);
        IBaseEntityResponse<POSCounter> CounterLogPostOnline(POSCounter item);
        IBaseEntityResponse<POSCounter> UserLogPostOnline(POSCounter item);
        IBaseEntityResponse<POSCounter> UserLogsPostOnline(POSCounter item);
    }
}
