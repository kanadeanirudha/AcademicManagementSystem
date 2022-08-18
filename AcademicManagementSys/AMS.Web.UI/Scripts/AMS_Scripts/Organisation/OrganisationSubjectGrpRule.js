//var OrganisationSubjectGrpRule = {

//    ActionName: null,
//    NumberOfSemester: null,
//    _subjectGroupRuleID : null,

//    Initialize: function () {
        
//        OrganisationSubjectGrpRule.constructor();
       
//    },

//    constructor: function () {

//        // Methods for Create/Edit View
//        $('#OrganisationSubjectGrpRuleNextbtn').click(function () {
            
//            //OrganisationSubjectGrpRule.ActionName = "CreateSubjectRule";
//            //OrganisationSubjectGrpRule.AjaxCallOrganisationSubjectGrpRule();
//            var val = $('#RuleName').val();
//            $('#ruleName').text(val).css("font-weight", "Bold");
//           $('#myTab li:eq(1) a').tab('show');
//        });
//        // SubElectiveGrpRule DropDown Load Method
//        $('#OrganisationElectiveGrpRuleNextbtn').click(function () {
           
//            $('#myTab li:eq(2) a').tab('show')

//            var Selectedval;
//            var $ddlElectiveGroup = $("#OrgElectiveGrpID");
//            var $ElectiveGroupProgress = $("#states-loading-progress");
//            if ($('input[name=ID]').val() > 0) {
//                 Selectedval = $('input[name=ID]').val();
//            }
//            else {
//                Selectedval = OrganisationSubjectGrpRule._subjectGroupRuleID;
//            }

//            $.ajax({
//                cache: false,
//                type: "GET",
//                url: "/OrganisationSubjectGrpRule/LoadElectiveGroupList",
//                data: { "SelectedSubjectGrpRuleID": Selectedval },
//                success: function (data) {
//                    $ddlElectiveGroup.html('');
//                    $ddlElectiveGroup.append('<option value="">---Select Elective Group---</option>');
//                    $.each(data, function (id, option) {

//                        $ddlElectiveGroup.append($('<option></option>').val(option.id).html(option.name));
//                    });
//                    $ElectiveGroupProgress.hide();
                  
//                },
//                error: function (xhr, ajaxOptions, thrownError) {
//                    alert('Failed to retrieve Elective Group.');
//                    $ElectiveGroupProgress.hide();
//                }
//            });
           
//        });
//        $('#OrganisationElectiveGrpRulePreviousbtn').click(function () {
//            if (OrganisationSubjectGrpRule._subjectGroupRuleID > 0) {
//                $('input[name=ID]').val(OrganisationSubjectGrpRule._subjectGroupRuleID);
//            }
            
//            $('#myTab li:eq(0) a').tab('show')
//        });
//        $('#OrganisationSubElectiveGrpRulePreviousbtn').click(function () {
//            $('#myTab li:eq(1) a').tab('show')
//        });
//        $('#myTab li:eq(0) a').click(function () {
//            return false;
//            //
//            //if (OrganisationSubjectGrpRule._subjectGroupRuleID > 0) {
//            //    $('input[name=ID]').val(OrganisationSubjectGrpRule._subjectGroupRuleID);
//            //}

//            //$('#myTab li:eq(0) a').tab('show')
//        });
//        $('#myTab li:eq(1) a').click(function () {
//            return false;
//            //
//            ////if ($('input[name=ID]').val() <= 0 && OrganisationSubjectGrpRule._subjectGroupRuleID <= 0) {
            
//            //    if ($('#RuleName').val() != "" && $('#RuleCode').val() != "" && $('#MaxCompulsorySubjects').val() > 0 && $('#MaxOptSubjects').val() >= 0 && $('#TotalSubjects').val() > 0 && $('#NoOfOptSubjects').val() >= 0 && $('#MaxGroups').val() >= 0 && $('#MaxNoOfCompulsoryGroups').val() >= 0) {

//            //        OrganisationSubjectGrpRule.ActionName = "CreateSubjectRule";
//            //        OrganisationSubjectGrpRule.AjaxCallOrganisationSubjectGrpRule();
//            //        var val = $('#RuleName').val();
//            //        $('#ruleName').text(val).css("font-weight", "Bold");
//            //        //$('#myTableElectiveGroupRule tbody tr').remove();
//            //        $('#myTab li:eq(1) a').tab('show');
//            //    }
//            //    else {
//            //        alert("Please enter required fields !")
//            //        return false;
//            //    }
//            ////}
//            ////else {
//            ////    return true;
//            ////}


//        });
//        $('#myTab li:eq(2) a').click(function () {
//            return false;
//            //
//            ////if ($('input[name=ID]').val() <= 0 && OrganisationSubjectGrpRule._subjectGroupRuleID <= 0) {
//            //    if ($('#RuleName').val() != "" && $('#RuleCode').val() != "" && $('#MaxCompulsorySubjects').val() > 0 && $('#MaxOptSubjects').val() >= 0 && $('#TotalSubjects').val() > 0 && $('#NoOfOptSubjects').val() >= 0 && $('#MaxGroups').val() >= 0 && $('#MaxNoOfCompulsoryGroups').val() >= 0) {

//            //        OrganisationSubjectGrpRule.ActionName = "CreateSubjectRule";
//            //        OrganisationSubjectGrpRule.AjaxCallOrganisationSubjectGrpRule();
//            //        var val = $('#RuleName').val();
//            //        $('#ruleName').text(val).css("font-weight", "Bold");
//            //        //$('#myTableElectiveGroupRule tbody tr').remove();
//            //        $('#myTab li:eq(2) a').tab('show');

//            //    }
//            //    else {
//            //        alert("Please enter required fields !")
//            //        return false;
//            //    }
//            //}
//            //else {

//            //    if ($('input[name=ID]').val() > 0) {
//            //        var Selectedval = $('input[name=ID]').val();
//            //        $('#OrgElectiveGrpID').load('/OrganisationSubjectGrpRule/CreateElectiveSubGroup?SelectedSubjectGrpRuleID=' + Selectedval);
//            //    }
//            //    else {
//            //        $('#OrgElectiveGrpID').load('/OrganisationSubjectGrpRule/CreateElectiveSubGroup?SelectedSubjectGrpRuleID=' + OrganisationSubjectGrpRule._subjectGroupRuleID);
//            //    }
//            //    return true;
//            //}

