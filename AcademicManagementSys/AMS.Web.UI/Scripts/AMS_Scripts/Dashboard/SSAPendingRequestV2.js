//this class contain methods related to nationality functionality
var SSAPendingRequest = {
    //Member variables
    ActionName: null,
    XMLstring: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        SSAPendingRequest.constructor();
        //SSAPendingRequest.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        // Create new record


        $('#CreateScholarShipAllocation').on("click", function () {
            SSAPendingRequest.ActionName = "Approved";
            SSAPendingRequest.GetXmlData();
            SSAPendingRequest.AjaxCallSSAPendingRequest();
        });

        $('#RejectScholarShipAllocation').on("click", function () {
            SSAPendingRequest.ActionName = "Rejected";
            SSAPendingRequest.GetXmlData();
            SSAPendingRequest.AjaxCallSSAPendingRequest();
        });

        

        $("#UserSearch").keyup(function () {
            var oTable = $("#MyDataTablePendingLeaveRequest").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });


        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='MyDataTablePendingLeaveRequest_length']").val(showRecord);
            $("select[name*='MyDataTablePendingLeaveRequest_length']").change();
        });

        //$(".ajax").colorbox();

        $('ul#pending_Request li').click(function () {
            

            var TaskCode = $(this).attr('id');
            var RequestName = $(this).text();
            $.ajax(
                  {
                      cache: false,
                      type: "GET",
                      dataType: "html",
                      data: { "TaskCode": TaskCode },
                      url: '/Home/List',
                      success: function (result) {
                          $('#ListViewModel').html(result);
                      }
                  });
        });
    },
    ////Load method is used to load *-Load-* page
    LoadList: function () {
        
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/Home/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {

        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode },
            url: '/Home/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
            }
        });
    },

    ReloadListAfterApproval: function (message, colorCode, actionMode) {
        notify(message, colorCode);
        $('#SSA').click();
        //var TaskCode = 'SSA'
        //$.ajax(
        //{
        //    cache: false,
        //    type: "POST",
        //    dataType: "html",
        //    data: { "actionMode": actionMode, "TaskCode": TaskCode },
        //    url: '/Home/NotificationListV2',
        //    success: function (data) {
        //        $('#content').empty().html(data);
        //        notify(message, colorCode);
        //    }
        //});
    },


    //Fire ajax call to insert update and delete record
    AjaxCallSSAPendingRequest: function () {
        var SSAPendingRequestData = null;
         if (SSAPendingRequest.ActionName == "Approved" || SSAPendingRequest.ActionName == "Rejected") {
            SSAPendingRequestData = null;
            SSAPendingRequestData = SSAPendingRequest.GetSSAPendingRequest();
            ajaxRequest.makeRequest("/ScholarShipAllocation/ScholarShipAllocationRequestApprovalV2", "POST", SSAPendingRequestData, SSAPendingRequest.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetSSAPendingRequest: function () {
        var Data = {
        };
        if (SSAPendingRequest.ActionName == "Approved" || SSAPendingRequest.ActionName == "Rejected") {
            
            Data.XMLstring = SSAPendingRequest.XMLstring
            Data.CentreCode = $('input[name=CentreCode]').val();
            Data.ScholarShipAllocationID = $('input[name=ScholarShipAllocationID]').val();
            Data.TaskCode = $('input[name=TaskCode]').val();
            Data.IsLastRecord = $('input[name=IsLastRecord]').val();
            Data.StudentID = $('input[name=StudentID]').val();
            Data.PersonID = $('input[name=PersonID]').val();
            Data.StageSequenceNumber = $('input[name=StageSequenceNumber]').val();
            Data.TaskNotificationMasterID = $('input[name=TaskNotificationMasterID]').val();
            Data.TaskNotificationDetailsID = $('input[name=TaskNotificationDetailsID]').val();
            Data.GeneralTaskReportingDetailsID = $('input[name=GeneralTaskReportingDetailsID]').val();
            if (SSAPendingRequest.ActionName == "Approved") {
                Data.RequestApprovedStatus = 1;
            }
            else {
                Data.RequestApprovedStatus = 0;
            }            
        }
        return Data;
    },

    GetXmlData: function () {
        
        var DataArray = [];
        $('#tblScholarShipAllocation tbody tr td input[type="text"]').each(function () {
            DataArray.push($(this).val());
        });
        var TotalRecord = DataArray.length;
        var ScholarShipAllocationXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 4) {
            if (DataArray[i] > 0) {
                ScholarShipAllocationXml = ScholarShipAllocationXml
                                    + "<row>"
               		                + "<TransactionSubID>0</TransactionSubID>"
               		                + "<AccountID>" + DataArray[i + 0] + "</AccountID>"
               		                + "<DebitCreditFlag>" + DataArray[i + 1] + "</DebitCreditFlag>"
               		                + "<TransactionAmount>" + DataArray[i + 2] + "</TransactionAmount>"
               		                + "<ChequeNo></ChequeNo>"
               		                + "<ChequeDatetime></ChequeDatetime>"
               		                + "<NarrationDescription>ScholarShip Allocation</NarrationDescription>"
               		                + "<BankName></BankName>"
               		                + "<BranchName></BranchName>"
               		                + "<PersonID>" + DataArray[i + 3] + "</PersonID>"
               		                + "<PersonType>S</PersonType>"
               		                + "<IsActive>1</IsActive>"
               	                    + "</row>";
            }
        }
        if (ScholarShipAllocationXml.length > 6) {
            SSAPendingRequest.XMLstring = ScholarShipAllocationXml + "</rows>";
        }
        else {
            SSAPendingRequest.XMLstring = "";
        }
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            $.magnificPopup.close();
            SSAPendingRequest.ReloadListAfterApproval(splitData[0], splitData[1], splitData[2]);
        } else {
            $.magnificPopup.close();
            SSAPendingRequest.ReloadListAfterApproval(splitData[0], splitData[1], splitData[2]);
        }
    },


};

