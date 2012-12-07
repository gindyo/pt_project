var change_made = false;
var last_selection; 

function loadSearchable(id, type) {
    if (change_made) {
        if (confirm("If you continue, you will lose your changes. Press OK to continue or press cancel to return and save your cahnges by clicking submit"))
        { window.location = "/unit/editcontent/" + id + "/" + type; }
        else
        {
            document.getElementById("types").selectedIndex = last_selection;
        }


    }
    else
        window.location = "/unit/editcontent/" + id + "/" + type;
}
function clear_textarea() {
    $('#searchable_textarea').val('');
}
$(document).ready(function(){
    $('#searchable_textarea').keyup(function () { change_made = true; });
    last_selection = document.getElementById("types").selectedIndex;
    
}
)