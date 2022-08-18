using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IGeneralLeaveDocumentDataProvider
    {
        IBaseEntityResponse<GeneralLeaveDocument> InsertGeneralLeaveDocument(GeneralLeaveDocument item);
        IBaseEntityResponse<GeneralLeaveDocument> UpdateGeneralLeaveDocument(GeneralLeaveDocument item);
        IBaseEntityResponse<GeneralLeaveDocument> DeleteGeneralLeaveDocument(GeneralLeaveDocument item);
        IBaseEntityCollectionResponse<GeneralLeaveDocument> GetGeneralLeaveDocumentBySearch(GeneralLeaveDocumentSearchRequest searchRequest);
        IBaseEntityResponse<GeneralLeaveDocument> GetGeneralLeaveDocumentByID(GeneralLeaveDocument item);
        IBaseEntityCollectionResponse<GeneralLeaveDocument> GetGeneralLeaveDocumentBySearchList(GeneralLeaveDocumentSearchRequest searchRequest);
    }
}
