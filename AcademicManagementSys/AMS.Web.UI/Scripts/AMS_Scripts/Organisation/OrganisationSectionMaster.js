//var OrganisationSectionMaster = {
//    variable: null,
//    Initialize: function () {
//        OrganisationSectionMaster.constructor();
//    },
//    constructor: function () {

//        $('#CreateOrganisationSectionMasterRecord').on("click", function () {
//            OrganisationSectionMaster.ActionName = "Create";
//            OrganisationSectionMaster.AjaxCallOrganisationSectionMaster();
//        });
//        $('#EditOrganisationSectionMasterRecord').on("click", function () {
//            OrganisationSectionMaster.ActionName = "Edit";
//            OrganisationSectionMaster.AjaxCallOrganisationSectionMaster();
//        });
//        $('#DeleteOrganisationSectionMasterRecord').on("click", function () {
//            OrganisationSectionMaster.ActionName = "Delete";
//            OrganisationSectionMaster.AjaxCallOrganisationSectionMaster();
//        });
//        $('#closeBtn').on("click", function () {
//            parent.$.colorbox.close();
//        });
//        $("#UserSearch").keyup(function () {
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
//            $('#SectionName').focus();
//            return false;
//        });
//    },
//    LoadList: function () {
//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            dataType: "html",
//            url: '/OrganisationSectionMaster/List',
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
//           url: '/OrganisationSectionMaster/List',
//           success: function (data) {
//               //Rebind Grid Data
//               $("#ListViewModel").empty().append(data);
//               //twitter type notification
//               $('#SuccessMessage').html(message);
//               $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
//           }
//       });
//    },

//    AjaxCallOrganisationSectionMaster: function () {
//        var OrganisationSectionMasterMasterData = null;
//        if (OrganisationSectionMaster.ActionName == "Create") {
//            $("#FormCreateOrganisationSectionMaster").validate();
//            if ($("#FormCreateOrganisationSectionMaster").valid()) {

//                OrganisationSectionMasterMasterData = OrganisationSectionMaster.GetOrganisationSectionMasterMaster();
//                ajaxRequest.makeRequest("/OrganisationSectionMaster/Create", "POST", OrganisationSectionMasterMasterData, OrganisationSectionMaster.Success);
//            }
//        }
//        else if (OrganisationSectionMaster.ActionName == "Edit") {
//            $("#FormEditOrganisationSectionMasterMaster").validate();
//            if ($("#FormEditOrganisationSectionMasterMaster").valid()) {

//                OrganisationSectionMasterMasterData = OrganisationSectionMaster.GetOrganisationSectionMasterMaster();
//                ajaxRequest.makeRequest("/OrganisationSectionMaster/Edit", "POST", OrganisationSectionMasterMasterData, OrganisationSectionMaster.Success);
//            }
//        }
//        else if (OrganisationSectionMaster.ActionName == "Delete") {

//            OrganisationSectionMasterMasterData = OrganisationSectionMaster.GetOrganisationSectionMasterMaster();
//            ajaxRequest.makeRequest("/OrganisationSectionMaster/Delete", "POST", OrganisationSectionMasterMasterData, OrganisationSectionMaster.Success);
//        }
//    },

//    GetOrganisationSectionMasterMaster: function () {
//        var Data = {
//        };
//        if (OrganisationSectionMaster.ActionName == "Create" || OrganisationSectionMaster.ActionName == "Edit") {
//            Data.ID = $('#ID').val();
//            Data.SectionName = $('#SectionName').val();
//        }
//        else if (OrganisationSectionMaster.ActionName == "Delete") {
//            Data.ID = $('input[name=ID]').val();
//        }
//        return Data;
//    },

//    Success: function (data) {
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            OrganisationSectionMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            OrganisationSectionMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },
//    //editSuccess: function (data) {
//    //    parent.$.colorbox.close();
//    //    //if ($("#update-message").html() == "True") {
//    //    //    //Reload List
//    //    OrganisationSectionMaster.ReloadList("Record Updated Sucessfully.");
//    //    //} else {
//    //    //    $("#update-message").show();
//    //    //}
//    //},
//    //deleteSuccess: function (data) {
//    //    parent.$.colorbox.close();
//    //    //if ($("#update-message").html() == "True") {
//    //    //    //Reload List
//    //    OrganisationSectionMaster.ReloadList("Record Deleted Sucessfully.");
//    //    //} else {
//    //    //    $("#update-message").show();
//    //    //}
//    //},
//};


