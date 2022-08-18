//this class contain methods related to nationality functionality
var GenGroupMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GenGroupMaster.constructor();
        //GenGroupMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#RegionID').focus();
            $('#RegionID').val('');
        });

        // Create new record
        $('#CreateGenGroupMasterRecord').on("click", function () {
            debugger;
            GenGroupMaster.ActionName = "Create";
            GenGroupMaster.AjaxCallGenGroupMaster();
        });

        $('#EditGenGroupMasterRecord').on("click", function () {
            debugger;
            GenGroupMaster.ActionName = "Edit";
            GenGroupMaster.AjaxCallGenGroupMaster();
        });

        $('#DeleteGenGroupMasterRecord').on("click", function () {

            GenGroupMaster.ActionName = "Delete";
            GenGroupMaster.AjaxCallGenGroupMaster();
        });
        $('#Description').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $("#UserSearch").keyup(function () {
            oTable = $("#myDataTable").dataTable();
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


    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/GenGroupMaster/List',
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
            url: '/GenGroupMaster/List',
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
    AjaxCallGenGroupMaster: function () {
        var GenGroupMasterData = null;
        if (GenGroupMaster.ActionName == "Create") {
            $("#FormCreateGenGroupMaster").validate();
            if ($("#FormCreateGenGroupMaster").valid()) {
                GenGroupMasterData = null;
                GenGroupMasterData = GenGroupMaster.GetGenGroupMaster();
                ajaxRequest.makeRequest("/GenGroupMaster/Create", "POST", GenGroupMasterData, GenGroupMaster.Success);
            }
        }
        else if (GenGroupMaster.ActionName == "Edit") {
            $("#FormEditGenGroupMaster").validate();
            if ($("#FormEditGenGroupMaster").valid()) {
                GenGroupMasterData = null;
                GenGroupMasterData = GenGroupMaster.GetGenGroupMaster();
                ajaxRequest.makeRequest("/GenGroupMaster/Edit", "POST", GenGroupMasterData, GenGroupMaster.Success);
            }
        }
        else if (GenGroupMaster.ActionName == "Delete") {
            GenGroupMasterData = null;
            $("#FormDeleteGenGroupMaster").validate();
            GenGroupMasterData = GenGroupMaster.GetGenGroupMaster();
            ajaxRequest.makeRequest("/GenGroupMaster/Delete", "POST", GenGroupMasterData, GenGroupMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGenGroupMaster: function () {
        var Data = {
        };
        if (GenGroupMaster.ActionName == "Create" || GenGroupMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.JobProfileID = $('#JobProfileID').val();
            Data.GroupName = $('#GroupName').val();
            Data.GroupDependentObject = $('#GroupDependentObject').val();

        }
        else if (GenGroupMaster.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },


    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            parent.$.colorbox.close();
            GenGroupMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            parent.$.colorbox.close();
            GenGroupMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //    debugger;
    //    debugger;
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        GenGroupMaster.ReloadList("Record Updated Sucessfully.", actionMode);
    //        //  alert("Record Created Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Updated Sucessfully. Please Try Again..");
    //    }

    //},
    ////this is used to for showing successfully record deletion message and reload the list view
    //deleteSuccess: function (data) {

    //    debugger;
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        GenGroupMaster.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

