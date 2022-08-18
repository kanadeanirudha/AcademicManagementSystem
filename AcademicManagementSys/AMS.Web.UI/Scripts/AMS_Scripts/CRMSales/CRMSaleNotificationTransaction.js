
var CRMSaleNotificationTransaction = {
    ActionName: null,
    EmployeeEmailXML: null,

    Initialize: function () {
        CRMSaleNotificationTransaction.constructor();
    },

    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            return false;
        });

        // Create new record
        $('#CreatePushNotificationRecord').on("click", function () {
            debugger;
            CRMSaleNotificationTransaction.ActionName = "PushNotification";
            if ($("#employee").val() != null) {
                CRMSaleNotificationTransaction.GetEmployeeEmailXML();
                if (CRMSaleNotificationTransaction.EmployeeEmailXML != "" && CRMSaleNotificationTransaction.EmployeeEmailXML != null) {
                    CRMSaleNotificationTransaction.AjaxCallCRMSaleNotificationTransaction();
                }
            }
            else {
                $("#displayErrorMessage").text("Please Select To User.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
            }
        });

        InitAnimatedBorder();

        CloseAlert();

    },

    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax({
            cache: false,
            type: "POST",
            dataType: "html",
            url: '/CRMSaleNotificationTransaction/List',
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);
            }
        });
    },

    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {

        $.ajax({
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode },
            url: '/CRMSaleNotificationTransaction/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    //Generate XML;
    GetEmployeeEmailXML: function () {
        debugger;
        var DataArray = "";        

        var selectedEmail = $("select[name=selEmployee]").val().toString();
        if ($("#employee").val() != null && $("#employee").val() != "") {           
            DataArray = selectedEmail.split(',');
        }
        
        var TotalRecord = selectedEmail.split(',').length;
        var EmployeeEmailXML = "<rows>";
        for (var i = 0; i < TotalRecord; i++) {
            debugger;
            //EmployeeEmailXML = EmployeeEmailXML + "<row><ID>0</ID><ToUserIDs>3</ToUserIDs><ToMailIDs>AA@test.com</ToMailIDs></row>";

            if (DataArray[i].split('~')[0] != "" && DataArray[i].split('~')[1] != "") {
                EmployeeEmailXML = EmployeeEmailXML + "<row><ID>0</ID><ToUserIDs>" + DataArray[i].split('~')[0] + "</ToUserIDs>" +
                                                         "<ToMailIDs>" + DataArray[i].split('~')[1] + "</ToMailIDs></row>";
            }
        }
        if (EmployeeEmailXML.length > 6) {
            CRMSaleNotificationTransaction.EmployeeEmailXML = EmployeeEmailXML + "</rows>";
        } else {
            CRMSaleNotificationTransaction.EmployeeEmailXML = "";
        }
    },


    //Fire ajax call to insert update and delete record
    AjaxCallCRMSaleNotificationTransaction: function () {

        var CRMSaleNotificationTransactionData = null;
        if (CRMSaleNotificationTransaction.ActionName == "PushNotification") {
            $("#FormCreatePushNotification").validate();
            if ($("#FormCreatePushNotification").valid()) {
                CRMSaleNotificationTransactionData = null;
                CRMSaleNotificationTransactionData = CRMSaleNotificationTransaction.GetCRMSaleNotificationTransaction();
                ajaxRequest.makeRequest("/CRMSaleNotificationTransaction/Push", "POST", CRMSaleNotificationTransactionData, CRMSaleNotificationTransaction.Success, "CreateCRMSaleTargetExceptionRecord");
            }
        }

    },

    //Get properties data from the Create, Update and Delete page
    GetCRMSaleNotificationTransaction: function () {
        debugger;
        var Data = {
        };
        if (CRMSaleNotificationTransaction.ActionName == "PushNotification") {

            Data.NotificationTypeMasterID = 1;    // Temparary purpose.
            Data.FromUserID = $('#FromUserID').val();
            Data.FromMailID = $('#FromMailID').val();
            Data.ToMailID = CRMSaleNotificationTransaction.EmployeeEmailXML;
            Data.SubjectDescription = $('#SubjectDescription').val();
            Data.BodyDescription = $('#BodyDescription').val();
        }

        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        debugger;
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            CRMSaleNotificationTransaction.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

}