//this class contain methods related to nationality functionality
var GeneralRequestApproval = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralRequestApproval.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#Approve').focus();

        // Create new record
        $('#CreateGeneralRequestApprovalRecord').on("click", function () {
            if ($('#Remark').val() != "" && $('#Remark').val() != null) {
                GeneralRequestApproval.ActionName = "Create";
                GeneralRequestApproval.AjaxCallRequestApproval();
            }
            else {
                $('#Remark').focus();
                $('#CompulsoryRemark').show();
            }
        });

        $('#EditRequestApprovalRecord').on("click", function () {
            GeneralRequestApproval.ActionName = "Edit";
            GeneralRequestApproval.AjaxCallRequestApproval();
        });

        $('#DeleteRequestApprovalRecord').on("click", function () {
            GeneralRequestApproval.ActionName = "Delete";
            GeneralRequestApproval.AjaxCallRequestApproval();
        });

        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });


        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });


    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/RequestApproval/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var TaskCode = $('input[name=TaskCode]').val();
        $.magnificPopup.close();
        notify(message, colorCode);
        $('#RequestsTab').click();
        //$.ajax(
        //{
        //    cache: false,
        //    type: "POST",
        //    dataType: "html",
        //    data: { "actionMode": actionMode, "TaskCode": TaskCode },
        //    url: '/Home/NotificationListV2',
        //    success: function (data) {
        //        //Rebind Grid Data
        //        $('#content').empty().html(data);
        //        notify(message, colorCode);
        //    }
        //});
    },


    //Fire ajax call to insert update and delete record
    AjaxCallRequestApproval: function () {
        var RequestApprovalData = null;
        if (GeneralRequestApproval.ActionName == "Create") {
            //$("#FormCreateRequestApproval").validate();
            //if ($("#FormCreateRequestApproval").valid()) {
            RequestApprovalData = null;
            RequestApprovalData = GeneralRequestApproval.GetRequestApproval();
            ajaxRequest.makeRequest("/Home/GeneralRequestApproval", "POST", RequestApprovalData, GeneralRequestApproval.Success);
            //}
        }
        else if (GeneralRequestApproval.ActionName == "Edit") {
            $("#FormEditRequestApproval").validate();
            if ($("#FormEditRequestApproval").valid()) {
                RequestApprovalData = null;
                RequestApprovalData = GeneralRequestApproval.GetRequestApproval();
                ajaxRequest.makeRequest("/Home/Edit", "POST", RequestApprovalData, GeneralRequestApproval.Success);
            }
        }
        else if (GeneralRequestApproval.ActionName == "Delete") {
            RequestApprovalData = null;
            //$("#FormCreateRequestApproval").validate();
            RequestApprovalData = GeneralRequestApproval.GetRequestApproval();
            ajaxRequest.makeRequest("/RequestApprovalV2/Delete", "POST", RequestApprovalData, GeneralRequestApproval.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetRequestApproval: function () {
        var Data = {
        };
        if (GeneralRequestApproval.ActionName == "Create") {
            Data.GeneralRequestTransactionID = $('input[name=GeneralRequestTransactionID]').val();
            Data.Remark = $("#Remark").val();
            Data.RequestCode = $('#_TaskCode').val();
            if ($('#Approve').is(':checked')) {
                Data.ApprovalStatus = 1;
            }
            else if ($('#Reject').is(':checked')) {
                Data.ApprovalStatus = 0;
            }


        }


        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        debugger;
        var splitData = data.split(',');
        if (data != null) {
            GeneralRequestApproval.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            GeneralRequestApproval.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
 
};

