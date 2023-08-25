
       var connection = $.hubConnection("https://localhost:7012");
        var hubProxy = connection.createHubProxy('/notificationHub'); // Replace 'MyHub' with your hub name

    // Define a function to handle incoming messages
       var userid = document.getElementById("userid").innerHTML
    hubProxy.on('ReceiveNotification', function (userid, message) {
        // Handle the received message here
        console.log(user + ': ' + message);
        });

    // Start the connection
    connection.start()
    .done(function () {
        console.log('Connected to SignalR hub');
            })
    .fail(function () {
        console.log('Failed to connect to SignalR hub');
            });
   
