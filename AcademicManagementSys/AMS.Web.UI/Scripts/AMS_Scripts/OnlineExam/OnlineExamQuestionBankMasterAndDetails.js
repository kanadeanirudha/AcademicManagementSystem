//this class contain methods related to nationality functionality
var OnlineExamQuestionBankMasterAndDetails = {
    //Member variables
    ActionName: null,
    OptionImageFileName: "",
    QuestionImageFileName: null,
    QuestionImageFileSize: null,
    XMLstring: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        OnlineExamQuestionBankMasterAndDetails.constructor();
        //OnlineExamQuestionBankMasterAndDetails.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('img').removeAttr('src');
            $('#GenQuestionType').val("");
            $('#GeneralQuestionLevelMasterID').val("");
            $('#tblData input').each(function () {
                $(this).parents('tr').find('input[type="checkbox"]').attr('checked', false);
                $(this).closest('tr').find('td input[id^=optionText]').val(0);
                $(this).closest('tr').find('td input[id^=optionText]').hide();
                $(this).closest('tr').remove();

            });
            return false;
        });
        $("#resetQuestionBankRecord").click(function () {
            $('#Center').val("");
            $('#CourseType').val("");
            $('#SubjectGroupType').val("");

        });
        $("#btnShowList").unbind('click').click(function () {
            var OnlineExamQuestionBankMasterID = $("#OnlineExamQuestionBankMasterID").val();
            if (OnlineExamQuestionBankMasterID == "") {
                notify("Please select Bank Master", 'warning');
                return false;
            }
            var splitedBankMaster = OnlineExamQuestionBankMasterID.split("~");
            var href = $("#btnCreateList").attr('href');
            href = '/OnlineExamQuestionBankMasterAndDetails/Create?OnlineExamQuestionBankMasterID=' + splitedBankMaster[0]
            $("#btnCreateList").attr('href', href);
            $("#btnCreateList").show();

            OnlineExamQuestionBankMasterAndDetails.LoadList();
        });

        $("#CourseType").on("change", function () {
            var courseTypeID = $(this).val();
            var $subjectgrp = $("#SubjectGroupType");
            //var ARMId = $('input[name=AdminRoleMasterID]').val();
            var splitedCourse = courseTypeID.split("~");
            if ($("#CourseType").val() != "") {

                $.ajax({

                    cache: false,
                    type: "GET",
                    url: "/OnlineExamQuestionBankMasterAndDetails/GetSubjectGroup",
                    data: { "SelectedCourseID": splitedCourse[0], 'SemesterID': splitedCourse[1] },
                    success: function (data) {

                        $subjectgrp.html('');
                        $subjectgrp.append('<option value="">---Select Subject---</option>');
                        $.each(data, function (id, option) {
                            $subjectgrp.append($('<option></option>').val(option.id + "~" + option.SubjectGroupID).html(option.name));
                        })
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Departments.');
                        //$departmentProgress.hide();
                    }

                })



            }

        });

        $("#Center").on("change", function () {
            var centerCode = $(this).val();
            var $courseYear = $("#CourseType");
            if ($("#Center").val() != "") {
                $.ajax({

                    cache: false,
                    type: "GET",
                    url: "/OnlineExamQuestionBankMasterAndDetails/GetCourseYearByCenterCode",
                    data: { "SelectedCenterCode": centerCode },
                    success: function (data) {
                        console.log(data);
                        $courseYear.html('');
                        $courseYear.append('<option value="">---Select Course---</option>');
                        $.each(data, function (id, option) {
                            $courseYear.append($('<option></option>').val(option.ID + "~" + option.OrgSemesterMstID).html(option.Name));
                        })
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Departments.');
                        //$departmentProgress.hide();
                    }
                })
            }

        });

      
        //Enable/Disable subject textbox according to questiontype
        $("#GenQuestionType").on("change", function () {
            var relatedWith = $(this).val().split("~")[0];
            if (relatedWith == "S") {
                $("#SubjectName").prop("disabled", false);
            }
            else {
                $("#SubjectName").prop("disabled", true);
                $("#SubjectID").val(0);
                $("#SubjectName").val('');
            }
        });

        //Initialize subject searchlist
        $("#SubjectName").on("keydown", function () {
            OnlineExamQuestionBankMasterAndDetails.SubjectSearchList();
        });
        $('#IsQuestionInImage').change(function () {
            if (this.checked) {
                $('#DivQuestionLableText').hide(true);
                $('#DivQuestionImage').show(true);
            }
            else {
                $('#DivQuestionLableText').show(true);
                $('#DivQuestionImage').hide(true);
                $('#DivQuestionLableText').val('');
            }
        });

        $('#IsOptionInImage').change(function () {
            if (this.checked) {
                $('#DivOptionText').hide(true);
                $('#DivOptionImage').show(true);
            }
            else {
                $('#DivOptionText').show(true);
                $('#DivOptionImage').hide(true);
                $('#DivOptionText').val('');
            }
        });

        $('#IsQuestionDescriptive').change(function () {
            if (this.checked) {
                $('#OptionDivForQuestion').hide();
                $('input[name=IsAttachmentCompalsary]').prop('disabled', false);
            }
            else {
                $('#OptionDivForQuestion').show();
                $('input[name=IsAttachmentCompalsary]').prop('disabled', true);
                $('input[name=IsAttachmentCompalsary]').prop('checked', false);
            }
        });

        $("#clearAttachementResponse").click(function () {
            $('input[name=IsAttachmentCompalsary]').prop('checked', false);
        });

        $("#OptionImageFile").change(function () {
            //  var filename = "OptionImageFile";
            var OptionImageType = $('#OptionImageFile')[0].files[0].type;
            var Extension = OptionImageType.split('/');
            OptionImageFileSize = $("#OptionImageFile")[0].files[0].size;
            OptionImageFilename = $('#OptionImageFile')[0].files[0].name;
            //  alert(OptionImageFileSize);
            if (OptionImageFilename != "" && OptionImageFilename != "undefined") {
                if (OptionImageFileSize <= 50000) {
                    if (Extension[1] == "gif" || Extension[1] == "png" || Extension[1] == "bmp" || Extension[1] == "jpeg" || Extension[1] == "jpg") {
                        var data = new FormData();
                        var files = $("#OptionImageFile").get(0).files;
                        if (files.length > 0) {
                            data.append("MyImages", files[0]);
                        }
                    }
                    else {
                        $('#DisplayMessage').html("Option image only allows file types of GIF, PNG, JPG, JPEG and BMP. ");
                        $('#DisplayMessage').delay(400).slideDown(400).delay(5000).slideUp(400).css('background-color', '#F5CCCC');
                        $("#OptionImageFile").replaceWith($("#OptionImageFile").val('').clone(true));
                        return false;
                    }
                }
                else {
                    $('#DisplayMessage').html("Maximum file size exceeds,Your option image size should be less than 50 kb ");
                    $('#DisplayMessage').delay(400).slideDown(400).delay(5000).slideUp(400).css('background-color', '#F5CCCC');
                    $("#OptionImageFile").replaceWith($("#OptionImageFile").val('').clone(true));
                }
            }
            else {
                $('#DisplayMessage').html("The selected file does not appear to be an image.");
                $('#DisplayMessage').delay(400).slideDown(400).delay(5000).slideUp(400).css('background-color', '#F5CCCC');
                $("#OptionImageFile").replaceWith($("#OptionImageFile").val('').clone(true));
            }
        });

        $("#QuestionImageFile").change(function () {
            debugger
            //  var filename = "OptionImageFile";
            var OptionImageType = $('#QuestionImageFile')[0].files[0].type;
            var Extension = OptionImageType.split('/');
            QuestionImageFileSize = $("#QuestionImageFile")[0].files[0].size;
            QuestionImageFileName = $('#QuestionImageFile')[0].files[0].name;
            //  alert(OptionImageFileSize);
            if (QuestionImageFileName != "" && QuestionImageFileName != "undefined") {
                if (QuestionImageFileSize <= 50000) {
                    if (Extension[1] == "gif" || Extension[1] == "png" || Extension[1] == "bmp" || Extension[1] == "jpeg" || Extension[1] == "jpg") {
                        var data = new FormData();
                        var files = $("#QuestionImageFile").get(0).files;
                        if (files.length > 0) {
                            data.append("MyImages", files[0]);
                        }
                    }
                    else {
                        $('#displayErrorMessage').html("Option image only allows file types of GIF, PNG, JPG, JPEG and BMP. ");
                        $('#displayErrorMessage').delay(400).slideDown(400).delay(5000).slideUp(400).css('background-color', '#F5CCCC');
                        $("#QuestionImageFile").replaceWith($("#QuestionImageFile").val('').clone(true));
                        return false;
                    }
                }
                else {
                    $('#displayErrorMessage').html("Maximum file size exceeds,Your option image size should be less than 50 kb ");
                    $('#displayErrorMessage').delay(400).slideDown(400).delay(5000).slideUp(400).css('background-color', '#F5CCCC');
                    $("#QuestionImageFile").replaceWith($("#QuestionImageFile").val('').clone(true));
                }
            }
            else {
                $('#displayErrorMessage').html("The selected file does not appear to be an image.");
                $('#displayErrorMessage').delay(400).slideDown(400).delay(5000).slideUp(400).css('background-color', '#F5CCCC');
                $("#QuestionImageFile").replaceWith($("#QuestionImageFile").val('').clone(true));
            }
        });

        // Create new record
        $('#addItem').on("click", function () {
            var IsOptionInImage = document.getElementById("IsOptionInImage").checked;
            if (IsOptionInImage == true && $("#OptionImageFile").get(0).files.length == 0) {
                //  alert("Please Select Option Image.");
                $('#DisplayMessage').html("Option image must be selected");
                $('#DisplayMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', '#F5CCCC');
                $('#OptionImageFile').focus();
                return false;
            }
            else if (IsOptionInImage == false && ($("#OptionText").val() == "" || $("#OptionText").val() == null)) {
                //alert("Please Enter Option Text.");
                $('#DisplayMessage').html("Option text should not be blank");
                $('#DisplayMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', '#F5CCCC');
                $("#OptionText").focus();
                return false;
            }
            var data = new FormData();
            var files = $("#OptionImageFile").get(0).files;
            if (files.length > 0) {
                data.append("MyImages", files[0]);
            }
            if (IsOptionInImage == true) {
                $.ajax({
                    url: "/OnlineExamQuestionBankMasterAndDetails/UploadFile",
                    type: "POST",
                    processData: false,
                    contentType: false,
                    data: data,              //A => Answer
                    dataType: 'json',
                    success: function (result) {
                        //alert(result)
                        //code after success
                        OnlineExamQuestionBankMasterAndDetails.OptionImageFileName = result;
                        //alert(OptionImageFileName);
                        //$("#txtImg").val(response);
                        //$("#imgPreview").attr('src', '/Upload/' + response);
                    },
                    async: false,
                    error: function (er) {
                        alert(er);
                    }
                });
            }
            var IsAns = '';
            var IsAnsVal = '';
            var isDisabled = '';
            if ((document.getElementById("IsAnswer").disabled == true)) {
                isDisabled = 'disabled';
            }
            if (document.getElementById("IsAnswer").checked == true) {
                IsAns = 'checked';
                IsAnsVal = 1;
                $("#IsAnswer").prop("disabled", true);
                $("#tblData tbody tr td input[id='IsAns']").prop("disabled", true);
            }
            else {
                IsAns = '';
                IsAnsVal = 0;
            };
            //if (parseFloat($('#AvailableStock').val()) > parseFloat($('#Quantity').val())) 
            //  alert(OnlineExamQuestionBankMasterAndDetails.OptionImageFileName);
            var IsOptionInImage = document.getElementById("IsOptionInImage").checked;
            if (IsOptionInImage == true) {

                $("#tblData tbody").append(
                    "<tr>" +
                    "<td ><input type='hidden' class='OnlineExamAnsDetailId' value='0' /><input type='checkbox' class='IsImg' value='1' checked='checked' disabled= 'disabled'/> " + "</td>" +
                    "<td><input type='text' style='width:60%;display:none;' value='" + OnlineExamQuestionBankMasterAndDetails.OptionImageFileName + "'/><img src='/Content/UploadedFiles/AnswerImage/" + OnlineExamQuestionBankMasterAndDetails.OptionImageFileName + "' style='width: 60px;'/></td>" +
                    "<td><input type='checkbox' id='IsAns' class='EnableDisable' value=" + IsAnsVal + " " + IsAns + " " + isDisabled + " > " + "</td>" +
                    "<td> <i class='zmdi zmdi-delete zmdi-hc-fw' style='cursor:pointer'' title = Delete></td>" +
                    "</tr>");

                $("#IsOptionInImage").prop("checked", false);
                $("#IsAnswer").prop("checked", false);
                $("#OptionImageFile").replaceWith($("#OptionImageFile").val('').clone(true));
                $('#DivOptionText').show(true);
                $('#DivOptionImage').hide(true);
                $('#DivOptionText').val('');
            }
            else {

                $("#tblData tbody").append(
                "<tr>" +
                    "<td ><input type='hidden' class='OnlineExamAnsDetailId' value='0' /><input type='checkbox' class='IsImg' value='0' disabled= 'disabled' /> " + "</td>" +
                    "<td><input id='optionText' type='text' style='width:94%' value='" + $("#OptionText").val() + "'/></td>" +
                    "<td ><input type='checkbox' id='IsAns' class='EnableDisable' value=" + IsAnsVal + " " + IsAns + " " + isDisabled + " > " + "</td>" +
                    "<td> <i class='zmdi zmdi-delete zmdi-hc-fw' style='cursor:pointer'' title = Delete></td>" +
                    "</tr>");
                $("#OptionText").val('');
                $("#IsAnswer").prop("checked", false);
            }
            $("#tblData tbody").on("click", "tr td i", function () {
                var ImageName = $(this).parent().prev().prev().children().val();
                $.ajax({
                    url: "/OnlineExamQuestionBankMasterAndDetails/DeleteImage",
                    type: "POST",
                    data: { "ImageName": ImageName },
                    dataType: 'json',
                    success: function (data) {
                    },
                });
                if ($(this).parent().prev().children().is(":checked")) {
                    $("#tblData tbody tr td input[id='IsAns']").prop("disabled", false);
                    $("#IsAnswer").prop("disabled", false);
                }
                $(this).closest('tr').remove();
            });
            OnlineExamQuestionBankMasterAndDetails.EnableDisable();
            OnlineExamQuestionBankMasterAndDetails.DeleteAnswerOption();
            $('#IsOptionInImage').focus();
        });

        // Create new record
        $('#CreateOnlineExamQuestionBankMasterAndDetailsRecord').on("click", function () {
            var GenQuestionType = $("#GenQuestionType").val()
            if (GenQuestionType == "") {
                $("#displayErrorMessage p").text('Please select General Question Type.').closest('div').fadeIn().closest('div').addClass('alert-' + 'warning');
            }
            var GeneralQuestionLevelMasterID = $("#GeneralQuestionLevelMasterID").val()
            if (GeneralQuestionLevelMasterID == "") {
                $("#displayErrorMessage p").text('Please select General Question Level.').closest('div').fadeIn().closest('div').addClass('alert-' + 'warning');
            }
            var IsAnswerSet = false;
            var IsQuestionDescriptive = $('#IsQuestionDescriptive').is(":checked") ? true : false;

            if (IsQuestionDescriptive == false) {
                $(".EnableDisable").each(function () {
                    if ($(this).is(":checked")) {
                        IsAnswerSet = true;
                    }
                });
                if (IsAnswerSet == false) {
                    $('#DisplayMessage').html("Answer Must Be Selected.");
                    $('#DisplayMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', '#F5CCCC');
                    return false;
                }
            }
            OnlineExamQuestionBankMasterAndDetails.ActionName = "Create";
            var relatedWith = $("#GenQuestionType").val().split('~')[0];
            var IsQuestionInImage = $('#IsQuestionInImage:checked').val() ? "true" : "false";
            //var subjectId = $("#SubjectID").val();
            if (relatedWith == "S") {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SubjectRequiredForQueType", "DivSuccessMessage", "#FFCC80");
            }
            else {
                if (IsQuestionDescriptive == false) {
                    OnlineExamQuestionBankMasterAndDetails.GetXmlData();
                    if (OnlineExamQuestionBankMasterAndDetails.XMLstring != null) {
                        OnlineExamQuestionBankMasterAndDetails.AjaxCallOnlineExamQuestionBankMasterAndDetails();
                    }
                } else {
                    OnlineExamQuestionBankMasterAndDetails.AjaxCallOnlineExamQuestionBankMasterAndDetails();
                }

                //if (OnlineExamQuestionBankMasterAndDetails.XMLstring != null) {
                //    if (IsQuestionInImage == "true" && $('#QuestionImageFile').val() != '') {
                //        OnlineExamQuestionBankMasterAndDetails.AjaxCallOnlineExamQuestionBankMasterAndDetails();
                //    }
                //    else if (IsQuestionInImage == "false") {
                //    OnlineExamQuestionBankMasterAndDetails.AjaxCallOnlineExamQuestionBankMasterAndDetails();
                //    }
                //    else {
                //        $('#DivSuccessMessage').html("Question image must be selected");
                //        $('#DivSuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', '#F5CCCC');
                //    }
                //}
                //else {
                //    $('#DivSuccessMessage').html("Please enter answer option");
                //    $('#DivSuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', '#F5CCCC');
                //}
            }
        });

        $('#CreateQuestionBankRecord').on("click", function () {
            //alert('');
            OnlineExamQuestionBankMasterAndDetails.ActionName = "CreateQuestionBank";
            OnlineExamQuestionBankMasterAndDetails.AjaxCallOnlineExamQuestionBankMasterAndDetails();
        });

        $('#EditOnlineExamQuestionBankMasterAndDetailsRecord').on("click", function () {
            var IsQuestionDescriptive = $('#IsQuestionDescriptive').is(":checked") ? true : false;
            var IsAnswerSet = false;
            if (IsQuestionDescriptive == false) {
                $(".EnableDisable").each(function () {
                    if ($(this).is(":checked")) {
                        IsAnswerSet = true;
                    }
                });
                if (IsAnswerSet == false) {
                    $('#DisplayMessage').html("Answer Must Be Selected.");
                    $('#DisplayMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', '#F5CCCC');
                    return false;
                }
            }
            OnlineExamQuestionBankMasterAndDetails.ActionName = "Edit";
            OnlineExamQuestionBankMasterAndDetails.GetXmlDataForEdit();
            OnlineExamQuestionBankMasterAndDetails.AjaxCallOnlineExamQuestionBankMasterAndDetails();
        });

        $('#DeleteOnlineExamQuestionBankMasterAndDetailsRecord').on("click", function () {
            OnlineExamQuestionBankMasterAndDetails.ActionName = "Delete";
            OnlineExamQuestionBankMasterAndDetails.AjaxCallOnlineExamQuestionBankMasterAndDetails();
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

    ValidateFileUpload: function (fileName) {
        var fuData = document.getElementById(fileName);
        var FileUploadPath = fuData.value;
        if (FileUploadPath == '') {
            alert("Please upload an image");

        } else {
            var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();

            if (Extension == "gif" || Extension == "png" || Extension == "bmp"
                        || Extension == "jpeg" || Extension == "jpg") {

                if (fuData.files && fuData.files[0]) {

                    var size = fuData.files[0].size;
                    //alert(size);

                    if (size > 50000) {
                        return 1;
                    } else {
                        var reader = new FileReader();

                        reader.onload = function (e) {
                            $('#blah').attr('src', e.target.result);
                        }

                        reader.readAsDataURL(fuData.files[0]);
                    }
                }

            }
            else {
                alert("Photo only allows file types of GIF, PNG, JPG, JPEG and BMP. ");
            }
        }
    },
    //LoadList method is used to load List page
    LoadList: function () {
        debugger
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/OnlineExamQuestionBankMasterAndDetails/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        debugger
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode },
            url: '/OnlineExamQuestionBankMasterAndDetails/List',
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
    AjaxCallOnlineExamQuestionBankMasterAndDetails: function () {
        var OnlineExamQuestionBankMasterAndDetailsData = null;
        if (OnlineExamQuestionBankMasterAndDetails.ActionName == "Create") {
            $("#FormCreateOnlineExamQuestionBankMasterAndDetails").validate();
            if ($("#FormCreateOnlineExamQuestionBankMasterAndDetails").valid()) {
                OnlineExamQuestionBankMasterAndDetailsData = null;
                OnlineExamQuestionBankMasterAndDetailsData = OnlineExamQuestionBankMasterAndDetails.GetOnlineExamQuestionBankMasterAndDetails();
                ajaxRequest.makeRequest("/OnlineExamQuestionBankMasterAndDetails/Create", "POST", OnlineExamQuestionBankMasterAndDetailsData, OnlineExamQuestionBankMasterAndDetails.Success);
            }
        }
        else if (OnlineExamQuestionBankMasterAndDetails.ActionName == "Edit") {
            debugger
            $("#FormEditOnlineExamQuestionBankMasterAndDetails").validate();
            if ($("#FormEditOnlineExamQuestionBankMasterAndDetails").valid()) {
                OnlineExamQuestionBankMasterAndDetailsData = null;
                OnlineExamQuestionBankMasterAndDetailsData = OnlineExamQuestionBankMasterAndDetails.GetOnlineExamQuestionBankMasterAndDetails();
                ajaxRequest.makeRequest("/OnlineExamQuestionBankMasterAndDetails/Edit", "POST", OnlineExamQuestionBankMasterAndDetailsData, OnlineExamQuestionBankMasterAndDetails.Success);
            }
        }
        else if (OnlineExamQuestionBankMasterAndDetails.ActionName == "Delete") {
            OnlineExamQuestionBankMasterAndDetailsData = null;
            //$("#FormCreateOnlineExamQuestionBankMasterAndDetails").validate();
            OnlineExamQuestionBankMasterAndDetailsData = OnlineExamQuestionBankMasterAndDetails.GetOnlineExamQuestionBankMasterAndDetails();
            ajaxRequest.makeRequest("/OnlineExamQuestionBankMasterAndDetails/Delete", "POST", OnlineExamQuestionBankMasterAndDetailsData, OnlineExamQuestionBankMasterAndDetails.Success);

        } else if (OnlineExamQuestionBankMasterAndDetails.ActionName == "CreateQuestionBank") {
            //alert();
            $("#FormCreateQuestionBank").validate();
            if ($("#FormCreateQuestionBank").valid()) {
                OnlineExamQuestionBankMasterAndDetailsData = null;
                OnlineExamQuestionBankMasterAndDetailsData = OnlineExamQuestionBankMasterAndDetails.GetOnlineExamQuestionBankMasterAndDetails();
                ajaxRequest.makeRequest("/OnlineExamQuestionBankMasterAndDetails/CreateQuestionBank", "POST", OnlineExamQuestionBankMasterAndDetailsData, OnlineExamQuestionBankMasterAndDetails.BankMasterSuccess);
            }
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetOnlineExamQuestionBankMasterAndDetails: function () {
        var Data = {
        };
        if (OnlineExamQuestionBankMasterAndDetails.ActionName == "Create" || OnlineExamQuestionBankMasterAndDetails.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.OnlineExamQuestionBankMasterID = $('#OnlineExamQuestionBankMasterID').val();
            Data.GeneralQuestionLevelMasterID = $('#GeneralQuestionLevelMasterID').val();
            if (OnlineExamQuestionBankMasterAndDetails.ActionName == "Create") {
                Data.GenQuestionTypeID = $("#GenQuestionType").val().split('~')[0];
                Data.GenQuestionType = $("#GenQuestionType").val().split('~')[1];
            }
            else {
                Data.GenQuestionTypeID = $("#GenQuestionTypeID").val();
                Data.OnlineExamQuestionBankDetailsID = $("#OnlineExamQuestionBankDetailsID").val();
            }
            // Data.SubjectID = $('input[name=SubjectID]').val();
            Data.IsQuestionInImage = $('#IsQuestionInImage:checked').val() ? true : false;
            var QuestionImageFileSize = null;
            var QuestionImageType = null;
            var QuestionImageFilename = null;
            var QuestionImageFileWidth = null;
            var QuestionImageFileHeight = null;
            Data.QuestionLableText = $('#QuestionLableText').val();
            Data.Width = 1;
            Data.Height = 1;
            Data.IsQuestionDescriptive = $('#IsQuestionDescriptive').is(":checked") ? true : false;;
            Data.IsAttachmentCompalsary = $('input[name=IsAttachmentCompalsary]:checked').val();
            //if (Data.IsQuestionInImage == false) {
                
            //    Data.ImageType = QuestionImageType;
            //    Data.ImageName = QuestionImageFilename;
                
            //}

            //else {
                //For Image          
                var img = document.getElementById('QuestionImageFile');
                if ($("#QuestionImageFile").val() != "") {
                    if (typeof ($("#QuestionImageFile")[0].files) != "undefined") {
                        QuestionImageFileSize = $("#QuestionImageFile")[0].files[0].size;
                        QuestionImageType = $('#QuestionImageFile')[0].files[0].type;
                        QuestionImageFilename = $('#QuestionImageFile')[0].files[0].name;
                        QuestionImageFileWidth = img.width;
                        QuestionImageFileHeight = img.height;
                    }
                    var data = new FormData();
                    var files = $("#QuestionImageFile").get(0).files;
                    if (files.length > 0 && QuestionImageFileSize <= 50000) {
                        data.append("MyImages", files[0]);
                        $.ajax({
                            url: "/OnlineExamQuestionBankMasterAndDetails/UploadQuestionFile",
                            type: "POST",
                            processData: false,
                            contentType: false,
                            data: data,               //Q => Question
                            dataType: 'json',
                            success: function (result) {
                                OnlineExamQuestionBankMasterAndDetails.QuestionImageFileName = result;
                            },
                            async: false,
                            error: function (er) {
                                // alert(er);
                            }
                        });
                    }
                    Data.ImageType = QuestionImageType;
                    Data.ImageName = OnlineExamQuestionBankMasterAndDetails.QuestionImageFileName;
                    Data.Width = QuestionImageFileWidth;
                    Data.Height = QuestionImageFileHeight;
                    //Data.QuestionLableText = "-";
                }
                else {
                    var ImageType = $('#ImageTypeID').val();
                    var ImageName = $('#ImageNameID').val();
                    Data.ImageType = ImageType;
                    Data.ImageName = ImageName;
                    //Data.QuestionLableText = "-";
                }
            //}
            Data.SelectedXml = OnlineExamQuestionBankMasterAndDetails.XMLstring;
        }
        else if (OnlineExamQuestionBankMasterAndDetails.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        } else if (OnlineExamQuestionBankMasterAndDetails.ActionName == "CreateQuestionBank") {
            var courseSelected = $('#CourseType').val();
            var splitcourseSelected = courseSelected.split("~");
            var SubjectGroupTypeSelected = $('#SubjectGroupType').val();
            var splitSubjectGroupTypeSelected = SubjectGroupTypeSelected.split("~");
            Data.Center = $('#Center').val();
            Data.CourseYearDetailID = splitcourseSelected[0];
            Data.OrgSemesterMstID = splitcourseSelected[1];
            Data.SubjectID = splitSubjectGroupTypeSelected[0];
            Data.SubjectGroupID = splitSubjectGroupTypeSelected[1];
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        debugger
        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            OnlineExamQuestionBankMasterAndDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            OnlineExamQuestionBankMasterAndDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    BankMasterSuccess: function (data) {

        var splitData = data.split(',');
        $(".sweet-overlay").css('z-index', 1043)
        swal({
            title: splitData[0],

            //type: points[parseInt(settings.bulktype)]['type'],
            //showCancelButton: true,
            confirmButtonClass: 'btn-' + splitData[1],
            confirmButtonText: "Ok!"
        }, function (isConfirm) {
            if (isConfirm) {
                window.location.reload();
            }
        });

    },

    EnableDisable: function () {
        $("#tblData tbody tr td input[id='IsAns']").on('click', function () {
            var $this = $(this);
            if ($this.is(":checked")) {
                $("#tblData tbody tr td input[id='IsAns']").prop("disabled", true);
                $("#IsAnswer").prop("disabled", true);
                $this.val(1);
                $this.prop("disabled", false);
            }
            else {
                $("#tblData tbody tr td input[id='IsAns']").prop("disabled", false);
                $("#IsAnswer").prop("disabled", false);
                $this.val(0);
            }
        });
    },

    DeleteAnswerOption: function () {
        $("#tblData tbody").on("click", "tr td i[class=icon-trash]", function () {
            $(this).closest('tr').remove();
        });
    },
    GetXmlData: function () {
        debugger
        var DataArray = [];
        $('#tblData input').each(function () {

            DataArray.push($(this).val());
        });
        var DatatableData, TotalRecord, TotalRow;
        TotalRecord = DataArray.length;
        ParameterXml = "<rows>";

        for (var i = 0; i < TotalRecord; i = i + 4) {

            if (DataArray[i + 1] == 1) {
                ParameterXml = ParameterXml + "<row><ID>" + DataArray[i] + "</ID><OptionText></OptionText><OptionImage>" + DataArray[i + 2] + "</OptionImage><IsAnswer>" + DataArray[i + 3] + "</IsAnswer></row>";
            }
            else {
                ParameterXml = ParameterXml + "<row><ID>" + DataArray[i] + "</ID><OptionText>" + DataArray[i + 2] + "</OptionText><OptionImage></OptionImage><IsAnswer>" + DataArray[i + 3] + "</IsAnswer></row>";
            }
            OnlineExamQuestionBankMasterAndDetails.XMLstring = ParameterXml + "</rows>";
        }
    },
    GetXmlDataForEdit: function () {
        var DataArray = [];
        $('#tblData input').each(function () {

            DataArray.push($(this).val());
        });
        var DatatableData, TotalRecord, TotalRow;
        TotalRecord = DataArray.length;
        ParameterXml = "<rows>";

        for (var i = 0; i < TotalRecord; i = i + 4) {
            if (DataArray[i + 1] == 1) {
                ParameterXml = ParameterXml + "<row><ID>" + DataArray[i] + "</ID><OptionText></OptionText><OptionImage>" + DataArray[i + 2] + "</OptionImage><IsAnswer>" + DataArray[i + 3] + "</IsAnswer></row>";
            }
            else {
                ParameterXml = ParameterXml + "<row><ID>" + DataArray[i] + "</ID><OptionText>" + DataArray[i + 2] + "</OptionText><OptionImage></OptionImage><IsAnswer>" + DataArray[i + 3] + "</IsAnswer></row>";
            }
            OnlineExamQuestionBankMasterAndDetails.XMLstring = ParameterXml + "</rows>";
        }
    },
    //Search list for subject
    SubjectSearchList: function () {
        $("#SubjectName").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "/Base/GetSubjectList",
                    type: "POST",
                    dataType: "json",
                    data: { "term": request.term },
                    success: function (data) {
                        if (!data.length) {
                            var result = [{ label: 'No matches found', value: response.term }];
                            response(result);
                        }
                        else {
                            response($.map(data, function (item) {
                                return { label: item.name, value: item.name, id: item.id };
                            }))
                        }
                    }
                })
            },
            select: function (event, ui) {
                if (ui.item.value != "No matches found") {
                    $(this).val(ui.item.label);
                    $("#SubjectID").val(parseInt(ui.item.id));
                }
            }
        });
    },

    showQueImageOnHover: function () {
        $("#myDataTable tbody").on("mouseenter", "tr td p img[id=QueImage]", function () {
            var img = this,
                $img = $(img),
                offset = $img.offset();
            $(this).removeClass('imageclass');
        });
        $("#myDataTable tbody").on("mouseleave", "tr td p img[id=QueImage]", function () {
            $(this).addClass('imageclass');
        });
    },

    showAnsImageOnHover: function () {
        $("#myDataTable tbody").on("mouseenter", "tr td p img[id=AnsImage]", function () {
            var img = this,
                $img = $(img),
                offset = $img.offset();
            $(this).removeClass('imageclass');
        });
        $("#myDataTable tbody").on("mouseleave", "tr td p img[id=AnsImage]", function () {
            $(this).addClass('imageclass');
        });
    },
};

