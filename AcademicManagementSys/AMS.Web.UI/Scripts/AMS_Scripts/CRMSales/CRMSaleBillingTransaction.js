//this class contain methods related to nationality functionality
var CRMSaleBillingTransaction = {

    //Member variables
    ActionName: null,

    //Class intialisation method
    Initialize: function () {
        CRMSaleBillingTransaction.constructor();
    },

    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            return false;
        });

        $("#btnShowList").on("click", function () {
            debugger;
            var valuCRMSaleEnquiryAccountMasterID = $("#CRMSaleEnquiryAccountMasterID").val();
            //if (valuCRMSaleEnquiryAccountMasterID != "" && valuCRMSaleEnquiryAccountMasterID > 0) {
                CRMSaleBillingTransaction.LoadListByAccountID(valuCRMSaleEnquiryAccountMasterID);
            //}
            //else if (valuCRMSaleEnquiryAccountMasterID == "") {
            //    notify("Please select account", 'warning');
            //}
        });

        $("#InvoiceNumber").on("keydown", function (e) {
            AMSValidation.AllowAlphaNumericOnly(e);
        });

        $('#InvoiceAmount').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
        });

        // Create new record
        $('#CreateCRMSaleBillingTransactionRecord').on("click", function () {
            debugger;
            CRMSaleBillingTransaction.ActionName = "Create";
            if ($("#InvoiceAmount").val() != "" && $("#CurrencyCode").val() == "") {
                $("#displayErrorMessage").text("Please select currency code.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            CRMSaleBillingTransaction.AjaxCallCRMSaleBillingTransaction();
        });

        $('#UpdateCRMSaleBillingTransactionRecord').on("click", function () {
            debugger;
            CRMSaleBillingTransaction.ActionName = "Edit";
            if ($("#InvoiceAmount").val() != "" && $("#CurrencyCode").val() == "") {
                $("#displayErrorMessage").text("Please select currency code.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            CRMSaleBillingTransaction.AjaxCallCRMSaleBillingTransaction();
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
             url: '/CRMSaleBillingTransaction/List',
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
            data: { actionMode: null, cRMSaleEnquiryAccountMasterID: $("#CRMSaleEnquiryAccountMasterID").val() },
            url: '/CRMSaleBillingTransaction/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    LoadListByAccountID: function (CRMSaleEnquiryAccountMasterID) {

        $.ajax({
            cache: false,
            type: "POST",
            data: { actionMode: null, cRMSaleEnquiryAccountMasterID: CRMSaleEnquiryAccountMasterID },
            dataType: "html",
            url: '/CRMSaleBillingTransaction/List',
            success: function (result) {
                //Rebind Grid Data                
                $('#ListViewModel').html(result);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallCRMSaleBillingTransaction: function () {
        var CRMSaleBillingTransactionData = null;
        if (CRMSaleBillingTransaction.ActionName == "Create") {
            $("#FormCreateCRMSaleBillingTransaction").validate();
            if ($("#FormCreateCRMSaleBillingTransaction").valid()) {
                CRMSaleBillingTransactionData = null;
                CRMSaleBillingTransactionData = CRMSaleBillingTransaction.GetCRMSaleBillingTransaction();
                ajaxRequest.makeRequest("/CRMSaleBillingTransaction/Create", "POST", CRMSaleBillingTransactionData, CRMSaleBillingTransaction.Success, "CreateCRMSaleBillingTransactionRecord");
            }


        } else if (CRMSaleBillingTransaction.ActionName == "Edit") {
            $("#FormEditCRMSaleBillingTransaction").validate();
            if ($("#FormEditCRMSaleBillingTransaction").valid()) {
                CRMSaleBillingTransactionData = null;
                CRMSaleBillingTransactionData = CRMSaleBillingTransaction.GetCRMSaleBillingTransaction();
                ajaxRequest.makeRequest("/CRMSaleBillingTransaction/Edit", "POST", CRMSaleBillingTransactionData, CRMSaleBillingTransaction.Success, "CreateCRMSaleBillingTransactionRecord");
            }


        }
        else if (CRMSaleBillingTransaction.ActionName == "Delete") {
            CRMSaleBillingTransactionData = null;
            CRMSaleBillingTransactionData = CRMSaleBillingTransaction.GetCRMSaleBillingTransaction();
            ajaxRequest.makeRequest("/CRMSaleBillingTransaction/Delete", "POST", CRMSaleBillingTransactionData, CRMSaleBillingTransaction.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCRMSaleBillingTransaction: function () {
        debugger;
        var Data = {
        };
        if (CRMSaleBillingTransaction.ActionName == "Create") {

            Data.CRMSaleEnquiryAccountMasterID = $("#CRMSaleEnquiryAccountMasterID").val();
            Data.CallEnquiryMasterID = $('#CallEnquiryMasterID').val();
            Data.InvoiceDate = $('#InvoiceDate').val();
            Data.InvoiceNumber = $('#InvoiceNumber').val();
            Data.InvoiceAmount = $("#InvoiceAmount").val();
            Data.CurrencyCode = $("#CurrencyCode").val();
        }
        else if (CRMSaleBillingTransaction.ActionName == "Edit") {

            Data.ID = $("#BillTransactionID").val();
            Data.CRMSaleEnquiryAccountMasterID = $("#CRMSaleEnquiryAccountMasterID").val();
            Data.CallEnquiryMasterID = $('#CallEnquiryMasterID').val();
            Data.InvoiceDate = $('#InvoiceDate').val();
            Data.InvoiceNumber = $('#InvoiceNumber').val();
            Data.InvoiceAmount = $("#InvoiceAmount").val();
            Data.CurrencyCode = $("#CurrencyCode").val();
        }
        else if (CRMSaleBillingTransaction.ActionName == "Delete") {
            Data.CRMSaleTargetGroupWiseID = $('input[name=CRMSaleTargetGroupWiseID]').val();

        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        debugger;
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            CRMSaleBillingTransaction.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};
