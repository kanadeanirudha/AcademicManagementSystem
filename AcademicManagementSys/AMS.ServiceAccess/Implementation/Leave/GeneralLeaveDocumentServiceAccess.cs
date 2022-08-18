using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class GeneralLeaveDocumentServiceAccess : IGeneralLeaveDocumentServiceAccess
    {
        IGeneralLeaveDocumentBA _generalLeaveDocumentBA = null;
        public GeneralLeaveDocumentServiceAccess()
        {
            _generalLeaveDocumentBA = new GeneralLeaveDocumentBA();
        }
        public IBaseEntityResponse<GeneralLeaveDocument> InsertGeneralLeaveDocument(GeneralLeaveDocument item)
        {
            return _generalLeaveDocumentBA.InsertGeneralLeaveDocument(item);
        }
        public IBaseEntityResponse<GeneralLeaveDocument> UpdateGeneralLeaveDocument(GeneralLeaveDocument item)
        {
            return _generalLeaveDocumentBA.UpdateGeneralLeaveDocument(item);
        }
        public IBaseEntityResponse<GeneralLeaveDocument> DeleteGeneralLeaveDocument(GeneralLeaveDocument item)
        {
            return _generalLeaveDocumentBA.DeleteGeneralLeaveDocument(item);
        }
        public IBaseEntityCollectionResponse<GeneralLeaveDocument> GetBySearch(GeneralLeaveDocumentSearchRequest searchRequest)
        {
            return _generalLeaveDocumentBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<GeneralLeaveDocument> SelectByID(GeneralLeaveDocument item)
        {
            return _generalLeaveDocumentBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<GeneralLeaveDocument> GetBySearchList(GeneralLeaveDocumentSearchRequest searchRequest)
        {
            return _generalLeaveDocumentBA.GetBySearchList(searchRequest);
        }
    }
}
