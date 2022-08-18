using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;


namespace AMS.ServiceAccess
{
    public class GeneralNationalityMasterServiceAccess : IGeneralNationalityMasterServiceAccess
    {
               IGeneralNationalityMasterBA _GeneralNationalityMasterBA = null;

        public GeneralNationalityMasterServiceAccess()
        {
            _GeneralNationalityMasterBA = new GeneralNationalityMasterBA();
        }

        public IBaseEntityResponse<GeneralNationalityMaster> InsertGeneralNationalityMaster(GeneralNationalityMaster item)
        {
            return _GeneralNationalityMasterBA.InsertGeneralNationalityMaster(item);
        }

        public IBaseEntityResponse<GeneralNationalityMaster> UpdateGeneralNationalityMaster(GeneralNationalityMaster item)
        {
            return _GeneralNationalityMasterBA.UpdateGeneralNationalityMaster(item);
        }

        public IBaseEntityResponse<GeneralNationalityMaster> DeleteGeneralNationalityMaster(GeneralNationalityMaster item)
        {
            return _GeneralNationalityMasterBA.DeleteGeneralNationalityMaster(item);
        }

        public IBaseEntityCollectionResponse<GeneralNationalityMaster> GetBySearch(GeneralNationalityMasterSearchRequest searchRequest)
        {
            return _GeneralNationalityMasterBA.GetBySearch(searchRequest);
        }

        public IBaseEntityCollectionResponse<GeneralNationalityMaster> GetBySearchList(GeneralNationalityMasterSearchRequest searchRequest)
        {
            return _GeneralNationalityMasterBA.GetBySearchList(searchRequest);
        }

        public IBaseEntityResponse<GeneralNationalityMaster> SelectByID(GeneralNationalityMaster item)
        {
            return _GeneralNationalityMasterBA.SelectByID(item);
        }
    }
}
