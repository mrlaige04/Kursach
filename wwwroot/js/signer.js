var signin = document.body.getElementsByClassName("signin");
var signup = document.body.getElementsByClassName("signup");
var submiter = document.body.getElementById("submitter");


$(signin).click(function () {
    document.body.removeChild(signup);
});

$(signup).click(function () {
    document.body.removeChild(signin);
});

