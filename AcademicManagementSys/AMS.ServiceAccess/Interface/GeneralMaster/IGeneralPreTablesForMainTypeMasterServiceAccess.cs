using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IGeneralPreTablesForMainTypeMasterServiceAccess
    {
        IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> InsertGeneralPreTablesForMainTypeMaster(GeneralPreTablesForMainTypeMaster item);
        IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> UpdateGeneralPreTablesForMainTypeMaster(GeneralPreTablesForMainTypeMaster item);
        IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> DeleteGeneralPreTablesForMainTypeMaster(GeneralPreTablesForMainTypeMaster item);
        IBaseEntityCollectionResponse<GeneralPreTablesForMainTypeMaster> GetBySearch(GeneralPreTablesForMainTypeMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> SelectByID(GeneralPreTablesForMainTypeMaster item);
    }
}
