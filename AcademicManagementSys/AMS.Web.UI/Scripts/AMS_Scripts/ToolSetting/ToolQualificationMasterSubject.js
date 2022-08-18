////this class contain methods related to nationality functionality
//var ToolQualificationMasterSubject = {
//    //Member variables
//    ActionName: null,
//    SelectedIDs: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        ToolQualificationMasterSubject.constructor();
//        //ToolQualificationMasterSubject.initializeValidation();
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

//        $('#addQualificationMasterSubjectType').on("click", function () {
            
//            //to check duplication of item while adding the item        
//            var DataArray = [];
//            $('#tblQualificationMasterSubject input[type=text]').each(function () {
//                DataArray.push($(this).val());
//            });

//            var TotalRecord = DataArray.length;
//            var i = 0;

//            for (var i = 0; i < TotalRecord; i = i + 2) {
//                var aa = (DataArray[i]).toUpperCase();
//                var bb = ($('#SubjectName').val()).toUpperCase();
//                if ((DataArray[i]).toUpperCase() == ($('#SubjectName').val()).toUpperCase()) {
//                    $('#DivSuccessMessage').html("You Cannot Enter Same Subject Twice");
//                    $('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
//                    $("#SubjectName").val("");
//                    $("#MarkOutOf").val("");

//                    return false
//                }
//            }

            
//            if ($('#SubjectName').val() != "" && $('#MarkOutOf').val() != "" && $('#MarkOutOf').val() > 0) {
//                var Abc = $('#SubjectName').val();
//                $("#tblQualificationMasterSubject tbody").append(

//                       "<tr>" +
//                        "<td style='font-weight: bold;'><input type='checkbox' checked='checked' disabled='disabled' value='0' /> " + "</td>" +
//                       "<td style='font-weight: bold;'><input type='text' value=" + Abc + " style='width:100%;' /> " + "</td>" +
//                       "<td><input id='rowSubjectType' type='text' maxlength='3' value=" + $('#MarkOutOf').val() + " style='width:100%;height:20px;text-align:right; font-weight: bold;'/></td>" +
//                       "<td  style='text-align:center; '> <i class='icon-trash' title = Delete></td>" +
//                       "</tr>");
//                $("#SubjectName").val("");
//                $("#MarkOutOf").val("");
//                // $("#QualifyingExamMstID").val("");
//                $('#SubjectName').focus();
//                $('input[id*=rowSubjectType]').on("keydown", function (e) {
//                    AMSValidation.AllowNumbersOnly(e);
//                    AMSValidation.NotAllowSpaces(e);
//                });
//                // FeeStructureMasterAndDetails.TotalFeeAmount();
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

//        $("#tblQualificationMasterSubject tbody").on("click", "tr td i[class=icon-trash]", function () {
//            $(this).closest('tr').remove();
//            // FeeStructureMasterAndDetails.TotalFeeInstallmentAmount();
//        });
//        //XML code Ends


//        // Create new record
//        $('#CreateToolQualificationMasterSubjectRecord').on("click", function () {
//            ToolQualificationMasterSubject.ActionName = "Create";
//            ToolQualificationMasterSubject.getDataFromDataTable();
//            // alert(ToolQualificationMasterSubject.SelectedIDs.length);
//            if (ToolQualificationMasterSubject.SelectedIDs != null && ToolQualificationMasterSubject.SelectedIDs != "") {

//                ToolQualificationMasterSubject.AjaxCallToolQualificationMasterSubject();
//            }



//        });
//        //To delete row generted by XML
//        $("#tblQualificationMasterSubject tbody").on("click", "tr i[class=icon-trash]", function () {
//            $(this).closest('tr').remove();

//        });
//        $('.MarkOutOf').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
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

//    },
//    //LoadList method is used to load List page
//    LoadList: function () {
//        $.ajax({
//             cache: false,
//             type: "POST",

