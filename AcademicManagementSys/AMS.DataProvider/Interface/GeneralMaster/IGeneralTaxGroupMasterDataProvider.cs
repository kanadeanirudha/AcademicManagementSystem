using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IGeneralTaxGroupMasterDataProvider
    {
        /// <summary>
        /// data provider interface of insert new record of GeneralTaxGroupMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTaxGroupMaster> InsertGeneralTaxGroupMaster(GeneralTaxGroupMaster item);

        /// <summary>
        /// data provider interface of update record of GeneralTaxGroupMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTaxGroupMaster> UpdateGeneralTaxGroupMaster(GeneralTaxGroupMaster item);

        /// <summary>
        /// data provider interface of dalete record of GeneralTaxGroupMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTaxGroupMaster> DeleteGeneralTaxGroupMaster(GeneralTaxGroupMaster item);

        /// <summary>
        /// data provider interface of select all record of GeneralTaxGroupMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralTaxGroupMaster> GetGeneralTaxGroupMasterBySearch(GeneralTaxGroupMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of GeneralCountryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralTaxGroupMaster> GetGeneralTaxGroupMasterBySearchList(GeneralTaxGroupMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of GeneralTaxGroupMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTaxGroupMaster> GetGeneralTaxGroupMasterByID(GeneralTaxGroupMaster item);
    }
}
