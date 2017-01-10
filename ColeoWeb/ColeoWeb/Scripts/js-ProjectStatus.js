var urlEdit;
var urlIndex;
var urlList;
var urlDelete;

function ShowList() {
    // re post the list with the updated item
    $.ajax({
        type: "GET",
        url: urlList,//'@Url.Action("List", "ProjectStatus")',
        success: function (response) {
            $("#index-projectstatus").html(response);
        },
        error: function () {
            alert("error occured");
        }
    });

    // validate form for alert
    //$.validator.unobtrusive.parse($("#edit-projectstatus"));
}


function ShowEdit(id) {

    event.preventDefault();

    $.ajax({
        type: "GET",
        remote: true,
        url: urlEdit,//'@Url.Action("Edit", "ProjectStatus")',
        data: { 'id': id },
        success: function (response) {
            $("#edit-projectstatus").html(response);
        },
        error: function (response) {
            console.log(response);
        }
    });
    return false;
}


function DeleteItem(item) {
    $.ajax({
        type: "POST",
        data: { id: item },
        url: urlDelete,//'@Url.Action("Delete", "ProjectStatus")',
        success: function (response) {

            $('#edit-projectstatus').empty();
            ShowList();

            if (response == 'True') {
                NotificationAlert('Project status deleted!');
            } else {
                NotificationAlert('The project status that you attempted to delete it is attached to a project therefore it can not be deleted!', "danger", false, 2000);
            }

        },
        error: function () {
            alert("error occured");
        }
    });
}

