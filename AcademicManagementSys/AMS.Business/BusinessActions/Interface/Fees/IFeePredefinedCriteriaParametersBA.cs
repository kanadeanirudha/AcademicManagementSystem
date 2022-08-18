﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IFeePredefinedCriteriaParametersBA
    {
        IBaseEntityResponse<FeePredefinedCriteriaParameters> InsertFeePredefinedCriteriaParameters(FeePredefinedCriteriaParameters item);
        IBaseEntityResponse<FeePredefinedCriteriaParameters> UpdateFeePredefinedCriteriaParameters(FeePredefinedCriteriaParameters item);
        IBaseEntityResponse<FeePredefinedCriteriaParameters> DeleteFeePredefinedCriteriaParameters(FeePredefinedCriteriaParameters item);
        IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> GetBySearch(FeePredefinedCriteriaParametersSearchRequest searchRequest);
        IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> GetFeePredefinedCriteriaParametersList(FeePredefinedCriteriaParametersSearchRequest searchRequest);
        IBaseEntityResponse<FeePredefinedCriteriaParameters> SelectByID(FeePredefinedCriteriaParameters item);
        IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> GetTableEntityNameList(FeePredefinedCriteriaParametersSearchRequest searchRequest);
        IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> GetPrimaryKeyFieldNameList(FeePredefinedCriteriaParametersSearchRequest searchRequest);
        IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> GetDisplayKeyFieldNameList(FeePredefinedCriteriaParametersSearchRequest searchRequest);
    }
}
