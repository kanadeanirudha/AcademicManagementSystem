using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IOnlineEntranceExamQuestionBankMasterDataProvider
    {
        IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> InsertSubjectOnlineExamQuestionBank(OnlineEntranceExamQuestionBankMaster item);

        IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> InsertOnlineEntranceExamQuestionBankMaster(OnlineEntranceExamQuestionBankMaster item);
        IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> UpdateOnlineEntranceExamQuestionBankMaster(OnlineEntranceExamQuestionBankMaster item);
        IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> DeleteOnlineEntranceExamQuestionBankMaster(OnlineEntranceExamQuestionBankMaster item);
        IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> GetOnlineEntranceExamQuestionBankMasterSelectAll(OnlineEntranceExamQuestionBankMasterSearchRequest searchRequest);
        IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> SelectOnlineEntranceExamQuestionBankMasterByID(OnlineEntranceExamQuestionBankMaster item);

        IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> GetCourseByCentreCodeAndUniversity(OnlineEntranceExamQuestionBankMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> GetCourseYearFromBranchMasterID(OnlineEntranceExamQuestionBankMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> GetSubjectGroupFromCourseYearDetail(OnlineEntranceExamQuestionBankMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralQuestionLevelMaster> GetGeneralQuestionLevelMasterList(GeneralQuestionLevelMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<OrganisationSyllabusGroupMaster> GetSyllabusGroupUnitList(OrganisationSyllabusGroupMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationSyllabusGroupMaster> GetSyllabusGroupTopicMasterList(OrganisationSyllabusGroupMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> GetQuestionBankAndDetailList(OnlineEntranceExamQuestionBankMasterSearchRequest searchRequest);
    }
}
