////this class contain methods related to nationality functionality
//var ToolQualificationExamMaster = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        ToolQualificationExamMaster.constructor();
//        //ToolQualificationExamMaster.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {



//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#CountryName').focus();
//            //var dt = new Date();
//            // document.write("getYear() : " + dt.getYear());
//            //$('#SessionFrom').val(dt.getFullYear());
//            //$('#SessionUpto').val(dt.getFullYear() + 1);
//            $('#SeqNo').val(0);
//            $('#EducationType').val('G');
//            //$('#SelectedCityID').val('0');
//            $('#QualificationName').focus();
//            return false;
//        });


//        // Create new record
//        $('#CreateToolQualificationExamMasterRecord').on("click", function () {
//            ToolQualificationExamMaster.ActionName = "Create";
//            ToolQualificationExamMaster.AjaxCallToolQualificationExamMaster();
//        });

//        $('#EditToolQualificationExamMasterRecord').on("click", function () {
            
//            ToolQualificationExamMaster.ActionName = "Edit";
//            ToolQualificationExamMaster.AjaxCallToolQualificationExamMaster();
//        });

//        $('#DeleteToolQualificationExamMasterRecord').on("click", function () {

//            ToolQualificationExamMaster.ActionName = "Delete";
//            ToolQualificationExamMaster.AjaxCallToolQualificationExamMaster();
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
//             url: '/ToolQualificationExamMaster/List',
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
//            url: '/ToolQualificationExamMaster/List',
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
//    AjaxCallToolQualificationExamMaster: function () {
//        var ToolQualificationExamMasterData = null;
//        if (ToolQualificationExamMaster.ActionName == "Create") {
//            $("#FormCreateToolQualificationExamMaster").validate();
//            if ($("#FormCreateToolQualificationExamMaster").valid()) {
//                ToolQualificationExamMasterData = null;
//                ToolQualificationExamMasterData = ToolQualificationExamMaster.GetToolQualificationExamMaster();
//                ajaxRequest.makeRequest("/ToolQualificationExamMaster/Create", "POST", ToolQualificationExamMasterData, ToolQualificationExamMaster.Success);
//            }
//        }
//        else if (ToolQualificationExamMaster.ActionName == "Edit") {
//            $("#FormEditToolQualificationExamMaster").validate();
//            if ($("#FormEditToolQualificationExamMaster").valid()) {
//                ToolQualificationExamMasterData = null;
//                ToolQualificationExamMasterData = ToolQualificationExamMaster.GetToolQualificationExamMaster();
//                ajaxRequest.makeRequest("/ToolQualificationExamMaster/Edit", "POST", ToolQualificationExamMasterData, ToolQualificationExamMaster.Success);
//            }
//        }
//        else if (ToolQualificationExamMaster.ActionName == "Delete") {
//            ToolQualificationExamMasterData = null;
//            //$("#FormCreateToolQualificationExamMaster").validate();
//            ToolQualificationExamMasterData = ToolQualificationExamMaster.GetToolQualificationExamMaster();
            
//            ajaxRequest.makeRequest("/ToolQualificationExamMaster/Delete", "POST", ToolQualificationExamMasterData, ToolQualificationExamMaster.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetToolQualificationExamMaster: function () {
//        var Data = {
         
//        };
        
//        if (ToolQualificationExamMaster.ActionName == "Create" || ToolQualificationExamMaster.ActionName == "Edit") {
//            Data.ID = $('#ID').val();
//            Data.QualificationName = $('#QualificationName').val();
//            Data.EducationType = $('#EducationType').val();

//        }
//        else if (ToolQualificationExamMaster.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//        }
//        return Data;
//    },

//    //this is used to for showing successfully record creation message and reload the list view

//    Success: function (data) {
        
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            ToolQualificationExamMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            ToolQualificationExamMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },
//    //this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {

//    //    
//    //    
//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        ToolQualificationExamMaster.ReloadList("Record Updated Sucessfully.");
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
//    //        ToolQualificationExamMaster.ReloadList("Record Deleted Sucessfully.");
//    //        //  alert("Record Deleted Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    //    }


//    //},
//};

///////////new js///////////////


//this class contain methods related to nationality functionality
var ToolQualificationExamMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        ToolQualificationExamMaster.constructor();
        //ToolQualificationExamMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {



        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#CountryName').focus();
            //var dt = new Date();
            // document.write("getYear() : " + dt.getYear());
            //$('#SessionFrom').val(dt.getFullYear());
            //$('#SessionUpto').val(dt.getFullYear() + 1);
            $('#SeqNo').val(0);
            $('#EducationType').val('G');
            //$('#SelectedCityID').val('0');
            $('#QualificationName').focus();
            return false;
        });


        // Create new record
        $('#CreateToolQualificationExamMasterRecord').on("click", function () {
            ToolQualificationExamMaster.ActionName = "Create";
            ToolQualificationExamMaster.AjaxCallToolQualificationExamMaster();
        });

        $('#EditToolQualificationExamMasterRecord').on("click", function () {

            ToolQualificationExamMaster.ActionName = "Edit";
            ToolQualificationExamMaster.AjaxCallToolQualificationExamMaster();
        });

        $('#DeleteToolQualificationExamMasterRecord').on("click", function () {

            ToolQualificationExamMaster.ActionName = "Delete";
            ToolQualificationExamMaster.AjaxCallToolQualificationExamMaster();
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
             url: '/ToolQualificationExamMaster/List',
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
            url: '/ToolQualificationExamMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message,colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallToolQualificationExamMaster: function () {
        var ToolQualificationExamMasterData = null;
        if (ToolQualificationExamMaster.ActionName == "Create") {
            $("#FormCreateToolQualificationExamMaster").validate();
            if ($("#FormCreateToolQualificationExamMaster").valid()) {
                ToolQualificationExamMasterData = null;
                ToolQualificationExamMasterData = ToolQualificationExamMaster.GetToolQualificationExamMaster();
                ajaxRequest.makeRequest("/ToolQualificationExamMaster/Create", "POST", ToolQualificationExamMasterData, ToolQualificationExamMaster.Success);
            }
        }
        else if (ToolQualificationExamMaster.ActionName == "Edit") {
            $("#FormEditToolQualificationExamMaster").validate();
            if ($("#FormEditToolQualificationExamMaster").valid()) {
                ToolQualificationExamMasterData = null;
                ToolQualificationExamMasterData = ToolQualificationExamMaster.GetToolQualificationExamMaster();
                ajaxRequest.makeRequest("/ToolQualificationExamMaster/Edit", "POST", ToolQualificationExamMasterData, ToolQualificationExamMaster.Success);
            }
        }
        else if (ToolQualificationExamMaster.ActionName == "Delete") {
            ToolQualificationExamMasterData = null;
            //$("#FormCreateToolQualificationExamMaster").validate();
            ToolQualificationExamMasterData = ToolQualificationExamMaster.GetToolQualificationExamMaster();

            ajaxRequest.makeRequest("/ToolQualificationExamMaster/Delete", "POST", ToolQualificationExamMasterData, ToolQualificationExamMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetToolQualificationExamMaster: function () {
        var Data = {

        };

        if (ToolQualificationExamMaster.ActionName == "Create" || ToolQualificationExamMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.QualificationName = $('#QualificationName').val();
            Data.EducationType = $('#EducationType').val();

        }
        else if (ToolQualificationExamMaster.ActionName == "Delete") {
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
            ToolQualificationExamMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            ToolQualificationExamMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    
};


