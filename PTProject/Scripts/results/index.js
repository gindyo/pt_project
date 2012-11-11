$(document).ready(function(){
    $(".toggle").click(function (button) {
        toggle_cs(this);
    });
})

function toggle_cs(button) {
    var type_to_toggle = $(button).data("type_to_toggle")
    if ($(button).data("state") % 2 == 0) {
        $("." + type_to_toggle).show(500);
        $(button).text("Hide" + $(button).data("type_for_label"))
    }
    else if (($(button).data("state")%2 == 1)) {
        $("." + type_to_toggle).hide(500);
        $(button).text("Show" + $(button).data("type_for_label"));
    }
    $(button).data("state", $(button).data("state") + 1)

}