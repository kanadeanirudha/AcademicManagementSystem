////this class contain methods related to nationality functionality
//var ToolQualifyingExamMaster = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        ToolQualifyingExamMaster.constructor();
//        //ToolQualifyingExamMaster.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {

//        $("#ExamName").focus();

//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#CountryName').focus();
//            //var dt = new Date();
//            // document.write("getYear() : " + dt.getYear());
//            //$('#SessionFrom').val(dt.getFullYear());
//            //$('#SessionUpto').val(dt.getFullYear() + 1);
//            $('#SeqNo').val(0);
//            //$('#SelectedCityID').val('0');
//            $("#ExamName").focus();
//            return false;
//        });


//        // Create new record
//        $('#CreateToolQualifyingExamMasterRecord').on("click", function () {
//            ToolQualifyingExamMaster.ActionName = "Create";
//            ToolQualifyingExamMaster.AjaxCallToolQualifyingExamMaster();
//        });

//        $('#EditToolQualifyingExamMasterRecord').on("click", function () {
            
//            ToolQualifyingExamMaster.ActionName = "Edit";
//            ToolQualifyingExamMaster.AjaxCallToolQualifyingExamMaster();
//        });

//        $('#DeleteToolQualifyingExamMasterRecord').on("click", function () {

//            ToolQualifyingExamMaster.ActionName = "Delete";
//            ToolQualifyingExamMaster.AjaxCallToolQualifyingExamMaster();
//        });
//        $('#SeqNo').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
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


//    },
//    //LoadList method is used to load List page
//    LoadList: function () {

//        $.ajax(

//         {

//             cache: false,
//             type: "POST",

//             dataType: "html",
//             url: '/ToolQualifyingExamMaster/List',
//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//             }
//         });
//    },
//    //ReloadList method is used to load List page
//    ReloadList: function (message, colorCode, actionMode) {

//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            dataType: "html",
//            data: { "actionMode": actionMode },
//            url: '/ToolQualifyingExamMaster/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#SuccessMessage').html(message);
//                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
//            }
//        });
//    },


//    //Fire ajax call to insert update and delete record
//    AjaxCallToolQualifyingExamMaster: function () {
//        var ToolQualifyingExamMasterData = null;
//        if (ToolQualifyingExamMaster.ActionName == "Create") {
//            $("#FormCreateToolQualifyingExamMaster").validate();
//            if ($("#FormCreateToolQualifyingExamMaster").valid()) {
//                ToolQualifyingExamMasterData = null;
//                ToolQualifyingExamMasterData = ToolQualifyingExamMaster.GetToolQualifyingExamMaster();
//                ajaxRequest.makeRequest("/ToolQualifyingExamMaster/Create", "POST", ToolQualifyingExamMasterData, ToolQualifyingExamMaster.Success);
//            }
//        }
//        else if (ToolQualifyingExamMaster.ActionName == "Edit") {
//            $("#FormEditToolQualifyingExamMaster").validate();
//            if ($("#FormEditToolQualifyingExamMaster").valid()) {
//                ToolQualifyingExamMasterData = null;
//                ToolQualifyingExamMasterData = ToolQualifyingExamMaster.GetToolQualifyingExamMaster();
//                ajaxRequest.makeRequest("/ToolQualifyingExamMaster/Edit", "POST", ToolQualifyingExamMasterData, ToolQualifyingExamMaster.Success);
//            }
//        }
//        else if (ToolQualifyingExamMaster.ActionName == "Delete") {
//            ToolQualifyingExamMasterData = null;
//            //$("#FormCreateToolQualifyingExamMaster").validate();
//            ToolQualifyingExamMasterData = ToolQualifyingExamMaster.GetToolQualifyingExamMaster();
//            ajaxRequest.makeRequest("/ToolQualifyingExamMaster/Delete", "POST", ToolQualifyingExamMasterData, ToolQualifyingExamMaster.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetToolQualifyingExamMaster: function () {
//        var Data = {
//        };
//        if (ToolQualifyingExamMaster.ActionName == "Create" || ToolQualifyingExamMaster.ActionName == "Edit") {
//            Data.ID = $('#ID').val();
//            Data.ExamName = $('#ExamName').val();
           
