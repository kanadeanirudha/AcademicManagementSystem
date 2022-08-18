//this class contain methods related to nationality functionality
var SalaryEmployeePayFixationMaster = {
    //Member variables
    ActionName: null,

    Initialize: function () {
        //organisationStudyCentre.loadData();
        SalaryEmployeePayFixationMaster.constructor();
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
        $('#CreateSalaryEmployeePayFixationMasterRecord').on("click", function () {
            debugger;
            SalaryEmployeePayFixationMaster.ActionName = "Create";
            SalaryEmployeePayFixationMaster.AjaxCallSalaryEmployeePayFixationMaster();
        });
        $('#EditSalaryEmployeePayFixationMasterRecord').on("click", function () {
            debugger;
            SalaryEmployeePayFixationMaster.ActionName = "Edit";
            SalaryEmployeePayFixationMaster.AjaxCallSalaryEmployeePayFixationMaster();
        });
        $('#DeleteSalaryEmployeePayFixationMasterRecord').on("click", function () {
            debugger;
            SalaryEmployeePayFixationMaster.ActionName = "Delete";
            SalaryEmployeePayFixationMaster.AjaxCallSalaryEmployeePayFixationMaster();
        });


        $('#DeductionType').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#DeductionHeadName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $("#OrderDate").datetimepicker({
            format: 'DD MMMM YYYY',
            maxDate: moment(),
        });
        $("#EffectiveFrom").datetimepicker({
            format: 'DD MMMM YYYY',
            maxDate: moment(),
        });
        $("#IsNeedGenerateArriers").on("click", function () {
            var IsNeedGenerateArriers = $('#IsNeedGenerateArriers').is(":checked") ? "true" : "false";
            if (IsNeedGenerateArriers == 'true') {
                $("#ArriersGenerationStatus").show(true);
            }
            else {
                $("#ArriersGenerationStatus").hide(true);
            }
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
             url: '/SalaryEmployeePayFixationMaster/List',
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
            url: '/SalaryEmployeePayFixationMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallSalaryEmployeePayFixationMaster: function () {
        debugger;
        var SalaryEmployeePayFixationMasterData = null;
        if (SalaryEmployeePayFixationMaster.ActionName == "Create") {
            $("#FormCreateSalaryEmployeePayFixationMaster").validate();
            if ($("#FormCreateSalaryEmployeePayFixationMaster").valid()) {
                SalaryEmployeePayFixationMasterData = null;
                SalaryEmployeePayFixationMasterData = SalaryEmployeePayFixationMaster.GetSalaryEmployeePayFixationMaster();
                ajaxRequest.makeRequest("/SalaryEmployeePayFixationMaster/Create", "POST", SalaryEmployeePayFixationMasterData, SalaryEmployeePayFixationMaster.Success, "CreateSalaryEmployeePayFixationMasterRecord");
            }
        }
        else if (SalaryEmployeePayFixationMaster.ActionName == "Edit") {
            debugger;
            $("#FormEditSalaryEmployeePayFixationMaster").validate();
            if ($("#FormEditSalaryEmployeePayFixationMaster").valid()) {
                SalaryEmployeePayFixationMasterData = null;
                SalaryEmployeePayFixationMasterData = SalaryEmployeePayFixationMaster.GetSalaryEmployeePayFixationMaster();
                ajaxRequest.makeRequest("/SalaryEmployeePayFixationMaster/Edit", "POST", SalaryEmployeePayFixationMasterData, SalaryEmployeePayFixationMaster.Success);
            }
        }
        else if (SalaryEmployeePayFixationMaster.ActionName == "Delete") {
            debugger;
            SalaryEmployeePayFixationMasterData = null;
            // $("#FormCreateSalaryEmployeePayFixationMaster").validate();
            SalaryEmployeePayFixationMasterData = SalaryEmployeePayFixationMaster.GetSalaryEmployeePayFixationMaster();
            ajaxRequest.makeRequest("/SalaryEmployeePayFixationMaster/Delete", "POST", SalaryEmployeePayFixationMasterData, SalaryEmployeePayFixationMaster.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetSalaryEmployeePayFixationMaster: function () {
        var Data = {
        };

        if (SalaryEmployeePayFixationMaster.ActionName == "Create") {
            debugger;
            Data.ID = $('#ID').val();
            Data.EmployeeID = $('#EmployeeID').val();
            Data.Basic = $('#Basic').val();
            Data.GradePay = $('#SalaryGradePayMasterID option:selected').text();
            Data.SalaryGradePayMasterID = $('#SalaryGradePayMasterID').val();
            Data.SalaryPayScaleMasterID = $('#SalaryPayScaleMasterID').val();
            Data.PayIncrementCount = $('#PayIncrementCount').val();
            Data.BandPay = $('#BandPay').val();
            Data.ApprovedStatus = $('#ApprovedStatus').val();
            Data.ApprovedBy = $('#ApprovedBy').val();
            Data.OrderDate = $('#OrderDate').val();
            Data.OrderNumber = $('#OrderNumber').val();
            Data.EffectiveFrom = $('#EffectiveFrom').val();
            Data.IsCurrent = $('#IsCurrent').is(":checked") ? "true" : "false";
            Data.IsNeedGenerateArriers = $('#IsNeedGenerateArriers').is(":checked") ? "true" : "false";
            Data.ArriersGenerationStatus = $('#ArriersGenerationStatus').val();
        }
        else if (SalaryEmployeePayFixationMaster.ActionName == "Edit") {
            debugger;
            Data.ID = $('#ID').val();
            Data.EmployeeID = $('#EmployeeID').val();
            Data.Basic = $('#Basic').val();
            Data.SalaryPayScaleMasterID = $('#SalaryPayScaleMasterID').val();
            Data.SalaryGradePayMasterID = $('#SalaryGradePayMasterID').val();
            Data.ArriersGenerationStatus = $('#ArriersGenerationStatus').val();
        }
        else if (SalaryEmployeePayFixationMaster.ActionName == "Delete") {
            debugger;
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        debugger;
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            SalaryEmployeePayFixationMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            //$("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
            $.magnificPopup.close()
            SalaryEmployeePayFixationMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
    },
};

