using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public interface IInventoryExcelUploadViewModel
    {
        string ExcelFile
        {
            get;
            set;
        }
    }
}
