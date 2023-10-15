document.addEventListener("DOMContentLoaded", function () {
    var buttonHeight = document.getElementById("details-btn").clientHeight;
    var customCardBody = document.getElementById("custom-card-body");
    customCardBody.style.height = `${buttonHeight + 10}px`;
});
