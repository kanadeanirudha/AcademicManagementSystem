using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class GeneralMovementTypeServiceAccess : IGeneralMovementTypeServiceAccess
    {
        IGeneralMovementTypeBA _GeneralMovementTypeBA = null;
        public GeneralMovementTypeServiceAccess()
        {
            _GeneralMovementTypeBA = new GeneralMovementTypeBA();
        }
        public IBaseEntityResponse<GeneralMovementType> InsertGeneralMovementType(GeneralMovementType item)
        {
            return _GeneralMovementTypeBA.InsertGeneralMovementType(item);
        }
        public IBaseEntityResponse<GeneralMovementType> UpdateGeneralMovementType(GeneralMovementType item)
        {
            return _GeneralMovementTypeBA.UpdateGeneralMovementType(item);
        }
        public IBaseEntityResponse<GeneralMovementType> DeleteGeneralMovementType(GeneralMovementType item)
        {
            return _GeneralMovementTypeBA.DeleteGeneralMovementType(item);
        }
        public IBaseEntityCollectionResponse<GeneralMovementType> GetBySearch(GeneralMovementTypeSearchRequest searchRequest)
        {
            return _GeneralMovementTypeBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralMovementType> GetGeneralMovementTypeSearchList(GeneralMovementTypeSearchRequest searchRequest)
        {
            return _GeneralMovementTypeBA.GetGeneralMovementTypeSearchList(searchRequest);
        }
        public IBaseEntityResponse<GeneralMovementType> SelectByID(GeneralMovementType item)
        {
            return _GeneralMovementTypeBA.SelectByID(item);
        }
        public IBaseEntityResponse<GeneralMovementType> InsertGeneralMovementTypeRules(GeneralMovementType item)
        {
            return _GeneralMovementTypeBA.InsertGeneralMovementTypeRules(item);
        }
      
    }
}
