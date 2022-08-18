//this class contain methods related to nationality functionality
var GeneralQuestionTypeMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralQuestionTypeMaster.constructor();
        //GeneralQuestionTypeMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#QuestionType').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#QuestionType').focus();
            return false;
        });



        // Create new record

        $('#CreateGeneralQuestionTypeMasterRecord').on("click", function () {

            GeneralQuestionTypeMaster.ActionName = "Create";
            GeneralQuestionTypeMaster.AjaxCallGeneralQuestionTypeMaster();
        });

        $('#EditGeneralQuestionTypeMasterRecord').on("click", function () {

            GeneralQuestionTypeMaster.ActionName = "Edit";
            GeneralQuestionTypeMaster.AjaxCallGeneralQuestionTypeMaster();
        });

        $('#DeleteGeneralQuestionTypeMasterRecord').on("click", function () {

            GeneralQuestionTypeMaster.ActionName = "Delete";
            GeneralQuestionTypeMaster.AjaxCallGeneralQuestionTypeMaster();
        });

        $('#QuestionType').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#MarchandiseGroupCode').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);

        });

        InitAnimatedBorder();

        CloseAlert();
        //$('#TypeDesc').on("keydown", function (e) {
        //    AMSValidation.AllowCharacterOnly(e);
        //});
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
             url: '/GeneralQuestionTypeMaster/List',
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
            url: '/GeneralQuestionTypeMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallGeneralQuestionTypeMaster: function () {
        var GeneralQuestionTypeMasterData = null;

        if (GeneralQuestionTypeMaster.ActionName == "Create") {
            debugger;
            $("#FormCreateGeneralQuestionTypeMaster").validate();
            if ($("#FormCreateGeneralQuestionTypeMaster").valid()) {
                GeneralQuestionTypeMasterData = null;
                GeneralQuestionTypeMasterData = GeneralQuestionTypeMaster.GetGeneralQuestionTypeMaster();
                ajaxRequest.makeRequest("/GeneralQuestionTypeMaster/Create", "POST", GeneralQuestionTypeMasterData, GeneralQuestionTypeMaster.Success, "CreateGeneralQuestionTypeMasterRecord");
            }
        }
        else if (GeneralQuestionTypeMaster.ActionName == "Edit") {
            $("#FormEditGeneralQuestionTypeMaster").validate();
            if ($("#FormEditGeneralQuestionTypeMaster").valid()) {
                GeneralQuestionTypeMasterData = null;
                GeneralQuestionTypeMasterData = GeneralQuestionTypeMaster.GetGeneralQuestionTypeMaster();
                ajaxRequest.makeRequest("/GeneralQuestionTypeMaster/Edit", "POST", GeneralQuestionTypeMasterData, GeneralQuestionTypeMaster.Success);
            }
        }
        else if (GeneralQuestionTypeMaster.ActionName == "Delete") {

            GeneralQuestionTypeMasterData = null;
            //$("#FormCreateGeneralQuestionTypeMaster").validate();
            GeneralQuestionTypeMasterData = GeneralQuestionTypeMaster.GetGeneralQuestionTypeMaster();
            ajaxRequest.makeRequest("/GeneralQuestionTypeMaster/Delete", "POST", GeneralQuestionTypeMasterData, GeneralQuestionTypeMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralQuestionTypeMaster: function () {
        var Data = {
        };

        if (GeneralQuestionTypeMaster.ActionName == "Create" || GeneralQuestionTypeMaster.ActionName == "Edit") {

            Data.ID = $('#ID').val();
            Data.QuestionType = $('#QuestionType').val();
            Data.RelatedWith = $('#RelatedWith').val();


        }
        else if (GeneralQuestionTypeMaster.ActionName == "Delete") {

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
            GeneralQuestionTypeMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
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
//       GeneralQuestionTypeMaster.ReloadList("Record Updated Sucessfully.", actionMode);
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
//        GeneralQuestionTypeMaster.ReloadList("Record Deleted Sucessfully.");
//      //  alert("Record Deleted Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    }


//},