//        });


//        $("#TotalSubjects").attr('readonly', true);
//        $("#OrganisationSubjectGrpRuleNextbtn").css('visibility', 'hidden');
//        $("#MaxOptSubjects").change(function () {

//            var bb =parseInt($("#MaxOptSubjects").val());
//            var aa =parseInt($('#MaxCompulsorySubjects').val());
//            if (aa > 0) {               
//                var cc  = aa + bb;
//                $('#TotalSubjects').val(cc); 
//            }
//            //if (bb == 0) {
                
//            //   $("#OrganisationSubjectGrpRuleNextbtn").css('visibility', 'hidden');
//            //   $("#CreateOrgMainRuleRecord").css('visibility', 'visible');
//            //}
//            //else {
//            //    $("#OrganisationSubjectGrpRuleNextbtn").css('visibility', 'visible');
//            //    $("#CreateOrgMainRuleRecord").css('visibility', 'hidden');
//            //}
//        });
       
//        if (parseInt($("#ID").val()) > 0) {
//            $("#OrganisationSubjectGrpRuleNextbtn").css('visibility', 'visible');
//            $("#CreateOrgMainRuleRecord").css('visibility', 'visible');
//        }
//        else {
//            $("#OrganisationSubjectGrpRuleNextbtn").css('visibility', 'hidden');
//            $("#CreateOrgMainRuleRecord").css('visibility', 'visible');
//        }
//        $("#MaxCompulsorySubjects").change(function () {

//            var bb = parseInt($("#MaxOptSubjects").val());
//            var aa = parseInt($('#MaxCompulsorySubjects').val());
         
//                var cc = aa + bb;
//                $('#TotalSubjects').val(cc);         
//        });
//        $('#AddGroup').on("click", function () {
 
           
//            //if ($('#GroupName').val() != "" && $('#GroupShortCode').val() != "" && $('#NoOfSubGroups').val() > 0 && $('#NoOfCompulsorySubGrp').val() >= 0 && $('#NoOfSubGrpSubjectSelect').val() >= 0) {
//                OrganisationSubjectGrpRule.ActionName = "CreateGroupRule";
//                OrganisationSubjectGrpRule.AjaxCallOrganisationSubjectGrpRule();
//                $('input[name=OrgElectiveGrpMasterID]').val(0);
//                $('#GroupName').val(" ");
//                $('#GroupShortCode').val(' ');
//                $('#NoOfSubGroups').val(0);
//                $('#NoOfCompulsorySubGrp').val(0);
//                $('#NoOfSubGrpSubjectSelect').val(0);
//                $('#GroupCompulsoryFlag').attr('checked', false);
//           // }
           
//        });        
//        $('#btnAddSubGroup').on("click", function () {
            

//            //  if ($('#OrgSubElectiveGrpDescription').val() != "" && $('#ShortDescription').val() != "" && $('#TotalNoOfSubjects').val() > 0 && $('#AllowToSelect').val() >= 0 ) {
               
//            OrganisationSubjectGrpRule.ActionName = "CreateSubGroupRule";
//            OrganisationSubjectGrpRule.AjaxCallOrganisationSubjectGrpRule();
//            $('#OrgSubElectiveGrpMasterID').val(0);
//            $('#OrgSubElectiveGrpDescription').val("");
//            $('#ShortDescription').val("");
//            $('#TotalNoOfSubjects').val(0);
//            $('#AllowToSelect').val(0);
//            $("#SubGroupCompulsoryFlag").attr('checked', false);
//        //}
//        });
//        $('#CreateOrgMainRuleRecord').on("click", function () {
//            OrganisationSubjectGrpRule.ActionName = "CreateSubjectRule";
//            OrganisationSubjectGrpRule.AjaxCallOrganisationSubjectGrpRule();
//        });
//        $('#OrgElectiveGrpID').change(function () {
            
//            ReloadElectiveSubGroupRuleTable();
//            //SelectedVal = $(this).val();
//            //OrganisationSubjectGrpRuleData = null;
//            //ajaxRequest.makeRequest("/OrganisationSubjectGrpRule/CreateElectiveSubGroup?GroupRuleID="+SelectedVal, "POST", OrganisationSubjectGrpRuleData, OrganisationSubjectGrpRule.createSubGroupRuleList);
//        });


//        $("#SelectedCentreCode").change(function () {
//            var selectedItem = $(this).val();
//            var $ddlUniversity = $("#SelectedUniversityID");
//            var $UniversityProgress = $("#states-loading-progress");
//            $UniversityProgress.show();
//            if ($("#SelectedCentreCode").val() != "") {
//                $.ajax({
//                    cache: false,
//                    type: "GET",
//                    url: "/OrganisationSubjectGrpRule/GetUniversityByCentreCode",

//                    data: { "SelectedCentreCode": selectedItem },
//                    success: function (data) {
//                        $ddlUniversity.html('');
//                        $ddlUniversity.append('<option value="">--Select University-</option>');
//                        $.each(data, function (id, option) {

//                            $ddlUniversity.append($('<option></option>').val(option.id).html(option.name));
//                        });
//                        $UniversityProgress.hide();
//                    },
//                    error: function (xhr, ajaxOptions, thrownError) {
//                        alert('Failed to retrieve University.');
//                        $UniversityProgress.hide();
//                    }
//                });
//            }
//            else {
//                $('#myDataTable tbody').empty();
//                $('#SelectedUniversityID').find('option').remove().end().append('<option value>---Select University---</option>');
//                $('#btnCreate').hide();
//            }
//            $('#myDataTable').html("");
//            $('#myDataTable_info').text("No entries to show");
//            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
//        });
//        $('#SelectedUniversityID').on("change", function () {
         
//            $('#myDataTable').html("");
//            $('#myDataTable_info').text("No entries to show");
//            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
//        });

//        $('#btnShowList').click(function () {
            
