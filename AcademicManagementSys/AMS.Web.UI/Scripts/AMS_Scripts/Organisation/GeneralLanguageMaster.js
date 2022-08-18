////this class contain methods related to nationality functionality
//var GeneralLanguageMaster = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        GeneralLanguageMaster.constructor();
//        //GeneralLanguageMaster.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {

//        $('#reset').on("click", function () {
//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#LanguageName').focus();
//            return false;
//        });
//        // Create new record
//        $('#CreateGeneralLanguageMasterRecord').on("click", function () {
//            GeneralLanguageMaster.ActionName = "Create";
//            GeneralLanguageMaster.AjaxCallGeneralLanguageMaster();
//        });

//        $('#EditGeneralLanguageMasterRecord').on("click", function () {
            
//            GeneralLanguageMaster.ActionName = "Edit";
//            GeneralLanguageMaster.AjaxCallGeneralLanguageMaster();
//        });

//        $('#DeleteGeneralLanguageMasterRecord').on("click", function () {

//            GeneralLanguageMaster.ActionName = "Delete";
//            GeneralLanguageMaster.AjaxCallGeneralLanguageMaster();
//        });
       
//        $("#UserSearch").keyup(function () {
//            var oTable = $("#myDataTable").dataTable();
//            oTable.fnFilter(this.value);
//        });

//        $("#searchBtn").click(function () {
//            $("#UserSearch").focus();
//        });


//        $("#showrecord").change(function () {
//            var showRecord = $("#showrecord").val();
//            $("select[name*='myDataTable_length']").val(showRecord);
//            $("select[name*='myDataTable_length']").change();
//        });

//        $(".ajax").colorbox();

//        $("#LanguageName").on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });

//    },
//    //LoadList method is used to load List page
//    LoadList: function () {
//        $.ajax(
//         {
//             cache: false,
//             type: "POST",

//             dataType: "html",
//             url: '/GeneralLanguageMaster/List',
//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//             }
//         });
//    },
//    //ReloadList method is used to load List page
//    ReloadList: function (message ,colorCode, actionMode) {
//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            dataType: "html",
//            data: { actionMode: actionMode },
//            url: '/GeneralLanguageMaster/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#SuccessMessage').html(message);
//                $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
//            }
//        });
//    },


//    //Fire ajax call to insert update and delete record
//    AjaxCallGeneralLanguageMaster: function () {
//        var GeneralLanguageMasterData = null;
//        if (GeneralLanguageMaster.ActionName == "Create") {
//            $("#FormCreateGeneralLanguageMaster").validate();
//            if ($("#FormCreateGeneralLanguageMaster").valid()) {
//                GeneralLanguageMasterData = null;
//                GeneralLanguageMasterData = GeneralLanguageMaster.GetGeneralLanguageMaster();
//                ajaxRequest.makeRequest("/GeneralLanguageMaster/Create", "POST", GeneralLanguageMasterData, GeneralLanguageMaster.Success);
//            }
//        }
//        else if (GeneralLanguageMaster.ActionName == "Edit") {
//            $("#FormEditGeneralLanguageMaster").validate();
//            if ($("#FormEditGeneralLanguageMaster").valid()) {
//                GeneralLanguageMasterData = null;
//                GeneralLanguageMasterData = GeneralLanguageMaster.GetGeneralLanguageMaster();
//                ajaxRequest.makeRequest("/GeneralLanguageMaster/Edit", "POST", GeneralLanguageMasterData, GeneralLanguageMaster.Success);
//            }
//        }
//        else if (GeneralLanguageMaster.ActionName == "Delete") {
//            GeneralLanguageMasterData = null;
//            //$("#FormCreateGeneralLanguageMaster").validate();
//            GeneralLanguageMasterData = GeneralLanguageMaster.GetGeneralLanguageMaster();
            
//            ajaxRequest.makeRequest("/GeneralLanguageMaster/Delete", "POST", GeneralLanguageMasterData, GeneralLanguageMaster.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetGeneralLanguageMaster: function () {
//        var Data = {
//        };
//        if (GeneralLanguageMaster.ActionName == "Create" || GeneralLanguageMaster.ActionName == "Edit") {
//            Data.ID = $('#ID').val();
//            Data.LanguageName = $('#LanguageName').val();
//        }
//        else if (GeneralLanguageMaster.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//        }
//        return Data;
//    },

