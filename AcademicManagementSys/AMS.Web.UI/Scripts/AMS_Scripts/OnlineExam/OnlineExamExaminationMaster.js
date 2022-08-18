//this class contain methods related to nationality functionality
var OnlineExamExaminationMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        OnlineExamExaminationMaster.constructor();
        //OnlineExamExaminationMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#ExaminationName').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');

            return false;
        });



        // Create new record
       
        $('#CreateOnlineExamExaminationMasterRecord').on("click", function () {

            OnlineExamExaminationMaster.ActionName = "Create";
            OnlineExamExaminationMaster.AjaxCallOnlineExamExaminationMaster();
        });

        //$('#EditOnlineExamExaminationMasterRecord').on("click", function () {

        //    OnlineExamExaminationMaster.ActionName = "Edit";
        //    OnlineExamExaminationMaster.AjaxCallOnlineExamExaminationMaster();
        //});

        $('#DeleteOnlineExamExaminationMasterRecord').on("click", function () {

            OnlineExamExaminationMaster.ActionName = "Delete";
            OnlineExamExaminationMaster.AjaxCallOnlineExamExaminationMaster();
        });

        //$('#LevelDescription').on("keydown", function (e) {
        //    AMSValidation.AllowCharacterOnly(e);
        //});

        $('#LevelCode').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);

        });

        InitAnimatedBorder();

        CloseAlert();

        $('#ExaminationName').on("keydown", function (e) {
        AMSValidation.AllowSpecialCharacterOnly(e);
         });
        $('#Purpose').on("keydown", function (e) {
           AMSValidation.AllowCharacterOnly(e);
        //  if (e.keyCode == 32) {
        //       return false;
        // }
         });
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
             url: '/OnlineExamExaminationMaster/List',
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
            url: '/OnlineExamExaminationMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallOnlineExamExaminationMaster: function () {
       
            debugger;
            var Data = {
            };

         if (OnlineExamExaminationMaster.ActionName == "Create") {
                debugger;
                $("#FormCreateOnlineExamExaminationMaster").validate();
                // ($("#FormCreateOnlineExamExaminationMaster").valid())
                {
                    OnlineExamExaminationMasterData = null;
                    OnlineExamExaminationMasterData = OnlineExamExaminationMaster.GetOnlineExamExaminationMaster();
                    ajaxRequest.makeRequest("/OnlineExamExaminationMaster/Create", "POST", OnlineExamExaminationMasterData, OnlineExamExaminationMaster.Success, "CreateOnlineExamExaminationMasterRecord");
                }
            }
                //else if (OnlineExamExaminationMaster.ActionName == "Edit") {
                //    $("#FormEditOnlineExamExaminationMaster").validate();
                //    if ($("#FormEditOnlineExamExaminationMaster").valid()) {
                //        OnlineExamExaminationMasterData = null;
                //        OnlineExamExaminationMasterData = OnlineExamExaminationMaster.GetOnlineExamExaminationMaster();
                //        ajaxRequest.makeRequest("/OnlineExamExaminationMaster/Edit", "POST", OnlineExamExaminationMasterData, OnlineExamExaminationMaster.Success);
                //    }
                //}
            else if (OnlineExamExaminationMaster.ActionName == "Delete") {
                debugger;
                OnlineExamExaminationMasterData = null;
                $("#FormCreateOnlineExamExaminationMaster").validate();
                OnlineExamExaminationMasterData = OnlineExamExaminationMaster.GetOnlineExamExaminationMaster();
                ajaxRequest.makeRequest("/OnlineExamExaminationMaster/Delete", "POST", OnlineExamExaminationMasterData, OnlineExamExaminationMaster.Success);

            }
        },
    
        
    //Get properties data from the Create, Update and Delete page
   

       GetOnlineExamExaminationMaster: function () 
        {
            debugger;
            var Data = {
            };
        

                 if (OnlineExamExaminationMaster.ActionName == "Create") {

                    Data.ID = $('#ID').val();
                    Data.ExaminationName = $('#ExaminationName').val();
                    Data.Purpose = $('#Purpose').val();
                    Data.AcadSessionId = $('#AcadSessionId').val();
                    Data.ExaminationFor = $('#ExaminationFor').val();
                    Data.SessionName = $('#SessionName').val();
                    // Data.IsActive = $("#IsActive").is(":checked") ? "true" : "false";
                }
                else if (OnlineExamExaminationMaster.ActionName == "Delete") {

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
            OnlineExamExaminationMaster.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
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
//       OnlineExamExaminationMaster.ReloadList("Record Updated Sucessfully.", actionMode);
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
//        OnlineExamExaminationMaster.ReloadList("Record Deleted Sucessfully.");
//      //  alert("Record Deleted Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    }


//},


