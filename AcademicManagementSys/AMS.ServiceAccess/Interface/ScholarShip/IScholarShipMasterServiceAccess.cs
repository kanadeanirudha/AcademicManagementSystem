using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IScholarShipMasterServiceAccess
    {
        IBaseEntityResponse<ScholarShipMaster> InsertScholarShipMaster(ScholarShipMaster item);
        IBaseEntityResponse<ScholarShipMaster> UpdateScholarShipMaster(ScholarShipMaster item);
        IBaseEntityResponse<ScholarShipMaster> DeleteScholarShipMaster(ScholarShipMaster item);
        IBaseEntityCollectionResponse<ScholarShipMaster> GetBySearch(ScholarShipMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<ScholarShipMaster> GetAccountTypeList(ScholarShipMasterSearchRequest searchRequest);
        IBaseEntityResponse<ScholarShipMaster> SelectByID(ScholarShipMaster item);
    }
}
