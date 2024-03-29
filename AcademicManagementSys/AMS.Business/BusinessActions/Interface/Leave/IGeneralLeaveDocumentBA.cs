﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IGeneralLeaveDocumentBA
    {
        IBaseEntityResponse<GeneralLeaveDocument> InsertGeneralLeaveDocument(GeneralLeaveDocument item);
        IBaseEntityResponse<GeneralLeaveDocument> UpdateGeneralLeaveDocument(GeneralLeaveDocument item);
        IBaseEntityResponse<GeneralLeaveDocument> DeleteGeneralLeaveDocument(GeneralLeaveDocument item);
        IBaseEntityCollectionResponse<GeneralLeaveDocument> GetBySearch(GeneralLeaveDocumentSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralLeaveDocument> GetBySearchList(GeneralLeaveDocumentSearchRequest searchRequest);
        IBaseEntityResponse<GeneralLeaveDocument> SelectByID(GeneralLeaveDocument item);
    }
}
