////this class contain methods related to nationality functionality
//var ToolQualifyingExamSubject = {
//    //Member variables
//    ActionName: null,
//    SelectedIDs: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        ToolQualifyingExamSubject.constructor();
//        //ToolQualifyingExamSubject.initializeValidation();
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
//            //$('#SelectedCityID').val('0');
//            return false;
//        });
//        //NewCode XML for Add button
           
//        $('#addQualifyingSubjectType').on("click", function () {
            

//            //to check duplication of item while adding the item        
//            var DataArray = [];
//            $('#tblDataSubject input[type=text]').each(function () {
//                DataArray.push($(this).val());
//            });

//            var TotalRecord = DataArray.length;
//            var i = 0;

//            for (var i = 0; i < TotalRecord; i = i + 2) {               
//                if ((DataArray[i]).toUpperCase() == ($('#SubjectName').val()).toUpperCase()) {
//                    $('#DivSuccessMessage').html("You can not enter same subject twice");
//                    $('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
//                    $("#SubjectName").val("");
//                    $("#MarkOutOf").val("");

//                    return false
//                }
//            }

//            if ($('#SubjectName').val() != "" && $('#MarkOutOf').val() != "" && $('#MarkOutOf').val() > 0 ) {
//                $("#tblDataSubject tbody").append(
//                    "<tr>" +
//                     "<td style='font-weight: bold;'><input type='checkbox' checked='checked' disabled='disabled' value='0' /> " + "</td>" +
//                    "<td style='font-weight: bold;'><input id='subjectName' type='text' value=" + $('#SubjectName').val() + " style='width:100%;' /> " + "</td>" +
//                    "<td><input id='rowSubjectType' type='text' maxlength='3' value=" + $('#MarkOutOf').val()+ " style='width:100%;height:20px;text-align:right; font-weight: bold;'/></td>" +
//                    "<td  style='text-align:center; '> <i class='icon-trash' title = Delete></td>" +
//                    "</tr>");
//                $("#SubjectName").val("");
//                $("#MarkOutOf").val("");
//               // $("#QualifyingExamMstID").val("");
//                $('#SubjectName').focus();
//                $('input[id*=rowSubjectType]').on("keydown", function (e) {
//                    AMSValidation.AllowNumbersOnly(e);
//                    AMSValidation.NotAllowSpaces(e);
//                });
//               // FeeStructureMasterAndDetails.TotalFeeAmount();
//            }
//            else if ($("#SubjectName").val() == "") {
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_EnterSubjectType", "DivSuccessMessage", "#FFCC80");
//                //$('#DivSuccessMessage').html("Please Enter Subject Type.");
//                //$('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");

//            }
            
//            else if ($("#MarkOutOf").val() == "" || $("#MarkOutOf").val() == 0 || $("#MarkOutOf").val() == '.') {
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_EnterMarkForSub", "DivSuccessMessage", "#FFCC80");
//                //$('#DivSuccessMessage').html("Please Enter Proper Marks for Subject ");
//                //$('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");

//            }

//        });
//        $("#tblDataSubject tbody").on("click", "tr td i[class=icon-trash]", function () {
//            $(this).closest('tr').remove();
//           // FeeStructureMasterAndDetails.TotalFeeInstallmentAmount();
//        });
//        //XML code Ends
//        // Create new record
//        $('#CreateToolQualifyingExamSubjectRecord').on("click", function () {
//            ToolQualifyingExamSubject.ActionName = "Create";
//            ToolQualifyingExamSubject.getDataFromDataTable();
//            //alert(ToolQualifyingExamSubject.SelectedIDs.length);
//            if (ToolQualifyingExamSubject.SelectedIDs != null && ToolQualifyingExamSubject.SelectedIDs != "") {

//                ToolQualifyingExamSubject.AjaxCallToolQualifyingExamSubject();
//            }
//        });
//        $('.MarkOutOf').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });

//        $('#SubjectName').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });

//        $("#MarkOutOf").on("keydown", function (e) {
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

//        $("#SubjectName").on("keypress", function (e) {           
//            var inputKeyCode = e.keyCode ? e.keyCode : e.which;
//            if (inputKeyCode == 8) {
//                $("#SubjectName").val('');
//                $("#MarkOutOf").val('');
//            }
//        });

//        $('#tblDataSubject tbody').on('keydown', "tr td input[id^=subjectName]", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });

