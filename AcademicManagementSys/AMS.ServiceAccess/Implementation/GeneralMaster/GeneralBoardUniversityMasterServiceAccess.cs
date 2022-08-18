using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class GeneralBoardUniversityMasterServiceAccess : IGeneralBoardUniversityMasterServiceAccess
    {
        IGeneralBoardUniversityMasterBA _generalBoardUniversityMasterBA = null;
        public GeneralBoardUniversityMasterServiceAccess()
        {
            _generalBoardUniversityMasterBA = new GeneralBoardUniversityMasterBA();
        }
        public IBaseEntityResponse<GeneralBoardUniversityMaster> InsertGeneralBoardUniversityMaster(GeneralBoardUniversityMaster item)
        {
            return _generalBoardUniversityMasterBA.InsertGeneralBoardUniversityMaster(item);
        }
        public IBaseEntityResponse<GeneralBoardUniversityMaster> UpdateGeneralBoardUniversityMaster(GeneralBoardUniversityMaster item)
        {
            return _generalBoardUniversityMasterBA.UpdateGeneralBoardUniversityMaster(item);
        }
        public IBaseEntityResponse<GeneralBoardUniversityMaster> DeleteGeneralBoardUniversityMaster(GeneralBoardUniversityMaster item)
        {
            return _generalBoardUniversityMasterBA.DeleteGeneralBoardUniversityMaster(item);
        }
        public IBaseEntityCollectionResponse<GeneralBoardUniversityMaster> GetBySearch(GeneralBoardUniversityMasterSearchRequest searchRequest)
        {
            return _generalBoardUniversityMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralBoardUniversityMaster> GetBySearchList(GeneralBoardUniversityMasterSearchRequest searchRequest)
        {
            return _generalBoardUniversityMasterBA.GetBySearchList(searchRequest);
        }
        public IBaseEntityResponse<GeneralBoardUniversityMaster> SelectByID(GeneralBoardUniversityMaster item)
        {
            return _generalBoardUniversityMasterBA.SelectByID(item);
        }
    }
}
