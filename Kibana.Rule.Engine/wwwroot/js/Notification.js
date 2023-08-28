"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7012/notificationHub").build();

this.connection.start().then(() => {
    console.log('connection started');
}).catch(err => console.log(err));

this.connection.on('privateMessageMethodName', (data) => {
    debugger;
    console.log('private Message:' + data);
});

//connection.on("ReceiveMessage", function (message) {
//    var li = document.createElement("li");
//    document.getElementById("messagesList").appendChild(li);

//    li.textContent = ` user says ${message}`;
//});

this.connection.on('test',(data) => {
    console.log(data);
    this.connection.invoke('SendMessage', 'admin1@gmail.com', data).catch(err => console.log(err));
    document.getElementById("msglabel").innerHTML = data;
});

//connection.start().then(function () {
//    document.getElementById("sendButton").disabled = false;
//}).catch(function (err) {
//    return console.error(err.toString());
//});

//document.getElementById("sendButton").addEventListener("click", function (event) {

//    var message = document.getElementById("messageInput").value;
//    connection.invoke("SendMessage", message).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});
