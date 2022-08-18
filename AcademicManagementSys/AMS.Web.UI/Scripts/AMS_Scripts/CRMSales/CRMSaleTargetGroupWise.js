//this class contain methods related to nationality functionality
var CRMSaleTargetGroupWise = {
    //Member variables
    ActionName: null,

    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CRMSaleTargetGroupWise.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            return false;
        });


        // Create new record
        $('#CreateCRMSaleTargetGroupWiseRecord').on("click", function () {
            CRMSaleTargetGroupWise.ActionName = "Create";
            CRMSaleTargetGroupWise.AjaxCallCRMSaleTargetGroupWise();
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
             url: '/CRMSaleTargetGroupWise/List',
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
            url: '/CRMSaleTargetGroupWise/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallCRMSaleTargetGroupWise: function () {
        var CRMSaleTargetGroupWiseData = null;
        if (CRMSaleTargetGroupWise.ActionName == "Create") {
            $("#FormCreateCRMSaleTargetGroupWise").validate();
            if ($("#FormCreateCRMSaleTargetGroupWise").valid()) {
                CRMSaleTargetGroupWiseData = null;
                CRMSaleTargetGroupWiseData = CRMSaleTargetGroupWise.GetCRMSaleTargetGroupWise();
                ajaxRequest.makeRequest("/CRMSaleTargetGroupWise/Create", "POST", CRMSaleTargetGroupWiseData, CRMSaleTargetGroupWise.Success, "CreateCRMSaleTargetGroupWiseRecord");
            }


        }
        else if (CRMSaleTargetGroupWise.ActionName == "Edit") {
            $("#FormEditCRMSaleTargetGroupWise").validate();
            if ($("#FormEditCRMSaleTargetGroupWise").valid()) {
                CRMSaleTargetGroupWiseData = null;

                CRMSaleTargetGroupWiseData = CRMSaleTargetGroupWise.GetCRMSaleTargetGroupWise();

                ajaxRequest.makeRequest("/CRMSaleTargetGroupWise/Edit", "POST", CRMSaleTargetGroupWiseData, CRMSaleTargetGroupWise.Success);

            }
        }
        else if (CRMSaleTargetGroupWise.ActionName == "Delete") {
            CRMSaleTargetGroupWiseData = null;
            //$("#FormCreateCRMSaleTargetGroupWise").validate();
            CRMSaleTargetGroupWiseData = CRMSaleTargetGroupWise.GetCRMSaleTargetGroupWise();
            ajaxRequest.makeRequest("/CRMSaleTargetGroupWise/Delete", "POST", CRMSaleTargetGroupWiseData, CRMSaleTargetGroupWise.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCRMSaleTargetGroupWise: function () {

        var Data = {
        };
        if (CRMSaleTargetGroupWise.ActionName == "Create" || CRMSaleTargetGroupWise.ActionName == "Edit") {

            Data.CRMSaleGroupMasterID = $('input[name=CRMSaleGroupMasterID]').val();
            Data.CRMSaleTargetTypeId = $('#CRMSaleTargetTypeId').val();
            Data.TargetValue = $('#TargetValue').val();
            Data.FromDate = $('#FromDate').val();
            Data.GeneralPeriodTypeMasterID = $("#GeneralPeriodTypeMasterID").val();
        }
        else if (CRMSaleTargetGroupWise.ActionName == "Delete") {
            Data.CRMSaleTargetGroupWiseID = $('input[name=CRMSaleTargetGroupWiseID]').val();

        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            CRMSaleTargetGroupWise.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

