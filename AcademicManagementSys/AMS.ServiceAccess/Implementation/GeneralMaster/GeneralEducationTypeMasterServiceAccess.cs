using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class GeneralEducationTypeMasterServiceAccess : IGeneralEducationTypeMasterServiceAccess
    {

        IGeneralEducationTypeMasterBA _GeneralEducationTypeMasterBA = null;

        public GeneralEducationTypeMasterServiceAccess()
        {
            _GeneralEducationTypeMasterBA = new GeneralEducationTypeMasterBA();
        }

        public IBaseEntityResponse<GeneralEducationTypeMaster> InsertGeneralEducationTypeMaster(GeneralEducationTypeMaster item)
        {
            return _GeneralEducationTypeMasterBA.InsertGeneralEducationTypeMaster(item);
        }

        public IBaseEntityResponse<GeneralEducationTypeMaster> UpdateGeneralEducationTypeMaster(GeneralEducationTypeMaster item)
        {
            return _GeneralEducationTypeMasterBA.UpdateGeneralEducationTypeMaster(item);
        }

        public IBaseEntityResponse<GeneralEducationTypeMaster> DeleteGeneralEducationTypeMaster(GeneralEducationTypeMaster item)
        {
            return _GeneralEducationTypeMasterBA.DeleteGeneralEducationTypeMaster(item);
        }

        public IBaseEntityCollectionResponse<GeneralEducationTypeMaster> GetBySearch(GeneralEducationTypeMasterSearchRequest searchRequest)
        {
            return _GeneralEducationTypeMasterBA.GetBySearch(searchRequest);
        }


        public IBaseEntityCollectionResponse<GeneralEducationTypeMaster> GetBySearchList(GeneralEducationTypeMasterSearchRequest searchRequest)
        {
            return _GeneralEducationTypeMasterBA.GetBySearchList(searchRequest);
        }
        public IBaseEntityResponse<GeneralEducationTypeMaster> SelectByID(GeneralEducationTypeMaster item)
        {
            return _GeneralEducationTypeMasterBA.SelectByID(item);
        }
    }
}
