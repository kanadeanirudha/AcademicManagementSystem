/// <reference path="../../bootstrap.min.js" />
//this class contain methods related to nationality functionality
var InventoryInWardMasterAndInWardDetails = {
    //Member variables
    ActionName: null,
    XMLstring: null,
    //Class intialisation method
    Initialize: function () {
        InventoryInWardMasterAndInWardDetails.constructor();
    },
    //Attach all event of page
    constructor: function () {
        
      
        $('#CreateApproveInventoryInwardDetails').on("click", function () {
            
            //  alert("asdfasdfasdf");
            InventoryInWardMasterAndInWardDetails.ActionName = "ApproveInward";
            InventoryInWardMasterAndInWardDetails.GetApprovedInwardkXmlData();
            if (InventoryInWardMasterAndInWardDetails.XMLstring != null && InventoryInWardMasterAndInWardDetails.XMLstring != "") {
                $('#CreateApproveInventoryInwardDetails').attr("disabled", true);
                InventoryInWardMasterAndInWardDetails.AjaxCallInventoryInWardMasterAndInWardDetails();
            }
            else {
                $('#SuccessMessage').html("No data available in table");
                $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");

            }
        });

        $("#UserSearch").on("keyup", function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").on("click", function () {
            $("#UserSearch").focus();
        });

        $("#showrecord").on("change", function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        $(".ajax").colorbox();

    },
    
    //LoadList method is used to load List page
    LoadList: function () {
        var Balancesheet = $("#selectedBalsheetID").val();
        var locationId = $("#LocationID").val();
        $.ajax(

         {
             cache: false,
             type: "GET",
             data: { "selectedBalsheet": Balancesheet, "locationId": locationId },
             dataType: "html",
             url: '/InventoryInWardMasterAndInWardDetails/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },

    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var Balancesheet = $("#selectedBalsheetID").val();
        var locationId = $("#LocationID").val();
        $.ajax(
        {
            cache: false,

            type: "GET",
            data: { "selectedBalsheet": Balancesheet, "locationId": locationId, "actionMode": actionMode },
            dataType: "html",
            url: '/InventoryInWardMasterAndInWardDetails/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
            }
        });
    },
    ReloadPendingRequestList: function (message, colorCode, actionMode) {
        var TaskCode = $('input[name=TaskCode]').val();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode, "TaskCode": TaskCode },
            url: '/Home/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#SuccessMessage').html('Request approved successfully');
                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', '#9FEA7A');
            }
        });
    },
    //Method to create xml
    GetApprovedInwardkXmlData: function () {
        
        
        
        
        
        var DataArray = [];
        var data = $('#tblData tbody tr td input').each(function () {
            DataArray.push($(this).val());
        });

        var TotalRecord = DataArray.length;
      //  alert(DataArray);
     //   var x = 0;
        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 6) {
           
            if ((parseFloat(parseFloat(DataArray[i + 2]) + parseFloat(DataArray[i + 3]) + parseFloat(DataArray[i + 4])) != parseFloat(DataArray[i + 1])))
                
            {
                $('#SuccessMessagediv').html("TotalQuantity should be equal to issue quantity ");
                $('#SuccessMessagediv').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', colorCode);
            }

            else if (((DataArray[i + 3]) > 0 || (DataArray[i + 4])> 0) && ((DataArray[i + 5]) ==null || (DataArray[i + 5])== "")) {

                $('#SuccessMessagediv').html("Remark should Not Be Blank ");
                $('#SuccessMessagediv').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', colorCode);
               // alert("BGG");
               // $('#tblData tbody tr:eq(' + x + ')').css("background-color", "red");
            }
            else {
                ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><ItemId>" + DataArray[i] + "</ItemId><InwardQuantity>" + parseFloat(DataArray[i + 2]).toFixed(2) + "</InwardQuantity><DamageQuantity>" + parseFloat(DataArray[i + 3]).toFixed(2) + "</DamageQuantity><StolenStockQuantity>" + parseFloat(DataArray[i + 4]).toFixed(2) + "</StolenStockQuantity><Remark>" + DataArray[i + 5] + "</Remark></row>";
            }

           // x++;
        }
      //  alert(ParameterXml);
        if (ParameterXml.length > 9)
            InventoryInWardMasterAndInWardDetails.XMLstring = ParameterXml + "</rows>";
        else
            InventoryInWardMasterAndInWardDetails.XMLstring = "";

        //alert(InventoryEstimationMasterAndDetails.XMLstring);
    },

    //Fire ajax call to insert update and delete record
    AjaxCallInventoryInWardMasterAndInWardDetails: function () {
        var InventoryInWardMasterAndInWardDetailsData = null;
        if (InventoryInWardMasterAndInWardDetails.ActionName == "Create") {
            $("#FormCreateInventorySalesAndTransaction").validate();
            if ($("#FormCreateInventorySalesAndTransaction").valid()) {
                InventoryInWardMasterAndInWardDetailsData = null;
                InventoryInWardMasterAndInWardDetailsData = InventoryInWardMasterAndInWardDetails.GetInventoryInWardMasterAndInWardDetails();
                ajaxRequest.makeRequest("/InventoryInWardMasterAndInWardDetails/Create", "POST", InventoryInWardMasterAndInWardDetailsData, InventoryInWardMasterAndInWardDetails.Success);
            }
        }
        if (InventoryInWardMasterAndInWardDetails.ActionName == "ApproveInward") {
            $("#FormApproveInventoryInwardDetails").validate();
            if ($("#FormApproveInventoryInwardDetails").valid()) {
                InventoryInWardMasterAndInWardDetailsData = null;
                InventoryInWardMasterAndInWardDetailsData = InventoryInWardMasterAndInWardDetails.GetInventoryInWardMasterAndInWardDetails();
                ajaxRequest.makeRequest("/InventoryInWardMaster/InwardRequestApproval", "POST", InventoryInWardMasterAndInWardDetailsData, InventoryInWardMasterAndInWardDetails.SuccessRequestList);
            }
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetInventoryInWardMasterAndInWardDetails: function () {
        
        var Data = {
        };
        Data.ID = $('input[name=ID]').val();
        Data.BillAmount = $('#TotalBillAmount').val();
        Data.DumpAndShrinkAmount = $('#TotalBillAmount').val();
        $("#BalanceSheetID").val($("#selectedBalsheetID").val());
        Data.BalanceSheetID = $("#BalanceSheetID").val($("#selectedBalsheetID").val());
        Data.LocationID = $("#LocationID").val();
        Data.FieldName = $("#FieldName").val();
        Data.XMLstring = InventoryInWardMasterAndInWardDetails.XMLstring;

        if (InventoryInWardMasterAndInWardDetails.ActionName == "ApproveInward") {
            Data.TaskCode = $('input[name=TaskCode]').val();
            Data.TaskNotificationDetailsID = $('input[name=TaskNotificationDetailsID]').val();
            Data.TaskNotificationMasterID = $('input[name=TaskNotificationMasterID]').val();
            Data.GeneralTaskReportingDetailsID = $('input[name=GeneralTaskReportingDetailsID]').val();
            Data.PersonID = $('input[name=PersonID]').val();
            Data.StageSequenceNumber = $('input[name=StageSequenceNumber]').val();
            Data.IsLastRecord = $('input[name=IsLastRecord]').val();
            Data.BalanceSheetID = $("input[name=BalanceSheetID]").val();
            Data.LocationID = $("input[name=LocationID]").val();
       
            Data.IssueToLocationID = $("input[name=IssueToLocationID]").val();
           
            //var Balancesheet = $("#selectedBalsheetID").val();
            //alert(Balancesheet);
            //   $("#BalanceSheetID").val($("#selectedBalsheetID").val());
            
            Data.BalanceSheetID = $("#selectedBalsheetID").val();
            Data.InventoryInWardMasterID = $("input[name=InventoryInWardMasterID]").val();
            Data.InventoryInWardDetailsID = $("#InventoryInWardDetailsID").val();
            Data.XMLstring = InventoryInWardMasterAndInWardDetails.XMLstring;
            Data.FieldName = $("input[name=FieldName]").val();
            Data.FieldValue = $("input[name=FieldValue]").val();
           
        }
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        parent.$.colorbox.close();
        InventoryInWardMasterAndInWardDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
    },
    SuccessRequestList: function (data) {
        var splitData = data.split(',');
        parent.$.colorbox.close();
        InventoryInWardMasterAndInWardDetails.ReloadPendingRequestList(splitData[0], splitData[1], splitData[2]);
        $('#CreateApproveInventoryInwardDetails').attr("disabled", true);
        
    },

    };