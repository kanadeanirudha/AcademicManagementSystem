//this class contain methods related to nationality functionality
var GeneralPaperSetMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralPaperSetMaster.constructor();
        //GeneralPaperSetMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#PaperSetCode').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');

            return false;
        });



        // Create new record

        $('#CreateGeneralPaperSetMasterRecord').on("click", function () {

            GeneralPaperSetMaster.ActionName = "Create";
            GeneralPaperSetMaster.AjaxCallGeneralPaperSetMaster();
        });

        //$('#EditGeneralPaperSetMasterRecord').on("click", function () {

        //    GeneralPaperSetMaster.ActionName = "Edit";
        //    GeneralPaperSetMaster.AjaxCallGeneralPaperSetMaster();
        //});

        $('#DeleteGeneralPaperSetMasterRecord').on("click", function () {

            GeneralPaperSetMaster.ActionName = "Delete";
            GeneralPaperSetMaster.AjaxCallGeneralPaperSetMaster();
        });

        $('#PaperSetCode').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        //$('#MovementCode').on("keydown", function (e) {
        //    AMSValidation.NotAllowSpaces(e);

        //});

        InitAnimatedBorder();

        CloseAlert();

        //   $('#CountryName').on("keydown", function (e) {
        //AMSValidation.AllowCharacterOnly(e);
        // });
        //  $('#ContryCode').on("keydown", function (e) {
        //   AMSValidation.AllowCharacterOnly(e);
        //  if (e.keyCode == 32) {
        //       return false;
        // }
        // });
        //$("#UserSearch").keyup(function () {
        //    var oTable = $("#myDataTable").dataTable();
        //    oTable.fnFilter(this.value);
        //});

        //$("#searchBtn").click(function () {
        //    $("#UserSearch").focus();
        //});


        //$("#showrecord").change(function () {
        //    var showRecord = $("#showrecord").val();
        //    $("select[name*='myDataTable_length']").val(showRecord);
        //    $("select[name*='myDataTable_length']").change();
        //});

        // $(".ajax").colorbox();


    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/GeneralPaperSetMaster/List',
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
            url: '/GeneralPaperSetMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallGeneralPaperSetMaster: function () {
        var GeneralPaperSetMasterData = null;

        if (GeneralPaperSetMaster.ActionName == "Create") {
            debugger;
            $("#FormCreateGeneralPaperSetMaster").validate();
            if ($("#FormCreateGeneralPaperSetMaster").valid()) {
                GeneralPaperSetMasterData = null;
                GeneralPaperSetMasterData = GeneralPaperSetMaster.GetGeneralPaperSetMaster();
                ajaxRequest.makeRequest("/GeneralPaperSetMaster/Create", "POST", GeneralPaperSetMasterData, GeneralPaperSetMaster.Success, "CreateGeneralPaperSetMasterRecord");
            }
        }
        //else if (GeneralPaperSetMaster.ActionName == "Edit") {
        //    $("#FormEditGeneralPaperSetMaster").validate();
        //    if ($("#FormEditGeneralPaperSetMaster").valid()) {
        //        GeneralPaperSetMasterData = null;
        //        GeneralPaperSetMasterData = GeneralPaperSetMaster.GetGeneralPaperSetMaster();
        //        ajaxRequest.makeRequest("/GeneralPaperSetMaster/Edit", "POST", GeneralPaperSetMasterData, GeneralPaperSetMaster.Success);
        //    }
        //}
        else if (GeneralPaperSetMaster.ActionName == "Delete") {

            GeneralPaperSetMasterData = null;
            //$("#FormCreateGeneralPaperSetMaster").validate();
            GeneralPaperSetMasterData = GeneralPaperSetMaster.GetGeneralPaperSetMaster();
            ajaxRequest.makeRequest("/GeneralPaperSetMaster/Delete", "POST", GeneralPaperSetMasterData, GeneralPaperSetMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralPaperSetMaster: function () {
        var Data = {
        };

        if (GeneralPaperSetMaster.ActionName == "Create" || GeneralPaperSetMaster.ActionName == "Edit") {

            Data.ID = $('#ID').val();
            Data.PaperSetCode = $('#PaperSetCode').val();
            //Data.MovementCode = $('#MovementCode').val();
            //Data.IsActive = $("#IsActive").is(":checked") ? "true" : "false";
        }
        else if (GeneralPaperSetMaster.ActionName == "Delete") {

            Data.ID = $('#ID').val();
            // Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {


        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            GeneralPaperSetMaster.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

//this is used to for showing successfully record updation message and reload the list view
// editSuccess: function (data) {



// if (data == "True") {

//        parent.$.colorbox.close();
//    var actionMode = "1";
//       GeneralPaperSetMaster.ReloadList("Record Updated Sucessfully.", actionMode);
//        //  alert("Record Created Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//        // alert("Record Not Updated Sucessfully. Please Try Again..");
//    }

//},
////this is used to for showing successfully record deletion message and reload the list view
//deleteSuccess: function (data) {


//    if (data == "True") {

//        parent.$.colorbox.close();
//        GeneralPaperSetMaster.ReloadList("Record Deleted Sucessfully.");
//      //  alert("Record Deleted Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    }


//},


