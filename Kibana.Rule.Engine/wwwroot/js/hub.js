"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7012/adminhub").build();

 connection.start().then(function () {
        console.log('Connected to adminHub');
    }).catch(function (err) {
        return console.error(err.toString());
    });


connection.on("ReceivedMessage", function (message) {
    console.log(message);
    document.getElementById("msglabel").innerHTML = message;
});
