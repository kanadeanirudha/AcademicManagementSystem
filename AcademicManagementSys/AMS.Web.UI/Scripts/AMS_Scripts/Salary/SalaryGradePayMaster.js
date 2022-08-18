//this class contain methods related to nationality functionality
var SalaryGradePayMaster = {
    //Member variables
    ActionName: null,
   
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();
        SalaryGradePayMaster.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            return false;
        });
        // Create new record
        $('#CreateSalaryGradePayMasterRecord').on("click", function () {
            debugger;
            SalaryGradePayMaster.ActionName = "Create";
            SalaryGradePayMaster.AjaxCallSalaryGradePayMaster();
        });
        $('#EditSalaryGradePayMasterRecord').on("click", function () {
            SalaryGradePayMaster.ActionName = "Edit";
            SalaryGradePayMaster.AjaxCallSalaryGradePayMaster();
        });
        $('#DeleteSalaryGradePayMasterRecord').on("click", function () {
            SalaryGradePayMaster.ActionName = "Delete";
            SalaryGradePayMaster.AjaxCallSalaryGradePayMaster();
        });


        $('#GradePayAmount').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
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
             url: '/SalaryGradePayMaster/List',
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
            url: '/SalaryGradePayMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallSalaryGradePayMaster: function () {
        debugger;
        var SalaryGradePayMasterData = null;
        if (SalaryGradePayMaster.ActionName == "Create") {
            $("#FormCreateSalaryGradePayMaster").validate();
            if ($("#FormCreateSalaryGradePayMaster").valid()) {
                SalaryGradePayMasterData = null;
                SalaryGradePayMasterData = SalaryGradePayMaster.GetSalaryGradePayMaster();
                ajaxRequest.makeRequest("/SalaryGradePayMaster/Create", "POST", SalaryGradePayMasterData, SalaryGradePayMaster.Success, "CreateSalaryGradePayMasterRecord");
            }
        }
        else if (SalaryGradePayMaster.ActionName == "Edit") {
            $("#FormEditSalaryGradePayMaster").validate();
            if ($("#FormEditSalaryGradePayMaster").valid()) {
                SalaryGradePayMasterData = null;
                SalaryGradePayMasterData = SalaryGradePayMaster.GetSalaryGradePayMaster();
                ajaxRequest.makeRequest("/SalaryGradePayMaster/Edit", "POST", SalaryGradePayMasterData, SalaryGradePayMaster.Success);
            }
        }
        else if (SalaryGradePayMaster.ActionName == "Delete") {
            SalaryGradePayMasterData = null;
            //$("#FormCreateSalaryGradePayMaster").validate();
            SalaryGradePayMasterData = SalaryGradePayMaster.GetSalaryGradePayMaster();
            ajaxRequest.makeRequest("/SalaryGradePayMaster/Delete", "POST", SalaryGradePayMasterData, SalaryGradePayMaster.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetSalaryGradePayMaster: function () {

        var Data = {
        };
        if (SalaryGradePayMaster.ActionName == "Create") {
            debugger;
           /// Data.ID = $('#ID').val();
            Data.DesignationID = $('#DesignationID').val();
            //Data.Description = $('#Description').val();
           // Data.PayScaleRuleDescription = $('#PayScaleRuleDescription').val();
            Data.GradePayAmount = $('#GradePayAmount').val();
            Data.SalaryPayRulesID = $('#SalaryPayRulesID').val();
          
        }
        else if (SalaryGradePayMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.DesignationID = $('#DesignationID').val();
            Data.GradePayAmount = $('#GradePayAmount').val();
            Data.SalaryPayRulesID = $('#SalaryPayRulesID').val();
        }
        else if (SalaryGradePayMaster.ActionName == "Delete") {
            Data.SalaryGradePayMasterID = $('input[name=SalaryGradePayMasterID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            debugger;
            $.magnificPopup.close()
            SalaryGradePayMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },
};

