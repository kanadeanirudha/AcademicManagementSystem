//this class contain methods related to nationality functionality
var SalaryPayScaleMaster = {
    //Member variables
    ActionName: null,
    map: {},
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();
        SalaryPayScaleMaster.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $('#Designation').focus();

        $("#reset").click(function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");

            return false;
        });
        // Create new record
        $('#CreateSalaryPayScaleMasterRecord').on("click", function () {
            SalaryPayScaleMaster.ActionName = "Create";
            SalaryPayScaleMaster.AjaxCallSalaryPayScaleMaster();
        });
        $('#EditSalaryPayScaleMasterRecord').on("click", function () {
            debugger;
            SalaryPayScaleMaster.ActionName = "Edit";
            SalaryPayScaleMaster.AjaxCallSalaryPayScaleMaster();
        });
        $('#DeleteSalaryPayScaleMasterRecord').on("click", function () {
            debugger;
            SalaryPayScaleMaster.ActionName = "Delete";
            SalaryPayScaleMaster.AjaxCallSalaryPayScaleMaster();
        });

        //$('#PayScaleRange').on("keydown", function (e) {
        //    AMSValidation.AllowNumbersOnly(e);
        //});
        $('#RangeFrom').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#RangeUpto').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#PayBandIncrementPercent').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#PaybandPeriodSpan').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        InitAnimatedBorder();
        CloseAlert();
    },

    //LoadList method is used to load List page
    LoadList: function () {
        debugger;
        $.ajax(
         {
            
             
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/SalaryPayScaleMaster/List',
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
            data: { actionMode: actionMode },
            url: '/SalaryPayScaleMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallSalaryPayScaleMaster: function () {
        var SalaryPayScaleMasterData = null;
        if (SalaryPayScaleMaster.ActionName == "Create") {
            $("#FormCreateSalaryPayScaleMaster").validate();
            if ($("#FormCreateSalaryPayScaleMaster").valid()) {
                SalaryPayScaleMasterData = null;
                SalaryPayScaleMasterData = SalaryPayScaleMaster.GetSalaryPayScaleMaster();
                ajaxRequest.makeRequest("/SalaryPayScaleMaster/Create", "POST", SalaryPayScaleMasterData, SalaryPayScaleMaster.Success, "CreateSalaryPayScaleMasterRecord");
            }
        }
        else if (SalaryPayScaleMaster.ActionName == "Edit") {
            debugger;
            $("#FormEditSalaryPayScaleMaster").validate();
            if ($("#FormEditSalaryPayScaleMaster").valid()) {
                SalaryPayScaleMasterData = null;
                SalaryPayScaleMasterData = SalaryPayScaleMaster.GetSalaryPayScaleMaster();
                ajaxRequest.makeRequest("/SalaryPayScaleMaster/Edit", "POST", SalaryPayScaleMasterData, SalaryPayScaleMaster.Success);
            }
        }
        else if (SalaryPayScaleMaster.ActionName == "Delete") {
            debugger;
            SalaryPayScaleMasterData = null;
           // $("#FormCreateSalaryPayScaleMaster").validate();
            SalaryPayScaleMasterData = SalaryPayScaleMaster.GetSalaryPayScaleMaster();
            ajaxRequest.makeRequest("/SalaryPayScaleMaster/Delete", "POST", SalaryPayScaleMasterData, SalaryPayScaleMaster.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetSalaryPayScaleMaster: function () {
        var Data = {
        };

        if (SalaryPayScaleMaster.ActionName == "Create") {
            debugger;
            Data.ID = $('#ID').val();
            Data.DesignationID = $('#DesignationID').val();
            Data.PayScaleRange = $('#PayScaleRange').val();
            Data.RangeFrom = $('#RangeFrom').val();
            Data.RangeUpto = $('#RangeUpto').val();
            Data.PayBandIncrementPercent = $('#PayBandIncrementPercent').val();
            Data.PaybandPeriodSpan = $('#PaybandPeriodSpan').val();
            Data.PaybandPeriodUnit = $('#PaybandPeriodUnit').val();
            Data.SalaryPayRulesID = $('#SalaryPayRulesID').val();
        }
        else if (SalaryPayScaleMaster.ActionName == "Edit") {
            debugger;
            Data.ID = $('#ID').val();
            Data.DesignationID = $('#DesignationID').val();
            Data.PayScaleRange = $('#PayScaleRange').val();
            Data.RangeFrom = $('#RangeFrom').val();
            Data.RangeUpto = $('#RangeUpto').val();
            Data.PayBandIncrementPercent = $('#PayBandIncrementPercent').val();
            Data.PaybandPeriodSpan = $('#PaybandPeriodSpan').val();
            Data.PaybandPeriodUnit = $('#PaybandPeriodUnit').val();
            Data.SalaryPayRulesID = $('#SalaryPayRulesID').val();
        }
        else if (SalaryPayScaleMaster.ActionName == "Delete") {
            debugger;
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        debugger;
        var splitData = data.split(',');
       if (splitData[1] == 'success') 
        {
            $.magnificPopup.close()
            SalaryPayScaleMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            //$("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
            $.magnificPopup.close()
            SalaryPayScaleMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
    },
};