//            var valuCentreCode = $('#SelectedCentreCode :selected').val();
//            var valuUniversityID = $('#SelectedUniversityID :selected').val();
//            if (valuCentreCode != "" && valuUniversityID > 0) {
//                OrganisationSubjectGrpRule.LoadListByCentreCodeAndUniversityID(valuCentreCode, valuUniversityID);
//            }
//            else if (valuCentreCode != "" && valuUniversityID <= 0) {
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectUniversity", "SuccessMessage", "#FFCC80");
//                //$('#SuccessMessage').html("Please select university");
//                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
//                $('#DivCreateNew').hide(true);
//            }
//            else if ((valuCentreCode == "" && valuUniversityID <= 0)) {
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
//                //$('#SuccessMessage').html("Please select centre");
//                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
//                $('#DivCreateNew').hide(true);
//            }
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
//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#StreamID').focus();
//            var dt = new Date();
//            $('#StreamID').val("");
//            $('#MediumID').val("");
//            $('#StandardID').val("");
//            $('#StreamID').val("");
//            return false;
//        });
//        $(".ajax").colorbox();

//        $('#myTableElectiveGroupRule tr').hover(function () {
//            $(this).css('cursor', 'pointer');
//        }); 

//        $('#myTableSubElectiveGroupRule tr').hover(function () {
//            $(this).css('cursor', 'pointer');
//        });

        
//        $("#myTableElectiveGroupRule tbody").on("click", "tr td i", function (event) {

           
//            var $td = $(this).closest('tr').find('td');
//            var jGroupName = $td.eq(0).text();
//            var jGroupShortCode = $td.eq(1).text();
//            var jNoOfSubGroups = $td.eq(2).text();
//            var jNoOfCompulsorySubGrp = $td.eq(3).text();
//            var splitData = $td.eq(5).find('input[type="hidden"]').val().split('~');
//            var jOrgElectiveGrpMasterID = splitData[0];
//            var jNoOfSubGrpSubjectSelect = splitData[1];
//            var jGroupCompulsoryFlag = splitData[2];

           

//            $('input[name=OrgElectiveGrpMasterID]').val(jQuery.trim(jOrgElectiveGrpMasterID));
//            $('#NoOfSubGrpSubjectSelect').val(jQuery.trim(jNoOfSubGrpSubjectSelect));
//            $('input[name=OrgElectiveGrpMasterID]').val(jQuery.trim(jOrgElectiveGrpMasterID));
//            $('#GroupName').val(jQuery.trim(jGroupName));
//            $('#GroupShortCode').val(jQuery.trim(jGroupShortCode));
//            $('#NoOfSubGroups').val(jQuery.trim(jNoOfSubGroups));
//            $('#NoOfCompulsorySubGrp').val(jQuery.trim(jNoOfCompulsorySubGrp));
//            if (jGroupCompulsoryFlag == "True") {
//                $('#GroupCompulsoryFlag').prop("checked", true);
//            }
//            else if (jGroupCompulsoryFlag == "False") {
//                $("#GroupCompulsoryFlag").prop("checked", false);
//            }


//        });

//        $("#myTableElectiveSubGroupRule tbody").on("click", "tr td i", function (event) {


//            var $td = $(this).closest('tr').children('td');
//            var jOrgSubElectiveGrpDescription = $td.eq(0).text();
//            var jShortDescription = $td.eq(1).text();
//            var jTotalNoOfSubjects = $td.eq(2).text();
//            var jAllowToSelect = $td.eq(3).text();
//            var splitData = $td.eq(5).find('input[type="hidden"]').val().split('~');
//            var jOrgSubElectiveGrpMasterID = splitData[0];
//            var jSubGrpCompulsoryFlag = splitData[1];

//            $('input[name=OrgSubElectiveGrpMasterID]').val(jQuery.trim(jOrgSubElectiveGrpMasterID));
//            $('#OrgSubElectiveGrpDescription').val(jQuery.trim(jOrgSubElectiveGrpDescription));
//            $('input[name=ShortDescription]').val(jQuery.trim(jShortDescription));
//            $('#TotalNoOfSubjects').val(jQuery.trim(jTotalNoOfSubjects));
//            $('#AllowToSelect').val(jQuery.trim(jAllowToSelect));
//            if (jSubGrpCompulsoryFlag == "True") {
//                $('#SubGroupCompulsoryFlag').prop("checked", true);
//            }
//            else if (jSubGrpCompulsoryFlag == "False") {
//                $("#SubGroupCompulsoryFlag").prop("checked", false);
//            }


//        });
//    },

//    LoadList: function () {
//        $.ajax(
//         {
//             cache: false,
//             type: "POST",
//             dataType: "html",
//             url: '/OrganisationSubjectGrpRule/List',
//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//             }
//         });
//    },

//    ReloadList: function (message) {
//        var SelectedCentreCode = $('#SelectedCentreCode :selected').val();
//        var SelectedUniversityID = $('#SelectedUniversityID option:selected').val();
//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            data: { centerCode: SelectedCentreCode, universityID: SelectedUniversityID },
//            dataType: "html",
//            url: '/OrganisationSubjectGrpRule/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#commonMessage').html(message);
//                $('#commonMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', '#5C8AE6');
//            }
//        });
//    },

//    LoadListByCentreCodeAndUniversityID: function (SelectedCentreCode, SelectedUniversityID) {

//        var selectedText = $('#SelectedUniversityID').text();
//        var selectedVal = $('#SelectedUniversityID').val();
//        $.ajax(
//          {
//              cache: false,
//              type: "POST",
//              data: { centerCode: SelectedCentreCode, universityID: SelectedUniversityID },
//              dataType: "html",
//              url: '/OrganisationSubjectGrpRule/List',
//              success: function (result) {
//                  //Rebind Grid Data                
//                  $('#ListViewModel').html(result);

//              }
//          });
//    },

//    AjaxCallOrganisationSubjectGrpRule: function () {
        
//        var OrganisationSubjectGrpRuleData = null;
//        if (OrganisationSubjectGrpRule.ActionName == "CreateSubjectRule") {
//            $("#FormCreateOrganisationSubjectGrpRule").validate();
//            if ($("#FormCreateOrganisationSubjectGrpRule").valid()) {
//                OrganisationSubjectGrpRuleData = null;
//                OrganisationSubjectGrpRuleData = OrganisationSubjectGrpRule.GetOrganisationSubjectGrpRule();

//                ajaxRequest.makeRequest("/OrganisationSubjectGrpRule/CreateSubjectGroupRule", "POST", OrganisationSubjectGrpRuleData, OrganisationSubjectGrpRule.createRuleSuccess);
//            }


