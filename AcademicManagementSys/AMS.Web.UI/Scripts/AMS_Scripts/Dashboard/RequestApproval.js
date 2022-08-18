//this class contain methods related to nationality functionality
var RequestApproval = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        RequestApproval.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#Approve').focus();

        // Create new record
        $('#CreateRequestApprovalRecord').on("click", function () {
            if ($('#Remark').val() != "" && $('#Remark').val() != null) {
                RequestApproval.ActionName = "Create";
                RequestApproval.AjaxCallRequestApproval();

            }
            else {
                alert("Please enter remark.");
            }
        });

        $('#EditRequestApprovalRecord').on("click", function () {

            RequestApproval.ActionName = "Edit";
            RequestApproval.AjaxCallRequestApproval();
        });

        $('#DeleteRequestApprovalRecord').on("click", function () {

            RequestApproval.ActionName = "Delete";
            RequestApproval.AjaxCallRequestApproval();
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

        $(".ajax").colorbox();


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
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', '#9FEA7A');
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallRequestApproval: function () {
        var RequestApprovalData = null;
        if (RequestApproval.ActionName == "Create") {
            //$("#FormCreateRequestApproval").validate();
            //if ($("#FormCreateRequestApproval").valid()) {
            RequestApprovalData = null;
            RequestApprovalData = RequestApproval.GetRequestApproval();
            ajaxRequest.makeRequest("/Home/RequestApproval", "POST", RequestApprovalData, RequestApproval.Success);
            //}
        }
        else if (RequestApproval.ActionName == "Edit") {
            $("#FormEditRequestApproval").validate();
            if ($("#FormEditRequestApproval").valid()) {
                RequestApprovalData = null;
                RequestApprovalData = RequestApproval.GetRequestApproval();
                ajaxRequest.makeRequest("/Home/Edit", "POST", RequestApprovalData, RequestApproval.Success);
            }
        }
        else if (RequestApproval.ActionName == "Delete") {
            RequestApprovalData = null;
            //$("#FormCreateRequestApproval").validate();
            RequestApprovalData = RequestApproval.GetRequestApproval();
            ajaxRequest.makeRequest("/RequestApproval/Delete", "POST", RequestApprovalData, RequestApproval.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetRequestApproval: function () {
        var Data = {
        };
        if (RequestApproval.ActionName == "Create") {
            debugger;
            Data.PersonID = $('input[name=PersonID]').val();
            Data.IsLastRecord = $('input[name=IsLastRecord]').val();
            Data.TaskNotificationMasterID = $('input[name=TaskNotificationMasterID]').val();
            Data.TaskNotificationDetailsID = $('input[name=TaskNotificationDetailsID]').val();
            Data.StageSequenceNumber = $('input[name=StageSequenceNumber]').val();
            Data.Remark = $("#Remark").val();
            Data.TaskCode = $('#_TaskCode').val();
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
            parent.$.colorbox.close();
            RequestApproval.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            parent.$.colorbox.close();
            RequestApproval.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {



    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        RequestApproval.ReloadList("Record Updated Sucessfully.", actionMode);
    //        //  alert("Record Created Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Updated Sucessfully. Please Try Again..");
    //    }

    //},
    ////this is used to for showing successfully record deletion message and reload the list view
    //deleteSuccess: function (data) {


    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        RequestApproval.ReloadList("Record Deleted Sucessfully.");
    //      //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //       // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

