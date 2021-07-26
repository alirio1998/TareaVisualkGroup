

$(document).on('ajaxStart', function () {

    loading_show();
});

$(document).on('ajaxStop', function (start) {
    loading_hide();
});

function loading_show() {
    console.log("Start");
    $('body').loadingModal({
        text: 'Por favor espere',
        animation: 'circle',
    });
    $('body').loadingModal('show');
}

function loading_hide() {
    $('body').loadingModal('hide');
}