//        }
//        else if (OrganisationSubjectGrpRule.ActionName == "CreateGroupRule") {
//            $("#FormCreateOrganisationSubjectGrpRule").validate();
//            if ($("#FormCreateOrganisationSubjectGrpRule").valid()) {
//                OrganisationSubjectGrpRuleData = null; 
//                Selectedval = $('#MaxGroups').val();
//                OrganisationSubjectGrpRuleData = OrganisationSubjectGrpRule.GetOrganisationSubjectGrpRule();           
//                ajaxRequest.makeRequest("/OrganisationSubjectGrpRule/CreateElectiveGroup?TotalNumberOfMaxGroups=" + Selectedval, "POST", OrganisationSubjectGrpRuleData, OrganisationSubjectGrpRule.createGroupRuleSuccess);
               

//            }
//        }
//        else if (OrganisationSubjectGrpRule.ActionName == "CreateSubGroupRule") {
//            $("#FormCreateOrganisationSubjectGrpRule").validate();
//            if ($("#FormCreateOrganisationSubjectGrpRule").valid()) {
//                OrganisationSubjectGrpRuleData = null; 
//                OrganisationSubjectGrpRuleData = OrganisationSubjectGrpRule.GetOrganisationSubjectGrpRule();
//                ajaxRequest.makeRequest("/OrganisationSubjectGrpRule/CreateElectiveSubGroup", "POST", OrganisationSubjectGrpRuleData, OrganisationSubjectGrpRule.createSubGroupRuleSuccess);

//            }

//        }
//    },
   
//    GetOrganisationSubjectGrpRule: function () {
        
//        var Data = {
//        };
//        if (OrganisationSubjectGrpRule.ActionName == "CreateSubjectRule" ) {
   
//            // Properties of table OrgSubjectGrpRule
//            Data.ID = $('input[name=ID]').val();
//            Data.CourseYearSemesterID = $('input[name=CourseYearSemesterID]').val();
//            Data.RuleName = $('#RuleName').val();
//            Data.RuleCode = $('#RuleCode').val();
//            Data.MaxCompulsorySubjects = $('#MaxCompulsorySubjects').val();
//            Data.MaxOptSubjects = $('#MaxOptSubjects').val();
//            Data.TotalSubjects = $('#TotalSubjects').val();
//            Data.NoOfOptSubjects = $('#NoOfOptSubjects').val();
//            Data.MaxGroups = $('#MaxGroups').val();
//            Data.MaxNoOfCompulsoryGroups = $('#MaxNoOfCompulsoryGroups').val();
//            Data.IsActive = $('input[name=IsActive]:checked').val() ? true : false;
          
//        }
//        else if (OrganisationSubjectGrpRule.ActionName == "CreateGroupRule") {
//            // Properties of table OrgElectiveGrpMaster
//            if ($('input[name=ID]').val() > 0) {
//                Data.SubjectRuleGrpNumber = $('input[name=ID]').val();
//            }
//            else {
//                Data.SubjectRuleGrpNumber = OrganisationSubjectGrpRule._subjectGroupRuleID;
//            }
            
//            Data.GroupName = $('#GroupName').val();
//            Data.GroupCompulsoryFlag = $('input[name=GroupCompulsoryFlag]:checked').val() ? true : false;
//            Data.GroupShortCode = $('#GroupShortCode').val();
//            Data.NoOfSubGroups = $('#NoOfSubGroups').val();
//            Data.NoOfCompulsorySubGrp = $('#NoOfCompulsorySubGrp').val();
//            Data.NoOfSubGrpSubjectSelect = $('#NoOfSubGrpSubjectSelect').val();
//            Data.OrgElectiveGrpMasterID = $('input[name=OrgElectiveGrpMasterID]').val();

//        }
//        else if (OrganisationSubjectGrpRule.ActionName == "CreateSubGroupRule") {
//            // Properties of table OrgElectiveSubGrpMaster
//            Data.OrgSubElectiveGrpMasterID = $('#OrgSubElectiveGrpMasterID').val();
//            Data.OrgElectiveGrpID = $('#OrgElectiveGrpID').val();
//            Data.OrgSubElectiveGrpDescription = $('#OrgSubElectiveGrpDescription').val();
//            Data.SubGroupCompulsoryFlag = $('input[name=SubGroupCompulsoryFlag]:checked').val() ? true : false;
//            Data.ShortDescription = $('#ShortDescription').val();
//            Data.TotalNoOfSubjects = $('#TotalNoOfSubjects').val();
//            Data.AllowToSelect = $('#AllowToSelect').val();            
//            Data.ID = $('input[name=ID]').val();

//        } 
//        return Data;
//    },

//    createRuleSuccess: function (data) {
//        var splitData = data.split('~');
//        OrganisationSubjectGrpRule._subjectGroupRuleID = splitData[1];
//        var splitMessage = splitData[0].split(',');
//        $('#DisplayMessage').html(splitMessage[0]);
//        $('#DisplayMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', splitMessage[1]);
//        if (OrganisationSubjectGrpRule._subjectGroupRuleID > 0) {
//            $("#OrganisationSubjectGrpRuleNextbtn").css('visibility', 'visible');
//        }
//        ListViewReload();
//    },
//    createGroupRuleSuccess: function (data) {


//        ReloadElectiveGroupRuleTable();
//        //var dd = data.ListOrganisationSubjectGrpRule[0].OrgElectiveGrpMasterID;
    
//        //if (dd != 0) {
//        //    $('#myTableElectiveGroupRule tbody tr').remove();
//        //    var arrayLength = $('#MaxGroups').val();
//        //    for (var i = 0; i < arrayLength; i++) {
//        //        var tr = "<tr><td style='display:none'>" + data.ListOrganisationSubjectGrpRule[i].OrgElectiveGrpMasterID + "</td><td style='display:none'>" + data.ListOrganisationSubjectGrpRule[i].NoOfCompulsorySubGrp + "</td><td style='display:none'>" + data.ListOrganisationSubjectGrpRule[i].GroupCompulsoryFlag + "</td><td>" + data.ListOrganisationSubjectGrpRule[i].GroupName + "</td><td>" + data.ListOrganisationSubjectGrpRule[i].GroupShortCode + "</td><td>" + data.ListOrganisationSubjectGrpRule[i].NoOfSubGroups + "</td><td>" + data.ListOrganisationSubjectGrpRule[i].NoOfCompulsorySubGrp + "</td><tr>"
//        //        $('#myTableElectiveGroupRule tbody').append(tr);
//        //    }
//        //    OrganisationSubjectGrpRule.SelectElectiveGrpRuleTable();
//        //}
       
