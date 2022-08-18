//////////////////////////////////////////////////////////////////////
////////////////-- Page load --//////////////////
//////////////////////////////////////////////////////////////////////
$(function () {
    LoadList();
});

//////////////////////////////////////////////////////////////////////
////////////////-- Load List by Get() method --//////////////////
//////////////////////////////////////////////////////////////////////
function LoadList() {
    $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            url: '/AdminRoleDetails/List',
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);
            }
        });
}

//////////////////////////////////////////////////////////////////////
//////////////-- Reload List by Ajax--//////////////////////////////
//////////////////////////////////////////////////////////////////////

function ReloadList1(message) {
    location.reload();
}

function ReloadList(message) {
    $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            url: '/AdminRoleDetails/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#commonMessage').html(message).css('color', '#FFFFFF');
                $('#commonMessage').delay(400).slideDown(400).delay(3000).slideUp(400).css('background-color', '#5C8AE6');
            }
        });
}

//////////////////////////////////////////////////////////////////////
//////-- Show Success Message after Add New Record --//////
//////////////////////////////////////////////////////////////////////
function createSuccess() {

    if ($("#update-message").html() == "True") {

        //now we can close the dialog
        $('#dailogPopUp').dialog('close');

        //Reload List
        ReloadList("Admin Role Created Sucessfully.");

    } else {
        $("#update-message").show();
    }
}

//////////////////////////////////////////////////////////////////////
//////-- Show Success Message after Edit Record --///////////
//////////////////////////////////////////////////////////////////////
function editSuccess() {

    if ($("#update-message").html() == "True") {

        //now we can close the dialog
        $('#dialog-edit').dialog('close');

        //Reload List
        ReloadList("Admin Role Updated Sucessfully.");

    } else {
        $("#update-message").show();
    }
}


////////////////////////////////////////////////////////////////////////
////////-- Show Success Message after Edit Record --///////////
////////////////////////////////////////////////////////////////////////

function deleteSuccess() {

    if ($("#update-message").html() == "True") {

        //now we can close the dialog
        $('#delete-dialog').dialog('close');

        //Reload List
        ReloadList("Admin Role Deleted Sucessfully.");

    } else {
        $("#update-message").show();
    }
}

