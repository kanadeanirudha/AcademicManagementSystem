
using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class GeneralPaperSetMasterServiceAccess : IGeneralPaperSetMasterServiceAccess
    {
        IGeneralPaperSetMasterBA _GeneralPaperSetMasterBA = null;
        public GeneralPaperSetMasterServiceAccess()
        {
            _GeneralPaperSetMasterBA = new GeneralPaperSetMasterBA();
        }
        public IBaseEntityResponse<GeneralPaperSetMaster> InsertGeneralPaperSetMaster(GeneralPaperSetMaster item)
        {
            return _GeneralPaperSetMasterBA.InsertGeneralPaperSetMaster(item);
        }
        public IBaseEntityResponse<GeneralPaperSetMaster> UpdateGeneralPaperSetMaster(GeneralPaperSetMaster item)
        {
            return _GeneralPaperSetMasterBA.UpdateGeneralPaperSetMaster(item);
        }
        public IBaseEntityResponse<GeneralPaperSetMaster> DeleteGeneralPaperSetMaster(GeneralPaperSetMaster item)
        {
            return _GeneralPaperSetMasterBA.DeleteGeneralPaperSetMaster(item);
        }
        public IBaseEntityCollectionResponse<GeneralPaperSetMaster> GetBySearch(GeneralPaperSetMasterSearchRequest searchRequest)
        {
            return _GeneralPaperSetMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralPaperSetMaster> GetGeneralPaperSetMasterSearchList(GeneralPaperSetMasterSearchRequest searchRequest)
        {
            return _GeneralPaperSetMasterBA.GetGeneralPaperSetMasterSearchList(searchRequest);
        }
        public IBaseEntityResponse<GeneralPaperSetMaster> SelectByID(GeneralPaperSetMaster item)
        {
            return _GeneralPaperSetMasterBA.SelectByID(item);
        }
    }
}
