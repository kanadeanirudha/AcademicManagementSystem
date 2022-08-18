//this class contain methods related to nationality functionality
var CRMSaleAccountProgressTypeRule = {
    //Member variables
    ActionName: null,

    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CRMSaleAccountProgressTypeRule.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            return false;
        });


        // Create new record
        $('#CreateCRMSaleAccountProgressTypeRuleRecord').on("click", function () {
            CRMSaleAccountProgressTypeRule.ActionName = "Create";
            CRMSaleAccountProgressTypeRule.AjaxCallCRMSaleAccountProgressTypeRule();
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
             url: '/CRMSaleAccountProgressTypeRule/List',
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
            data: { actionMode: actionMode },
            url: '/CRMSaleAccountProgressTypeRule/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallCRMSaleAccountProgressTypeRule: function () {
        var CRMSaleAccountProgressTypeRuleData = null;
        if (CRMSaleAccountProgressTypeRule.ActionName == "Create") {
            $("#FormCreateCRMSaleAccountProgressTypeRule").validate();
            if ($("#FormCreateCRMSaleAccountProgressTypeRule").valid()) {
                CRMSaleAccountProgressTypeRuleData = null;
                CRMSaleAccountProgressTypeRuleData = CRMSaleAccountProgressTypeRule.GetCRMSaleAccountProgressTypeRule();
                ajaxRequest.makeRequest("/CRMSaleAccountProgressTypeRule/Create", "POST", CRMSaleAccountProgressTypeRuleData, CRMSaleAccountProgressTypeRule.Success, "CreateCRMSaleAccountProgressTypeRuleRecord");
            }


        }
        else if (CRMSaleAccountProgressTypeRule.ActionName == "Edit") {
            $("#FormEditCRMSaleAccountProgressTypeRule").validate();
            if ($("#FormEditCRMSaleAccountProgressTypeRule").valid()) {
                CRMSaleAccountProgressTypeRuleData = null;

                CRMSaleAccountProgressTypeRuleData = CRMSaleAccountProgressTypeRule.GetCRMSaleAccountProgressTypeRule();

                ajaxRequest.makeRequest("/CRMSaleAccountProgressTypeRule/Edit", "POST", CRMSaleAccountProgressTypeRuleData, CRMSaleAccountProgressTypeRule.Success);

            }
        }
        else if (CRMSaleAccountProgressTypeRule.ActionName == "Delete") {
            CRMSaleAccountProgressTypeRuleData = null;
            //$("#FormCreateCRMSaleAccountProgressTypeRule").validate();
            CRMSaleAccountProgressTypeRuleData = CRMSaleAccountProgressTypeRule.GetCRMSaleAccountProgressTypeRule();
            ajaxRequest.makeRequest("/CRMSaleAccountProgressTypeRule/Delete", "POST", CRMSaleAccountProgressTypeRuleData, CRMSaleAccountProgressTypeRule.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCRMSaleAccountProgressTypeRule: function () {

        var Data = {
        };
        if (CRMSaleAccountProgressTypeRule.ActionName == "Create" || CRMSaleAccountProgressTypeRule.ActionName == "Edit") {

            Data.CRMSaleAccountProgressTypeID = $('input[name=CRMSaleAccountProgressTypeID]').val();
            Data.Operator = $('#Operator :selected').val();
            Data.Days = $('#Days').val();
            Data.FromDate = $('#FromDate').val();
        }
        else if (CRMSaleAccountProgressTypeRule.ActionName == "Delete") {
            Data.CRMSaleAccountProgressTypeRuleID = $('input[name=CRMSaleAccountProgressTypeRuleID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            CRMSaleAccountProgressTypeRule.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