//        var splitData = data.errorMessage.split(',')
//        $('#DisplayMessage').html(splitData[0]);
//        $('#DisplayMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', splitData[1]);
        

//        //$('#myTableSubElectiveGroupRule tr').hover(function () {
//        //    $(this).css('cursor', 'pointer');
//        //});

//    },
//    createSubGroupRuleSuccess: function (data) {
        
        
//        ReloadElectiveSubGroupRuleTable()
//        //var bb = data.ListOrganisationSubjectGrpRule[0].OrgSubElectiveGrpMasterID;
//        //    if (bb != 0) {
//        //        $('#myTableSubElectiveGroupRule tbody tr').remove();
//        //        var arrayLength = data.ListOrganisationSubjectGrpRule.length;
//        //        for (var i = 0; i < arrayLength; i++) {
//        //            var tr = "<tr><td style='display:none'>" + data.ListOrganisationSubjectGrpRule[i].OrgSubElectiveGrpMasterID + "</td><td style='display:none'>" + data.ListOrganisationSubjectGrpRule[i].SubGroupCompulsoryFlag + "</td><td>" + data.ListOrganisationSubjectGrpRule[i].OrgSubElectiveGrpDescription + "</td><td>" + data.ListOrganisationSubjectGrpRule[i].ShortDescription + "</td><td>" + data.ListOrganisationSubjectGrpRule[i].TotalNoOfSubjects + "</td><td>" + data.ListOrganisationSubjectGrpRule[i].AllowToSelect + "</td><tr>"
//        //            $('#myTableSubElectiveGroupRule tbody').append(tr);
//        //        }
//        //        OrganisationSubjectGrpRule.SelectSubElectiveGrpRuleTable();
                
//        //    }
           
//            var splitData = data.errorMessage.split(',')
//            $('#DisplayMessage').html(splitData[0]);
//            $('#DisplayMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', splitData[1]);
//            //$('#myTableElectiveGroupRule tr').hover(function () {
//            //    $(this).css('cursor', 'pointer');
//            //});

//            //$('#myTableSubElectiveGroupRule tr').hover(function () {
//            //    $(this).css('cursor', 'pointer');
//            //});

//    },


//};

////////////new js/////////////


