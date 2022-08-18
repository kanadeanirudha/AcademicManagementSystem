////this class contain methods related to nationality functionality
//var GeneralReligionMaster = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        GeneralReligionMaster.constructor();
//        //GeneralReligionMaster.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {

//        $.fn.dataTableExt.oApi.fnPagingInfo = function (oSettings) {
//            return {
//                "iStart": oSettings._iDisplayStart,
//                "iEnd": oSettings.fnDisplayEnd(),
//                "iLength": oSettings._iDisplayLength,
//                "iTotal": oSettings.fnRecordsTotal(),
//                "iFilteredTotal": oSettings.fnRecordsDisplay(),
//                "iPage": Math.ceil(oSettings._iDisplayStart / oSettings._iDisplayLength),
//                "iTotalPages": Math.ceil(oSettings.fnRecordsDisplay() / oSettings._iDisplayLength)
//            };
//        };


//        $('#reset').on("click", function () {
//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#Description').focus();
//            return false;
//        });

//        // Create new record
//        $('#CreateGeneralReligionMasterRecord').on("click", function () {
//            GeneralReligionMaster.ActionName = "Create";
//            GeneralReligionMaster.AjaxCallGeneralReligionMaster();
//        });

//        $('#EditGeneralReligionMasterRecord').on("click", function () {
            
//            GeneralReligionMaster.ActionName = "Edit";
//            GeneralReligionMaster.AjaxCallGeneralReligionMaster();
//        });

//        $('#DeleteGeneralReligionMasterRecord').on("click", function () {

//            GeneralReligionMaster.ActionName = "Delete";
//            GeneralReligionMaster.AjaxCallGeneralReligionMaster();
//        });
//        $('#SeqNo').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });
//        $("#UserSearch").keyup(function () {
//            var oTable = $("#myDataTable").dataTable();
//            oTable.fnFilter(this.value);
//            oTable.draw(false);
    
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

//        $('#Description').on("keydown", function (e) {
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
//             url: '/GeneralReligionMaster/List',
//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//             }
//         });
//    },
//    //ReloadList method is used to load List page
//    ReloadList: function (message,colorCode, actionMode) {

//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            dataType: "html",
//            data: { actionMode: actionMode },
//            url: '/GeneralReligionMaster/List',
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
//    AjaxCallGeneralReligionMaster: function () {
        
//        var GeneralReligionMasterData = null;
//        if (GeneralReligionMaster.ActionName == "Create") {
//            $("#FormCreateGeneralReligionMaster").validate();
//            if ($("#FormCreateGeneralReligionMaster").valid()) {
//                GeneralReligionMasterData = null;
//                GeneralReligionMasterData = GeneralReligionMaster.GetGeneralReligionMaster();
//                ajaxRequest.makeRequest("/GeneralReligionMaster/Create", "POST", GeneralReligionMasterData, GeneralReligionMaster.Success);
//            }
//        }
//        else if (GeneralReligionMaster.ActionName == "Edit") {
//            $("#FormEditGeneralReligionMaster").validate();
//            if ($("#FormEditGeneralReligionMaster").valid()) {
//                GeneralReligionMasterData = null;
//                GeneralReligionMasterData = GeneralReligionMaster.GetGeneralReligionMaster();
//                ajaxRequest.makeRequest("/GeneralReligionMaster/Edit", "POST", GeneralReligionMasterData, GeneralReligionMaster.Success);
//            }
//        }
//        else if (GeneralReligionMaster.ActionName == "Delete") {
//            GeneralReligionMasterData = null;
//            //$("#FormCreateGeneralReligionMaster").validate();
//            GeneralReligionMasterData = GeneralReligionMaster.GetGeneralReligionMaster();
            
//            ajaxRequest.makeRequest("/GeneralReligionMaster/Delete", "POST", GeneralReligionMasterData, GeneralReligionMaster.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetGeneralReligionMaster: function () {
//        var Data = {
//        };
//        if (GeneralReligionMaster.ActionName == "Create" || GeneralReligionMaster.ActionName == "Edit") {
//            Data.ID = $('#ID').val();
//            Data.Description = $('#Description').val();
//        }
//        else if (GeneralReligionMaster.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//        }
//        return Data;
//    },


