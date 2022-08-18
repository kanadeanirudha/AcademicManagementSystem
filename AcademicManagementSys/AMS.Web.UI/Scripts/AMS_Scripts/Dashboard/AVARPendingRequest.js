//this class contain methods related to nationality functionality
var AVARPendingRequest = {
    //Member variables
    ActionName: null,
    XMLstring: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        AVARPendingRequest.constructor();
        //AVARPendingRequest.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        // Create new record


        $('#ApproveAccountVoucher').on("click", function () {
            AVARPendingRequest.ActionName = "Approved";
            AVARPendingRequest.GetXmlData();
            AVARPendingRequest.AjaxCallAVARPendingRequest();
        });

        $('#RejectAccountVoucher').on("click", function () {
            AVARPendingRequest.ActionName = "Rejected";
            AVARPendingRequest.GetXmlData();
            AVARPendingRequest.AjaxCallAVARPendingRequest();
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

        $(".ajax").colorbox();

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
    ReloadList: function (meAVARge, colorCode, actionMode) {

        $("#AVAR").click();
        $('#SuccessMessage').html(meAVARge);
        $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
    },

    ReloadListAfterApproval: function (meAVARge, colorCode, actionMode) {
        $("#AVAR").click();
        $('#SuccessMessage').html(meAVARge);
        $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
    },


    //Fire ajax call to insert update and delete record
    AjaxCallAVARPendingRequest: function () {
        var AVARPendingRequestData = null;
        if (AVARPendingRequest.ActionName == "Approved" || AVARPendingRequest.ActionName == "Rejected") {
            AVARPendingRequestData = null;
            AVARPendingRequestData = AVARPendingRequest.GetAVARPendingRequest();
            ajaxRequest.makeRequest("/AccountTransactionMaster/AccountVoucherRequestApproval", "POST", AVARPendingRequestData, AVARPendingRequest.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetAVARPendingRequest: function () {
        var Data = {
        };
        if (AVARPendingRequest.ActionName == "Approved" || AVARPendingRequest.ActionName == "Rejected") {

            Data.XMLstring = AVARPendingRequest.XMLstring
            Data.AccSessionID = $('input[name=AccSessionID]').val();
            Data.TransactionMainID = $('input[name=TransactionMainID]').val();
            Data.AccBalsheetMstID = $('input[name=AccBalsheetMstID]').val();
            Data.TransactionType = $('input[name=TransactionType]').val();
            Data.NarrationDescription = $('input[name=NarrationDescription]').val();
            Data.TransactionDate = $('input[name=TransactionDate]').val();
            Data.IsLastRecord = $('input[name=IsLastRecord]').val();
            Data.PersonID = $('input[name=PersonID]').val();
            Data.StageSequenceNumber = $('input[name=StageSequenceNumber]').val();
            Data.TaskNotificationMasterID = $('input[name=TaskNotificationMasterID]').val();
            Data.TaskNotificationDetailsID = $('input[name=TaskNotificationDetailsID]').val();
            Data.GeneralTaskReportingDetailsID = $('input[name=GeneralTaskReportingDetailsID]').val();
            Data.VoucherAmount = $('#tblVoucherDetails tbody tr:last').find('td').eq(1).find('b span').text();
            if (AVARPendingRequest.ActionName == "Approved") {
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
        $('#tblVoucherDetails tbody tr td input[type="text"]').each(function () {
            DataArray.push($(this).val());
        });
        var TotalRecord = DataArray.length;
        var AccountTransactionMasterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 11) {
            if (DataArray[i] > 0) {
                AccountTransactionMasterXml = AccountTransactionMasterXml
                                    + "<row>"
               		                + "<TransactionSubID>" + DataArray[i] + "</TransactionSubID>"
               		                + "<AccountID>" + DataArray[i + 1] + "</AccountID>"
               		                + "<DebitCreditFlag>" + DataArray[i + 2] + "</DebitCreditFlag>"
               		                + "<TransactionAmount>" + DataArray[i + 3] + "</TransactionAmount>"
               		                + "<ChequeNo>" + DataArray[i + 4] + "</ChequeNo>"
               		                + "<ChequeDatetime>" + DataArray[i + 5] + "</ChequeDatetime>"
               		                + "<NarrationDescription>" + DataArray[i + 6] + "</NarrationDescription>"
               		                + "<BankName>" + DataArray[i + 7] + "</BankName>"
               		                + "<BranchName>" + DataArray[i + 8] + "</BranchName>"
               		                + "<PersonID>" + DataArray[i + 9] + "</PersonID>"
               		                + "<PersonType>" + DataArray[i + 10] + "</PersonType>"
               		                + "<IsActive>1</IsActive>"
               	                    + "</row>";
            }
        }
        if (AccountTransactionMasterXml.length > 6) {
            AVARPendingRequest.XMLstring = AccountTransactionMasterXml + "</rows>";
        }
        else {
            AVARPendingRequest.XMLstring = "";
        }
    },

    //this is used to for showing successfully record creation meAVARge and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            parent.$.colorbox.close();
            AVARPendingRequest.ReloadListAfterApproval(splitData[0], splitData[1], splitData[2]);
        } else {
            parent.$.colorbox.close();
            AVARPendingRequest.ReloadListAfterApproval(splitData[0], splitData[1], splitData[2]);
        }
    },


};

