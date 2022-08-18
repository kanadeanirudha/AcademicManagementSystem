using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ExceptionManager;
using AMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;
using AMS.DataProvider;
using System.IO;
//using System.Data.OleDb;
//using System.Data.SqlClient;
using System.Web.Hosting;
using System.Data;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Text.RegularExpressions;
using System.Collections;
namespace AMS.Web.UI.Controllers
{
    public class CRMCallEnquiryDetailsController : BaseController
    {
        ICRMCallEnquiryDetailsServiceAccess _CRMCallEnquiryDetailsServiceAcess = null;
        ICRMCallTypeServiceAccess _CRMCallTypeServiceAcess = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        static string xmlParameter = null;
        static bool IsExcelValid = true;
        static string errorMessage = null;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public CRMCallEnquiryDetailsController()
        {
            _CRMCallEnquiryDetailsServiceAcess = new CRMCallEnquiryDetailsServiceAccess();
            _CRMCallTypeServiceAcess = new CRMCallTypeServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index(string _CallTypeID)
        {
            CRMCallEnquiryDetailsViewModel model = new CRMCallEnquiryDetailsViewModel();
            model.CallTypeID = Convert.ToInt16(_CallTypeID);
            if (TempData["_errorMsg"] != null)
            {
                model.errorMessage = Convert.ToString(TempData["_errorMsg"]);
            }
            else
            {
                model.errorMessage = "NoMessage";
            }
            List<SelectListItem> li = new List<SelectListItem>();
            // li.Add(new SelectListItem { Text = "--Select--", Value = " " });
            //   li.Add(new SelectListItem { Text = "All", Value = "0" });
            //  li.Add(new SelectListItem { Text = "Completed", Value = "1" });
            li.Add(new SelectListItem { Text = "Unallocated", Value = "3" });
            li.Add(new SelectListItem { Text = "Allocated", Value = "2" });
            ViewData["Status"] = li;

            List<CRMCallType> CallTypeList = GetListCallType();
            List<SelectListItem> callTypelist = new List<SelectListItem>();
            foreach (CRMCallType item in CallTypeList)
            {
                callTypelist.Add(new SelectListItem { Text = item.CallTypeDescription, Value = Convert.ToString(item.ID) });
            }
            ViewBag.CallTypeDescription = new SelectList(callTypelist, "Value", "Text");
            return View("/Views/CRM/CRMCallEnquiryDetails/Index.cshtml", model);
        }

        public ActionResult List(string actionMode, CRMCallEnquiryDetailsViewModel model)
        {
            try
            {
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CRM/CRMCallEnquiryDetails/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }


        [HttpGet]
        public ActionResult Create()
        {
            CRMCallEnquiryDetailsViewModel model = new CRMCallEnquiryDetailsViewModel();
            List<CRMCallType> CallTypeList = GetListCallType();
            List<SelectListItem> callTypelist = new List<SelectListItem>();
            foreach (CRMCallType item in CallTypeList)
            {
                callTypelist.Add(new SelectListItem { Text = item.CallTypeDescription, Value = Convert.ToString(item.ID) });
            }
            ViewBag.CallTypeDescription = new SelectList(callTypelist, "Value", "Text");
            return PartialView("/Views/CRM/CRMCallEnquiryDetails/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(CRMCallEnquiryDetailsViewModel model)
        {
            try
            {

                if (model != null && model.CRMCallEnquiryDetailsDTO != null)
                {
                    UploadQuestionFile1();
                    model.CRMCallEnquiryDetailsDTO.ConnectionString = _connectioString;
                    model.CRMCallEnquiryDetailsDTO.CallTypeID = model.CallTypeID;
                    model.CRMCallEnquiryDetailsDTO.XMLstring = xmlParameter; ;
                    model.CRMCallEnquiryDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    model.CRMCallEnquiryDetailsDTO.errorMessage = errorMessage;
                    if (xmlParameter != string.Empty && xmlParameter != null && IsExcelValid == true)
                    {
                        IBaseEntityResponse<CRMCallEnquiryDetails> response = _CRMCallEnquiryDetailsServiceAcess.InsertCRMCallEnquiryDetails(model.CRMCallEnquiryDetailsDTO);
                        model.CRMCallEnquiryDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    else if (IsExcelValid == false)
                    {
                        model.CRMCallEnquiryDetailsDTO.errorMessage = errorMessage;// "Invalide excel column,#FFCC80";
                    }
                    else if (xmlParameter == string.Empty || xmlParameter != null)
                    {
                        model.CRMCallEnquiryDetailsDTO.errorMessage = errorMessage;// "No data found in excel,#FFCC80";
                    }

                    TempData["_errorMsg"] = model.CRMCallEnquiryDetailsDTO.errorMessage;
                    xmlParameter = null;
                    IsExcelValid = true;
                    errorMessage = null;
                    return RedirectToAction("Index", "CRMCallEnquiryDetails", new { _CallTypeID = model.CallTypeID });
                }


                else
                {
                    return Json("Please review your form");
                }
            }

            catch (Exception)
            {
                throw;
            }





        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CRMCallEnquiryDetailsViewModel model = new CRMCallEnquiryDetailsViewModel();
            try
            {
                model.CRMCallEnquiryDetailsDTO = new CRMCallEnquiryDetails();
                model.CRMCallEnquiryDetailsDTO.ID = id;
                model.CRMCallEnquiryDetailsDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CRMCallEnquiryDetails> response = _CRMCallEnquiryDetailsServiceAcess.SelectByID(model.CRMCallEnquiryDetailsDTO);
                if (response != null && response.Entity != null)
                {
                    model.CRMCallEnquiryDetailsDTO.ID = response.Entity.ID;
                    model.CRMCallEnquiryDetailsDTO.CalleeFirstName = response.Entity.CalleeFirstName;
                    model.CRMCallEnquiryDetailsDTO.CalleeEmailID = response.Entity.CalleeEmailID;
                    model.CRMCallEnquiryDetailsDTO.CalleeMobileNo = response.Entity.CalleeMobileNo;
                    model.CRMCallEnquiryDetailsDTO.Status = response.Entity.Status;
                    model.CRMCallEnquiryDetailsDTO.Source = response.Entity.Source;

                    List<SelectListItem> li = new List<SelectListItem>();
                    // li.Add(new SelectListItem { Text = "--Select--", Value = " " });
                    li.Add(new SelectListItem { Text = "All", Value = "0" });
                    li.Add(new SelectListItem { Text = "Completed", Value = "1" });
                    li.Add(new SelectListItem { Text = "In Progress", Value = "2" });
                    li.Add(new SelectListItem { Text = "Pending", Value = "3" });
                    ViewData["Status"] = li;
                    ViewData["Status"] = new SelectList(li, model.CRMCallEnquiryDetailsDTO.Status);

                    model.CRMCallEnquiryDetailsDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/CRM/CRMCallEnquiryDetails/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(CRMCallEnquiryDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.CRMCallEnquiryDetailsDTO != null)
                {
                    if (model != null && model.CRMCallEnquiryDetailsDTO != null)
                    {
                        // model.CRMCallEnquiryDetailsDTO.ConnectionString = _connectioString;
                        // model.CRMCallEnquiryDetailsDTO.CounterName = model.CounterName;
                        //// model.CRMCallEnquiryDetailsDTO.SeqNo = model.SeqNo;
                        // model.CRMCallEnquiryDetailsDTO.CounterCode = model.CounterCode;
                        model.CRMCallEnquiryDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CRMCallEnquiryDetails> response = _CRMCallEnquiryDetailsServiceAcess.UpdateCRMCallEnquiryDetails(model.CRMCallEnquiryDetailsDTO);
                        model.CRMCallEnquiryDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.CRMCallEnquiryDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            CRMCallEnquiryDetailsViewModel model = new CRMCallEnquiryDetailsViewModel();
            model.CRMCallEnquiryDetailsDTO = new CRMCallEnquiryDetails();
            model.CRMCallEnquiryDetailsDTO.ID = ID;
            return PartialView("/Views/Inventory/CRMCallEnquiryDetails/Delete.cshtml", model);
        }

        [HttpPost]
        public ActionResult Delete(CRMCallEnquiryDetailsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                if (model.ID > 0)
                {
                    CRMCallEnquiryDetails CRMCallEnquiryDetailsDTO = new CRMCallEnquiryDetails();
                    CRMCallEnquiryDetailsDTO.ConnectionString = _connectioString;
                    CRMCallEnquiryDetailsDTO.ID = model.ID;
                    CRMCallEnquiryDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<CRMCallEnquiryDetails> response = _CRMCallEnquiryDetailsServiceAcess.DeleteCRMCallEnquiryDetails(CRMCallEnquiryDetailsDTO);
                    model.CRMCallEnquiryDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

                }
                return Json(model.CRMCallEnquiryDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        public FileResult Download()
        {
            string FileName = "CallEnquiryExcelFile.xlsx";
            string filePath = Path.Combine(Server.MapPath("~") + "Content\\DownloadFiles\\", FileName);
            string contentType = "application/vnd.ms-excel";
            return File(filePath, contentType, FileName);
        }
        #endregion

        // Non-Action Method
        #region Methods



        public IEnumerable<CRMCallEnquiryDetailsViewModel> GetCRMCallEnquiryDetails(string UploadDate, string CallTypeID, string Status, out int TotalRecords)
        {
            CRMCallEnquiryDetailsSearchRequest searchRequest = new CRMCallEnquiryDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.UploadDate = UploadDate;
                    searchRequest.CallTypeID = Convert.ToInt16(CallTypeID);
                    searchRequest.Status = Convert.ToInt16(Status);
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.UploadDate = UploadDate;
                    searchRequest.CallTypeID = Convert.ToInt16(CallTypeID);
                    searchRequest.Status = Convert.ToInt16(Status);

                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.UploadDate = UploadDate;
                searchRequest.CallTypeID = Convert.ToInt16(CallTypeID);
                searchRequest.Status = Convert.ToInt16(Status);

            }
            List<CRMCallEnquiryDetailsViewModel> listCRMCallEnquiryDetailsViewModel = new List<CRMCallEnquiryDetailsViewModel>();
            List<CRMCallEnquiryDetails> listCRMCallEnquiryDetails = new List<CRMCallEnquiryDetails>();
            IBaseEntityCollectionResponse<CRMCallEnquiryDetails> baseEntityCollectionResponse = _CRMCallEnquiryDetailsServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCRMCallEnquiryDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CRMCallEnquiryDetails item in listCRMCallEnquiryDetails)
                    {
                        CRMCallEnquiryDetailsViewModel CRMCallEnquiryDetailsViewModel = new CRMCallEnquiryDetailsViewModel();
                        CRMCallEnquiryDetailsViewModel.CRMCallEnquiryDetailsDTO = item;
                        listCRMCallEnquiryDetailsViewModel.Add(CRMCallEnquiryDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCRMCallEnquiryDetailsViewModel;
        }

        [AcceptVerbs(HttpVerbs.Post)]

        public void UploadQuestionFile1()
        {
            string _ExcelFileXML = string.Empty;
            //   string XMLstring = string.Empty;
            var _comPath = "";
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var ExcelFile = System.Web.HttpContext.Current.Request.Files["MyFile"];
                if (ExcelFile.ContentLength > 0)
                {
                    string extension = System.IO.Path.GetExtension(ExcelFile.FileName);
                    _comPath = Server.MapPath("~") + "Content\\UploadedFiles\\UplodedExcel\\";
                    var myUniqueFileName = Guid.NewGuid();
                    string filePath = String.Concat(myUniqueFileName, ExcelFile.FileName);
                    filePath = string.Format("{0}{1}", _comPath, filePath);

                    if (!Directory.Exists(_comPath))
                    {
                        Directory.CreateDirectory(_comPath);
                    }
                    if (System.IO.File.Exists(filePath))
                        System.IO.File.Delete(filePath);

                    ExcelFile.SaveAs(filePath);

                    //Create connection string to Excel work book
                    // string excelConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + ";Extended Properties=Excel 12.0;Persist Security Info=False";


                    ////Create Connection to Excel work book
                    //OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                    //excelConnection.Open();
                    ////Create OleDbCommand to fetch data from Excel
                    ////OleDbCommand cmd = new OleDbCommand("Select [StudentFirstName],[StudentMiddelName],[StudentLastName],[StudentMobileNo],[StudentEmailID],[Source],[SourceContactPerson] from [Sheet1$]", excelConnection);
                    //DataTable dtExcelSchema;

                    //dtExcelSchema = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    //string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

                    //OleDbCommand cmd = new OleDbCommand("Select * from [" + SheetName + "]", excelConnection);

                    ////  excelConnection.Open();
                    //OleDbDataReader dReader;
                    //dReader = cmd.ExecuteReader();
                    xmlParameter = "<rows>";
                    //Open the Excel file in Read Mode using OpenXml.
                    using (SpreadsheetDocument doc = SpreadsheetDocument.Open(filePath, false))
                    {
                        //Read the first Sheet from Excel file.
                        Sheet sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();

                        //Get the Worksheet instance.
                        Worksheet worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;

                        //Fetch all the rows present in the Worksheet.
                        // IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();
                        SheetData rows = worksheet.GetFirstChild<SheetData>();

                        DataTable dt = new DataTable();
                        //Loop through the Worksheet rows.


                        foreach (Cell cell in rows.ElementAt(0))
                        {
                            if ((GetCellValue(doc, cell)) == "StudentFirstName" || (GetCellValue(doc, cell)) == "StudentMiddelName" || (GetCellValue(doc, cell)) == "StudentLastName" || (GetCellValue(doc, cell)) == "StudentMobileNo" || (GetCellValue(doc, cell)) == "StudentEmailID" || (GetCellValue(doc, cell)) == "Source" || (GetCellValue(doc, cell)) == "SourceContactPerson")
                            {
                                dt.Columns.Add(GetCellValue(doc, cell));
                            }
                            else
                            {
                                IsExcelValid = false;
                                errorMessage = "Invalid excel column,#FFCC80";

                            }

                        }
                        if (dt.Columns.Count > 0)
                        {
                            foreach (Row row in rows)
                            {
                                DataRow tempRow = dt.NewRow();
                                int columnIndex = 0;
                                foreach (Cell cell in row.Descendants<Cell>())
                                {
                                    // Gets the column index of the cell with data

                                    int cellColumnIndex = (int)GetColumnIndexFromName(GetColumnName(cell.CellReference));

                                    cellColumnIndex--; //zero based index
                                    if (columnIndex < cellColumnIndex)
                                    {
                                        do
                                        {
                                            tempRow[columnIndex] = ""; //Insert blank data here;
                                            columnIndex++;
                                        }
                                        while (columnIndex < cellColumnIndex);
                                    }
                                    tempRow[columnIndex] = GetCellValue(doc, cell);

                                    columnIndex++;
                                }
                                dt.Rows.Add(tempRow);
                            }

                            dt.Rows.RemoveAt(0); //...so i'm taking it out here.

                            RemoveDuplicateRows(dt, "StudentMobileNo");

                            if (extension == ".xls" || extension == ".xlsx")
                            {
                                if (
                                    dt.Columns[0].ColumnName != "StudentFirstName" ||
                                    dt.Columns[1].ColumnName != "StudentMiddelName" ||
                                    dt.Columns[2].ColumnName != "StudentLastName" ||
                                    dt.Columns[3].ColumnName != "StudentMobileNo" ||
                                    dt.Columns[4].ColumnName != "StudentEmailID" ||
                                    dt.Columns[5].ColumnName != "Source" ||
                                    dt.Columns[6].ColumnName != "SourceContactPerson"
                                    )
                                {
                                    IsExcelValid = false;
                                    errorMessage = "Invalid excel column,#FFCC80";
                                }

                                if (IsExcelValid == true)
                                {
                                    long result;

                                    //while (dReader.Read())
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        if ((long.TryParse(dt.Rows[i]["StudentMobileNo"].ToString().Replace('-', ' ').Replace('+', ' ').Trim(), out result)) || (dt.Rows[i]["StudentEmailID"].ToString().Length >= 5))
                                        {
                                            if (dt.Rows[i]["StudentMobileNo"].ToString().Trim().Length > 2)
                                            {
                                                if (dt.Rows[i]["StudentMobileNo"].ToString().Contains('+') || dt.Rows[i]["StudentMobileNo"].ToString().Contains('-') || long.TryParse(dt.Rows[i]["StudentMobileNo"].ToString(), out result))
                                                {
                                                    xmlParameter = xmlParameter + "<row><ID>" + 0 + "</ID><CalleeFirstName>" + dt.Rows[i]["StudentFirstName"].ToString().Trim() + "</CalleeFirstName><CalleeMiddelName>" + dt.Rows[i]["StudentMiddelName"].ToString().Trim() + "</CalleeMiddelName><CalleeLastName>" + dt.Rows[i]["StudentLastName"].ToString().Trim() + "</CalleeLastName><CalleeMobileNo>" + dt.Rows[i]["StudentMobileNo"].ToString().Trim() + "</CalleeMobileNo><CalleeEmailID>" + dt.Rows[i]["StudentEmailID"].ToString().Trim() + "</CalleeEmailID><CalleeEntityType>Student</CalleeEntityType><Source>" + dt.Rows[i]["Source"].ToString().Trim() + "</Source><SourceContactPerson>" + dt.Rows[i]["SourceContactPerson"].ToString().Trim() + "</SourceContactPerson></row>";
                                                }
                                            }
                                        }
                                    }
                                    if (xmlParameter.Length > 9)
                                    {
                                        xmlParameter = xmlParameter + "</rows>";
                                    }
                                    else
                                    {
                                        xmlParameter = string.Empty;
                                        errorMessage = "No data found in excel,#FFCC80";
                                    }
                                }
                            }
                            else
                            {
                                errorMessage = "The selected file does not appear to be an excel file,#FFCC80";
                            }
                        }
                        else
                        {
                            IsExcelValid = false;
                            errorMessage = "Invalid excel column,#FFCC80";
                        }
                        dt.Dispose();
                    }

                    // excelConnection.Close();

                    // SQL Server Connection String
                }
                else
                {
                    errorMessage = "Excel file not selected,#FFCC80";
                }
            }

        }

        public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
        {
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
            //And add duplicate item value in arraylist.
            foreach (DataRow drow in dTable.Rows)
            {
                if (hTable.Contains(drow[colName]))
                    duplicateList.Add(drow);
                else
                    hTable.Add(drow[colName], string.Empty);
            }

            //Removing a list of duplicate items from datatable.
            foreach (DataRow dRow in duplicateList)
                dTable.Rows.Remove(dRow);

            //Datatable which contains unique records will be return as output.
            return dTable;
        }
        /// <summary>
        /// Given a cell name, parses the specified cell to get the column name.
        /// </summary>
        /// <param name="cellReference">Address of the cell (ie. B2)</param>
        /// <returns>Column Name (ie. B)</returns>
        public static string GetColumnName(string cellReference)
        {
            // Create a regular expression to match the column name portion of the cell name.
            Regex regex = new Regex("[A-Za-z]+");
            Match match = regex.Match(cellReference);
            return match.Value;
        }
        /// <summary>
        /// Given just the column name (no row index), it will return the zero based column index.
        /// Note: This method will only handle columns with a length of up to two (ie. A to Z and AA to ZZ). 
        /// A length of three can be implemented when needed.
        /// </summary>
        /// <param name="columnName">Column Name (ie. A or AB)</param>
        /// <returns>Zero based index if the conversion was successful; otherwise null</returns>
        public static int? GetColumnIndexFromName(string columnName)
        {

            //return columnIndex;
            string name = columnName;
            int number = 0;
            int pow = 1;
            for (int i = name.Length - 1; i >= 0; i--)
            {
                number += (name[i] - 'A' + 1) * pow;
                pow *= 26;
            }
            return number;
        }
        public static string GetCellValue(SpreadsheetDocument document, Cell cell)
        {
            SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
            if (cell.CellValue == null)
            {
                return "";
            }
            string value = cell.CellValue.InnerXml;
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
            }
            else
            {
                return value;
            }
        }


        //public JsonResult UploadQuestionFile()
        //{
        //    string _ExcelFileXML = string.Empty;
        //    //   string XMLstring = string.Empty;
        //    var _comPath = "";
        //    if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
        //    {
        //        var ExcelFile = System.Web.HttpContext.Current.Request.Files["MyFile"];
        //        if (ExcelFile.ContentLength > 0)
        //        {
        //            string extension = System.IO.Path.GetExtension(ExcelFile.FileName);
        //            _comPath = Server.MapPath("~") + "Content\\UploadedFiles\\UplodedExcel\\";
        //            string path1 = string.Format("{0}/{1}", _comPath, ExcelFile.FileName);
        //            if (!Directory.Exists(_comPath))
        //            {
        //                Directory.CreateDirectory(_comPath);
        //            }
        //            if (System.IO.File.Exists(path1))
        //                System.IO.File.Delete(path1);

        //            ExcelFile.SaveAs(path1);

        //            //Create connection string to Excel work book
        //            string excelConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + ";Extended Properties=Excel 12.0;Persist Security Info=False";
        //            //Create Connection to Excel work book
        //            OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
        //            //Create OleDbCommand to fetch data from Excel
        //            OleDbCommand cmd = new OleDbCommand("Select [CalleeFirstName],[CalleeMiddelName],[CalleeLastName],[CalleeMobileNo],[CalleeEmailID],[CalleeEntityType],[Source],[SourceContactPerson] from [Sheet1$]", excelConnection);

        //            excelConnection.Open();
        //            OleDbDataReader dReader;
        //            dReader = cmd.ExecuteReader();
        //            string aa = string.Empty;
        //            string xmlParameter = "<rows>";

        //            while (dReader.Read())
        //            {

        //                xmlParameter = xmlParameter + "<row><ID>" + 0 + "</ID><CalleeFirstName>" + dReader.GetValue(0).ToString() + "</CalleeFirstName><CalleeMiddelName>" + dReader.GetValue(1).ToString() + "</CalleeMiddelName><CalleeLastName>" + dReader.GetValue(2).ToString() + "</CalleeLastName><CalleeMobileNo>" + dReader.GetValue(3).ToString() + "</CalleeMobileNo><CalleeEmailID>" + dReader.GetValue(4).ToString() + "</CalleeEmailID><CalleeEntityType>" + dReader.GetValue(5).ToString() + "</CalleeEntityType><Source>" + dReader.GetValue(6).ToString() + "</Source><SourceContactPerson>" + dReader.GetValue(7).ToString() + "</SourceContactPerson></row>";
        //            }
        //            if (xmlParameter.Length > 9)
        //            {
        //                xmlParameter = xmlParameter + "</rows>";
        //            }
        //            else
        //            {
        //                xmlParameter = "";
        //            }
        //            excelConnection.Close();

        //            // SQL Server Connection String


        //        }

        //    }
        //    return Json(Convert.ToString(_comPath), JsonRequestBehavior.AllowGet);
        //}


        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string UploadDate, string CallTypeID, string Status)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<CRMCallEnquiryDetailsViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "B.ID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "B.CalleeFirstName like '%'";
                        }
                        else
                        {
                            _searchBy = "B.CalleeFirstName Like '%" + param.sSearch + "%' or B.CalleeEmailID Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "CalleeMobileNo";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "B.CalleeFirstName like '%'";
                        }
                        else
                        {
                            _searchBy = "B.CalleeFirstName Like '%" + param.sSearch + "%' or B.CalleeEmailID Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "CalleeEmailID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "B.CalleeFirstName like '%'";
                        }
                        else
                        {
                            _searchBy = "B.CalleeFirstName Like '%" + param.sSearch + "%' or B.CalleeEmailID Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                    case 4:
                        _sortBy = "Source";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "B.CalleeFirstName like '%'";
                        }
                        else
                        {
                            _searchBy = "B.CalleeFirstName Like '%" + param.sSearch + "%' or B.CalleeEmailID Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                    case 5:
                        _sortBy = "SourceContactPerson";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "B.CalleeFirstName like '%'";
                        }
                        else
                        {
                            _searchBy = "B.CalleeFirstName Like '%" + param.sSearch + "%' or B.CalleeEmailID Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;

                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                //filteredCountryMaster = new List<CRMCallEnquiryDetailsViewModel>(); 

                if (!string.IsNullOrEmpty(CallTypeID))
                {
                    filteredCountryMaster = GetCRMCallEnquiryDetails(UploadDate, Convert.ToString(CallTypeID), Convert.ToString(Status), out TotalRecords);
                }
                else
                {
                    filteredCountryMaster = new List<CRMCallEnquiryDetailsViewModel>();
                    TotalRecords = 0;
                }


                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { c.CalleeFirstName.ToString(), c.CalleeMiddelName.ToString(), c.CalleeLastName.ToString(), c.CalleeEmailID.ToString(), c.Status.ToString(), c.Source.ToString(), c.SourceContactPerson.ToString(), Convert.ToString(c.ID), Convert.ToString(c.CalleeFirstName + " " + c.CalleeMiddelName + " " + c.CalleeLastName), Convert.ToString(c.CalleeMobileNo), Convert.ToString(c.UnallocatedCalls), Convert.ToString(c.AllocatedCalls) };
                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                //return View("Login","Account");
                //return RedirectToAction("Login", "Account");
                var result = 0;
                return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
                // return PartialView("Login");
            }
        }
        #endregion
    }
}