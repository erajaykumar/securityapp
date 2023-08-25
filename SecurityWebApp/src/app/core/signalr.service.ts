import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SignalrService {
  // data: any;
  hubConnection: any;
  message: string;

  static data = new Subject<string>();
  hub: any;

  constructor() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .configureLogging(signalR.LogLevel.Information)
      .withUrl('https://localhost:7012/notificationHub')
      .build();

    this.hubConnection
      .start()
      .then(() => {
        console.log('connection started');
      })
      .catch((err: any) =>
        console.log('Error while starting connection' + err)
      );

    this.hubConnection.on('publicMessageMethodName', function (message) {
      var msg = message
        .replace(/&/g, '&amp;')
        .replace(/</g, '&lt;')
        .replace(/>/g, '&gt;');
      var encodedMsg = ' Recived message:  ' + msg;

      SignalrService.data.next(encodedMsg);
    });
  }

  getMessage() {
    return SignalrService.data;
  }
}
