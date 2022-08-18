
//This class cantain methods for Fish License type funcationality.
var FishLicenseType = {
    //Member variables
    ActionName: null,                                                  
    Initialize: function () {
        //Class intialisation method
        FishLicenseType.constructor();                                 
    },
    constructor: function () {
        $("reset").click(function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val('');
            $('input:checkbox,input:radio').removeAttr('checked');
        });

        //Create New Record  
        $('#CreateFishLicenseTypeRecord').on("click", function () {
            FishLicenseType.ActionName = "Create";
            FishLicenseType.AjaxCallFishLicenseType();
        });

        //Edit Existing Record
        $('#EditFishLicenseTypeMasterRecord').on("click", function () {
            FishLicenseType.ActionName = "Edit";
            FishLicenseType.AjaxCallFishLicenseType();
        });

        //Delete Record
        $('#DeleteFishLicenseTypeMasterRecord').on("click", function ()
        {
            FishLicenseType.ActionName = "Delete";
            FishLicenseType.AjaxCallFishLicenseType();
        });

        $("#UserSearch").keyup(function () {            
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });

        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        $(".ajax").colorbox();

        $('#LicenseType').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

    },
    LoadList: function () {
        $.ajax({
            cache: false,
            type: "POST",
            datatype: "html",
            url: '/FishLicenceTypeMaster/List',
            data: { "actionMode": null},
            success: function (data) {
                //Rebind Grid Data.
                $('#ListViewModel').html(data);
            }
        });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        $.ajax({
            cache: false,
            type: "POST",
            datatype: "html",
            data: { actionMode: actionMode },
            url: '/FishLicenceTypeMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallFishLicenseType: function () {
        var FishLicenseTypeData = null;
        if (FishLicenseType.ActionName == "Create") {
            $("#FormCreateFishLicenseType").validate();
            if ($("#FormCreateFishLicenseType").valid()) {
                FishLicenseTypeData = null;
                FishLicenseTypeData = FishLicenseType.GetFishLicenseType();
                ajaxRequest.makeRequest("/FishLicenceTypeMaster/Create", "POST", FishLicenseTypeData, FishLicenseType.Success);
            }
        }
        else if (FishLicenseType.ActionName == "Edit") {
            $("#FormEditFishLicenseType").validate();
            if ($("#FormEditFishLicenseType").valid()) {
                FishLicenseTypeData = null;
                FishLicenseTypeData = FishLicenseType.GetFishLicenseType();
                ajaxRequest.makeRequest("/FishLicenceTypeMaster/Edit", "POST", FishLicenseTypeData, FishLicenseType.Success);
            }
        }
        else if (FishLicenseType.ActionName == "Delete") {
            FishLicenseTypeData = null;
            FishLicenseTypeData = FishLicenseType.GetFishLicenseType();           
            ajaxRequest.makeRequest("/FishLicenceTypeMaster/Delete", "POST", FishLicenseTypeData, FishLicenseType.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetFishLicenseType: function () {
        var Data = {
        };
        if (FishLicenseType.ActionName == "Create" || FishLicenseType.ActionName == "Edit") {
            Data.ID = $('input[name=ID]').val();
            Data.LicenseType = $("#LicenseType").val();
        }
        else if (FishLicenseType.ActionName == "Delete") {            
            Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');        
        parent.$.colorbox.close();
        FishLicenseType.ReloadList(splitData[0], splitData[1], splitData[2]);
    }
};