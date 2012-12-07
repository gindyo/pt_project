$(document).ready(function () {
    $(".search_types").click(function () {
       $('#all').prop("checked",false)
   });
    $("#all").click(function () {
        $('.search_types').prop("checked", false)
    });

    $("#filters_a").click(function () {
        toggle_filters(this);
        });
})

function toggle_filters(a) {
    if ($(a).data('state') % 2 == 1) {
        $("#filters").hide(500);
        $(a).data('state', $(a).data('state') + 1);
    }
    else {
        $("#filters").show(500);
        $(a).data('state', $(a).data('state') + 1);
    }
}