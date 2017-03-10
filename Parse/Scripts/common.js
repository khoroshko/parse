$(document).ready(function () {
    initInputMask();
});

function initInputMask() {
    try {
        if (jQuery().mask) {
            //Phone
            $("[phonemask]").mask("1(999) 999-9999");
        }
    } catch (e) {
        console.error(e);
    }
}