//this class contain methods related to nationality functionality
var HMRoomType = {
    //Member variables
    ActionName: null,

    Initialize: function () {
        //organisationStudyCentre.loadData();
        HMRoomType.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $('#RoomType').focus();

        $("#reset").click(function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");

            return false;
        });
        // Create new record
        $('#CreateHMRoomTypeRecord').on("click", function () {
            debugger;
            HMRoomType.ActionName = "Create";
            HMRoomType.AjaxCallHMRoomType();
        });
        $('#EditHMRoomTypeRecord').on("click", function () {
            debugger;
            HMRoomType.ActionName = "Edit";
            HMRoomType.AjaxCallHMRoomType();
        });
        $('#DeleteHMRoomTypeRecord').on("click", function () {
            debugger;
            HMRoomType.ActionName = "Delete";
            HMRoomType.AjaxCallHMRoomType();
        });


        $('#DeductionType').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#DeductionHeadName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
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
             url: '/HMRoomType/List',
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
            url: '/HMRoomType/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallHMRoomType: function () {
        debugger;
        var HMRoomTypeData = null;
        if (HMRoomType.ActionName == "Create") {
            $("#FormCreateHMRoomType").validate();
            if ($("#FormCreateHMRoomType").valid()) {
                HMRoomTypeData = null;
                HMRoomTypeData = HMRoomType.GetHMRoomType();
                ajaxRequest.makeRequest("/HMRoomType/Create", "POST", HMRoomTypeData, HMRoomType.Success, "CreateHMRoomTypeRecord");
            }
        }
        else if (HMRoomType.ActionName == "Edit") {
            debugger;
            $("#FormEditHMRoomType").validate();
            if ($("#FormEditHMRoomType").valid()) {
                HMRoomTypeData = null;
                HMRoomTypeData = HMRoomType.GetHMRoomType();
                ajaxRequest.makeRequest("/HMRoomType/Edit", "POST", HMRoomTypeData, HMRoomType.Success);
            }
        }
        else if (HMRoomType.ActionName == "Delete") {
            debugger;
            HMRoomTypeData = null;
            // $("#FormCreateHMRoomType").validate();
            HMRoomTypeData = HMRoomType.GetHMRoomType();
            ajaxRequest.makeRequest("/HMRoomType/Delete", "POST", HMRoomTypeData, HMRoomType.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetHMRoomType: function () {
        var Data = {
        };

        if (HMRoomType.ActionName == "Create") {
            debugger;
            Data.ID = $('#ID').val();
            Data.RoomType = $('#RoomType').val();
           // Data.DeductionType = $('#DeductionType').val();
        }
        else if (HMRoomType.ActionName == "Edit") {
            debugger;
            Data.ID = $('#ID').val();
           // Data.DeductionHeadName = $('#DeductionHeadName').val();
           // Data.DeductionType = $('#DeductionType').val();
        }
        else if (HMRoomType.ActionName == "Delete") {
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
            HMRoomType.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            //$("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
            $.magnificPopup.close()
            HMRoomType.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
    },
};

