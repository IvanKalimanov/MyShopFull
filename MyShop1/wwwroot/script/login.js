// если в сессии уже сохранен токен, то переходим на страницу чата
if (sessionStorage.getItem("token") != null)
document.location.href = "http://localhost:5000/index.html";

$('#enter').click(function () { // при клике на кнопку производим вход
let email = $('#email').val(); // вытаскиваем email
let password = $('#password').val(); // вытаскиваем пароль
$.ajax(
    {
        type: 'POST',
        url: 'http://localhost:5000/api/login',
        contentType: "application/json; charset=utf-8",
        data: `{ "email": "${email}", "password": "${password}" }`,
        success: function (data, textStatus) {
            sessionStorage.setItem("token", data);
            document.location.href = "http://localhost:5000/index.html";
        }
    });
});