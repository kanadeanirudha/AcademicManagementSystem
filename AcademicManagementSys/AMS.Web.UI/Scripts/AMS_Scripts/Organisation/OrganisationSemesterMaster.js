//var OrganisationSemesterMaster = {
//    variable: null,
//    Initialize: function () {
       
//        OrganisationSemesterMaster.constructor();
//    },
//    constructor: function () {
      
     

//        $('#CreateOrganisationSemesterMasterRecord').on("click", function () {
//            OrganisationSemesterMaster.ActionName = "Create";
//            OrganisationSemesterMaster.AjaxCallOrganisationSemesterMaster();
//        });
//        $('#EditOrganisationSemesterMasterRecord').on("click", function () {
//            OrganisationSemesterMaster.ActionName = "Edit";
//            OrganisationSemesterMaster.AjaxCallOrganisationSemesterMaster();
//        });
//        $('#DeleteOrganisationSemesterMasterRecord').on("click", function () {
//            OrganisationSemesterMaster.ActionName = "Delete";
//            OrganisationSemesterMaster.AjaxCallOrganisationSemesterMaster();
//        });
//        $('#closeBtn').on("click", function () {
//            parent.$.colorbox.close();
//        });
//        $("#UserSearch").on("keyup", function () {
//            var oTable = $("#myDataTable").dataTable();
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
//        $('#reset').on("click", function () {
//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#OrgSemesterName').focus();
//            $('#SemesterType').val("E");
//            return false;
//        });
//    },
//    LoadList: function () {
//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            dataType: "html",
//            url: '/OrganisationSemesterMaster/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $('#ListViewModel').html(data);
//            }
//        });
//    },
//    ReloadList: function (message, colorCode, actionMode) {
//        $.ajax(
//       {
//           cache: false,
//           type: "POST",
//           dataType: "html",
//           data: { "actionMode": actionMode },
//           url: '/OrganisationSemesterMaster/List',
//           success: function (data) {
//               //Rebind Grid Data
//               $("#ListViewModel").empty().append(data);
//               //twitter type notification
//               $('#SuccessMessage').html(message);
//               $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
//           }
//       });
//    },

//    AjaxCallOrganisationSemesterMaster: function () {
//        var OrganisationSemesterMasterMasterData = null;
//        if (OrganisationSemesterMaster.ActionName == "Create") {
//            $("#FormCreateOrganisationSemesterMaster").validate();
//            if ($("#FormCreateOrganisationSemesterMaster").valid()) {

//                OrganisationSemesterMasterMasterData = OrganisationSemesterMaster.GetOrganisationSemesterMasterMaster();
//                ajaxRequest.makeRequest("/OrganisationSemesterMaster/Create", "POST", OrganisationSemesterMasterMasterData, OrganisationSemesterMaster.Success);
//            }
//        }
//        else if (OrganisationSemesterMaster.ActionName == "Edit") {
//            $("#FormEditOrganisationSemesterMaster").validate();
//            if ($("#FormEditOrganisationSemesterMaster").valid()) {

//                OrganisationSemesterMasterMasterData = OrganisationSemesterMaster.GetOrganisationSemesterMasterMaster();
//                ajaxRequest.makeRequest("/OrganisationSemesterMaster/Edit", "POST", OrganisationSemesterMasterMasterData, OrganisationSemesterMaster.Success);
//            }
//        }
//        else if (OrganisationSemesterMaster.ActionName == "Delete") {

//            OrganisationSemesterMasterMasterData = OrganisationSemesterMaster.GetOrganisationSemesterMasterMaster();
//            ajaxRequest.makeRequest("/OrganisationSemesterMaster/Delete", "POST", OrganisationSemesterMasterMasterData, OrganisationSemesterMaster.Success);
//        }
//    },

//    GetOrganisationSemesterMasterMaster: function () {
//        var Data = {
//        };
//        if (OrganisationSemesterMaster.ActionName == "Create" || OrganisationSemesterMaster.ActionName == "Edit") {
//            Data.ID = $('#ID').val();
//            Data.OrgSemesterName = $('#OrgSemesterName').val();
//            Data.SemesterType = $('#SemesterType').val();
//            Data.SemesterCode = $('#SemesterCode').val();
//        }
//        else if (OrganisationSemesterMaster.ActionName == "Delete") {
//            Data.ID = $('input[name=ID]').val();
//        }
//        return Data;
//    },

