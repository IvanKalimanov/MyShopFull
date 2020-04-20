$('#register').click(function () { // при клике на кнопку производим регистрацию
    let email = $('#email').val(); // вытаскиваем email
    let password = $('#password').val(); // вытаскиваем пароль
    let name  = $('#name').val();
    let role = document.forms.regForm.role.value;
    $.ajax(
        {
            type: 'POST',
            url:   `http://localhost:5000/api/register/${role}`,
            contentType: "application/json; charset=utf-8",
            data: `{ "email": "${email}", "name": "${name}", "password": "${password}" }`,
            success: function (data, textStatus) {
                sessionStorage.setItem("token", data);
                document.location.href = "http://localhost:5000/index.html";
            }
        });
    });