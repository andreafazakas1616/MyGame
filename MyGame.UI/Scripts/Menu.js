var popUp = document.getElementById("myRestOption");
var button = document.getElementById("restOption");
var closeButton = document.getElementsByClassName("close")[0];

window.onclick = function (event) {
    if (event.target == popUp) {
        popUp.style.display = "none";
    }
}
button.onclick = function () {
        popUp.style.display = "block";
};
closeButton.onclick = function () {
    popUp.style.display = "none";
};