
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IOnlineExamExaminationMasterDataProvider
    {
        IBaseEntityResponse<OnlineExamExaminationMaster> InsertOnlineExamExaminationMaster(OnlineExamExaminationMaster item);
        IBaseEntityResponse<OnlineExamExaminationMaster> UpdateOnlineExamExaminationMaster(OnlineExamExaminationMaster item);
        IBaseEntityResponse<OnlineExamExaminationMaster> DeleteOnlineExamExaminationMaster(OnlineExamExaminationMaster item);
        IBaseEntityCollectionResponse<OnlineExamExaminationMaster> GetOnlineExamExaminationMasterBySearch(OnlineExamExaminationMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OnlineExamExaminationMaster> GetOnlineExamExaminationMasterSearchList(OnlineExamExaminationMasterSearchRequest searchRequest);
       // IBaseEntityCollectionResponse<OnlineExamExaminationMaster> GetSessionNameList(OnlineExamExaminationMaster searchRequest);
        IBaseEntityResponse<OnlineExamExaminationMaster> GetOnlineExamExaminationMasterByID(OnlineExamExaminationMaster item);
        IBaseEntityCollectionResponse<OnlineExamExaminationMaster>GetExaminationNameList(OnlineExamExaminationMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<OnlineExamExaminationMaster> OnlineExamGetExaminationListCentreWise(OnlineExamExaminationMasterSearchRequest searchRequest);
    }
}