//        $('#tblDataSubject tbody').on('keydown', "tr td input[id^=markOutOf]", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });
//    },
//    //LoadList method is used to load List page
//    LoadList: function () {

//        $.ajax(

//         {

//             cache: false,
//             type: "POST",

//             dataType: "html",
//             url: '/ToolQualifyingExamSubject/List',
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
//            url: '/ToolQualifyingExamSubject/List',
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
//    AjaxCallToolQualifyingExamSubject: function () {
//        var ToolQualifyingExamSubjectData = null;
//        if (ToolQualifyingExamSubject.ActionName == "Create") {
//            //$("#FormCreateToolQualifyingExamSubject").validate();
//            //if ($("#FormCreateToolQualifyingExamSubject").valid()) {
//                ToolQualifyingExamSubjectData = null;
//                ToolQualifyingExamSubjectData = ToolQualifyingExamSubject.GetToolQualifyingExamSubject();
//                ajaxRequest.makeRequest("/ToolQualifyingExamSubject/Create", "POST", ToolQualifyingExamSubjectData, ToolQualifyingExamSubject.Success);
//            //}
//        }
//        else if (ToolQualifyingExamSubject.ActionName == "Edit") {
//            $("#FormEditToolQualifyingExamSubject").validate();
//            if ($("#FormEditToolQualifyingExamSubject").valid()) {
//                ToolQualifyingExamSubjectData = null;
//                ToolQualifyingExamSubjectData = ToolQualifyingExamSubject.GetToolQualifyingExamSubject();
//                ajaxRequest.makeRequest("/ToolQualifyingExamSubject/Edit", "POST", ToolQualifyingExamSubjectData, ToolQualifyingExamSubject.Success);
//            }
//        }
//        else if (ToolQualifyingExamSubject.ActionName == "Delete") {
//            ToolQualifyingExamSubjectData = null;
//            //$("#FormCreateToolQualifyingExamSubject").validate();
//            ToolQualifyingExamSubjectData = ToolQualifyingExamSubject.GetToolQualifyingExamSubject();
            
//            ajaxRequest.makeRequest("/ToolQualifyingExamSubject/Delete", "POST", ToolQualifyingExamSubjectData, ToolQualifyingExamSubject.Success);

//        }
//    },

//    //Get properties data from the Create, Update and Delete page
//    GetToolQualifyingExamSubject: function () {
//        var Data = {
//        };
//        if (ToolQualifyingExamSubject.ActionName == "Create" || ToolQualifyingExamSubject.ActionName == "Edit") {
//            Data.QualifyingExamMstID = $('input[name=QualifyingExamMstID]').val();
//            Data.SelectedIDs = ToolQualifyingExamSubject.SelectedIDs;

//        }
       
//        return Data;
//    },

//    getDataFromDataTable: function () {
        
//        var DataArray = [];
//        var table = $('#tblDataSubject').DataTable();
//        var data = table.$('input').each(function () {
//            DataArray.push($(this).val());
//        });
//        var selected;
//        selected = DataArray.join(',') + ",";
//        var count = DataArray.length;
//      //  alert(selected);
//        var x = 0,i=0;
//        var xmlParamList = "<rows>"
//        for(i ; i<count ; i=i+3)
//        {
            
//            //xmlUpdate code here
//            if (DataArray[x] != "0") {
//                if (DataArray[x + 1] == "" || DataArray[x + 1] == null) {
//                    ToolQualifyingExamSubject.SelectedIDs = "";
//                    ajaxRequest.ErrorMessageForJS("JsValidationMessages_EnterSubjectType", "DivSuccessMessage", "#FFCC80");
//                    //$('#DivSuccessMessage').html('Please enter subject name.');
//                    //$('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', '#FFCC80');
//                    return false;
//                }
//                else if (DataArray[x + 2] == "" || DataArray[x + 2] == null || DataArray[x + 2] == "0") {
//                    ToolQualifyingExamSubject.SelectedIDs = "";
//                    $('#DivSuccessMessage').html('Please enter ' + DataArray[x + 1] + 'Out Of marks.');
//                    $('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', '#FFCC80');
//                    return false;
//                }
//                else {
//                    xmlParamList = xmlParamList + "<row>" + "<ID>" + DataArray[x] + "</ID>" + "<SubjectName>" + DataArray[x + 1] + "</SubjectName>" + "<MarkOutOf>" + DataArray[x + 2] + "</MarkOutOf>" + "</row>";
//                }
//            }

