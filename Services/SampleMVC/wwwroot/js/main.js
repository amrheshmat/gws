/* Set the width of the sidebar to 250px (show it) */
function openNav() {
    var element = document.getElementById("db-wrapper");
    element.classList.toggle("toggled");
}

/* Set the width of the sidebar to 0 (hide it) */
function closeNav() {
    document.getElementById("mySidepanel").style.width = "0";
}
$('#myModal').on('shown.bs.modal', function () {
    $('#myInput').trigger('focus')
})
$(document).ready(function () {
    setTimeout(function () {
        $("#preloader").css("z-index", "0");
    },4000);
});