//////////new js/////////////


var OrganisationSectionMaster = {
    variable: null,
    Initialize: function () {
        OrganisationSectionMaster.constructor();
    },
    constructor: function () {

        $('#CreateOrganisationSectionMasterRecord').on("click", function () {
            OrganisationSectionMaster.ActionName = "Create";
            OrganisationSectionMaster.AjaxCallOrganisationSectionMaster();
        });
        $('#EditOrganisationSectionMasterRecord').on("click", function () {
            OrganisationSectionMaster.ActionName = "Edit";
            OrganisationSectionMaster.AjaxCallOrganisationSectionMaster();
        });
        $('#DeleteOrganisationSectionMasterRecord').on("click", function () {
            OrganisationSectionMaster.ActionName = "Delete";
            OrganisationSectionMaster.AjaxCallOrganisationSectionMaster();
        });
        $('#closeBtn').on("click", function () {
            parent.$.colorbox.close();
        });
        $("#UserSearch").keyup(function () {
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

        $('#reset').on("click", function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#SectionName').focus();
            return false;
        });
    },
    LoadList: function () {
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            url: '/OrganisationSectionMaster/List',
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
           url: '/OrganisationSectionMaster/List',
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

    AjaxCallOrganisationSectionMaster: function () {
        var OrganisationSectionMasterMasterData = null;
        if (OrganisationSectionMaster.ActionName == "Create") {
            $("#FormCreateOrganisationSectionMaster").validate();
            if ($("#FormCreateOrganisationSectionMaster").valid()) {

                OrganisationSectionMasterMasterData = OrganisationSectionMaster.GetOrganisationSectionMasterMaster();
                ajaxRequest.makeRequest("/OrganisationSectionMaster/Create", "POST", OrganisationSectionMasterMasterData, OrganisationSectionMaster.Success);
            }
        }
        else if (OrganisationSectionMaster.ActionName == "Edit") {
            $("#FormEditOrganisationSectionMasterMaster").validate();
            if ($("#FormEditOrganisationSectionMasterMaster").valid()) {

                OrganisationSectionMasterMasterData = OrganisationSectionMaster.GetOrganisationSectionMasterMaster();
                ajaxRequest.makeRequest("/OrganisationSectionMaster/Edit", "POST", OrganisationSectionMasterMasterData, OrganisationSectionMaster.Success);
            }
        }
        else if (OrganisationSectionMaster.ActionName == "Delete") {

            OrganisationSectionMasterMasterData = OrganisationSectionMaster.GetOrganisationSectionMasterMaster();
            ajaxRequest.makeRequest("/OrganisationSectionMaster/Delete", "POST", OrganisationSectionMasterMasterData, OrganisationSectionMaster.Success);
        }
    },

    GetOrganisationSectionMasterMaster: function () {
        var Data = {
        };
        if (OrganisationSectionMaster.ActionName == "Create" || OrganisationSectionMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.SectionName = $('#SectionName').val();
        }
        else if (OrganisationSectionMaster.ActionName == "Delete") {
            Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            $.magnificPopup.close();
            OrganisationSectionMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            $.magnificPopup.close();
            OrganisationSectionMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //editSuccess: function (data) {
    //    parent.$.colorbox.close();
    //    //if ($("#update-message").html() == "True") {
    //    //    //Reload List
    //    OrganisationSectionMaster.ReloadList("Record Updated Sucessfully.");
    //    //} else {
    //    //    $("#update-message").show();
    //    //}
    //},
    //deleteSuccess: function (data) {
    //    parent.$.colorbox.close();
    //    //if ($("#update-message").html() == "True") {
    //    //    //Reload List
    //    OrganisationSectionMaster.ReloadList("Record Deleted Sucessfully.");
    //    //} else {
    //    //    $("#update-message").show();
    //    //}
    //},
};


