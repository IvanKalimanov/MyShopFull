let hubUrl = 'http://localhost:5000/chat'; //ссылка, по которому будем обращаться к хабу
let connection = new signalR.HubConnectionBuilder()  //строим соединение с хабом
    .withUrl(hubUrl)                      // в нашем случае будет использована технология web-socket
    .build();

//здесь мы задаем функцию, в которую будет отправлять новые данные хаб
connection.on('SendComment', function (name, message) {//первый параметр дублирует имя в методе отсылки хаба
    // в функции параметры - параметры, которые мы ожидаем получить от хаба
    $('#msgArea').append(`<div><h4><b>${name}: </b> ${message}</h4></div>`); //вставляем на страницу наши сообщения

});
connection.start(); // с этого момента мы пытаемся наладить соединение

$('#sendMsg').click(function () {
    console.log(1)
    // при клике на кнопку отсылаем сообщение
    let txt = $('#textOfMsg').val(); // вытаскиваем текст сообщения
    let name = $('#nameOfSender').val(); // вытаскиваем имя
    $('#textOfMsg').val(''); // обнуляем текст сообщения
    $.ajax(
        {
            type: 'POST',
            url: 'http://localhost:5000/api/chat/sendcomment',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: `{ "productId": "24b02989-18d1-4926-7926-08d7be907e21",
            "productName": "Обработка матриц","text": "${txt}", "nameOfSender": "${name}" }`,
            success: function (data, textStatus) {
                console.log(data); //выведем в консоль результат
            }
        });
});