//             dataType: "html",
//             url: '/ToolQualificationMasterSubject/List',
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
//            url: '/ToolQualificationMasterSubject/List',
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
//    AjaxCallToolQualificationMasterSubject: function () {
//        var ToolQualificationMasterSubjectData = null;
//        if (ToolQualificationMasterSubject.ActionName == "Create") {
//            //$("#FormCreateToolQualificationMasterSubject").validate();
//            //if ($("#FormCreateToolQualificationMasterSubject").valid()) {
//            ToolQualificationMasterSubjectData = null;
//            ToolQualificationMasterSubjectData = ToolQualificationMasterSubject.GetToolQualificationMasterSubject();
//            ajaxRequest.makeRequest("/ToolQualificationMasterSubject/Create", "POST", ToolQualificationMasterSubjectData, ToolQualificationMasterSubject.Success);
//            //}
//        }
//        else if (ToolQualificationMasterSubject.ActionName == "Edit") {
//            $("#FormEditToolQualificationMasterSubject").validate();
//            if ($("#FormEditToolQualificationMasterSubject").valid()) {
//                ToolQualificationMasterSubjectData = null;
//                ToolQualificationMasterSubjectData = ToolQualificationMasterSubject.GetToolQualificationMasterSubject();
//                ajaxRequest.makeRequest("/ToolQualificationMasterSubject/Edit", "POST", ToolQualificationMasterSubjectData, ToolQualificationMasterSubject.Success);
//            }
//        }
//        else if (ToolQualificationMasterSubject.ActionName == "Delete") {
//            ToolQualificationMasterSubjectData = null;
//            //$("#FormCreateToolQualificationMasterSubject").validate();
//            ToolQualificationMasterSubjectData = ToolQualificationMasterSubject.GetToolQualificationMasterSubject();
            
//            ajaxRequest.makeRequest("/ToolQualificationMasterSubject/Delete", "POST", ToolQualificationMasterSubjectData, ToolQualificationMasterSubject.Success);

//        }
//    },




//    //Get properties data from the Create, Update and Delete page
//    GetToolQualificationMasterSubject: function () {
//        var Data = {
//        };
//        if (ToolQualificationMasterSubject.ActionName == "Create" || ToolQualificationMasterSubject.ActionName == "Edit") {
//            Data.QualificationMstID = $('input[name=QualificationMstID]').val();
//            Data.SelectedIDs = ToolQualificationMasterSubject.SelectedIDs;

//        }

//        return Data;
//    },


//    getDataFromDataTable: function () {
        
//        var DataArray = [];
//        var table = $('#tblQualificationMasterSubject').DataTable();
//        var data = table.$('input').each(function () {
//            DataArray.push($(this).val());
//        });
//        var selected;
//        selected = DataArray.join(',') + ",";
//        var count = DataArray.length;
//        // alert(selected);
//        var x = 0, i = 0;
//        var xmlParamList = "<rows>"
//        for (i ; i < count ; i = i + 3) {
            
//            //xmlUpdate code here
//            if (DataArray[x] != "0") {

//                if (DataArray[x + 1] == "" || DataArray[x + 1] == null) {
//                    ToolQualificationMasterSubject.SelectedIDs = "";
//                    ajaxRequest.ErrorMessageForJS("JsValidationMessages_EnterSubjectType", "DivSuccessMessage", "#FFCC80");
//                    //$('#DivSuccessMessage').html('Please enter subject name.');
//                    //$('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', '#FFCC80');
//                    return false;
//                }
//                else if (DataArray[x + 2] == 0 || DataArray[x + 2] == "" || DataArray[x + 2] == null) {
//                    ToolQualificationMasterSubject.SelectedIDs = "";
//                    $('#DivSuccessMessage').html('Please enter ' + DataArray[x + 1] + ' subject marks.');
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
//                    ToolQualificationMasterSubject.SelectedIDs = "";
//                    ajaxRequest.ErrorMessageForJS("JsValidationMessages_EnterSubjectType", "DivSuccessMessage", "#FFCC80");
//                    //$('#DivSuccessMessage').html('Please enter subject name.');
//                    //$('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', '#FFCC80');
//                    return false;
//                }
//                else if (DataArray[x + 2] == "" || DataArray[x + 2] == null || DataArray[x + 2] == "0") {
//                    ToolQualificationMasterSubject.SelectedIDs = "";
//                    $('#DivSuccessMessage').html('Please enter ' + DataArray[x + 1] + ' Out Of marks.');
//                    $('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', '#FFCC80');
//                    return false;
//                }
//                else {
//                    xmlParamList = xmlParamList + "<row>" + "<ID>" + DataArray[x] + "</ID>" + "<SubjectName>" + DataArray[x + 1] + "</SubjectName>" + "<MarkOutOf>" + DataArray[x + 2] + "</MarkOutOf>" + "</row>";
//                }
//            }
//            x = x + 3;
//        }

