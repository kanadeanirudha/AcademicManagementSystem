using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;

namespace AMS.ServiceAccess
{
    public class GeneralMainTypeMasterServiceAccess : IGeneralMainTypeMasterServiceAccess
    {
        IGeneralMainTypeMasterBA _generalMainTypeMasterBA = null;

        public GeneralMainTypeMasterServiceAccess()
        {
            _generalMainTypeMasterBA = new GeneralMainTypeMasterBA();
        }

        /// Service access of create new record of GeneralMainTypeMaster.
        public IBaseEntityResponse<GeneralMainTypeMaster> InsertGeneralMainTypeMaster(GeneralMainTypeMaster item)
        {
            return _generalMainTypeMasterBA.InsertGeneralMainTypeMaster(item);
        }

        /// Service access of update a specific record of GeneralMainTypeMaster.
        public IBaseEntityResponse<GeneralMainTypeMaster> UpdateGeneralMainTypeMaster(GeneralMainTypeMaster item)
        {
            return _generalMainTypeMasterBA.UpdateGeneralMainTypeMaster(item);
        }

        /// Service access of delete a selected record from GeneralMainTypeMaster.
        public IBaseEntityResponse<GeneralMainTypeMaster> DeleteGeneralMainTypeMaster(GeneralMainTypeMaster item)
        {
            return _generalMainTypeMasterBA.DeleteGeneralMainTypeMaster(item);
        }

        /// Service access of select all record from GeneralCountryMaster table with search parameters.
        public IBaseEntityCollectionResponse<GeneralMainTypeMaster> GetBySearch(GeneralMainTypeMasterSearchRequest searchRequest)
        {
            return _generalMainTypeMasterBA.GetBySearch(searchRequest);
        }

        /// Service access of select all record from GeneralMainTypeMaster table with search parameters.
        public IBaseEntityCollectionResponse<GeneralMainTypeMaster> GetBySearchList(GeneralMainTypeMasterSearchRequest searchRequest)
        {
            return _generalMainTypeMasterBA.GetBySearchList(searchRequest);
        }

        /// Service access of select a record from GeneralMainTypeMaster table by ID
        public IBaseEntityResponse<GeneralMainTypeMaster> SelectByID(GeneralMainTypeMaster item)
        {
            return _generalMainTypeMasterBA.SelectByID(item);
        }

        ///Service Access interface to select record from GeneralPreTableForMainTypeMaster on Module code and MenuCode
        public IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> GetGeneralPreTablesForMainTypeByModuleCodeAndMenuCode(GeneralPreTablesForMainTypeMaster item)
        {
            return _generalMainTypeMasterBA.GetGeneralPreTablesForMainTypeByModuleCodeAndMenuCode(item);
        }
    }
}
