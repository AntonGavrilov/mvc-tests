$(document).ready(function () {

    $("#btnLogin").click(function () {
        var nickName = $("#txtUserName").val();

        if (nickName) {
            var href = "/Home?user=" + encodeURIComponent(nickName);
            href = href + "&logOn=true";
            $("#LoginButton").attr("href", href).click();

            $("#UserName").text(nickName);
        }
    });
});

function LoginOnSuccess(result) {
    scroll();
    ShowLastRefresh();

    setTimeout("Refresh()", 5000);


    $('#txtMessage').keydown(function (e) {
        if (e.keyCode == 13) {
            e.preventDefault();
            $("#btnMessage").click();
        }
    });

    $("#btnMessage").click(function () {
        var text = $("#txtMessage").val();
        if (text) {

            //обращаемся к методу Index и передаем параметр "chatMessage"
            var href = "/Home?user=" + encodeURIComponent($("#UserName").text());
            href = href + "&chatMessage=" + encodeURIComponent(text);
            $("#ActionLink").attr("href", href).click();
            $("#txtMessage").val("");
        }
    });

    $("#btnLogOff").click(function () {

        var href = "/Home?user=" + encodeURIComponent($("#UserName").text());
        href = href + "&logOff=true";
        $("#ActionLink").attr("href", href).click();

        document.location.href = "Home";
    })
}

function LoginOnFailure(result) {
    $("#UserName").val("");
    $("#Error").text(result.responseText)
    setTimeout("$('#Error').empty();", 2000);
}

function Refresh(result) {
    var href = "?Home?user=" + encodeURIComponent($("#UserName").text());
    $("#ActionLink").attr("href", href).click();
    setTimeout("Refresh();", 5000);
}

function ChatOnFailure(result) {
    $("#Error").text(result.responseText)
    setTimeout("$('#Error').empty();", 2000);
}

function ChatOnSucess(result) {
    Scroll();
    ShowLastRefresh();
}


function Scroll() {
    var win = $('#Messages');
    var heigth = win[0].scrollHeight;
    win.scrollTop(heigth);
}

function ShowLastRefresh() {
    var dt = new Date();
    var time = dt.getHours() + ":" + dt.getMinutes() + ":" + dt.setSeconds();
    $("#LastRefresh").text("Последнее обновление бьыло в " + time);
}

