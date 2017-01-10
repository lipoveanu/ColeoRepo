// Pick-up-color

function InitializePickColor() {
    console.log("initialize pick a color");

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
    console.log("notification defaults");

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
        axis: "y",
        opacity: 0.9,
        cursor: 'move',
        containment: '#sortable',
        update: function () {
            ChangeOrder();
        }
    });
    
    //$('.panel').on('mousedown', function () {
    //    $(this).css('cursor', 'move');
    //}).on('mouseup', function () {
    //    $(this).css('cursor', 'auto');
    //});;
}

function ChangeOrder() {
    // reposition all components
    var positionIndex = 1;
    $('.sortable-item').each(function () {
        $(this).find('.position').val(positionIndex++);
    });
    //save in db
    $('#btn-save').trigger('click');
}

