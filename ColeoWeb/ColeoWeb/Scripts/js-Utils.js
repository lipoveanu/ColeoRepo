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

function NotificationAlert(response) {

    var notifyDefault = $.notifyDefaults('');

    $.notify(response.Message, {
        type: response.Type,
        allow_dismiss: response.AllowDismiss,
        delay: response.Delay
    });
}


function AddTooltip() {
    $(".add-tooltip").tooltip();
}

function SaveItem() {
    $('#item-save').trigger('click');
}


function ShowList(elem, order) {

    $.ajax({
        type: "GET",
        url: urlList,
        data: {order: order},
        success: function (response) {
            elem.html(response);
            
        },
        error: function () {
            alert("error occured");
        }
    });

}


function ShowEdit(id, elem) {

    event.preventDefault();

    $.ajax({
        type: "GET",
        remote: true,
        url: urlEdit,
        data: { 'id': id },
        success: function (response) {
            elem.html(response);
            //divList.find('.sortable-list').find('.sortable-item').removeClass('animated flipInY');
        },
        error: function (response) {
            console.log(response);
        }
    });
    return false;
}


function DeleteItem(id, elemList, elemEdit) {
    $.ajax({
        type: "POST",
        data: { id: id },
        url: urlDelete,
        dataType: "json",
        success: function (response) {

            elemEdit.empty();
            ShowList(elemList);
            NotificationAlert(response);
            
        },
        error: function (data) {
            console.log(data)
        }
    });
}

function DeleteFile(id) {
    $.ajax({
        type: "POST",
        data: { id: id },
        url: urlDeleteFile,
        dataType: "json",
        success: function (response) {

            SaveItem();
            NotificationAlert(response);
            
        },
        error: function (data) {
            console.log(data)
        }
    });
}

function SetUpSortable() {

    $('.sortable-list').sortable({
        opacity: 0.7,
        cursor: 'move',
        containment: '#sortable',
        update: function (event, ui) {
            ChangeOrder();
        },
        create: function (event, ui) {
            //console.log(ui);
        },
        start: function (event, ui) {
            ui.item.find(".mask").hide();
        },
        stop: function (event, ui) {
            ui.item.addClass("animated flipInY");
            ui.item.find(".mask").show();
        }
    });
}

function ChangeOrder() {
    // reposition all components
    var positionIndex = 1;
    var a = [];
    $('.sortable-item').each(function () {
        $(this).find('.position').val(positionIndex++);
        var key = $(this).find('.id').val();
        var value = $(this).find('.position').val();
        var obj = { Key: parseInt(key), Value: parseInt(value) };
        a.push(obj);
    });
    Reorder(a);
}

function Reorder(a) {
    $.ajax({
        type: "POST",
        data: { test: a },
        url: urlOrder,
        success: function (response) {
            console.log(response)
        },
        error: function () {
            alert("error occured");
        }
    });
}

function InitializeSortable2Lists() {

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


function ShowFunctionals() {
    $("#functional-buttons").show();
}

function FadeToogle() {

    if (divList.hasClass('slideInDown')) {
        divList.removeClass("slideInDown").addClass("slideOutUp");
        divEdit.removeClass("animated slideInUp slideInDown").addClass("animated slideInUp");
        divFunc.removeClass("animated slideInUp slideInDown").addClass("animated slideInUp");
    }
    else {

        divList.removeClass("slideOutUp").addClass("slideInDown");
        divEdit.removeClass("animated slideInUp slideInDown").addClass("animated slideInUp");
        divFunc.removeClass("animated slideInUp slideInDown").addClass("animated slideInUp");
    }

    divList.fadeToggle(500);
}

function MarkCurrent(elem) {
    $(".sortable-list").children().css("transform", "");
    $(elem).css("transform", "scale(0.95,0.95)");
}

function goToByScroll(id) {
    // Remove "link" from the ID
    id = id.replace("link", "");
    // Scroll
    $('html,body').animate({
        scrollTop: $("#" + id).offset().top
    },
        'slow');
}