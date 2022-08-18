using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class GeneralPackageTypeServiceAccess : IGeneralPackageTypeServiceAccess
    {
        IGeneralPackageTypeBA _GeneralPackageTypeBA = null;
        public GeneralPackageTypeServiceAccess()
        {
            _GeneralPackageTypeBA = new GeneralPackageTypeBA();
        }
        public IBaseEntityResponse<GeneralPackageType> InsertGeneralPackageType(GeneralPackageType item)
        {
            return _GeneralPackageTypeBA.InsertGeneralPackageType(item);
        }
        public IBaseEntityResponse<GeneralPackageType> UpdateGeneralPackageType(GeneralPackageType item)
        {
            return _GeneralPackageTypeBA.UpdateGeneralPackageType(item);
        }
        public IBaseEntityResponse<GeneralPackageType> DeleteGeneralPackageType(GeneralPackageType item)
        {
            return _GeneralPackageTypeBA.DeleteGeneralPackageType(item);
        }
        public IBaseEntityCollectionResponse<GeneralPackageType> GetBySearch(GeneralPackageTypeSearchRequest searchRequest)
        {
            return _GeneralPackageTypeBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralPackageType> GetGeneralPackageTypeSearchList(GeneralPackageTypeSearchRequest searchRequest)
        {
            return _GeneralPackageTypeBA.GetGeneralPackageTypeSearchList(searchRequest);
        }
        public IBaseEntityResponse<GeneralPackageType> SelectByID(GeneralPackageType item)
        {
            return _GeneralPackageTypeBA.SelectByID(item);
        }
    }
}
