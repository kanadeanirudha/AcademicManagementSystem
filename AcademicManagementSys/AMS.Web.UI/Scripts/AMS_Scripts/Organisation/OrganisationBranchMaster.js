//var OrganisationBranchMaster = {
//    ActionName: null,
//    Initialize: function () {
//        OrganisationBranchMaster.constructor();
//    },
//    constructor: function () {
//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $("#SelectedDepartmentID").val("");
//            $('#SelectedDepartmentID').focus();
//            $("#SelectedUniversityID").val("");
//             return false;
//        });

//        $('#CreateOrganisationBranchMasterRecord').on("click", function () {
//            OrganisationBranchMaster.ActionName = "Create";
//            OrganisationBranchMaster.AjaxCallOrganisationBranchMaster();
//        });

//        $('#EditOrganisationBranchMasterRecord').on("click", function () {
//            OrganisationBranchMaster.ActionName = "Edit";
//            OrganisationBranchMaster.AjaxCallOrganisationBranchMaster();
//        });

//        $('#DeleteOrganisationBranchMasterRecord').on("click", function () {
//            OrganisationBranchMaster.ActionName = "Delete";
//            OrganisationBranchMaster.AjaxCallOrganisationBranchMaster();
//        });

//        $('#closeBtn').on("click", function () {
//            parent.$.colorbox.close();
//        });
//        $("#UserSearch").on("keyup", function () {
//           var oTable = $("#myDataTable").dataTable();
//            oTable.fnFilter(this.value);
//        });
//        $("#searchBtn").on("click", function () {
//            $("#UserSearch").focus();
//        });
//        $("#showrecord").on("change", function () {
//            var showRecord = $("#showrecord").val();
//            $("select[name*='myDataTable_length']").val(showRecord);
//            $("select[name*='myDataTable_length']").change();
//        });
//        $(".ajax").colorbox();

//        $('#IntroductionYear').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });
//        $('#BranchDescription').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });
//        $('#DurationInDays').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });

        
//        $('#BranchShortCode').on("keydown", function (e) {
//            AMSValidation.NotAllowSpaces(e);
//        });
//        $('#PrintShortCode').on("keydown", function (e) {
//            AMSValidation.NotAllowSpaces(e);
//        });
//        $('#IntroductionYear').on("keydown", function (e) {
//            AMSValidation.NotAllowSpaces(e);
//        });
     
//        $('#DurationInDays').on("keydown", function (e) {
//            AMSValidation.NotAllowSpaces(e);
//        });



//        $("#IsCommonBranchApplicable").on("click", function () {
//            $('#CommonBranch').prop('checked', false);
//        });


//        $("#CommonBranch").on("click", function () {
//            $('#IsCommonBranchApplicable').prop('checked', false);
//        });


//    },
//    LoadList: function () {
//        $.ajax(
//         {
//             cache: false,
//             type: "POST",
//             dataType: "html",
//             url: '/OrganisationBranchMaster/List',
//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//             }
//         });
//    },
//    ReloadList: function (message, colorCode, actionMode) {
//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            dataType: "html",
//            data: { "actionMode": actionMode },
//            url: '/OrganisationBranchMaster/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#SuccessMessage').html(message);
//                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
//            }
//        });
//    },

