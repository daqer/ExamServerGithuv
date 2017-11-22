var login = {
    fldUsername: $('#email').val(),
    fldPassword: $('#password').val(),
}
var project = {

}

$(document).ready(function () {

    $("#CreateLogin").click(function () {
        $.post({
            url: 'http://localhost:50458/api/logins',
            method: 'POST',
            data: {
                    
            },
            success: function () {
                alert("Success");
            }
        })
        $.post({
            url: 'http://localhost:50458/api/teams',
            method: 'POST',
            data: {
                fldTeamName: $('#TeamName').val(),
                fldTopic: $('#Category').val(),
                fldLeaderName: $('#TeamLeader').val(),

            }

        })
        alert("Team has been registered. Please log in to continue");
        window.location.href = "index.html";
    });

});



