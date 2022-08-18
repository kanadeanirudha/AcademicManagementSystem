using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IGeneralTaskModelServiceAccess
    {
        IBaseEntityResponse<GeneralTaskModel> InsertGeneralTaskModel(GeneralTaskModel item);
        IBaseEntityResponse<GeneralTaskModel> UpdateGeneralTaskModel(GeneralTaskModel item);
        IBaseEntityResponse<GeneralTaskModel> DeleteGeneralTaskModel(GeneralTaskModel item);
        IBaseEntityCollectionResponse<GeneralTaskModel> GetBySearch(GeneralTaskModelSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralTaskModel> GetMenuCodeAndMenuLink(GeneralTaskModelSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralTaskModel> GetTaskCode(GeneralTaskModelSearchRequest searchRequest);
        IBaseEntityResponse<GeneralTaskModel> SelectByID(GeneralTaskModel item);
    }
}