//            //xmlInsert code here
            
//            if (DataArray[x] == "0") {
//                if (DataArray[x + 1] == "" || DataArray[x + 1] == null) {
//                    ToolQualifyingExamSubject.SelectedIDs = "";
//                    ajaxRequest.ErrorMessageForJS("JsValidationMessages_EnterSubjectType", "DivSuccessMessage", "#FFCC80");
//                    //$('#DivSuccessMessage').html('Please enter subject name.');
//                    //$('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', '#FFCC80');
//                    return false;
//                }
//                else if ( DataArray[x + 2] == "0" || DataArray[x + 2] == "" || DataArray[x + 2] == null) {
//                    ToolQualifyingExamSubject.SelectedIDs = "";
//                    $('#DivSuccessMessage').html('Please enter ' + DataArray[x + 1] + ' subject marks.');
//                    $('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', '#FFCC80');
//                    return false;
//                }
//                else {
//                    xmlParamList = xmlParamList + "<row>" + "<ID>" + DataArray[x] + "</ID>" + "<SubjectName>" + DataArray[x + 1] + "</SubjectName>" + "<MarkOutOf>" + DataArray[x + 2] + "</MarkOutOf>" + "</row>";
//                }
//            }
//            x = x + 3;
//        }
//        //alert(xmlParamList);
//        if (xmlParamList.length > 6) {

//            ToolQualifyingExamSubject.SelectedIDs = xmlParamList.replace("&", "And").toString() + "</rows>";
//        }
//        else {
//            ToolQualifyingExamSubject.SelectedIDs = "";

//            //alert("Enter atlest one subject");
//            ajaxRequest.ErrorMessageForJS("JsValidationMessages_AtleastOneSubWithMark", "DivSuccessMessage", "#FFCC80");
//            //$('#DivSuccessMessage').html('Please Enter Altleast one Subject with its marks.');
//            //$('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', '#FFCC80');
//            return false;

//        }
//      //  alert(ToolQualifyingExamSubject.SelectedIDs);
//    },
//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
        
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            ToolQualifyingExamSubject.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            ToolQualifyingExamSubject.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },
//    //this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {

//    //    
//    //    
//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        ToolQualifyingExamSubject.ReloadList("Record Updated Sucessfully.");
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
//    //        ToolQualifyingExamSubject.ReloadList("Record Deleted Sucessfully.");
//    //        //  alert("Record Deleted Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    //    }


//    //},
//};

/////////////////////new code//////////////////


