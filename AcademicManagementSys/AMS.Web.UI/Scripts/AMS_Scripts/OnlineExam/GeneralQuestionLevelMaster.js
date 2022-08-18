//this class contain methods related to nationality functionality
var GeneralQuestionLevelMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralQuestionLevelMaster.constructor();
        //GeneralQuestionLevelMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#LevelDescription').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');

            return false;
        });



        // Create new record

        $('#CreateGeneralQuestionLevelMasterRecord').on("click", function () {

            GeneralQuestionLevelMaster.ActionName = "Create";
            GeneralQuestionLevelMaster.AjaxCallGeneralQuestionLevelMaster();
        });

        //$('#EditGeneralQuestionLevelMasterRecord').on("click", function () {

        //    GeneralQuestionLevelMaster.ActionName = "Edit";
        //    GeneralQuestionLevelMaster.AjaxCallGeneralQuestionLevelMaster();
        //});

        $('#DeleteGeneralQuestionLevelMasterRecord').on("click", function () {

            GeneralQuestionLevelMaster.ActionName = "Delete";
            GeneralQuestionLevelMaster.AjaxCallGeneralQuestionLevelMaster();
        });

        //$('#LevelDescription').on("keydown", function (e) {
        //    AMSValidation.AllowCharacterOnly(e);
        //});

        $('#LevelCode').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);

        });

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
             url: '/GeneralQuestionLevelMaster/List',
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
            url: '/GeneralQuestionLevelMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallGeneralQuestionLevelMaster: function () {
        var GeneralQuestionLevelMasterData = null;

        if (GeneralQuestionLevelMaster.ActionName == "Create") {
            debugger;
            $("#FormCreateGeneralQuestionLevelMaster").validate();
              ($("#FormCreateGeneralQuestionLevelMaster").valid()) 
            {
                GeneralQuestionLevelMasterData = null;
                GeneralQuestionLevelMasterData = GeneralQuestionLevelMaster.GetGeneralQuestionLevelMaster();
                ajaxRequest.makeRequest("/GeneralQuestionLevelMaster/Create", "POST", GeneralQuestionLevelMasterData, GeneralQuestionLevelMaster.Success, "CreateGeneralQuestionLevelMasterRecord");
            }
        }
        //else if (GeneralQuestionLevelMaster.ActionName == "Edit") {
        //    $("#FormEditGeneralQuestionLevelMaster").validate();
        //    if ($("#FormEditGeneralQuestionLevelMaster").valid()) {
        //        GeneralQuestionLevelMasterData = null;
        //        GeneralQuestionLevelMasterData = GeneralQuestionLevelMaster.GetGeneralQuestionLevelMaster();
        //        ajaxRequest.makeRequest("/GeneralQuestionLevelMaster/Edit", "POST", GeneralQuestionLevelMasterData, GeneralQuestionLevelMaster.Success);
        //    }
        //}
        else if (GeneralQuestionLevelMaster.ActionName == "Delete") {
            debugger;
            GeneralQuestionLevelMasterData = null;
            $("#FormCreateGeneralQuestionLevelMaster").validate();
            GeneralQuestionLevelMasterData = GeneralQuestionLevelMaster.GetGeneralQuestionLevelMaster();
            ajaxRequest.makeRequest("/GeneralQuestionLevelMaster/Delete", "POST", GeneralQuestionLevelMasterData, GeneralQuestionLevelMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralQuestionLevelMaster: function () {
        var Data = {
        };

        if (GeneralQuestionLevelMaster.ActionName == "Create" ) {

            Data.ID = $('#ID').val();
            Data.LevelDescription = $('#LevelDescription').val();
            Data.LevelCode = $('#LevelCode').val();
           // Data.IsActive = $("#IsActive").is(":checked") ? "true" : "false";
        }
        else if (GeneralQuestionLevelMaster.ActionName == "Delete") {

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
            GeneralQuestionLevelMaster.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
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
//       GeneralQuestionLevelMaster.ReloadList("Record Updated Sucessfully.", actionMode);
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
//        GeneralQuestionLevelMaster.ReloadList("Record Deleted Sucessfully.");
//      //  alert("Record Deleted Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    }


//},