//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            GeneralLanguageMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            GeneralLanguageMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },
//    //this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {
//    //    
//    //    
//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        var actionMode = "1";
//    //        GeneralLanguageMaster.ReloadList("Record Updated Sucessfully.",actionMode );
//    //        //  alert("Record Created Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Updated Sucessfully. Please Try Again..");
//    //    }

//    //},
//    ////this is used to for showing successfully record deletion message and reload the list view
//    //deleteSuccess: function (data) {
//    //    
//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        GeneralLanguageMaster.ReloadList("Record Deleted Sucessfully.");
//    //        //  alert("Record Deleted Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    //    }
//    //},
//};

/////////////new js//////////////////


//this class contain methods related to nationality functionality
var GeneralLanguageMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralLanguageMaster.constructor();
        //GeneralLanguageMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#reset').on("click", function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#LanguageName').focus();
            return false;
        });
        // Create new record
        $('#CreateGeneralLanguageMasterRecord').on("click", function () {
            GeneralLanguageMaster.ActionName = "Create";
            GeneralLanguageMaster.AjaxCallGeneralLanguageMaster();
        });

        $('#EditGeneralLanguageMasterRecord').on("click", function () {

            GeneralLanguageMaster.ActionName = "Edit";
            GeneralLanguageMaster.AjaxCallGeneralLanguageMaster();
        });

        $('#DeleteGeneralLanguageMasterRecord').on("click", function () {

            GeneralLanguageMaster.ActionName = "Delete";
            GeneralLanguageMaster.AjaxCallGeneralLanguageMaster();
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

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();

        $("#LanguageName").on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

    },
    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/GeneralLanguageMaster/List',
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
            url: '/GeneralLanguageMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
                notify(message,colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallGeneralLanguageMaster: function () {
        var GeneralLanguageMasterData = null;
        if (GeneralLanguageMaster.ActionName == "Create") {
            $("#FormCreateGeneralLanguageMaster").validate();
            if ($("#FormCreateGeneralLanguageMaster").valid()) {
                GeneralLanguageMasterData = null;
                GeneralLanguageMasterData = GeneralLanguageMaster.GetGeneralLanguageMaster();
                ajaxRequest.makeRequest("/GeneralLanguageMaster/Create", "POST", GeneralLanguageMasterData, GeneralLanguageMaster.Success);
            }
        }
        else if (GeneralLanguageMaster.ActionName == "Edit") {
            $("#FormEditGeneralLanguageMaster").validate();
            if ($("#FormEditGeneralLanguageMaster").valid()) {
                GeneralLanguageMasterData = null;
                GeneralLanguageMasterData = GeneralLanguageMaster.GetGeneralLanguageMaster();
                ajaxRequest.makeRequest("/GeneralLanguageMaster/Edit", "POST", GeneralLanguageMasterData, GeneralLanguageMaster.Success);
            }
        }
        else if (GeneralLanguageMaster.ActionName == "Delete") {
            GeneralLanguageMasterData = null;
            //$("#FormCreateGeneralLanguageMaster").validate();
            GeneralLanguageMasterData = GeneralLanguageMaster.GetGeneralLanguageMaster();

            ajaxRequest.makeRequest("/GeneralLanguageMaster/Delete", "POST", GeneralLanguageMasterData, GeneralLanguageMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralLanguageMaster: function () {
        var Data = {
        };
        if (GeneralLanguageMaster.ActionName == "Create" || GeneralLanguageMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.LanguageName = $('#LanguageName').val();
        }
        else if (GeneralLanguageMaster.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            GeneralLanguageMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            GeneralLanguageMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {
    //    
    //    
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        GeneralLanguageMaster.ReloadList("Record Updated Sucessfully.",actionMode );
    //        //  alert("Record Created Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Updated Sucessfully. Please Try Again..");
    //    }

    //},
    ////this is used to for showing successfully record deletion message and reload the list view
    //deleteSuccess: function (data) {
    //    
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        GeneralLanguageMaster.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }
    //},
};

