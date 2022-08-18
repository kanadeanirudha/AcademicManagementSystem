using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class GeneralPreTablesForMainTypeMasterServiceAccess : IGeneralPreTablesForMainTypeMasterServiceAccess
    {
        IGeneralPreTablesForMainTypeMasterBA _generalPreTablesForMainTypeMasterBA = null;
        public GeneralPreTablesForMainTypeMasterServiceAccess()
        {
            _generalPreTablesForMainTypeMasterBA = new GeneralPreTablesForMainTypeMasterBA();
        }
        public IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> InsertGeneralPreTablesForMainTypeMaster(GeneralPreTablesForMainTypeMaster item)
        {
            return _generalPreTablesForMainTypeMasterBA.InsertGeneralPreTablesForMainTypeMaster(item);
        }
        public IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> UpdateGeneralPreTablesForMainTypeMaster(GeneralPreTablesForMainTypeMaster item)
        {
            return _generalPreTablesForMainTypeMasterBA.UpdateGeneralPreTablesForMainTypeMaster(item);
        }
        public IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> DeleteGeneralPreTablesForMainTypeMaster(GeneralPreTablesForMainTypeMaster item)
        {
            return _generalPreTablesForMainTypeMasterBA.DeleteGeneralPreTablesForMainTypeMaster(item);
        }
        public IBaseEntityCollectionResponse<GeneralPreTablesForMainTypeMaster> GetBySearch(GeneralPreTablesForMainTypeMasterSearchRequest searchRequest)
        {
            return _generalPreTablesForMainTypeMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> SelectByID(GeneralPreTablesForMainTypeMaster item)
        {
            return _generalPreTablesForMainTypeMasterBA.SelectByID(item);
        }
                        
    }
}