//    AjaxCallOrganisationBranchMaster: function () {
//        var OrganisationBranchMasterData = null;
//        if (OrganisationBranchMaster.ActionName == "Create") {
//            $("#FormCreateOrganisationBranchMaster").validate();
//            if ($("#FormCreateOrganisationBranchMaster").valid()) {
//                OrganisationBranchMasterData = null;
//                OrganisationBranchMasterData = OrganisationBranchMaster.GetOrganisationBranchMaster();
//                ajaxRequest.makeRequest("/OrganisationBranchMaster/Create", "POST", OrganisationBranchMasterData, OrganisationBranchMaster.Success);
//            }
//        }
//        else if (OrganisationBranchMaster.ActionName == "Edit") {
//            $("#FormEditOrganisationBranchMaster").validate();
//            if ($("#FormEditOrganisationBranchMaster").valid()) {
//                OrganisationBranchMasterData = null;
//                OrganisationBranchMasterData = OrganisationBranchMaster.GetOrganisationBranchMaster();
//                ajaxRequest.makeRequest("/OrganisationBranchMaster/Edit", "POST", OrganisationBranchMasterData, OrganisationBranchMaster.Success);
//            }
//        }
//        else if (OrganisationBranchMaster.ActionName == "Delete") {
//                OrganisationBranchMasterData = null;               
//                OrganisationBranchMasterData = OrganisationBranchMaster.GetOrganisationBranchMaster();
//                ajaxRequest.makeRequest("/OrganisationBranchMaster/Delete", "POST", OrganisationBranchMasterData, OrganisationBranchMaster.Success);
           
//        }
//    },

//    GetOrganisationBranchMaster: function () {
//        var Data = {
//        };
//        if (OrganisationBranchMaster.ActionName == "Create" || OrganisationBranchMaster.ActionName == "Edit") {
            
//            Data.ID = $('#ID').val();
//            Data.BranchDescription = $('#BranchDescription').val();
//            Data.BranchShortCode = $('#BranchShortCode').val();
//            Data.PrintShortCode = $('#PrintShortCode').val();
//            Data.CommonBranch = $('input[name=CommonBranch]:checked').val() ? true : false;
//            Data.IsCommonBranchApplicable = $('input[name=IsCommonBranchApplicable]:checked').val() ? true : false;
//            Data.IntroductionYear = $('#IntroductionYear').val();
//            Data.DepartmentID = $('#DepartmentID').val();
//            Data.UniversityID = $('#UniversityID').val();
//            Data.SelectedDepartmentID = $('#SelectedDepartmentID').val();
//            Data.SelectedUniversityID = $('#SelectedUniversityID').val();
//            Data.DurationInDays = $('#DurationInDays').val(); 
//            Data.DepartmentBranchID = $('#DepartmentBranchID').val();
//        }
//        else if (OrganisationBranchMaster.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//        }
//        return Data;
//    },

//    Success: function (data) {
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            OrganisationBranchMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            OrganisationBranchMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },
//    //editSuccess: function (data) {
//    //    parent.$.colorbox.close();
//    //    OrganisationBranchMaster.ReloadList("Record Created Sucessfully.");
//    //},
//    //deleteSuccess: function (data) {
//    //    parent.$.colorbox.close();
//    //    OrganisationBranchMaster.ReloadList("Record Created Sucessfully.");
//    //},
//};

////////new code////////////


