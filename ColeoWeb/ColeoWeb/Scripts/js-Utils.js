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
        allow_dismiss: false,
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

function SetUpSortable() {
    $('.row').sortable({
        connectWith: ".panel",
        handle: ".item",
        placeholder: "panel-placeholder",
        update: function () {
            ChangeOrder();
        }
    });

    $('.panel').on('mousedown', function () {
        $(this).css('cursor', 'move');
    }).on('mouseup', function () {
        $(this).css('cursor', 'auto');
    });;
}

function ChangeOrder() {
    // reposition all components
    var positionIndex = 1;
    $('.panel-body').each(function () {
        $(this).find('.position').val(positionIndex++);
    });
    //save in db
    $('#btn-save').trigger('click');
}