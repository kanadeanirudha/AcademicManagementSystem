//this class contain methods related to nationality functionality
var CRMSaleJobUserJobScheduleUpdateStatus = {

    ActionName: null,
    VisitingCardName: null,

    //Class intialisation method
    Initialize: function () {
        CRMSaleJobUserJobScheduleUpdateStatus.constructor();
    },

    //Attach all event of page
    constructor: function () {

        $("#btnShowList").on("click", function () {
            debugger;
            CRMSaleJobUserJobScheduleUpdateStatus.LoadListByJobScheduleUpdateStatus($('#TransactionDate').val(), $('#MeetingStatus').val());
        });

        //Meeting With Done.
        $("#UpdateMeetingWithDoneRecord").on("click", function () {
            debugger;
            CRMSaleJobUserJobScheduleUpdateStatus.ActionName = "MeetingWithDone";
            //CRMSaleJobUserJobScheduleUpdateStatus.GetVisitingCard();
            //if (CRMSaleJobUserJobScheduleUpdateStatus.VisitingCardName != null && CRMSaleJobUserJobScheduleUpdateStatus.VisitingCardName != "") {
                if ($("#Interestlevel").val() > 0) {
                    if ($("#CallStatus").val() > 0) {
                        CRMSaleJobUserJobScheduleUpdateStatus.AjaxCallCRMSaleJobUserJobScheduleUpdateDone();
                    } else {
                        $("#displayErrorMessage").text("Please select call status.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                        $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                    }
                } else {
                    $("#displayErrorMessage").text("Please select interest level.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                }
            //} else {
            //    $("#displayErrorMessage").text("Please upload visiting card.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
            //    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
            //}
        });

        $("#UpdateMeetingWithReschedule").on("click", function () {
            debugger;
            CRMSaleJobUserJobScheduleUpdateStatus.ActionName = "MeetingWithReschedule";
            CRMSaleJobUserJobScheduleUpdateStatus.AjaxCallCRMSaleJobUserJobScheduleUpdateReschedule();
        });

        $("#UpdateMeetingWithCancel").on("click", function () {
            debugger;
            CRMSaleJobUserJobScheduleUpdateStatus.ActionName = "MeetingWithCancel";
            CRMSaleJobUserJobScheduleUpdateStatus.AjaxCallCRMSaleJobUserJobScheduleUpdateCancel();
        });

        $("#UpdateFollowUpWithDone").on("click", function () {
            debugger;
            if ($("#FollowUpType").val()!= "" ) {
                if ($("#Interestlevel").val() > 0) {
                    if ($("#CallStatus").val() > 0) {
                    CRMSaleJobUserJobScheduleUpdateStatus.ActionName = "FollowUpWithDone";
                    CRMSaleJobUserJobScheduleUpdateStatus.AjaxCallCRMSaleJobUserJobScheduleUpdateDone();
                    }
                    else {
                        $("#displayErrorMessage").text("Please select call status.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                        $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                    }
                }
                else {
                    $("#displayErrorMessage").text("Please select interest level.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                }
            } else {
                $("#displayErrorMessage").text("Please select follow-up type.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
            }
        });

        $("#UpdateFollowUpWithReschedule").on("click", function () {
            debugger;
            CRMSaleJobUserJobScheduleUpdateStatus.ActionName = "FollowUpWithReschedule";
            CRMSaleJobUserJobScheduleUpdateStatus.AjaxCallCRMSaleJobUserJobScheduleUpdateReschedule();
        });

        $("#UpdateFollowUpWithCancel").on("click", function () {
            debugger;
            CRMSaleJobUserJobScheduleUpdateStatus.ActionName = "FollowUpWithCancel";
            CRMSaleJobUserJobScheduleUpdateStatus.AjaxCallCRMSaleJobUserJobScheduleUpdateCancel();
        });

        $("#UpdateServeyWithDone").on("click", function () {
            debugger;
            CRMSaleJobUserJobScheduleUpdateStatus.ActionName = "ServeyWithDone";
            CRMSaleJobUserJobScheduleUpdateStatus.AjaxCallCRMSaleJobUserJobScheduleUpdateDone();
        });

        $("#UpdateServeyWithReschedule").on("click", function () {
            debugger;
            CRMSaleJobUserJobScheduleUpdateStatus.ActionName = "ServeyWithReschedule";
            CRMSaleJobUserJobScheduleUpdateStatus.AjaxCallCRMSaleJobUserJobScheduleUpdateReschedule();
        });

        $("#UpdateServeyWithCancel").on("click", function () {
            debugger;
            CRMSaleJobUserJobScheduleUpdateStatus.ActionName = "ServeyWithCancel";
            CRMSaleJobUserJobScheduleUpdateStatus.AjaxCallCRMSaleJobUserJobScheduleUpdateCancel();
        });

        $("#UpdateOtherWithDone").on("click", function () {
            debugger;
            CRMSaleJobUserJobScheduleUpdateStatus.ActionName = "OtherWithDone";
            CRMSaleJobUserJobScheduleUpdateStatus.AjaxCallCRMSaleJobUserJobScheduleUpdateDone();
        });

        $("#UpdateOtherWithReschedule").on("click", function () {
            debugger;
            CRMSaleJobUserJobScheduleUpdateStatus.ActionName = "OtherWithReschedule";
            CRMSaleJobUserJobScheduleUpdateStatus.AjaxCallCRMSaleJobUserJobScheduleUpdateReschedule();
        });

        $("#UpdateOtherWithCancel").on("click", function () {
            debugger;
            CRMSaleJobUserJobScheduleUpdateStatus.ActionName = "OtherWithCancel";
            CRMSaleJobUserJobScheduleUpdateStatus.AjaxCallCRMSaleJobUserJobScheduleUpdateCancel();
        });
                
        $("#UpdateCallWithDone").on("click", function () {
            debugger;
            CRMSaleJobUserJobScheduleUpdateStatus.ActionName = "CallWithDone";
            CRMSaleJobUserJobScheduleUpdateStatus.AjaxCallCRMSaleJobUserJobScheduleUpdateDone();
        });

        $("#UpdateCallWithReschedule").on("click", function () {
            debugger;
            CRMSaleJobUserJobScheduleUpdateStatus.ActionName = "CallWithReschedule";
            CRMSaleJobUserJobScheduleUpdateStatus.AjaxCallCRMSaleJobUserJobScheduleUpdateReschedule();
        });

        $("#UpdateCallWithCancel").on("click", function () {
            debugger;
            CRMSaleJobUserJobScheduleUpdateStatus.ActionName = "CallWithCancel";
            CRMSaleJobUserJobScheduleUpdateStatus.AjaxCallCRMSaleJobUserJobScheduleUpdateCancel();
        });
              

        $('#ToSubject').on("keydown", function (e) {
            AMSValidation.AllowAlphaNumericOnly(e);
        });

        $('#Remark').on("keydown", function (e) {
            AMSValidation.AllowAlphaNumericOnly(e);
        });

        InitAnimatedBorder();
        CloseAlert();
    },



    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/CRMSaleJobUserJobScheduleUpdateStatus/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        debugger;
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { TransactionDate: $("#TransactionDate").val(), MeetingStatus: $("#MeetingStatus").val(), actionMode: actionMode },
            url: '/CRMSaleJobUserJobScheduleUpdateStatus/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    LoadListByJobScheduleUpdateStatus: function (TransactionDate, MeetingStatus) {
        debugger;
        $.ajax({
            cache: false,
            type: "POST",
            data: { TransactionDate: TransactionDate, MeetingStatus: MeetingStatus },
            dataType: "html",
            url: '/CRMSaleJobUserJobScheduleUpdateStatus/List',
            success: function (result) {
                //Rebind Grid Data                
                $('#ListViewModel').html(result);
            }
        });
    },

    GetVisitingCard: function () {
        var imgValue = new FormData();
        var files = $("#VisitingCard").get(0).files;
        if (files.length > 0) {
            imgValue.append("MyImages", files[0]);
        }
        $.ajax({
            url: "/CRMSaleJobUserJobScheduleUpdateStatus/UploadFile",
            type: "POST",
            processData: false,
            contentType: false,
            data: imgValue,
            dataType: 'json',
            success: function (imgValue) {
                //code after success                       
                CRMSaleJobUserJobScheduleUpdateStatus.VisitingCardName = imgValue;
            },
            error: function (er) {
                alert(er);
            }
        });
    },

    //Fire ajax call to update meeting.
    AjaxCallCRMSaleJobUserJobScheduleUpdateDone: function () {
        debugger;
        var CRMSaleJobUserJobScheduleUpdateStatusData = null;
        if (CRMSaleJobUserJobScheduleUpdateStatus.ActionName == "MeetingWithDone") {
            $("#FormUpDateMeetingWithDone").validate();
            if ($("#FormUpDateMeetingWithDone").valid()) {
                CRMSaleJobUserJobScheduleUpdateStatusData = null;
                CRMSaleJobUserJobScheduleUpdateStatusData = CRMSaleJobUserJobScheduleUpdateStatus.GetCRMSaleJobUserJobScheduleUpdateStatus();
                ajaxRequest.makeRequest("/CRMSaleJobUserJobScheduleUpdateStatus/CompleteMeeting", "POST", CRMSaleJobUserJobScheduleUpdateStatusData, CRMSaleJobUserJobScheduleUpdateStatus.Success, "UpdateFeedBackCRMSaleJobUserJobScheduleUpdateStatusRecord");
            }
        }
        else if (CRMSaleJobUserJobScheduleUpdateStatus.ActionName == "FollowUpWithDone") {
            $("#FormUpdateFollowUpWithDone").validate();
            if ($("#FormUpdateFollowUpWithDone").valid()) {
                CRMSaleJobUserJobScheduleUpdateStatusData = null;
                CRMSaleJobUserJobScheduleUpdateStatusData = CRMSaleJobUserJobScheduleUpdateStatus.GetCRMSaleJobUserJobScheduleUpdateStatus();
                ajaxRequest.makeRequest("/CRMSaleJobUserJobScheduleUpdateStatus/CompleteMeeting", "POST", CRMSaleJobUserJobScheduleUpdateStatusData, CRMSaleJobUserJobScheduleUpdateStatus.Success, "UpdateMeetingCRMSaleJobUserJobScheduleUpdateStatusRecord");
            }
        }
        else if (CRMSaleJobUserJobScheduleUpdateStatus.ActionName == "ServeyWithDone") {
            $("#FormUpdateServeyWithDone").validate();
            if ($("#FormUpdateServeyWithDone").valid()) {
                CRMSaleJobUserJobScheduleUpdateStatusData = null;
                CRMSaleJobUserJobScheduleUpdateStatusData = CRMSaleJobUserJobScheduleUpdateStatus.GetCRMSaleJobUserJobScheduleUpdateStatus();
                ajaxRequest.makeRequest("/CRMSaleJobUserJobScheduleUpdateStatus/CompleteMeeting", "POST", CRMSaleJobUserJobScheduleUpdateStatusData, CRMSaleJobUserJobScheduleUpdateStatus.Success, "UpdateServeyCRMSaleJobUserJobScheduleUpdateStatusRecord");
            }
        }
        else if (CRMSaleJobUserJobScheduleUpdateStatus.ActionName == "OtherWithDone") {
            $("#FormUpdateOtherWithDone").validate();
            if ($("#FormUpdateOtherWithDone").valid()) {
                CRMSaleJobUserJobScheduleUpdateStatusData = null;
                CRMSaleJobUserJobScheduleUpdateStatusData = CRMSaleJobUserJobScheduleUpdateStatus.GetCRMSaleJobUserJobScheduleUpdateStatus();
                ajaxRequest.makeRequest("/CRMSaleJobUserJobScheduleUpdateStatus/CompleteMeeting", "POST", CRMSaleJobUserJobScheduleUpdateStatusData, CRMSaleJobUserJobScheduleUpdateStatus.Success, "UpdateServeyCRMSaleJobUserJobScheduleUpdateStatusRecord");
            }
        }
        else if (CRMSaleJobUserJobScheduleUpdateStatus.ActionName == "CallWithDone")
        {
            $("#FormUpdateCallWithDone").validate();
            if ($("#FormUpdateCallWithDone").valid()) {
                CRMSaleJobUserJobScheduleUpdateStatusData = null;
                CRMSaleJobUserJobScheduleUpdateStatusData = CRMSaleJobUserJobScheduleUpdateStatus.GetCRMSaleJobUserJobScheduleUpdateStatus();
                ajaxRequest.makeRequest("/CRMSaleJobUserJobScheduleUpdateStatus/CompleteMeeting", "POST", CRMSaleJobUserJobScheduleUpdateStatusData, CRMSaleJobUserJobScheduleUpdateStatus.Success, "UpdateCallCRMSaleJobUserJobScheduleUpdateStatusRecord");
            }
        }

    },

    //Fire ajax call to update Reschedule.
    AjaxCallCRMSaleJobUserJobScheduleUpdateReschedule: function () {
        debugger;
        var CRMSaleJobUserJobScheduleUpdateStatusData = null;
        if (CRMSaleJobUserJobScheduleUpdateStatus.ActionName == "MeetingWithReschedule") {
            $("#FormUpDateMeetingWithReschedule").validate();
            if ($("#FormUpDateMeetingWithReschedule").valid()) {
                CRMSaleJobUserJobScheduleUpdateStatusData = null;
                CRMSaleJobUserJobScheduleUpdateStatusData = CRMSaleJobUserJobScheduleUpdateStatus.GetCRMSaleJobUserJobScheduleUpdateStatus();
                ajaxRequest.makeRequest("/CRMSaleJobUserJobScheduleUpdateStatus/CompleteMeeting", "POST", CRMSaleJobUserJobScheduleUpdateStatusData, CRMSaleJobUserJobScheduleUpdateStatus.Success, "UpdateFeedBackCRMSaleJobUserJobScheduleUpdateStatusRecord");
            }
        }
        else if (CRMSaleJobUserJobScheduleUpdateStatus.ActionName == "FollowUpWithReschedule") {
            $("#FormUpDateFollowUpWithReschedule").validate();
            if ($("#FormUpDateFollowUpWithReschedule").valid()) {
                CRMSaleJobUserJobScheduleUpdateStatusData = null;
                CRMSaleJobUserJobScheduleUpdateStatusData = CRMSaleJobUserJobScheduleUpdateStatus.GetCRMSaleJobUserJobScheduleUpdateStatus();
                ajaxRequest.makeRequest("/CRMSaleJobUserJobScheduleUpdateStatus/CompleteMeeting", "POST", CRMSaleJobUserJobScheduleUpdateStatusData, CRMSaleJobUserJobScheduleUpdateStatus.Success, "UpdateMeetingCRMSaleJobUserJobScheduleUpdateStatusRecord");
            }
        }
        else if (CRMSaleJobUserJobScheduleUpdateStatus.ActionName == "ServeyWithReschedule") {
            $("#FormUpdateServeyWithReschedule").validate();
            if ($("#FormUpdateServeyWithReschedule").valid()) {
                CRMSaleJobUserJobScheduleUpdateStatusData = null;
                CRMSaleJobUserJobScheduleUpdateStatusData = CRMSaleJobUserJobScheduleUpdateStatus.GetCRMSaleJobUserJobScheduleUpdateStatus();
                ajaxRequest.makeRequest("/CRMSaleJobUserJobScheduleUpdateStatus/CompleteMeeting", "POST", CRMSaleJobUserJobScheduleUpdateStatusData, CRMSaleJobUserJobScheduleUpdateStatus.Success, "UpdateServeyCRMSaleJobUserJobScheduleUpdateStatusRecord");
            }
        }
        else if (CRMSaleJobUserJobScheduleUpdateStatus.ActionName == "OtherWithReschedule") {
            $("#FormUpdateOtherWithReschedule").validate();
            if ($("#FormUpdateOtherWithReschedule").valid()) {
                CRMSaleJobUserJobScheduleUpdateStatusData = null;
                CRMSaleJobUserJobScheduleUpdateStatusData = CRMSaleJobUserJobScheduleUpdateStatus.GetCRMSaleJobUserJobScheduleUpdateStatus();
                ajaxRequest.makeRequest("/CRMSaleJobUserJobScheduleUpdateStatus/CompleteMeeting", "POST", CRMSaleJobUserJobScheduleUpdateStatusData, CRMSaleJobUserJobScheduleUpdateStatus.Success, "UpdateServeyCRMSaleJobUserJobScheduleUpdateStatusRecord");
            }
        }
        else if (CRMSaleJobUserJobScheduleUpdateStatus.ActionName == "CallWithReschedule") {
            $("#FormUpdateOtherWithReschedule").validate();
            if ($("#FormUpdateOtherWithReschedule").valid()) {
                CRMSaleJobUserJobScheduleUpdateStatusData = null;
                CRMSaleJobUserJobScheduleUpdateStatusData = CRMSaleJobUserJobScheduleUpdateStatus.GetCRMSaleJobUserJobScheduleUpdateStatus();
                ajaxRequest.makeRequest("/CRMSaleJobUserJobScheduleUpdateStatus/CompleteMeeting", "POST", CRMSaleJobUserJobScheduleUpdateStatusData, CRMSaleJobUserJobScheduleUpdateStatus.Success, "UpdateServeyCRMSaleJobUserJobScheduleUpdateStatusRecord");
            }
        }
    },

    //Fire ajax call to update Cancel.
    AjaxCallCRMSaleJobUserJobScheduleUpdateCancel: function () {
        debugger;
        var CRMSaleJobUserJobScheduleUpdateStatusData = null;
        if (CRMSaleJobUserJobScheduleUpdateStatus.ActionName == "MeetingWithCancel") {
            $("#FormUpDateMeetingWithCancel").validate();
            if ($("#FormUpDateMeetingWithCancel").valid()) {
                CRMSaleJobUserJobScheduleUpdateStatusData = null;
                CRMSaleJobUserJobScheduleUpdateStatusData = CRMSaleJobUserJobScheduleUpdateStatus.GetCRMSaleJobUserJobScheduleUpdateStatus();
                ajaxRequest.makeRequest("/CRMSaleJobUserJobScheduleUpdateStatus/CompleteMeeting", "POST", CRMSaleJobUserJobScheduleUpdateStatusData, CRMSaleJobUserJobScheduleUpdateStatus.Success, "UpdateFeedBackCRMSaleJobUserJobScheduleUpdateStatusRecord");
            }
        }
        else if (CRMSaleJobUserJobScheduleUpdateStatus.ActionName == "FollowUpWithCancel") {
            $("#FormUpDateFollowUpWithCancel").validate();
            if ($("#FormUpDateFollowUpWithCancel").valid()) {
                CRMSaleJobUserJobScheduleUpdateStatusData = null;
                CRMSaleJobUserJobScheduleUpdateStatusData = CRMSaleJobUserJobScheduleUpdateStatus.GetCRMSaleJobUserJobScheduleUpdateStatus();
                ajaxRequest.makeRequest("/CRMSaleJobUserJobScheduleUpdateStatus/CompleteMeeting", "POST", CRMSaleJobUserJobScheduleUpdateStatusData, CRMSaleJobUserJobScheduleUpdateStatus.Success, "UpdateFollowUpWithCancel");
            }
        }
        else if (CRMSaleJobUserJobScheduleUpdateStatus.ActionName == "ServeyWithCancel") {
            $("#FormUpDateServeyWithCancel").validate();
            if ($("#FormUpDateServeyWithCancel").valid()) {
                CRMSaleJobUserJobScheduleUpdateStatusData = null;
                CRMSaleJobUserJobScheduleUpdateStatusData = CRMSaleJobUserJobScheduleUpdateStatus.GetCRMSaleJobUserJobScheduleUpdateStatus();
                ajaxRequest.makeRequest("/CRMSaleJobUserJobScheduleUpdateStatus/CompleteMeeting", "POST", CRMSaleJobUserJobScheduleUpdateStatusData, CRMSaleJobUserJobScheduleUpdateStatus.Success, "UpdateServeyCRMSaleJobUserJobScheduleUpdateStatusRecord");
            }
        }
        else if (CRMSaleJobUserJobScheduleUpdateStatus.ActionName == "OtherWithCancel") {
            $("#FormUpDateOtherWithCancel").validate();
            if ($("#FormUpDateOtherWithCancel").valid()) {
                CRMSaleJobUserJobScheduleUpdateStatusData = null;
                CRMSaleJobUserJobScheduleUpdateStatusData = CRMSaleJobUserJobScheduleUpdateStatus.GetCRMSaleJobUserJobScheduleUpdateStatus();
                ajaxRequest.makeRequest("/CRMSaleJobUserJobScheduleUpdateStatus/CompleteMeeting", "POST", CRMSaleJobUserJobScheduleUpdateStatusData, CRMSaleJobUserJobScheduleUpdateStatus.Success, "UpdateServeyCRMSaleJobUserJobScheduleUpdateStatusRecord");
            }
        }
        else if (CRMSaleJobUserJobScheduleUpdateStatus.ActionName == "CallWithCancel")
        {
            $("#FormUpDateCallWithCancel").validate();
            if ($("#FormUpDateCallWithCancel").valid()) {
                CRMSaleJobUserJobScheduleUpdateStatusData = null;
                CRMSaleJobUserJobScheduleUpdateStatusData = CRMSaleJobUserJobScheduleUpdateStatus.GetCRMSaleJobUserJobScheduleUpdateStatus();
                ajaxRequest.makeRequest("/CRMSaleJobUserJobScheduleUpdateStatus/CompleteMeeting", "POST", CRMSaleJobUserJobScheduleUpdateStatusData, CRMSaleJobUserJobScheduleUpdateStatus.Success, "UpdateServeyCRMSaleJobUserJobScheduleUpdateStatusRecord");
            }
        }

    },


    //Get properties data from the Create, Update and Delete page
    GetCRMSaleJobUserJobScheduleUpdateStatus: function () {
        debugger;
        var Data = {
        };

        Data.ID = $("#ID").val();
        Data.JobCreationAllocationID = $("#JobCreationAllocationID").val();
        Data.CallEnquiryMasterID = $("#CallEnquiryMasterID").val();
        Data.CRMSaleCallMasterID = $("#CRMSaleCallMasterID").val();
        Data.ScheduleType = $("#ScheduleType").val();
        Data.TransactionDate = $("#TransactionDate").val();

        if (CRMSaleJobUserJobScheduleUpdateStatus.ActionName == "MeetingWithDone") {

            Data.VisitingCardName = CRMSaleJobUserJobScheduleUpdateStatus.VisitingCardName;

            Data.SubScheduleType = $("#SubScheduleType").val();
            Data.CallerJobStatus = 1;
            Data.Interestlevel = $("#Interestlevel").val();
            Data.CallStatus = $("#CallStatus").val();
            Data.Remark = $("#Remark").val();
            Data.ScheduleStatus = 1;
        }

        if (CRMSaleJobUserJobScheduleUpdateStatus.ActionName == "MeetingWithReschedule") {
            Data.SubScheduleType = $("#SubScheduleType").val();
            Data.CallerJobStatus = 0;
            Data.Remark = $("#Remark").val();
            Data.ScheduleStatus = 4;
            Data.CallStatus = 0;
            Data.NextDate = $("#NextDate").val();
            Data.NextFromTime = $("#NextFromTime").val();
            Data.NextUpToTime = $("#NextUpToTime").val();
        }

        if (CRMSaleJobUserJobScheduleUpdateStatus.ActionName == "MeetingWithCancel") {
            Data.SubScheduleType = $("#SubScheduleType").val();
            Data.CallerJobStatus = 0;
            Data.Remark = $("#Remark").val();
            Data.ScheduleStatus = 2;
            Data.CallStatus = 0;
        }

        if (CRMSaleJobUserJobScheduleUpdateStatus.ActionName == "FollowUpWithDone") {
            Data.SubScheduleType = $("#SubScheduleType").val();
            Data.Remark = $("#Remark").val();
            Data.CallerJobStatus = 1;
            Data.ScheduleStatus = 1;
            Data.FollowUpType = $("#FollowUpType").val();
            Data.CallStatus = $("#CallStatus").val();
            if ($("#FollowUpType").val() == "Email") {
                Data.ToMail = $("#ToMail").val();
                Data.ToSubject = $("#ToSubject").val();
            }
            else if ($("#FollowUpType").val() == "Call") {
                Data.ToCall = $("#ToCall").val();
            }
            Data.Description = $("#Description").val();
        }

        if (CRMSaleJobUserJobScheduleUpdateStatus.ActionName == "FollowUpWithReschedule") {
            Data.SubScheduleType = $("#SubScheduleType").val();
            Data.CallerJobStatus = 0;
            Data.CallStatus = 0;
            Data.ScheduleStatus = 4;
            Data.NextDate = $("#NextDate").val();
            Data.Remark = $("#Remark").val();
            Data.NextFromTime = $("#NextFromTime").val();
            Data.NextUpToTime = $("#NextUpToTime").val();
        }

        if (CRMSaleJobUserJobScheduleUpdateStatus.ActionName == "FollowUpWithCancel") {
            Data.SubScheduleType = $("#SubScheduleType").val();
            Data.ScheduleStatus = 2;
            Data.CallerJobStatus = 0;
            Data.CallStatus = 0;
            Data.Remark = $("#Remark").val();
        }

        if (CRMSaleJobUserJobScheduleUpdateStatus.ActionName == "ServeyWithDone") {
            Data.ScheduleStatus = 1;
            Data.FromAddress = $("#FromAddress").val();
            Data.ToAddress = $("#ToAddress").val();
            Data.ServeyDate = $("#ServeyDate").val();
            Data.ServeyTime = $("#ServeyTime").val();
            Data.Remark = $("#Remark").val();
        }

        if (CRMSaleJobUserJobScheduleUpdateStatus.ActionName == "ServeyWithReschedule") {
            Data.ScheduleStatus = 4;
            Data.FromAddress = $("#FromAddress").val();
            Data.ToAddress = $("#ToAddress").val();
            Data.NextDate = $("#NextDate").val();
            Data.NextFromTime = $("#NextFromTime").val();
            Data.NextUpToTime = $("#NextUpToTime").val();
            Data.Remark = $("#Remark").val();
        }

        if (CRMSaleJobUserJobScheduleUpdateStatus.ActionName == "ServeyWithCancel") {
            Data.ScheduleStatus = 2;
            Data.Remark = $("#Remark").val();
        }

        if (CRMSaleJobUserJobScheduleUpdateStatus.ActionName == "OtherWithDone") {
            Data.ScheduleStatus = 1;
            Data.NextDate = $("#NextDate").val();
            Data.NextFromTime = $("#NextFromTime").val();
            Data.NextUpToTime = $("#NextUpToTime").val();
            Data.Remark = $("#Remark").val();
        }

        if (CRMSaleJobUserJobScheduleUpdateStatus.ActionName == "OtherWithReschedule") {
            Data.ScheduleStatus = 4;
            Data.NextDate = $("#NextDate").val();
            Data.NextFromTime = $("#NextFromTime").val();
            Data.NextUpToTime = $("#NextUpToTime").val();
            Data.Remark = $("#Remark").val();
        }

        if (CRMSaleJobUserJobScheduleUpdateStatus.ActionName == "OtherWithCancel") {
            Data.ScheduleStatus = 2;
            Data.Remark = $("#Remark").val();
        }

        if (CRMSaleJobUserJobScheduleUpdateStatus.ActionName == "CallWithDone")
        {
            Data.ScheduleStatus = 1;
            Data.NextDate = $("#NextDate").val();
            Data.NextFromTime = $("#NextFromTime").val();
            Data.NextUpToTime = $("#NextUpToTime").val();
            Data.Remark = $("#Remark").val();
        }

        if (CRMSaleJobUserJobScheduleUpdateStatus.ActionName == "CallWithReschedule") {
            Data.ScheduleStatus = 4;
            Data.NextDate = $("#NextDate").val();
            Data.NextFromTime = $("#NextFromTime").val();
            Data.NextUpToTime = $("#NextUpToTime").val();
            Data.Remark = $("#Remark").val();
        }

        if (CRMSaleJobUserJobScheduleUpdateStatus.ActionName == "CallWithCancel") {
            Data.ScheduleStatus = 2;
            Data.Remark = $("#Remark").val();
        }

        return Data;
    },


    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        debugger;
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            CRMSaleJobUserJobScheduleUpdateStatus.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

