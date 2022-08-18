﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IGeneralPriceListAndListLineServiceAccess
    {
        //For Inventory UoM Group
        IBaseEntityResponse<GeneralPriceListAndListLine> InsertGeneralPriceList(GeneralPriceListAndListLine item);
        IBaseEntityResponse<GeneralPriceListAndListLine> UpdateGeneralPriceList(GeneralPriceListAndListLine item);
        IBaseEntityResponse<GeneralPriceListAndListLine> DeleteGeneralPriceList(GeneralPriceListAndListLine item);
        IBaseEntityCollectionResponse<GeneralPriceListAndListLine> SelectByGeneralPriceListID(GeneralPriceListAndListLineSearchRequest searchRequest);
        IBaseEntityResponse<GeneralPriceListAndListLine> GetIsRootCount(GeneralPriceListAndListLine item);

        //For Inventory UoM Group Details
        IBaseEntityResponse<GeneralPriceListAndListLine> InsertGeneralPriceListAndListLine(GeneralPriceListAndListLine item);
        IBaseEntityResponse<GeneralPriceListAndListLine> UpdateGeneralPriceListAndListLine(GeneralPriceListAndListLine item);
        IBaseEntityResponse<GeneralPriceListAndListLine> DeleteGeneralPriceListAndListLine(GeneralPriceListAndListLine item);
        IBaseEntityCollectionResponse<GeneralPriceListAndListLine> GetBySearch(GeneralPriceListAndListLineSearchRequest searchRequest);
        IBaseEntityResponse<GeneralPriceListAndListLine> SelectByID(GeneralPriceListAndListLine item);
        IBaseEntityCollectionResponse<GeneralPriceListAndListLine> GetGeneralPriceListAndListLineSearchList(GeneralPriceListAndListLineSearchRequest searchRequest);
    }
}
