using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class StudyCentreMasterServiceAccess : IStudyCentreMasterServiceAccess
    {
        IStudyCentreMasterBA _StudyCentreMasterBA = null;
        public StudyCentreMasterServiceAccess()
        {
            _StudyCentreMasterBA = new StudyCentreMasterBA();
        }
        public IBaseEntityCollectionResponse<StudyCentreMaster> GetStudyCentreMaster(StudyCentreMasterSearchRequest searchRequest)
        {
            return _StudyCentreMasterBA.GetStudyCentreMaster(searchRequest);
        }
    }
}