var OrganisationBranchMaster = {
    ActionName: null,
    Initialize: function () {
        OrganisationBranchMaster.constructor();
    },
    constructor: function () {
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $("#SelectedDepartmentID").val("");
            $('#SelectedDepartmentID').focus();
            $("#SelectedUniversityID").val("");
            return false;
        });

        $('#CreateOrganisationBranchMasterRecord').on("click", function () {
            OrganisationBranchMaster.ActionName = "Create";
            OrganisationBranchMaster.AjaxCallOrganisationBranchMaster();
        });

        $('#EditOrganisationBranchMasterRecord').on("click", function () {
            OrganisationBranchMaster.ActionName = "Edit";
            OrganisationBranchMaster.AjaxCallOrganisationBranchMaster();
        });

        $('#DeleteOrganisationBranchMasterRecord').on("click", function () {
            OrganisationBranchMaster.ActionName = "Delete";
            OrganisationBranchMaster.AjaxCallOrganisationBranchMaster();
        });

        $('#closeBtn').on("click", function () {
            parent.$.colorbox.close();
        });
        $("#UserSearch").on("keyup", function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });
        $("#searchBtn").on("click", function () {
            $("#UserSearch").focus();
        });
        $("#showrecord").on("change", function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });
        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();

        $('#IntroductionYear').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#BranchDescription').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#DurationInDays').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });


        $('#BranchShortCode').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);
        });
        $('#PrintShortCode').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);
        });
        $('#IntroductionYear').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);
        });

        $('#DurationInDays').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);
        });



        $("#IsCommonBranchApplicable").on("click", function () {
            $('#CommonBranch').prop('checked', false);
        });


        $("#CommonBranch").on("click", function () {
            $('#IsCommonBranchApplicable').prop('checked', false);
        });


    },
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/OrganisationBranchMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    ReloadList: function (message, colorCode, actionMode) {
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode },
            url: '/OrganisationBranchMaster/List',
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

    AjaxCallOrganisationBranchMaster: function () {
        var OrganisationBranchMasterData = null;
        if (OrganisationBranchMaster.ActionName == "Create") {
            $("#FormCreateOrganisationBranchMaster").validate();
            if ($("#FormCreateOrganisationBranchMaster").valid()) {
                OrganisationBranchMasterData = null;
                OrganisationBranchMasterData = OrganisationBranchMaster.GetOrganisationBranchMaster();
                ajaxRequest.makeRequest("/OrganisationBranchMaster/Create", "POST", OrganisationBranchMasterData, OrganisationBranchMaster.Success);
            }
        }
        else if (OrganisationBranchMaster.ActionName == "Edit") {
            $("#FormEditOrganisationBranchMaster").validate();
            if ($("#FormEditOrganisationBranchMaster").valid()) {
                OrganisationBranchMasterData = null;
                OrganisationBranchMasterData = OrganisationBranchMaster.GetOrganisationBranchMaster();
                ajaxRequest.makeRequest("/OrganisationBranchMaster/Edit", "POST", OrganisationBranchMasterData, OrganisationBranchMaster.Success);
            }
        }
        else if (OrganisationBranchMaster.ActionName == "Delete") {
            OrganisationBranchMasterData = null;
            OrganisationBranchMasterData = OrganisationBranchMaster.GetOrganisationBranchMaster();
            ajaxRequest.makeRequest("/OrganisationBranchMaster/Delete", "POST", OrganisationBranchMasterData, OrganisationBranchMaster.Success);

        }
    },

    GetOrganisationBranchMaster: function () {
        var Data = {
        };
        if (OrganisationBranchMaster.ActionName == "Create" || OrganisationBranchMaster.ActionName == "Edit") {

            Data.ID = $('#ID').val();
            Data.BranchDescription = $('#BranchDescription').val();
            Data.BranchShortCode = $('#BranchShortCode').val();
            Data.PrintShortCode = $('#PrintShortCode').val();
            //Data.CommonBranch = $('input[name=CommonBranch]:checked').val() ? true : false;
            //Data.IsCommonBranchApplicable = $('input[name=IsCommonBranchApplicable]:checked').val() ? true : false;
            Data.CommonBranch = $('input[id=CommonBranch]:checked').val() ? true : false;
            Data.IsCommonBranchApplicable = $('input[id=IsCommonBranchApplicable]:checked').val() ? true : false;
            Data.IntroductionYear = $('#IntroductionYear').val();
            Data.DepartmentID = $('#DepartmentID').val();
            Data.UniversityID = $('#UniversityID').val();
            Data.SelectedDepartmentID = $('#SelectedDepartmentID').val();
            Data.SelectedUniversityID = $('#SelectedUniversityID').val();
            Data.DurationInDays = $('#DurationInDays').val();
            Data.DepartmentBranchID = $('#DepartmentBranchID').val();
        }
        else if (OrganisationBranchMaster.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            OrganisationBranchMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            OrganisationBranchMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //editSuccess: function (data) {
    //    parent.$.colorbox.close();
    //    OrganisationBranchMaster.ReloadList("Record Created Sucessfully.");
    //},
    //deleteSuccess: function (data) {
    //    parent.$.colorbox.close();
    //    OrganisationBranchMaster.ReloadList("Record Created Sucessfully.");
    //},
};

