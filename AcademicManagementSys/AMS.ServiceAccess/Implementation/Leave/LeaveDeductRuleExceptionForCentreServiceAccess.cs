using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class LeaveDeductRuleExceptionForCentreServiceAccess : ILeaveDeductRuleExceptionForCentreServiceAccess
    {
        ILeaveDeductRuleExceptionForCentreBA _generalCountryMasterBA = null;

        public LeaveDeductRuleExceptionForCentreServiceAccess()
        {
            _generalCountryMasterBA = new LeaveDeductRuleExceptionForCentreBA();
        }
        /// <summary>
        /// Service access of create new record of LeaveDeductRuleExceptionForCentre.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> InsertLeaveDeductRuleExceptionForCentre(LeaveDeductRuleExceptionForCentre item)
        {
            return _generalCountryMasterBA.InsertLeaveDeductRuleExceptionForCentre(item);
        }

        /// <summary>
        /// Service access of update a specific record of LeaveDeductRuleExceptionForCentre.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> UpdateLeaveDeductRuleExceptionForCentre(LeaveDeductRuleExceptionForCentre item)
        {
            return _generalCountryMasterBA.UpdateLeaveDeductRuleExceptionForCentre(item);
        }

        /// <summary>
        /// Service access of delete a selected record from LeaveDeductRuleExceptionForCentre.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> DeleteLeaveDeductRuleExceptionForCentre(LeaveDeductRuleExceptionForCentre item)
        {
            return _generalCountryMasterBA.DeleteLeaveDeductRuleExceptionForCentre(item);
        }

        /// <summary>
        /// /// Service access of select all record from LeaveDeductRuleExceptionForCentre table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveDeductRuleExceptionForCentre> GetBySearch(LeaveDeductRuleExceptionForCentreSearchRequest searchRequest)
        {
            return _generalCountryMasterBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all record from LeaveDeductRuleExceptionForCentre table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveDeductRuleExceptionForCentre> GetBySearchList(LeaveDeductRuleExceptionForCentreSearchRequest searchRequest)
        {
            return _generalCountryMasterBA.GetBySearchList(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from LeaveDeductRuleExceptionForCentre table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> SelectByID(LeaveDeductRuleExceptionForCentre item)
        {
            return _generalCountryMasterBA.SelectByID(item);
        }
    }
}

