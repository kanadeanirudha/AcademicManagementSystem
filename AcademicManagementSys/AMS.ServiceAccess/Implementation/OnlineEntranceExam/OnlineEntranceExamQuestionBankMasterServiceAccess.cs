using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class OnlineEntranceExamQuestionBankMasterServiceAccess : IOnlineEntranceExamQuestionBankMasterServiceAccess
    {
        IOnlineEntranceExamQuestionBankMasterBA _OnlineEntranceExamQuestionBankMasterBA = null;
        public OnlineEntranceExamQuestionBankMasterServiceAccess()
        {
            _OnlineEntranceExamQuestionBankMasterBA = new OnlineEntranceExamQuestionBankMasterBA();
        }

        public IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> InsertSubjectOnlineExamQuestionBank(OnlineEntranceExamQuestionBankMaster item)
        {
            return _OnlineEntranceExamQuestionBankMasterBA.InsertSubjectOnlineExamQuestionBank(item);
        }

        public IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> InsertOnlineEntranceExamQuestionBankMaster(OnlineEntranceExamQuestionBankMaster item)
        {
            return _OnlineEntranceExamQuestionBankMasterBA.InsertOnlineEntranceExamQuestionBankMaster(item);
        }

        public IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> UpdateOnlineEntranceExamQuestionBankMaster(OnlineEntranceExamQuestionBankMaster item)
        {
            return _OnlineEntranceExamQuestionBankMasterBA.UpdateOnlineEntranceExamQuestionBankMaster(item);
        }

        public IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> DeleteOnlineEntranceExamQuestionBankMaster(OnlineEntranceExamQuestionBankMaster item)
        {
            return _OnlineEntranceExamQuestionBankMasterBA.DeleteOnlineEntranceExamQuestionBankMaster(item);
        }

        public IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> GetOnlineEntranceExamQuestionBankMasterSelectAll(OnlineEntranceExamQuestionBankMasterSearchRequest searchRequest)
        {
            return _OnlineEntranceExamQuestionBankMasterBA.GetOnlineEntranceExamQuestionBankMasterSelectAll(searchRequest);
        }

        public IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> SelectOnlineEntranceExamQuestionBankMasterByID(OnlineEntranceExamQuestionBankMaster item)
        {
            return _OnlineEntranceExamQuestionBankMasterBA.SelectOnlineEntranceExamQuestionBankMasterByID(item);
        }

        public IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> GetCourseByCentreCodeAndUniversity(OnlineEntranceExamQuestionBankMasterSearchRequest searchRequest)
        {
            return _OnlineEntranceExamQuestionBankMasterBA.GetCourseByCentreCodeAndUniversity(searchRequest);
        }

        public IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> GetCourseYearFromBranchMasterID(OnlineEntranceExamQuestionBankMasterSearchRequest searchRequest)
        {
            return _OnlineEntranceExamQuestionBankMasterBA.GetCourseYearFromBranchMasterID(searchRequest);
        }


        public IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> GetSubjectGroupFromCourseYearDetail(OnlineEntranceExamQuestionBankMasterSearchRequest searchRequest)
        {
            return _OnlineEntranceExamQuestionBankMasterBA.GetSubjectGroupFromCourseYearDetail(searchRequest);
        }

        public IBaseEntityCollectionResponse<GeneralQuestionLevelMaster> GetGeneralQuestionLevelMasterList(GeneralQuestionLevelMasterSearchRequest searchRequest)
        {
            return _OnlineEntranceExamQuestionBankMasterBA.GetGeneralQuestionLevelMasterList(searchRequest);
        }

        //Get Unit
        public IBaseEntityCollectionResponse<OrganisationSyllabusGroupMaster> GetSyllabusGroupUnitList(OrganisationSyllabusGroupMasterSearchRequest searchRequest)
        {
            return _OnlineEntranceExamQuestionBankMasterBA.GetSyllabusGroupUnitList(searchRequest);
        }
        //Get Topic
        public IBaseEntityCollectionResponse<OrganisationSyllabusGroupMaster> GetSyllabusGroupTopicMasterList(OrganisationSyllabusGroupMasterSearchRequest searchRequest)
        {
            return _OnlineEntranceExamQuestionBankMasterBA.GetSyllabusGroupTopicMasterList(searchRequest);
        }

        public IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> GetQuestionBankAndDetailList(OnlineEntranceExamQuestionBankMasterSearchRequest searchRequest)
        {
            return _OnlineEntranceExamQuestionBankMasterBA.GetQuestionBankAndDetailList(searchRequest);
        }
    }
}
