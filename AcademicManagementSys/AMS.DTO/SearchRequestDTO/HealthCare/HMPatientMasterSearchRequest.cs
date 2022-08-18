using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class HMPatientMasterSearchRequest : Request
{
                public Int64 ID{get;set;}
                public string PatientCode{get;set;}
                public string FirstName{get;set;}
                public string MiddleName{get;set;}
                public string LastName{get;set;}
                public string DOB     {get;set;}
                public bool IsDeleted{get;set;}
                public string CentreCode { get;set; }
                public string SortOrder{ get;set;}
                public string SortBy{ get;set; }
                public int StartRow { get;set; }
                public int EndRow
                {
                    get;
                    set;
                }

                public int RowLength
                {
                    get;
                    set;
                }
                public string SearchBy
                {
                    get;
                    set;
                }
                public string SortDirection
                {
                    get;
                    set;
                }

                public string SearchWord { get; set; }
}
}
