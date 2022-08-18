using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IEntranceExamInfrastructureDetailDataProvider
    {
        // EntranceExamAvailableCentres Method
        IBaseEntityResponse<EntranceExamInfrastructureDetail> InsertEntranceExamAvailableCentres(EntranceExamInfrastructureDetail item);
        IBaseEntityResponse<EntranceExamInfrastructureDetail> UpdateEntranceExamAvailableCentres(EntranceExamInfrastructureDetail item);
        IBaseEntityResponse<EntranceExamInfrastructureDetail> DeleteEntranceExamAvailableCentres(EntranceExamInfrastructureDetail item);
        IBaseEntityCollectionResponse<EntranceExamInfrastructureDetail> GetEntranceExamAvailableCentresBySearch(EntranceExamInfrastructureDetailSearchRequest searchRequest);
        IBaseEntityResponse<EntranceExamInfrastructureDetail> GetEntranceExamAvailableCentresByID(EntranceExamInfrastructureDetail item);

        //Search EntranceExamInfrastructureDetail List
        IBaseEntityCollectionResponse<EntranceExamInfrastructureDetail> GetEntranceExamAvailableCentresSearchList(EntranceExamInfrastructureDetailSearchRequest searchRequest);


        // EntranceExamInfrastructureDetail Method
        IBaseEntityResponse<EntranceExamInfrastructureDetail> InsertEntranceExamInfrastructureDetail(EntranceExamInfrastructureDetail item);
        IBaseEntityResponse<EntranceExamInfrastructureDetail> UpdateEntranceExamInfrastructureDetail(EntranceExamInfrastructureDetail item);
        IBaseEntityResponse<EntranceExamInfrastructureDetail> DeleteEntranceExamInfrastructureDetail(EntranceExamInfrastructureDetail item);
        IBaseEntityCollectionResponse<EntranceExamInfrastructureDetail> GetEntranceExamInfrastructureDetailBySearch(EntranceExamInfrastructureDetailSearchRequest searchRequest);
        IBaseEntityResponse<EntranceExamInfrastructureDetail> GetEntranceExamInfrastructureDetailByID(EntranceExamInfrastructureDetail item);

        //Search EntranceExamInfrastructureDetail List
        IBaseEntityCollectionResponse<EntranceExamInfrastructureDetail> GetEntranceExamInfrastructureDetailSearchList(EntranceExamInfrastructureDetailSearchRequest searchRequest);
    }
}
