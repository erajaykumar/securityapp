import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { SignalrService } from './services/signalr.service';
import { GridListComponent } from './Components/grid-list/grid-list.component';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'flourish';
  constructor(private signalR:SignalrService, private httpClient:HttpClient){}

  ngOnInit(){
    this.signalR.startConnection();
    this.signalR.addTransferChartDataListener();
    this.startHttpRequest();
  }

  private startHttpRequest = () => {
    this.httpClient.get('https://mocki.io/v1/d4867d8b-b5d5-4a48-a4ab-79131b5809b8')
      .subscribe(res => {
        console.log(res);
      })
  }

}