//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            GeneralReligionMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            GeneralReligionMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },
//    //this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {

        
        
//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        var actionMode = "1";
//    //        GeneralReligionMaster.ReloadList("Record Updated Sucessfully.",actionMode );
//    //        //  alert("Record Created Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Updated Sucessfully. Please Try Again..");
//    //    }

//    //},
//    ////this is used to for showing successfully record deletion message and reload the list view
//    //deleteSuccess: function (data) {

        
//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        GeneralReligionMaster.ReloadList("Record Deleted Sucessfully.");
//    //        //  alert("Record Deleted Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    //    }


//    //},
//};

/////////////////////////////new js////////////////////////


//this class contain methods related to nationality functionality
var GeneralReligionMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralReligionMaster.constructor();
        //GeneralReligionMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $.fn.dataTableExt.oApi.fnPagingInfo = function (oSettings) {
            return {
                "iStart": oSettings._iDisplayStart,
                "iEnd": oSettings.fnDisplayEnd(),
                "iLength": oSettings._iDisplayLength,
                "iTotal": oSettings.fnRecordsTotal(),
                "iFilteredTotal": oSettings.fnRecordsDisplay(),
                "iPage": Math.ceil(oSettings._iDisplayStart / oSettings._iDisplayLength),
                "iTotalPages": Math.ceil(oSettings.fnRecordsDisplay() / oSettings._iDisplayLength)
            };
        };


        $('#reset').on("click", function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#Description').focus();
            return false;
        });

        // Create new record
        $('#CreateGeneralReligionMasterRecord').on("click", function () {
            GeneralReligionMaster.ActionName = "Create";
            GeneralReligionMaster.AjaxCallGeneralReligionMaster();
        });

        $('#EditGeneralReligionMasterRecord').on("click", function () {

            GeneralReligionMaster.ActionName = "Edit";
            GeneralReligionMaster.AjaxCallGeneralReligionMaster();
        });

        $('#DeleteGeneralReligionMasterRecord').on("click", function () {

            GeneralReligionMaster.ActionName = "Delete";
            GeneralReligionMaster.AjaxCallGeneralReligionMaster();
        });
        $('#SeqNo').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
            oTable.draw(false);

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

        $('#Description').on("keydown", function (e) {
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
             url: '/GeneralReligionMaster/List',
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
            url: '/GeneralReligionMaster/List',
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
    AjaxCallGeneralReligionMaster: function () {

        var GeneralReligionMasterData = null;
        if (GeneralReligionMaster.ActionName == "Create") {
            $("#FormCreateGeneralReligionMaster").validate();
            if ($("#FormCreateGeneralReligionMaster").valid()) {
                GeneralReligionMasterData = null;
                GeneralReligionMasterData = GeneralReligionMaster.GetGeneralReligionMaster();
                ajaxRequest.makeRequest("/GeneralReligionMaster/Create", "POST", GeneralReligionMasterData, GeneralReligionMaster.Success);
            }
        }
        else if (GeneralReligionMaster.ActionName == "Edit") {
            $("#FormEditGeneralReligionMaster").validate();
            if ($("#FormEditGeneralReligionMaster").valid()) {
                GeneralReligionMasterData = null;
                GeneralReligionMasterData = GeneralReligionMaster.GetGeneralReligionMaster();
                ajaxRequest.makeRequest("/GeneralReligionMaster/Edit", "POST", GeneralReligionMasterData, GeneralReligionMaster.Success);
            }
        }
        else if (GeneralReligionMaster.ActionName == "Delete") {
            GeneralReligionMasterData = null;
            //$("#FormCreateGeneralReligionMaster").validate();
            GeneralReligionMasterData = GeneralReligionMaster.GetGeneralReligionMaster();

            ajaxRequest.makeRequest("/GeneralReligionMaster/Delete", "POST", GeneralReligionMasterData, GeneralReligionMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralReligionMaster: function () {
        var Data = {
        };
        if (GeneralReligionMaster.ActionName == "Create" || GeneralReligionMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.Description = $('#Description').val();
        }
        else if (GeneralReligionMaster.ActionName == "Delete") {
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
            GeneralReligionMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            GeneralReligionMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    
};