//        // alert(xmlParamList);
//        if (xmlParamList.length > 6) {

//            ToolQualificationMasterSubject.SelectedIDs = xmlParamList.replace("&", "And").toString() + "</rows>";
//        }
//        else {
//            ToolQualificationMasterSubject.SelectedIDs = "";

//            //alert("Enter atlest one subject");
//            ajaxRequest.ErrorMessageForJS("JsValidationMessages_AtleastOneSubWithMark", "DivSuccessMessage", "#FFCC80");
//            $('#DivSuccessMessage').html('Please Enter Altleast one Subject with its marks.');
//            $('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', '#FFCC80');
//            return false;

//        }


//        //  alert(ToolQualificationMasterSubject.SelectedIDs);
//    },
//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
        
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            ToolQualificationMasterSubject.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            ToolQualificationMasterSubject.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },


//    //this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {

//    //    
//    //    
//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        ToolQualificationMasterSubject.ReloadList("Record Updated Sucessfully.");
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
//    //        ToolQualificationMasterSubject.ReloadList("Record Deleted Sucessfully.");
//    //        //  alert("Record Deleted Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    //    }


//    //},
//};

////////////NEW JS////////////////


//this class contain methods related to nationality functionality
var ToolQualificationMasterSubject = {
    //Member variables
    ActionName: null,
    SelectedIDs: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        ToolQualificationMasterSubject.constructor();
        //ToolQualificationMasterSubject.initializeValidation();
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

        $('#addQualificationMasterSubjectType').on("click", function () {

            //to check duplication of item while adding the item        
            var DataArray = [];
            $('#tblQualificationMasterSubject input[type=text]').each(function () {
                DataArray.push($(this).val());
            });

            var TotalRecord = DataArray.length;
            var i = 0;

            for (var i = 0; i < TotalRecord; i = i + 2) {
                var aa = (DataArray[i]).toUpperCase();
                var bb = ($('#SubjectName').val()).toUpperCase();
                if ((DataArray[i]).toUpperCase() == ($('#SubjectName').val()).toUpperCase()) {
                    $('#DivSuccessMessage').html("You Cannot Enter Same Subject Twice");
                    $('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFC107");
                    $("#SubjectName").val("");
                    $("#MarkOutOf").val("");

                    return false
                }
            }


            if ($('#SubjectName').val() != "" && $('#MarkOutOf').val() != "" && $('#MarkOutOf').val() > 0) {
                var Abc = $('#SubjectName').val();
                $("#tblQualificationMasterSubject tbody").append(

                       "<tr class='active'>" +
                        "<td style=''><p class='checkbox'><input type='checkbox' checked='checked' disabled='disabled' value='0' /> " + "<i class='input-helper'></i></p></td>" +
                       "<td style='font-weight: bold;'><div class='form-group fg-line'><input type='text' class='form-control' value=" + Abc + " style='' /> " + "</div></td>" +
                       "<td><div class='form-group fg-line'><input id='rowSubjectType' class='form-control' type='text' maxlength='3' value=" + $('#MarkOutOf').val() + " style='text-align:right; font-weight: bold;'/></div></td>" +
                       //"<td  style='text-align:center; '> <i class='icon-trash' title = Delete></td>" +
                       "<td  style=''> <button class='btn btn-danger btn-xs waves-effect' type='button'><i class='icon-trash' style='cursor:pointer' title = Delete>Delete </button></td>" +
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

                ajaxRequest.ErrorMessageForJS("JsValidationMessages_EnterMarkForSub", "DivSuccessMessage", "#FFCC80");
                //$('#DivSuccessMessage').html("Please Enter Proper Marks for Subject ");
                //$('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            }
        });

        //$("#tblQualificationMasterSubject tbody").on("click", "tr td i[class=icon-trash]", function () {
        //    $(this).closest('tr').remove();
        //    // FeeStructureMasterAndDetails.TotalFeeInstallmentAmount();
        //});
        //XML code Ends
        $("#tblQualificationMasterSubject tbody").on("click", "tr td button", function () {
            $(this).closest('tr').remove();
        });

        // Create new record
        $('#CreateToolQualificationMasterSubjectRecord').on("click", function () {
            ToolQualificationMasterSubject.ActionName = "Create";
            ToolQualificationMasterSubject.getDataFromDataTable();
            // alert(ToolQualificationMasterSubject.SelectedIDs.length);
            if (ToolQualificationMasterSubject.SelectedIDs != null && ToolQualificationMasterSubject.SelectedIDs != "") {

                ToolQualificationMasterSubject.AjaxCallToolQualificationMasterSubject();
            }



        });
        //To delete row generted by XML
        $("#tblQualificationMasterSubject tbody").on("click", "tr i[class=icon-trash]", function () {
            $(this).closest('tr').remove();

        });
        $('.MarkOutOf').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });


        $("#MarkOutOf").on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        //$("#form-control MarkOutOf").on("keydown", function (e) {
        //    AMSValidation.AllowNumbersOnly(e);
        //});

        //$(".form-control MarkOutOf").on("keydown", function (e) {
        //    AMSValidation.AllowNumbersOnly(e);
        //});

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

    },
    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax({
            cache: false,
            type: "POST",

            dataType: "html",
            url: '/ToolQualificationMasterSubject/List',
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
            url: '/ToolQualificationMasterSubject/List',
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
    AjaxCallToolQualificationMasterSubject: function () {
        var ToolQualificationMasterSubjectData = null;
        if (ToolQualificationMasterSubject.ActionName == "Create") {
            //$("#FormCreateToolQualificationMasterSubject").validate();
            //if ($("#FormCreateToolQualificationMasterSubject").valid()) {
            ToolQualificationMasterSubjectData = null;
            ToolQualificationMasterSubjectData = ToolQualificationMasterSubject.GetToolQualificationMasterSubject();
            ajaxRequest.makeRequest("/ToolQualificationMasterSubject/Create", "POST", ToolQualificationMasterSubjectData, ToolQualificationMasterSubject.Success);
            //}
        }
        else if (ToolQualificationMasterSubject.ActionName == "Edit") {
            $("#FormEditToolQualificationMasterSubject").validate();
            if ($("#FormEditToolQualificationMasterSubject").valid()) {
                ToolQualificationMasterSubjectData = null;
                ToolQualificationMasterSubjectData = ToolQualificationMasterSubject.GetToolQualificationMasterSubject();
                ajaxRequest.makeRequest("/ToolQualificationMasterSubject/Edit", "POST", ToolQualificationMasterSubjectData, ToolQualificationMasterSubject.Success);
            }
        }
        else if (ToolQualificationMasterSubject.ActionName == "Delete") {
            ToolQualificationMasterSubjectData = null;
            //$("#FormCreateToolQualificationMasterSubject").validate();
            ToolQualificationMasterSubjectData = ToolQualificationMasterSubject.GetToolQualificationMasterSubject();

            ajaxRequest.makeRequest("/ToolQualificationMasterSubject/Delete", "POST", ToolQualificationMasterSubjectData, ToolQualificationMasterSubject.Success);

        }
    },




    //Get properties data from the Create, Update and Delete page
    GetToolQualificationMasterSubject: function () {
        var Data = {
        };
        if (ToolQualificationMasterSubject.ActionName == "Create" || ToolQualificationMasterSubject.ActionName == "Edit") {
            Data.QualificationMstID = $('input[name=QualificationMstID]').val();
            Data.SelectedIDs = ToolQualificationMasterSubject.SelectedIDs;

        }

        return Data;
    },


    getDataFromDataTable: function () {

        var DataArray = [];
        var table = $('#tblQualificationMasterSubject').DataTable();
        var data = table.$('input').each(function () {
            DataArray.push($(this).val());
        });
        var selected;
        selected = DataArray.join(',') + ",";
        var count = DataArray.length;
        // alert(selected);
        var x = 0, i = 0;
        var xmlParamList = "<rows>"
        for (i ; i < count ; i = i + 3) {

            //xmlUpdate code here
            if (DataArray[x] != "0") {

                if (DataArray[x + 1] == "" || DataArray[x + 1] == null) {
                    ToolQualificationMasterSubject.SelectedIDs = "";
                    ajaxRequest.ErrorMessageForJS("JsValidationMessages_EnterSubjectType", "DivSuccessMessage", "#FFCC80");
                    //$('#DivSuccessMessage').html('Please enter subject name.');
                    //$('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', '#FFCC80');
                    return false;
                }
                else if (DataArray[x + 2] == 0 || DataArray[x + 2] == "" || DataArray[x + 2] == null) {
                    ToolQualificationMasterSubject.SelectedIDs = "";
                    $('#DivSuccessMessage').html('Please enter ' + DataArray[x + 1] + ' subject marks.');
                    $('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', '#FFCC80');
                    return false;
                }
                else {
                    xmlParamList = xmlParamList + "<row>" + "<ID>" + DataArray[x] + "</ID>" + "<SubjectName>" + DataArray[x + 1] + "</SubjectName>" + "<MarkOutOf>" + DataArray[x + 2] + "</MarkOutOf>" + "</row>";
                }
            }

            //xmlInsert code here
            if (DataArray[x] == "0") {
                if (DataArray[x + 1] == "" || DataArray[x + 1] == null) {
                    ToolQualificationMasterSubject.SelectedIDs = "";
                    ajaxRequest.ErrorMessageForJS("JsValidationMessages_EnterSubjectType", "DivSuccessMessage", "#FFCC80");
                    //$('#DivSuccessMessage').html('Please enter subject name.');
                    //$('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', '#FFCC80');
                    return false;
                }
                else if (DataArray[x + 2] == "" || DataArray[x + 2] == null || DataArray[x + 2] == "0") {
                    ToolQualificationMasterSubject.SelectedIDs = "";
                    $('#DivSuccessMessage').html('Please enter ' + DataArray[x + 1] + ' Out Of marks.');
                    $('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', '#FFCC80');
                    return false;
                }
                else {
                    xmlParamList = xmlParamList + "<row>" + "<ID>" + DataArray[x] + "</ID>" + "<SubjectName>" + DataArray[x + 1] + "</SubjectName>" + "<MarkOutOf>" + DataArray[x + 2] + "</MarkOutOf>" + "</row>";
                }
            }
            x = x + 3;
        }

        // alert(xmlParamList);
        if (xmlParamList.length > 6) {

            ToolQualificationMasterSubject.SelectedIDs = xmlParamList.replace("&", "And").toString() + "</rows>";
        }
        else {
            ToolQualificationMasterSubject.SelectedIDs = "";

            //alert("Enter atlest one subject");
            ajaxRequest.ErrorMessageForJS("JsValidationMessages_AtleastOneSubWithMark", "DivSuccessMessage", "#FFCC80");
            $('#DivSuccessMessage').html('Please Enter Altleast one Subject with its marks.');
            $('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', '#FFCC80');
            return false;

        }


        //  alert(ToolQualificationMasterSubject.SelectedIDs);
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            ToolQualificationMasterSubject.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            ToolQualificationMasterSubject.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },



};

