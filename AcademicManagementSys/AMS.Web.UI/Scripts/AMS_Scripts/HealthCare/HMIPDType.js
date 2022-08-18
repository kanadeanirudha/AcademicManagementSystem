//this class contain methods related to nationality functionality
var HMIPDType = {
    //Member variables
    ActionName: null,

    Initialize: function () {
        //organisationStudyCentre.loadData();
        HMIPDType.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $('#Name').focus();

        $("#reset").click(function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");

            return false;
        });
        // Create new record
        $('#CreateHMIPDTypeRecord').on("click", function () {
            debugger;
            HMIPDType.ActionName = "Create";
            HMIPDType.AjaxCallHMIPDType();
        });
        $('#EditHMIPDTypeRecord').on("click", function () {
            debugger;
            HMIPDType.ActionName = "Edit";
            HMIPDType.AjaxCallHMIPDType();
        });
        $('#DeleteHMIPDTypeRecord').on("click", function () {
            debugger;
            HMIPDType.ActionName = "Delete";
            HMIPDType.AjaxCallHMIPDType();
        });


        $('#Name').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        //$('#DeductionHeadName').on("keydown", function (e) {
        //    AMSValidation.AllowCharacterOnly(e);
        //});



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
             url: '/HMIPDType/List',
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
            url: '/HMIPDType/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallHMIPDType: function () {
        debugger;
        var HMIPDTypeData = null;
        if (HMIPDType.ActionName == "Create") {
            $("#FormCreateHMIPDType").validate();
            if ($("#FormCreateHMIPDType").valid()) {
                HMIPDTypeData = null;
                HMIPDTypeData = HMIPDType.GetHMIPDType();
                ajaxRequest.makeRequest("/HMIPDType/Create", "POST", HMIPDTypeData, HMIPDType.Success, "CreateHMIPDTypeRecord");
            }
        }
        else if (HMIPDType.ActionName == "Edit") {
            debugger;
            $("#FormEditHMIPDType").validate();
            if ($("#FormEditHMIPDType").valid()) {
                HMIPDTypeData = null;
                HMIPDTypeData = HMIPDType.GetHMIPDType();
                ajaxRequest.makeRequest("/HMIPDType/Edit", "POST", HMIPDTypeData, HMIPDType.Success);
            }
        }
        else if (HMIPDType.ActionName == "Delete") {
            debugger;
            HMIPDTypeData = null;
            // $("#FormCreateHMIPDType").validate();
            HMIPDTypeData = HMIPDType.GetHMIPDType();
            ajaxRequest.makeRequest("/HMIPDType/Delete", "POST", HMIPDTypeData, HMIPDType.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetHMIPDType: function () {
        var Data = {
        };

        if (HMIPDType.ActionName == "Create") {
            debugger;
            Data.ID = $('#ID').val();
            Data.Name = $('#Name').val();
            Data.Type = $('#IPDType').val();
        }
        else if (HMIPDType.ActionName == "Edit") {
            debugger;
            Data.ID = $('#ID').val();
          
        }
        else if (HMIPDType.ActionName == "Delete") {
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
            HMIPDType.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            //$("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
            $.magnificPopup.close()
            HMIPDType.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
    },
};

