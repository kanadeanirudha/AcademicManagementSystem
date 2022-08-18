using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IScholarShipMasterDataProvider
    {
        IBaseEntityResponse<ScholarShipMaster> InsertScholarShipMaster(ScholarShipMaster item);
        IBaseEntityResponse<ScholarShipMaster> UpdateScholarShipMaster(ScholarShipMaster item);
        IBaseEntityResponse<ScholarShipMaster> DeleteScholarShipMaster(ScholarShipMaster item);
        IBaseEntityCollectionResponse<ScholarShipMaster> GetScholarShipMasterBySearch(ScholarShipMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<ScholarShipMaster> GetAccountTypeList(ScholarShipMasterSearchRequest searchRequest);
        IBaseEntityResponse<ScholarShipMaster> GetScholarShipMasterByID(ScholarShipMaster item);
    }
}
