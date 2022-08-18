using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class POSCounterServiceAccess : IPOSCounterServiceAccess
    {
        IPOSCounterBA _POSCounterBA = null;

        public POSCounterServiceAccess()
        {
            _POSCounterBA = new POSCounterBA();
        }
        public IBaseEntityCollectionResponse<POSCounter> GeneralCounterPOSApplicableGetOnline(POSCounterSearchRequest searchRequest)
        {
            return _POSCounterBA.GeneralCounterPOSApplicableGetOnline(searchRequest);
        }
        public IBaseEntityCollectionResponse<POSCounter> UserMasterGetOnlineForPOS(POSCounterSearchRequest searchRequest)
        {
            return _POSCounterBA.UserMasterGetOnlineForPOS(searchRequest);
        }
        public IBaseEntityResponse<POSCounter> InventoryPOSSelfAssignPostOnline(POSCounter item)
        {
            return _POSCounterBA.InventoryPOSSelfAssignPostOnline(item);
        }
        public IBaseEntityResponse<POSCounter> CounterLogPostOnline(POSCounter item)
        {
            return _POSCounterBA.CounterLogPostOnline(item);
        }
        public IBaseEntityResponse<POSCounter> UserLogPostOnline(POSCounter item)
        {
            return _POSCounterBA.UserLogPostOnline(item);
        }
        public IBaseEntityResponse<POSCounter> UserLogsPostOnline(POSCounter item)
        {
            return _POSCounterBA.UserLogsPostOnline(item);
        }
    }
}
