using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessAction
{
    public interface IEntranceExamInfrastructureDetailBA
    {
        // EntranceExamAvailableCentres Table Property.
        IBaseEntityResponse<EntranceExamInfrastructureDetail> InsertEntranceExamAvailableCentres(EntranceExamInfrastructureDetail item);
        IBaseEntityResponse<EntranceExamInfrastructureDetail> UpdateEntranceExamAvailableCentres(EntranceExamInfrastructureDetail item);
        IBaseEntityResponse<EntranceExamInfrastructureDetail> DeleteEntranceExamAvailableCentres(EntranceExamInfrastructureDetail item);
        IBaseEntityCollectionResponse<EntranceExamInfrastructureDetail> GetEntranceExamAvailableCentresBySearch(EntranceExamInfrastructureDetailSearchRequest searchRequest);
        IBaseEntityResponse<EntranceExamInfrastructureDetail> SelectEntranceExamAvailableCentresByID(EntranceExamInfrastructureDetail item);

        //For Serach List Entrance Exam Infrastructure Detail
        IBaseEntityCollectionResponse<EntranceExamInfrastructureDetail> GetEntranceExamAvailableCentresSearchList(EntranceExamInfrastructureDetailSearchRequest searchRequest);

        // EntranceExamInfrastructureDetail Table Property.
        IBaseEntityResponse<EntranceExamInfrastructureDetail> InsertEntranceExamInfrastructureDetail(EntranceExamInfrastructureDetail item);
        IBaseEntityResponse<EntranceExamInfrastructureDetail> UpdateEntranceExamInfrastructureDetail(EntranceExamInfrastructureDetail item);
        IBaseEntityResponse<EntranceExamInfrastructureDetail> DeleteEntranceExamInfrastructureDetail(EntranceExamInfrastructureDetail item);
        IBaseEntityCollectionResponse<EntranceExamInfrastructureDetail> GetEntranceExamInfrastructureDetailBySearch(EntranceExamInfrastructureDetailSearchRequest searchRequest);
        IBaseEntityResponse<EntranceExamInfrastructureDetail> SelectEntranceExamInfrastructureDetailByID(EntranceExamInfrastructureDetail item);

        //For Serach List Entrance Exam Infrastructure Detail
        IBaseEntityCollectionResponse<EntranceExamInfrastructureDetail> GetEntranceExamInfrastructureDetailSearchList(EntranceExamInfrastructureDetailSearchRequest searchRequest);
    }
}