var OrganisationSubjectGrpRule = {

    ActionName: null,
    NumberOfSemester: null,
    _subjectGroupRuleID: null,

    Initialize: function () {

        OrganisationSubjectGrpRule.constructor();

    },

    constructor: function () {

        // Methods for Create/Edit View
        $('#OrganisationSubjectGrpRuleNextbtn').click(function () {

            //OrganisationSubjectGrpRule.ActionName = "CreateSubjectRule";
            //OrganisationSubjectGrpRule.AjaxCallOrganisationSubjectGrpRule();
            var val = $('#RuleName').val();
            $('#ruleName').text(val).css("font-weight", "Bold");
            $('#myTab li:eq(1) a').tab('show');
        });
        // SubElectiveGrpRule DropDown Load Method
        $('#OrganisationElectiveGrpRuleNextbtn').click(function () {

            $('#myTab li:eq(2) a').tab('show')

            var Selectedval;
            var $ddlElectiveGroup = $("#OrgElectiveGrpID");
            var $ElectiveGroupProgress = $("#states-loading-progress");
            if ($('input[name=ID]').val() > 0) {
                Selectedval = $('input[name=ID]').val();
            }
            else {
                Selectedval = OrganisationSubjectGrpRule._subjectGroupRuleID;
            }

            $.ajax({
                cache: false,
                type: "GET",
                url: "/OrganisationSubjectGrpRule/LoadElectiveGroupList",
                data: { "SelectedSubjectGrpRuleID": Selectedval },
                success: function (data) {
                    $ddlElectiveGroup.html('');
                    $ddlElectiveGroup.append('<option value="">---Select Elective Group---</option>');
                    $.each(data, function (id, option) {

                        $ddlElectiveGroup.append($('<option></option>').val(option.id).html(option.name));
                    });
                    $ElectiveGroupProgress.hide();

                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert('Failed to retrieve Elective Group.');
                    $ElectiveGroupProgress.hide();
                }
            });

        });
        $('#OrganisationElectiveGrpRulePreviousbtn').click(function () {
            if (OrganisationSubjectGrpRule._subjectGroupRuleID > 0) {
                $('input[name=ID]').val(OrganisationSubjectGrpRule._subjectGroupRuleID);
            }

            $('#myTab li:eq(0) a').tab('show')
        });
        $('#OrganisationSubElectiveGrpRulePreviousbtn').click(function () {
            $('#myTab li:eq(1) a').tab('show')
        });
        $('#myTab li:eq(0) a').click(function () {
            return false;
            //
            //if (OrganisationSubjectGrpRule._subjectGroupRuleID > 0) {
            //    $('input[name=ID]').val(OrganisationSubjectGrpRule._subjectGroupRuleID);
            //}

            //$('#myTab li:eq(0) a').tab('show')
        });
        $('#myTab li:eq(1) a').click(function () {
            return false;
            //
            ////if ($('input[name=ID]').val() <= 0 && OrganisationSubjectGrpRule._subjectGroupRuleID <= 0) {

            //    if ($('#RuleName').val() != "" && $('#RuleCode').val() != "" && $('#MaxCompulsorySubjects').val() > 0 && $('#MaxOptSubjects').val() >= 0 && $('#TotalSubjects').val() > 0 && $('#NoOfOptSubjects').val() >= 0 && $('#MaxGroups').val() >= 0 && $('#MaxNoOfCompulsoryGroups').val() >= 0) {

            //        OrganisationSubjectGrpRule.ActionName = "CreateSubjectRule";
            //        OrganisationSubjectGrpRule.AjaxCallOrganisationSubjectGrpRule();
            //        var val = $('#RuleName').val();
            //        $('#ruleName').text(val).css("font-weight", "Bold");
            //        //$('#myTableElectiveGroupRule tbody tr').remove();
            //        $('#myTab li:eq(1) a').tab('show');
            //    }
            //    else {
            //        alert("Please enter required fields !")
            //        return false;
            //    }
            ////}
            ////else {
            ////    return true;
            ////}


        });
        $('#myTab li:eq(2) a').click(function () {
            return false;
            //
            ////if ($('input[name=ID]').val() <= 0 && OrganisationSubjectGrpRule._subjectGroupRuleID <= 0) {
            //    if ($('#RuleName').val() != "" && $('#RuleCode').val() != "" && $('#MaxCompulsorySubjects').val() > 0 && $('#MaxOptSubjects').val() >= 0 && $('#TotalSubjects').val() > 0 && $('#NoOfOptSubjects').val() >= 0 && $('#MaxGroups').val() >= 0 && $('#MaxNoOfCompulsoryGroups').val() >= 0) {

            //        OrganisationSubjectGrpRule.ActionName = "CreateSubjectRule";
            //        OrganisationSubjectGrpRule.AjaxCallOrganisationSubjectGrpRule();
            //        var val = $('#RuleName').val();
            //        $('#ruleName').text(val).css("font-weight", "Bold");
            //        //$('#myTableElectiveGroupRule tbody tr').remove();
            //        $('#myTab li:eq(2) a').tab('show');

            //    }
            //    else {
            //        alert("Please enter required fields !")
            //        return false;
            //    }
            //}
            //else {

            //    if ($('input[name=ID]').val() > 0) {
            //        var Selectedval = $('input[name=ID]').val();
            //        $('#OrgElectiveGrpID').load('/OrganisationSubjectGrpRule/CreateElectiveSubGroup?SelectedSubjectGrpRuleID=' + Selectedval);
            //    }
            //    else {
            //        $('#OrgElectiveGrpID').load('/OrganisationSubjectGrpRule/CreateElectiveSubGroup?SelectedSubjectGrpRuleID=' + OrganisationSubjectGrpRule._subjectGroupRuleID);
            //    }
            //    return true;
            //}

        });


        $("#TotalSubjects").attr('readonly', true);
        $("#OrganisationSubjectGrpRuleNextbtn").css('visibility', 'hidden');
        $("#MaxOptSubjects").change(function () {

            var bb = parseInt($("#MaxOptSubjects").val());
            var aa = parseInt($('#MaxCompulsorySubjects').val());
            if (aa > 0) {
                var cc = aa + bb;
                $('#TotalSubjects').val(cc);
            }
            //if (bb == 0) {

            //   $("#OrganisationSubjectGrpRuleNextbtn").css('visibility', 'hidden');
            //   $("#CreateOrgMainRuleRecord").css('visibility', 'visible');
            //}
            //else {
            //    $("#OrganisationSubjectGrpRuleNextbtn").css('visibility', 'visible');
            //    $("#CreateOrgMainRuleRecord").css('visibility', 'hidden');
            //}
        });

        if (parseInt($("#ID").val()) > 0) {
            $("#OrganisationSubjectGrpRuleNextbtn").css('visibility', 'visible');
            $("#CreateOrgMainRuleRecord").css('visibility', 'visible');
        }
        else {
            $("#OrganisationSubjectGrpRuleNextbtn").css('visibility', 'hidden');
            $("#CreateOrgMainRuleRecord").css('visibility', 'visible');
        }
        $("#MaxCompulsorySubjects").change(function () {

            var bb = parseInt($("#MaxOptSubjects").val());
            var aa = parseInt($('#MaxCompulsorySubjects').val());

            var cc = aa + bb;
            $('#TotalSubjects').val(cc);
        });
        $('#AddGroup').on("click", function () {


            //if ($('#GroupName').val() != "" && $('#GroupShortCode').val() != "" && $('#NoOfSubGroups').val() > 0 && $('#NoOfCompulsorySubGrp').val() >= 0 && $('#NoOfSubGrpSubjectSelect').val() >= 0) {
            OrganisationSubjectGrpRule.ActionName = "CreateGroupRule";
            OrganisationSubjectGrpRule.AjaxCallOrganisationSubjectGrpRule();
            $('input[name=OrgElectiveGrpMasterID]').val(0);
            $('#GroupName').val(" ");
            $('#GroupShortCode').val(' ');
            $('#NoOfSubGroups').val(0);
            $('#NoOfCompulsorySubGrp').val(0);
            $('#NoOfSubGrpSubjectSelect').val(0);
            $('#GroupCompulsoryFlag').attr('checked', false);
            // }

        });
        $('#btnAddSubGroup').on("click", function () {
            
            //debugger;
            //  if ($('#OrgSubElectiveGrpDescription').val() != "" && $('#ShortDescription').val() != "" && $('#TotalNoOfSubjects').val() > 0 && $('#AllowToSelect').val() >= 0 ) {

            OrganisationSubjectGrpRule.ActionName = "CreateSubGroupRule";
            OrganisationSubjectGrpRule.AjaxCallOrganisationSubjectGrpRule();
            $('#OrgSubElectiveGrpMasterID').val(0);
            $('#OrgSubElectiveGrpDescription').val("");
            $('#ShortDescription').val("");
            $('#TotalNoOfSubjects').val(0);
            $('#AllowToSelect').val(0);
            $("#SubGroupCompulsoryFlag").attr('checked', false);
            //}
        });
        $('#CreateOrgMainRuleRecord').on("click", function () {
            //alert('ok');
            //debugger;
            OrganisationSubjectGrpRule.ActionName = "CreateSubjectRule";
            OrganisationSubjectGrpRule.AjaxCallOrganisationSubjectGrpRule();
        });
        $('#OrgElectiveGrpID').change(function () {

            ReloadElectiveSubGroupRuleTable();
            //SelectedVal = $(this).val();
            //OrganisationSubjectGrpRuleData = null;
            //ajaxRequest.makeRequest("/OrganisationSubjectGrpRule/CreateElectiveSubGroup?GroupRuleID="+SelectedVal, "POST", OrganisationSubjectGrpRuleData, OrganisationSubjectGrpRule.createSubGroupRuleList);
        });


        $("#SelectedCentreCode").change(function () {
            var selectedItem = $(this).val();
            var $ddlUniversity = $("#SelectedUniversityID");
            var $UniversityProgress = $("#states-loading-progress");
            $UniversityProgress.show();
            if ($("#SelectedCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/OrganisationSubjectGrpRule/GetUniversityByCentreCode",

                    data: { "SelectedCentreCode": selectedItem },
                    success: function (data) {
                        $ddlUniversity.html('');
                        $ddlUniversity.append('<option value="">--Select University-</option>');
                        $.each(data, function (id, option) {

                            $ddlUniversity.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $UniversityProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve University.');
                        $UniversityProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#SelectedUniversityID').find('option').remove().end().append('<option value>---Select University---</option>');
                $('#btnCreate').hide();
            }
            //$('#myDataTable').html("");
            //$('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
        });
        $('#SelectedUniversityID').on("change", function () {

            //$('#myDataTable').html("");
            //$('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
        });

        $('#btnShowList').click(function () {

            var valuCentreCode = $('#SelectedCentreCode :selected').val();
            var valuUniversityID = $('#SelectedUniversityID :selected').val();
            if (valuCentreCode != "" && valuUniversityID > 0) {
                OrganisationSubjectGrpRule.LoadListByCentreCodeAndUniversityID(valuCentreCode, valuUniversityID);
            }
            else if (valuCentreCode != "" && valuUniversityID <= 0) {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectUniversity", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("Please select university");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
                $('#DivCreateNew').hide(true);
            }
            else if ((valuCentreCode == "" && valuUniversityID <= 0)) {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("Please select centre");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
                $('#DivCreateNew').hide(true);
            }
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
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#StreamID').focus();
            var dt = new Date();
            $('#StreamID').val("");
            $('#MediumID').val("");
            $('#StandardID').val("");
            $('#StreamID').val("");
            return false;
        });

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();

        $('#myTableElectiveGroupRule tr').hover(function () {
            $(this).css('cursor', 'pointer');
        });

        $('#myTableSubElectiveGroupRule tr').hover(function () {
            $(this).css('cursor', 'pointer');
        });


        $("#myTableElectiveGroupRule tbody").on("click", "tr td i", function (event) {


            var $td = $(this).closest('tr').find('td');
            var jGroupName = $td.eq(0).text();
            var jGroupShortCode = $td.eq(1).text();
            var jNoOfSubGroups = $td.eq(2).text();
            var jNoOfCompulsorySubGrp = $td.eq(3).text();
            var splitData = $td.eq(5).find('input[type="hidden"]').val().split('~');
            var jOrgElectiveGrpMasterID = splitData[0];
            var jNoOfSubGrpSubjectSelect = splitData[1];
            var jGroupCompulsoryFlag = splitData[2];



            $('input[name=OrgElectiveGrpMasterID]').val(jQuery.trim(jOrgElectiveGrpMasterID));
            $('#NoOfSubGrpSubjectSelect').val(jQuery.trim(jNoOfSubGrpSubjectSelect));
            $('input[name=OrgElectiveGrpMasterID]').val(jQuery.trim(jOrgElectiveGrpMasterID));
            $('#GroupName').val(jQuery.trim(jGroupName));
            $('#GroupShortCode').val(jQuery.trim(jGroupShortCode));
            $('#NoOfSubGroups').val(jQuery.trim(jNoOfSubGroups));
            $('#NoOfCompulsorySubGrp').val(jQuery.trim(jNoOfCompulsorySubGrp));
            if (jGroupCompulsoryFlag == "True") {
                $('#GroupCompulsoryFlag').prop("checked", true);
            }
            else if (jGroupCompulsoryFlag == "False") {
                $("#GroupCompulsoryFlag").prop("checked", false);
            }


        });

        $("#myTableElectiveSubGroupRule tbody").on("click", "tr td i", function (event) {


            var $td = $(this).closest('tr').children('td');
            var jOrgSubElectiveGrpDescription = $td.eq(0).text();
            var jShortDescription = $td.eq(1).text();
            var jTotalNoOfSubjects = $td.eq(2).text();
            var jAllowToSelect = $td.eq(3).text();
            var splitData = $td.eq(5).find('input[type="hidden"]').val().split('~');
            var jOrgSubElectiveGrpMasterID = splitData[0];
            var jSubGrpCompulsoryFlag = splitData[1];

            $('input[name=OrgSubElectiveGrpMasterID]').val(jQuery.trim(jOrgSubElectiveGrpMasterID));
            $('#OrgSubElectiveGrpDescription').val(jQuery.trim(jOrgSubElectiveGrpDescription));
            $('input[name=ShortDescription]').val(jQuery.trim(jShortDescription));
            $('#TotalNoOfSubjects').val(jQuery.trim(jTotalNoOfSubjects));
            $('#AllowToSelect').val(jQuery.trim(jAllowToSelect));
            if (jSubGrpCompulsoryFlag == "True") {
                $('#SubGroupCompulsoryFlag').prop("checked", true);
            }
            else if (jSubGrpCompulsoryFlag == "False") {
                $("#SubGroupCompulsoryFlag").prop("checked", false);
            }


        });
    },

    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/OrganisationSubjectGrpRule/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },

    ReloadList: function (message) {
        var SelectedCentreCode = $('#SelectedCentreCode :selected').val();
        var SelectedUniversityID = $('#SelectedUniversityID option:selected').val();
        $.ajax(
        {
            cache: false,
            type: "POST",
            data: { centerCode: SelectedCentreCode, universityID: SelectedUniversityID },
            dataType: "html",
            url: '/OrganisationSubjectGrpRule/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#commonMessage').html(message);
                //$('#commonMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', '#5C8AE6');
                notify(message, '#5C8AE6');
            }
        });
    },

    LoadListByCentreCodeAndUniversityID: function (SelectedCentreCode, SelectedUniversityID) {

        var selectedText = $('#SelectedUniversityID').text();
        var selectedVal = $('#SelectedUniversityID').val();
        $.ajax(
          {
              cache: false,
              type: "POST",
              data: { centerCode: SelectedCentreCode, universityID: SelectedUniversityID },
              dataType: "html",
              url: '/OrganisationSubjectGrpRule/List',
              success: function (result) {
                  //Rebind Grid Data                
                  $('#ListViewModel').html(result);

              }
          });
    },

    AjaxCallOrganisationSubjectGrpRule: function () {

        var OrganisationSubjectGrpRuleData = null;
        if (OrganisationSubjectGrpRule.ActionName == "CreateSubjectRule") {
            $("#FormCreateOrganisationSubjectGrpRule").validate();
            if ($("#FormCreateOrganisationSubjectGrpRule").valid()) {
                OrganisationSubjectGrpRuleData = null;
                OrganisationSubjectGrpRuleData = OrganisationSubjectGrpRule.GetOrganisationSubjectGrpRule();

                ajaxRequest.makeRequest("/OrganisationSubjectGrpRule/CreateSubjectGroupRule", "POST", OrganisationSubjectGrpRuleData, OrganisationSubjectGrpRule.createRuleSuccess);
            }


        }
        else if (OrganisationSubjectGrpRule.ActionName == "CreateGroupRule") {
            $("#FormCreateOrganisationSubjectGrpRule").validate();
            if ($("#FormCreateOrganisationSubjectGrpRule").valid()) {
                OrganisationSubjectGrpRuleData = null;
                Selectedval = $('#MaxGroups').val();
                OrganisationSubjectGrpRuleData = OrganisationSubjectGrpRule.GetOrganisationSubjectGrpRule();
                ajaxRequest.makeRequest("/OrganisationSubjectGrpRule/CreateElectiveGroup?TotalNumberOfMaxGroups=" + Selectedval, "POST", OrganisationSubjectGrpRuleData, OrganisationSubjectGrpRule.createGroupRuleSuccess);


            }
        }
        else if (OrganisationSubjectGrpRule.ActionName == "CreateSubGroupRule") {
            $("#FormCreateOrganisationSubjectGrpRule").validate();
            if ($("#FormCreateOrganisationSubjectGrpRule").valid()) {
                OrganisationSubjectGrpRuleData = null;
                OrganisationSubjectGrpRuleData = OrganisationSubjectGrpRule.GetOrganisationSubjectGrpRule();
                ajaxRequest.makeRequest("/OrganisationSubjectGrpRule/CreateElectiveSubGroup", "POST", OrganisationSubjectGrpRuleData, OrganisationSubjectGrpRule.createSubGroupRuleSuccess);

            }

        }
    },

    GetOrganisationSubjectGrpRule: function () {

        var Data = {
        };
        if (OrganisationSubjectGrpRule.ActionName == "CreateSubjectRule") {

            // Properties of table OrgSubjectGrpRule
            Data.ID = $('input[name=ID]').val();
            Data.CourseYearSemesterID = $('input[name=CourseYearSemesterID]').val();
            Data.RuleName = $('#RuleName').val();
            Data.RuleCode = $('#RuleCode').val();
            Data.MaxCompulsorySubjects = $('#MaxCompulsorySubjects').val();
            Data.MaxOptSubjects = $('#MaxOptSubjects').val();
            Data.TotalSubjects = $('#TotalSubjects').val();
            Data.NoOfOptSubjects = $('#NoOfOptSubjects').val();
            Data.MaxGroups = $('#MaxGroups').val();
            Data.MaxNoOfCompulsoryGroups = $('#MaxNoOfCompulsoryGroups').val();
            Data.IsActive = $('input[name=IsActive]:checked').val() ? true : false;

        }
        else if (OrganisationSubjectGrpRule.ActionName == "CreateGroupRule") {
            // Properties of table OrgElectiveGrpMaster
            if ($('input[name=ID]').val() > 0) {
                Data.SubjectRuleGrpNumber = $('input[name=ID]').val();
            }
            else {
                Data.SubjectRuleGrpNumber = OrganisationSubjectGrpRule._subjectGroupRuleID;
            }

            Data.GroupName = $('#GroupName').val();
            //Data.GroupCompulsoryFlag = $('input[name=GroupCompulsoryFlag]:checked').val() ? true : false;
            Data.GroupCompulsoryFlag = $('input[id=GroupCompulsoryFlag]:checked').val() ? true : false;
            Data.GroupShortCode = $('#GroupShortCode').val();
            Data.NoOfSubGroups = $('#NoOfSubGroups').val();
            Data.NoOfCompulsorySubGrp = $('#NoOfCompulsorySubGrp').val();
            Data.NoOfSubGrpSubjectSelect = $('#NoOfSubGrpSubjectSelect').val();
            Data.OrgElectiveGrpMasterID = $('input[name=OrgElectiveGrpMasterID]').val();

        }
        else if (OrganisationSubjectGrpRule.ActionName == "CreateSubGroupRule") {
            // Properties of table OrgElectiveSubGrpMaster
            Data.OrgSubElectiveGrpMasterID = $('#OrgSubElectiveGrpMasterID').val();
            Data.OrgElectiveGrpID = $('#OrgElectiveGrpID').val();
            Data.OrgSubElectiveGrpDescription = $('#OrgSubElectiveGrpDescription').val();
            //Data.SubGroupCompulsoryFlag = $('input[name=SubGroupCompulsoryFlag]:checked').val() ? true : false;
            Data.SubGroupCompulsoryFlag = $('input[id=SubGroupCompulsoryFlag]:checked').val() ? true : false;
            Data.ShortDescription = $('#ShortDescription').val();
            Data.TotalNoOfSubjects = $('#TotalNoOfSubjects').val();
            Data.AllowToSelect = $('#AllowToSelect').val();
            Data.ID = $('input[name=ID]').val();

        }
        return Data;
    },

    createRuleSuccess: function (data) {
        var splitData = data.split('~');
        OrganisationSubjectGrpRule._subjectGroupRuleID = splitData[1];
        var splitMessage = splitData[0].split(',');
        $('#DisplayMessage').html(splitMessage[0]);
        $('#DisplayMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', splitMessage[1]);
        //notify(splitMessage[0], splitMessage[1]);

        if (OrganisationSubjectGrpRule._subjectGroupRuleID > 0) {
            $("#OrganisationSubjectGrpRuleNextbtn").css('visibility', 'visible');
        }
        ListViewReload();
    },
    createGroupRuleSuccess: function (data) {


        ReloadElectiveGroupRuleTable();
        

        var splitData = data.errorMessage.split(',')
        $('#DisplayMessage').html(splitData[0]);
        $('#DisplayMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', splitData[1]);
        //notify(splitData[0], splitData[1]);


        //$('#myTableSubElectiveGroupRule tr').hover(function () {
        //    $(this).css('cursor', 'pointer');
        //});

    },
    createSubGroupRuleSuccess: function (data) {


        ReloadElectiveSubGroupRuleTable()
        

        var splitData = data.errorMessage.split(',')
        $('#DisplayMessage').html(splitData[0]);
        $('#DisplayMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', splitData[1]);
        //notify(splitData[0], splitData[1]);
        //$('#myTableElectiveGroupRule tr').hover(function () {
        //    $(this).css('cursor', 'pointer');
        //});

        //$('#myTableSubElectiveGroupRule tr').hover(function () {
        //    $(this).css('cursor', 'pointer');
        //});

    },


};

