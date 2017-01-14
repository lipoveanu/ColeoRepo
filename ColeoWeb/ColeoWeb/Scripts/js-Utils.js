// Pick-up-color

function InitializePickColor() {

    //setting up pick up color
    $(".pick-a-color").pickAColor({
        showSpectrum: true,
        showSavedColors: true,
        saveColorsPerElement: false,
        fadeMenuToggle: true,
        showHexInput: true,
        showBasicColors: true,
        allowBlank: false,
        inlineDropdown: false
    });
}

function NotificationDefaults() {

    $.notifyDefaults({
        type: "success",
        allow_dismiss: true,
        newest_on_top: true,
        delay: 1000,
        placement: {
            from: "top",
            align: "right"
        },
        animate: {
            enter: 'animated fadeInDown',
            exit: 'animated fadeOutUp'
        },
        offset: {
            x: 30,
            y: 65
        }
    });
}

function NotificationAlert(message, type, allowDismiss, delay) {

    var notifyDefault = $.notifyDefaults('');

    if (type == null) {
        type = notifyDefault.type;
    }

    if (allowDismiss == null) {
        allowDismiss = notifyDefault.allow_dismiss;
    }

    if (delay == null) {
        delay = notifyDefault.delay;
    }

    $.notify(message, {
        type: type,
        allow_dismiss: allowDismiss,
        delay: delay
    });
}

function SetUpSortable() {

    $('.sortable-list').sortable({
        opacity: 0.7,
        cursor: 'move',
        containment: '#sortable',
        update: function () {
            ChangeOrder();
        }
    });
}

function ChangeOrder() {
    // reposition all components
    var positionIndex = 1;
    $('.sortable-item').each(function () {
        $(this).find('.position').val(positionIndex++);
    });
    //save in db
    $('#list-save').trigger('click');
}

function AddTooltip() {
    $(".add-tooltip").tooltip();
}

function SaveItem() {
    $('#item-save').trigger('click');
}

function ShowList(elem) {

    $.ajax({
        type: "GET",
        url: urlList,
        success: function (response) {
            elem.html(response);
        },
        error: function () {
            alert("error occured");
        }
    });

    // validate form for alert
    //$.validator.unobtrusive.parse($("#edit-projectstatus"));
}


function ShowEdit(id, elem) {

    event.preventDefault();

    $.ajax({
        type: "GET",
        remote: true,
        url: urlEdit,
        data: { 'id': id },
        success: function (response) {
            divList.removeClass().addClass("col-md-4");
            elem.html(response);
        },
        error: function (response) {
            console.log(response);
        }
    });
    return false;
}


function DeleteItem(id, elemList, elemEdit, alertDeleteSucces, alertDeleteError) {
    $.ajax({
        type: "POST",
        data: { id: id },
        url: urlDelete,
        success: function (response) {

            elemEdit.empty();
            ShowList(elemList);

            if (response == 'True') {
                NotificationAlert(alertDeleteSucces);
            } else {
                NotificationAlert(alertDeleteError, "danger", false, 2000);
            }

        },
        error: function () {
            alert("error occured");
        }
    });
}

function InitializeSortable2Lists() {

    console.log("initialize sortable list");


    $("#sortable1,#sortable2").sortable({
        connectWith: "#sortable1,#sortable2",
        opacity: 0.9,
        cursor: 'move',
        create: function (event, ui) {
            if (this.id == "sortable2") {
                var color = "#" + $(".pick-a-color").val();
                $(this).find(".sortable-item").css("background-color", color);
            }
        },
        beforeStop: function (event, ui) {
            $(this).sortable("option", "selfDrop", $(ui.placeholder).parent()[0] == this);
        },
        stop: function (event, ui) {
            var $sortable = $(this);
            if ($sortable.sortable("option", "selfDrop")) {
                $sortable.sortable('cancel');
                return;
            }
        },
        receive: function (event, ui) {
            var value;
            if (this.id == "sortable1") {
                value = "False";
                ui.item.css("background-color", "");
            }
            else {
                value = "True"
                var color = "#" + $(".pick-a-color").val();
                ui.item.css("background-color", color);
            }

            $(this).children().find('.assigned').val(value);


            //console.log("[" + this.id + "] received [" + ui.item.html() + "] from [" + ui.sender.attr("id") + "]");
        },
        over: function (event, ui) {
            if (this.id == "sortable1") {
                ui.item.css("background-color", "");
            }
            else {
                var color = "#" + $(".pick-a-color").val();
                ui.item.css("background-color", color);
            }
        }
    });

    $("#sortable1,#sortable2").disableSelection();

}


