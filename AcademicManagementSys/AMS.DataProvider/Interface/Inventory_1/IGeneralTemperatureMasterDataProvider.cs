﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IGeneralTemperatureMasterDataProvider
    {
        IBaseEntityResponse<GeneralTemperatureMaster> InsertGeneralTemperatureMaster(GeneralTemperatureMaster item);
        IBaseEntityResponse<GeneralTemperatureMaster> UpdateGeneralTemperatureMaster(GeneralTemperatureMaster item);
        IBaseEntityResponse<GeneralTemperatureMaster> DeleteGeneralTemperatureMaster(GeneralTemperatureMaster item);
        IBaseEntityCollectionResponse<GeneralTemperatureMaster> GetGeneralTemperatureMasterBySearch(GeneralTemperatureMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralTemperatureMaster> GetGeneralTemperatureMasterSearchList(GeneralTemperatureMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralTemperatureMaster> GetGeneralTemperatureMasterByID(GeneralTemperatureMaster item);
    }
}
