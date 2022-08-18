using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class GeneralTaskModelServiceAccess : IGeneralTaskModelServiceAccess
    {
        IGeneralTaskModelBA _GeneralTaskModelBA = null;
        public GeneralTaskModelServiceAccess()
        {
            _GeneralTaskModelBA = new GeneralTaskModelBA();
        }
        public IBaseEntityResponse<GeneralTaskModel> InsertGeneralTaskModel(GeneralTaskModel item)
        {
            return _GeneralTaskModelBA.InsertGeneralTaskModel(item);
        }
        public IBaseEntityResponse<GeneralTaskModel> UpdateGeneralTaskModel(GeneralTaskModel item)
        {
            return _GeneralTaskModelBA.UpdateGeneralTaskModel(item);
        }
        public IBaseEntityResponse<GeneralTaskModel> DeleteGeneralTaskModel(GeneralTaskModel item)
        {
            return _GeneralTaskModelBA.DeleteGeneralTaskModel(item);
        }
        public IBaseEntityCollectionResponse<GeneralTaskModel> GetBySearch(GeneralTaskModelSearchRequest searchRequest)
        {
            return _GeneralTaskModelBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralTaskModel> GetMenuCodeAndMenuLink(GeneralTaskModelSearchRequest searchRequest)
        {
            return _GeneralTaskModelBA.GetMenuCodeAndMenuLink(searchRequest);
        }

        public IBaseEntityCollectionResponse<GeneralTaskModel> GetTaskCode(GeneralTaskModelSearchRequest searchRequest)
        {
            return _GeneralTaskModelBA.GetTaskCode(searchRequest);
        }


        public IBaseEntityResponse<GeneralTaskModel> SelectByID(GeneralTaskModel item)
        {
            return _GeneralTaskModelBA.SelectByID(item);
        }
    }
}
