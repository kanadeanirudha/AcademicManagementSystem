using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class GeneralPolicyRulesServiceAccess : IGeneralPolicyRulesServiceAccess
    {
        IGeneralPolicyRulesBA  _GeneralPolicyRulesBA = null;

        public GeneralPolicyRulesServiceAccess()
        {
            _GeneralPolicyRulesBA = new GeneralPolicyRulesBA();
        }
        /// <summary>
        /// Service access of create new record of GeneralPolicyRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPolicyRules> InsertGeneralPolicyRules(GeneralPolicyRules item)
        {
            return _GeneralPolicyRulesBA.InsertGeneralPolicyRules(item);
        }

        /// <summary>
        /// Service access of update a specific record of GeneralPolicyRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPolicyRules> UpdateGeneralPolicyRules(GeneralPolicyRules item)
        {
            return _GeneralPolicyRulesBA.UpdateGeneralPolicyRules(item);
        }

        /// <summary>
        /// Service access of delete a selected record from GeneralPolicyRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPolicyRules> DeleteGeneralPolicyRules(GeneralPolicyRules item)
        {
            return _GeneralPolicyRulesBA.DeleteGeneralPolicyRules(item);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralPolicyRules table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralPolicyRules> GetBySearch(GeneralPolicyRulesSearchRequest searchRequest)
        {
            return _GeneralPolicyRulesBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralPolicyRules table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralPolicyRules> GetGeneralPolicyRulesForPolicyRange(GeneralPolicyRulesSearchRequest searchRequest)
        {
            return _GeneralPolicyRulesBA.GetGeneralPolicyRulesForPolicyRange(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from GeneralPolicyRules table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// 

        public IBaseEntityCollectionResponse<GeneralPolicyRules> GetGeneralPolicyRulesGetBySearchList(GeneralPolicyRulesSearchRequest searchRequest)
        {
            return _GeneralPolicyRulesBA.GetGeneralPolicyRulesGetBySearchList(searchRequest);
        }



        public IBaseEntityResponse<GeneralPolicyRules> SelectByID(GeneralPolicyRules item)
        {
            return _GeneralPolicyRulesBA.SelectByID(item);
        }

        public IBaseEntityCollectionResponse<GeneralPolicyRules> GetPolicyAnswerByPolicyStatus(GeneralPolicyRulesSearchRequest searchRequest)
        {
            return _GeneralPolicyRulesBA.GetPolicyAnswerByPolicyStatus(searchRequest);
        }
        public IBaseEntityResponse<GeneralPolicyRules> GetPolicyApplicableStatus(GeneralPolicyRules item)
        {
            return _GeneralPolicyRulesBA.GetPolicyApplicableStatus(item);
        }
    }
}

