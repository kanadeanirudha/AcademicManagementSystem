using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface ILeaveDeductRuleExceptionForCentreServiceAccess
    {
        
        /// Service access interface of insert new record of LeaveDeductRuleExceptionForCentre.        
        IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> InsertLeaveDeductRuleExceptionForCentre(LeaveDeductRuleExceptionForCentre item);

       
        /// Service access interface of update record of LeaveDeductRuleExceptionForCentre.        
        IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> UpdateLeaveDeductRuleExceptionForCentre(LeaveDeductRuleExceptionForCentre item);

     
        /// Service access interface of dalete record of LeaveDeductRuleExceptionForCentre.        
        IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> DeleteLeaveDeductRuleExceptionForCentre(LeaveDeductRuleExceptionForCentre item);

        
        /// Service access interface of select all record of LeaveDeductRuleExceptionForCentre.        
        IBaseEntityCollectionResponse<LeaveDeductRuleExceptionForCentre> GetBySearch(LeaveDeductRuleExceptionForCentreSearchRequest searchRequest);

        
        /// Service access interface of select all record of LeaveDeductRuleExceptionForCentre.       
        IBaseEntityCollectionResponse<LeaveDeductRuleExceptionForCentre> GetBySearchList(LeaveDeductRuleExceptionForCentreSearchRequest searchRequest);

       
        /// Service access interface of select one record of LeaveDeductRuleExceptionForCentre.        
        IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> SelectByID(LeaveDeductRuleExceptionForCentre item);
    }
}
