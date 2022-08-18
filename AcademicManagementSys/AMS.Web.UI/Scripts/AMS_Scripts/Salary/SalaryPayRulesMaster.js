//this class contain methods related to nationality functionality
var SalaryPayRulesMaster = {
    //Member variables
    ActionName: null,
    XMLstring: null,
    XMLstringForVouchar: null,
    Islocked: 0,
    ItemID: 0,
    DataAppend: null,
    DataApproved: null,
    map: {},
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();
        SalaryPayRulesMaster.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            return false;
        });
        // Create new record
        $('#CreateSalaryPayRulesMasterRecord').on("click", function () {
            SalaryPayRulesMaster.ActionName = "Create";
            SalaryPayRulesMaster.AjaxCallSalaryPayRulesMaster();
        });
        $('#EditSalaryPayRulesMasterRecord').on("click", function () {
            SalaryPayRulesMaster.ActionName = "Edit";
            SalaryPayRulesMaster.AjaxCallSalaryPayRulesMaster();
        });
        $('#DeleteSalaryPayRulesMasterRecord').on("click", function () {
            SalaryPayRulesMaster.ActionName = "Delete";
            SalaryPayRulesMaster.AjaxCallSalaryPayRulesMaster();
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
             url: '/SalaryPayRulesMaster/List',
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
            url: '/SalaryPayRulesMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallSalaryPayRulesMaster: function () {
        var SalaryPayRulesMasterData = null;
        if (SalaryPayRulesMaster.ActionName == "Create") {
            $("#FormCreateSalaryPayRulesMaster").validate();
            if ($("#FormCreateSalaryPayRulesMaster").valid()) {
                SalaryPayRulesMasterData = null;
                SalaryPayRulesMasterData = SalaryPayRulesMaster.GetSalaryPayRulesMaster();
                ajaxRequest.makeRequest("/SalaryPayRulesMaster/Create", "POST", SalaryPayRulesMasterData, SalaryPayRulesMaster.Success, "CreateSalaryPayRulesMasterRecord");
            }
        }
        else if (SalaryPayRulesMaster.ActionName == "Edit") {
            $("#FormEditSalaryPayRulesMaster").validate();
            if ($("#FormEditSalaryPayRulesMaster").valid()) {
                SalaryPayRulesMasterData = null;
                SalaryPayRulesMasterData = SalaryPayRulesMaster.GetSalaryPayRulesMaster();
                ajaxRequest.makeRequest("/SalaryPayRulesMaster/Edit", "POST", SalaryPayRulesMasterData, SalaryPayRulesMaster.Success);
            }
        }
        else if (SalaryPayRulesMaster.ActionName == "Delete") {
            SalaryPayRulesMasterData = null;
            //$("#FormCreateSalaryPayRulesMaster").validate();
            SalaryPayRulesMasterData = SalaryPayRulesMaster.GetSalaryPayRulesMaster();
            ajaxRequest.makeRequest("/SalaryPayRulesMaster/Delete", "POST", SalaryPayRulesMasterData, SalaryPayRulesMaster.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetSalaryPayRulesMaster: function () {
        var Data = {
        };
        if (SalaryPayRulesMaster.ActionName == "Create") {
            
            Data.PayScaleRuleDescription = $('#PayScaleRuleDescription').val();
            Data.PayScaleFromDate = $('#PayScaleFromDate').val();
            Data.PayScaleUptoDate = $('#PayScaleUptoDate').val();
        }
        else if (SalaryPayRulesMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.PayScaleRuleDescription = $('#PayScaleRuleDescription').val();
            Data.PayScaleFromDate = $('#PayScaleFromDate').val();
            Data.PayScaleUptoDate = $('#PayScaleUptoDate').val();
            Data.IsActive = $('#IsActive').is(":checked") ? "true" : "false";
        }
        else if (SalaryPayRulesMaster.ActionName == "Delete") {
            Data.SalaryPayRulesMasterID = $('input[name=SalaryPayRulesMasterID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            SalaryPayRulesMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },
};