//        }
//        else if (ToolQualifyingExamMaster.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//        }
//        return Data;
//    },

//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
        
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            ToolQualifyingExamMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            ToolQualifyingExamMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },
//    //this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {

//    //    
//    //    
//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        ToolQualifyingExamMaster.ReloadList("Record Updated Sucessfully.");
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
//    //        ToolQualifyingExamMaster.ReloadList("Record Deleted Sucessfully.");
//    //        //  alert("Record Deleted Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    //    }


//    //},
//};

//////////////////////new js/////////////////


//this class contain methods related to nationality functionality
var ToolQualifyingExamMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        ToolQualifyingExamMaster.constructor();
        //ToolQualifyingExamMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#ExamName").focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#CountryName').focus();
            //var dt = new Date();
            // document.write("getYear() : " + dt.getYear());
            //$('#SessionFrom').val(dt.getFullYear());
            //$('#SessionUpto').val(dt.getFullYear() + 1);
            $('#SeqNo').val(0);
            //$('#SelectedCityID').val('0');
            $("#ExamName").focus();
            return false;
        });


        // Create new record
        $('#CreateToolQualifyingExamMasterRecord').on("click", function () {
            ToolQualifyingExamMaster.ActionName = "Create";
            ToolQualifyingExamMaster.AjaxCallToolQualifyingExamMaster();
        });

        $('#EditToolQualifyingExamMasterRecord').on("click", function () {

            ToolQualifyingExamMaster.ActionName = "Edit";
            ToolQualifyingExamMaster.AjaxCallToolQualifyingExamMaster();
        });

        $('#DeleteToolQualifyingExamMasterRecord').on("click", function () {

            ToolQualifyingExamMaster.ActionName = "Delete";
            ToolQualifyingExamMaster.AjaxCallToolQualifyingExamMaster();
        });
        $('#SeqNo').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
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


    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/ToolQualifyingExamMaster/List',
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
            data: { "actionMode": actionMode },
            url: '/ToolQualifyingExamMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallToolQualifyingExamMaster: function () {
        var ToolQualifyingExamMasterData = null;
        if (ToolQualifyingExamMaster.ActionName == "Create") {
            $("#FormCreateToolQualifyingExamMaster").validate();
            if ($("#FormCreateToolQualifyingExamMaster").valid()) {
                ToolQualifyingExamMasterData = null;
                ToolQualifyingExamMasterData = ToolQualifyingExamMaster.GetToolQualifyingExamMaster();
                ajaxRequest.makeRequest("/ToolQualifyingExamMaster/Create", "POST", ToolQualifyingExamMasterData, ToolQualifyingExamMaster.Success);
            }
        }
        else if (ToolQualifyingExamMaster.ActionName == "Edit") {
            $("#FormEditToolQualifyingExamMaster").validate();
            if ($("#FormEditToolQualifyingExamMaster").valid()) {
                ToolQualifyingExamMasterData = null;
                ToolQualifyingExamMasterData = ToolQualifyingExamMaster.GetToolQualifyingExamMaster();
                ajaxRequest.makeRequest("/ToolQualifyingExamMaster/Edit", "POST", ToolQualifyingExamMasterData, ToolQualifyingExamMaster.Success);
            }
        }
        else if (ToolQualifyingExamMaster.ActionName == "Delete") {
            ToolQualifyingExamMasterData = null;
            //$("#FormCreateToolQualifyingExamMaster").validate();
            ToolQualifyingExamMasterData = ToolQualifyingExamMaster.GetToolQualifyingExamMaster();
            ajaxRequest.makeRequest("/ToolQualifyingExamMaster/Delete", "POST", ToolQualifyingExamMasterData, ToolQualifyingExamMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetToolQualifyingExamMaster: function () {
        var Data = {
        };
        if (ToolQualifyingExamMaster.ActionName == "Create" || ToolQualifyingExamMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.ExamName = $('#ExamName').val();

        }
        else if (ToolQualifyingExamMaster.ActionName == "Delete") {
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
            ToolQualifyingExamMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            ToolQualifyingExamMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    
};

