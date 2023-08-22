import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
export class SignalrService {

  constructor() { }
  data: any
  hubConnection = new signalR.HubConnectionBuilder()
                      .configureLogging(signalR.LogLevel.Information)
                      .withUrl('https://mocki.io/v1/d4867d8b-b5d5-4a48-a4ab-79131b5809b8')
                      .build();


  public startConnection = () => {

    this.hubConnection.start().then(() => {
      console.log('connection started');
    }).catch((err: any) => console.log('Error while starting connection' + err))
  }

    public addTransferChartDataListener = () => {
      this.hubConnection.on('transferchartdata', (data: any) => {
        this.data = data;
        console.log(data);
      });
    }

}