//this class contain methods related to nationality functionality
var ToolQualifyingExamSubject = {
    //Member variables
    ActionName: null,
    SelectedIDs: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        ToolQualifyingExamSubject.constructor();
        //ToolQualifyingExamSubject.initializeValidation();
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
            //$('#SelectedCityID').val('0');
            return false;
        });
        //NewCode XML for Add button

        $('#addQualifyingSubjectType').on("click", function () {


            //to check duplication of item while adding the item        
            var DataArray = [];
            $('#tblDataSubject input[type=text]').each(function () {
                DataArray.push($(this).val());
            });

            var TotalRecord = DataArray.length;
            var i = 0;

            for (var i = 0; i < TotalRecord; i = i + 2) {
                if ((DataArray[i]).toUpperCase() == ($('#SubjectName').val()).toUpperCase()) {
                    $('#DivSuccessMessage').html("You can not enter same subject twice");
                    $('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFC107");
                    $("#SubjectName").val("");
                    $("#MarkOutOf").val("");

                    return false
                }
            }

            if ($('#SubjectName').val() != "" && $('#MarkOutOf').val() != "" && $('#MarkOutOf').val() > 0) {
                $("#tblDataSubject tbody").append(
                    "<tr>" +
                     "<td style='font-weight: bold;'><p class='checkbox'><input type='checkbox' checked='checked' disabled='disabled' value='0' /> " + "<i class='input-helper'></i></p></td>" +
                    "<td style='font-weight: bold;'><div class='form-group fg-line'><input id='subjectName' class='form-control' type='text' value=" + $('#SubjectName').val() + " style='width:100%;' /> " + "</div></td>" +
                    "<td><div class='form-group fg-line'><input id='rowSubjectType' type='text' maxlength='3' class='form-control' value=" + $('#MarkOutOf').val() + " style='text-align:right; font-weight: bold;'/></div></td>" +
                    "<td  style='text-align:center; '><button class='btn btn-danger btn-xs waves-effect' type='button'> <i class='icon-trash' title = Delete>Delete</button></td>" +
                    "</tr>");
                $("#SubjectName").val("");
                $("#MarkOutOf").val("");
                // $("#QualifyingExamMstID").val("");
                $('#SubjectName').focus();
                $('input[id*=rowSubjectType]').on("keydown", function (e) {
                    AMSValidation.AllowNumbersOnly(e);
                    AMSValidation.NotAllowSpaces(e);
                });
                // FeeStructureMasterAndDetails.TotalFeeAmount();
            }
            else if ($("#SubjectName").val() == "") {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_EnterSubjectType", "DivSuccessMessage", "#FFC107");
                //$('#DivSuccessMessage').html("Please Enter Subject Type.");
                //$('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");

            }

            else if ($("#MarkOutOf").val() == "" || $("#MarkOutOf").val() == 0 || $("#MarkOutOf").val() == '.') {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_EnterMarkForSub", "DivSuccessMessage", "#FFC107");
                //$('#DivSuccessMessage').html("Please Enter Proper Marks for Subject ");
                //$('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");

            }

        });
        //$("#tblDataSubject tbody").on("click", "tr td i[class=icon-trash]", function () {
        //    $(this).closest('tr').remove();
        //    // FeeStructureMasterAndDetails.TotalFeeInstallmentAmount();
        //});

        $("#tblDataSubject tbody").on("click", "tr td button", function () {
            $(this).closest('tr').remove();
        });

        //XML code Ends
        // Create new record
        $('#CreateToolQualifyingExamSubjectRecord').on("click", function () {
            ToolQualifyingExamSubject.ActionName = "Create";
            ToolQualifyingExamSubject.getDataFromDataTable();
            //alert(ToolQualifyingExamSubject.SelectedIDs.length);
            if (ToolQualifyingExamSubject.SelectedIDs != null && ToolQualifyingExamSubject.SelectedIDs != "") {

                ToolQualifyingExamSubject.AjaxCallToolQualifyingExamSubject();
            }
        });
        $('.MarkOutOf').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#SubjectName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $("#MarkOutOf").on("keydown", function (e) {
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

        $("#SubjectName").on("keypress", function (e) {
            var inputKeyCode = e.keyCode ? e.keyCode : e.which;
            if (inputKeyCode == 8) {
                $("#SubjectName").val('');
                $("#MarkOutOf").val('');
            }
        });

        $('#tblDataSubject tbody').on('keydown', "tr td input[id^=subjectName]", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#tblDataSubject tbody').on('keydown', "tr td input[id^=markOutOf]", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/ToolQualifyingExamSubject/List',
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
            url: '/ToolQualifyingExamSubject/List',
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
    AjaxCallToolQualifyingExamSubject: function () {
        var ToolQualifyingExamSubjectData = null;
        if (ToolQualifyingExamSubject.ActionName == "Create") {
            //$("#FormCreateToolQualifyingExamSubject").validate();
            //if ($("#FormCreateToolQualifyingExamSubject").valid()) {
            ToolQualifyingExamSubjectData = null;
            ToolQualifyingExamSubjectData = ToolQualifyingExamSubject.GetToolQualifyingExamSubject();
            ajaxRequest.makeRequest("/ToolQualifyingExamSubject/Create", "POST", ToolQualifyingExamSubjectData, ToolQualifyingExamSubject.Success);
            //}
        }
        else if (ToolQualifyingExamSubject.ActionName == "Edit") {
            $("#FormEditToolQualifyingExamSubject").validate();
            if ($("#FormEditToolQualifyingExamSubject").valid()) {
                ToolQualifyingExamSubjectData = null;
                ToolQualifyingExamSubjectData = ToolQualifyingExamSubject.GetToolQualifyingExamSubject();
                ajaxRequest.makeRequest("/ToolQualifyingExamSubject/Edit", "POST", ToolQualifyingExamSubjectData, ToolQualifyingExamSubject.Success);
            }
        }
        else if (ToolQualifyingExamSubject.ActionName == "Delete") {
            ToolQualifyingExamSubjectData = null;
            //$("#FormCreateToolQualifyingExamSubject").validate();
            ToolQualifyingExamSubjectData = ToolQualifyingExamSubject.GetToolQualifyingExamSubject();

            ajaxRequest.makeRequest("/ToolQualifyingExamSubject/Delete", "POST", ToolQualifyingExamSubjectData, ToolQualifyingExamSubject.Success);

        }
    },

    //Get properties data from the Create, Update and Delete page
    GetToolQualifyingExamSubject: function () {
        var Data = {
        };
        if (ToolQualifyingExamSubject.ActionName == "Create" || ToolQualifyingExamSubject.ActionName == "Edit") {
            Data.QualifyingExamMstID = $('input[name=QualifyingExamMstID]').val();
            Data.SelectedIDs = ToolQualifyingExamSubject.SelectedIDs;

        }

        return Data;
    },

    getDataFromDataTable: function () {

        var DataArray = [];
        var table = $('#tblDataSubject').DataTable();
        var data = table.$('input').each(function () {
            DataArray.push($(this).val());
        });
        var selected;
        selected = DataArray.join(',') + ",";
        var count = DataArray.length;
        //  alert(selected);
        var x = 0, i = 0;
        var xmlParamList = "<rows>"
        for (i ; i < count ; i = i + 3) {

            //xmlUpdate code here
            if (DataArray[x] != "0") {
                if (DataArray[x + 1] == "" || DataArray[x + 1] == null) {
                    ToolQualifyingExamSubject.SelectedIDs = "";
                    ajaxRequest.ErrorMessageForJS("JsValidationMessages_EnterSubjectType", "DivSuccessMessage", "#FFC107");
                    //$('#DivSuccessMessage').html('Please enter subject name.');
                    //$('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', '#FFCC80');
                    return false;
                }
                else if (DataArray[x + 2] == "" || DataArray[x + 2] == null || DataArray[x + 2] == "0") {
                    ToolQualifyingExamSubject.SelectedIDs = "";
                    $('#DivSuccessMessage').html('Please enter ' + DataArray[x + 1] + 'Out Of marks.');
                    $('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', '#FFC107');
                    return false;
                }
                else {
                    xmlParamList = xmlParamList + "<row>" + "<ID>" + DataArray[x] + "</ID>" + "<SubjectName>" + DataArray[x + 1] + "</SubjectName>" + "<MarkOutOf>" + DataArray[x + 2] + "</MarkOutOf>" + "</row>";
                }
            }

            //xmlInsert code here

            if (DataArray[x] == "0") {
                if (DataArray[x + 1] == "" || DataArray[x + 1] == null) {
                    ToolQualifyingExamSubject.SelectedIDs = "";
                    ajaxRequest.ErrorMessageForJS("JsValidationMessages_EnterSubjectType", "DivSuccessMessage", "#FFC107");
                    //$('#DivSuccessMessage').html('Please enter subject name.');
                    //$('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', '#FFCC80');
                    return false;
                }
                else if (DataArray[x + 2] == "0" || DataArray[x + 2] == "" || DataArray[x + 2] == null) {
                    ToolQualifyingExamSubject.SelectedIDs = "";
                    $('#DivSuccessMessage').html('Please enter ' + DataArray[x + 1] + ' subject marks.');
                    $('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', '#FFC107');
                    return false;
                }
                else {
                    xmlParamList = xmlParamList + "<row>" + "<ID>" + DataArray[x] + "</ID>" + "<SubjectName>" + DataArray[x + 1] + "</SubjectName>" + "<MarkOutOf>" + DataArray[x + 2] + "</MarkOutOf>" + "</row>";
                }
            }
            x = x + 3;
        }
        //alert(xmlParamList);
        if (xmlParamList.length > 6) {

            ToolQualifyingExamSubject.SelectedIDs = xmlParamList.replace("&", "And").toString() + "</rows>";
        }
        else {
            ToolQualifyingExamSubject.SelectedIDs = "";

            //alert("Enter atlest one subject");
            ajaxRequest.ErrorMessageForJS("JsValidationMessages_AtleastOneSubWithMark", "DivSuccessMessage", "#FFC107");
            //$('#DivSuccessMessage').html('Please Enter Altleast one Subject with its marks.');
            //$('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', '#FFCC80');
            return false;

        }
        //  alert(ToolQualifyingExamSubject.SelectedIDs);
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            ToolQualifyingExamSubject.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            ToolQualifyingExamSubject.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    
};