//    Success: function (data) {
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            OrganisationSemesterMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            OrganisationSemesterMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },
//    //editSuccess: function (data) {
//    //    parent.$.colorbox.close();
//    //    //if ($("#update-message").html() == "True") {
//    //    //    //Reload List
//    //    OrganisationSemesterMaster.ReloadList("Record Updated Sucessfully.");
//    //    //} else {
//    //    //    $("#update-message").show();
//    //    //}
//    //},
//    //deleteSuccess: function (data) {
//    //    parent.$.colorbox.close();
//    //    //if ($("#update-message").html() == "True") {
//    //    //    //Reload List
//    //    OrganisationSemesterMaster.ReloadList("Record Deleted Sucessfully.");
//    //    //} else {
//    //    //    $("#update-message").show();
//    //    //}
//    //},
//};


////////new js//////////////

var OrganisationSemesterMaster = {
    variable: null,
    Initialize: function () {

        OrganisationSemesterMaster.constructor();
    },
    constructor: function () {



        $('#CreateOrganisationSemesterMasterRecord').on("click", function () {
            OrganisationSemesterMaster.ActionName = "Create";
            OrganisationSemesterMaster.AjaxCallOrganisationSemesterMaster();
        });
        $('#EditOrganisationSemesterMasterRecord').on("click", function () {
            OrganisationSemesterMaster.ActionName = "Edit";
            OrganisationSemesterMaster.AjaxCallOrganisationSemesterMaster();
        });
        $('#DeleteOrganisationSemesterMasterRecord').on("click", function () {
            OrganisationSemesterMaster.ActionName = "Delete";
            OrganisationSemesterMaster.AjaxCallOrganisationSemesterMaster();
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
        InitAnimatedBorder();
        CloseAlert();
        $('#reset').on("click", function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#OrgSemesterName').focus();
            $('#SemesterType').val("E");
            return false;
        });
    },
    LoadList: function () {
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            url: '/OrganisationSemesterMaster/List',
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
           url: '/OrganisationSemesterMaster/List',
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

    AjaxCallOrganisationSemesterMaster: function () {
        var OrganisationSemesterMasterMasterData = null;
        if (OrganisationSemesterMaster.ActionName == "Create") {
            $("#FormCreateOrganisationSemesterMaster").validate();
            if ($("#FormCreateOrganisationSemesterMaster").valid()) {

                OrganisationSemesterMasterMasterData = OrganisationSemesterMaster.GetOrganisationSemesterMasterMaster();
                ajaxRequest.makeRequest("/OrganisationSemesterMaster/Create", "POST", OrganisationSemesterMasterMasterData, OrganisationSemesterMaster.Success);
            }
        }
        else if (OrganisationSemesterMaster.ActionName == "Edit") {
            $("#FormEditOrganisationSemesterMaster").validate();
            if ($("#FormEditOrganisationSemesterMaster").valid()) {

                OrganisationSemesterMasterMasterData = OrganisationSemesterMaster.GetOrganisationSemesterMasterMaster();
                ajaxRequest.makeRequest("/OrganisationSemesterMaster/Edit", "POST", OrganisationSemesterMasterMasterData, OrganisationSemesterMaster.Success);
            }
        }
        else if (OrganisationSemesterMaster.ActionName == "Delete") {

            OrganisationSemesterMasterMasterData = OrganisationSemesterMaster.GetOrganisationSemesterMasterMaster();
            ajaxRequest.makeRequest("/OrganisationSemesterMaster/Delete", "POST", OrganisationSemesterMasterMasterData, OrganisationSemesterMaster.Success);
        }
    },

    GetOrganisationSemesterMasterMaster: function () {
        var Data = {
        };
        if (OrganisationSemesterMaster.ActionName == "Create" || OrganisationSemesterMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.OrgSemesterName = $('#OrgSemesterName').val();
            Data.SemesterType = $('#SemesterType').val();
            Data.SemesterCode = $('#SemesterCode').val();
        }
        else if (OrganisationSemesterMaster.ActionName == "Delete") {
            Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            OrganisationSemesterMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            OrganisationSemesterMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //editSuccess: function (data) {
    //    parent.$.colorbox.close();
    //    //if ($("#update-message").html() == "True") {
    //    //    //Reload List
    //    OrganisationSemesterMaster.ReloadList("Record Updated Sucessfully.");
    //    //} else {
    //    //    $("#update-message").show();
    //    //}
    //},
    //deleteSuccess: function (data) {
    //    parent.$.colorbox.close();
    //    //if ($("#update-message").html() == "True") {
    //    //    //Reload List
    //    OrganisationSemesterMaster.ReloadList("Record Deleted Sucessfully.");
    //    //} else {
    //    //    $("#update-message").show();
    //    //}
    //},
};


