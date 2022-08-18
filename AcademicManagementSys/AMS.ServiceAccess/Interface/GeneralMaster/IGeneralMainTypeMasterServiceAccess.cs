using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IGeneralMainTypeMasterServiceAccess
    {
        /// Service access interface of insert new record of GeneralMainTypeMaster.
        IBaseEntityResponse<GeneralMainTypeMaster> InsertGeneralMainTypeMaster(GeneralMainTypeMaster item);

        /// Service access interface of update record of GeneralCountryMaster.
        IBaseEntityResponse<GeneralMainTypeMaster> UpdateGeneralMainTypeMaster(GeneralMainTypeMaster item);

        ///Service Access Interface of delete record of GeneralMainTypeMaster.
        IBaseEntityResponse<GeneralMainTypeMaster> DeleteGeneralMainTypeMaster(GeneralMainTypeMaster item);

        ///Service access interface of select all record of GeneralMainTypeMaster.
        IBaseEntityCollectionResponse<GeneralMainTypeMaster> GetBySearch(GeneralMainTypeMasterSearchRequest searchRequest);

        /// Service access interface of select all record of GeneralMainTypeMaster.
        IBaseEntityCollectionResponse<GeneralMainTypeMaster> GetBySearchList(GeneralMainTypeMasterSearchRequest searchRequest);

        /// Service access interface of select one record of GeneralMainTypeMaster.
        IBaseEntityResponse<GeneralMainTypeMaster> SelectByID(GeneralMainTypeMaster item);

        ///Service Access interface to select record from GeneralPreTableForMainTypeMaster on Module code and MenuCode
        IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> GetGeneralPreTablesForMainTypeByModuleCodeAndMenuCode(GeneralPreTablesForMainTypeMaster item);
    }
}
