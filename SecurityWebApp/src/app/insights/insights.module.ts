import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InsightDashboardComponent } from './insight-dashboard/insight-dashboard.component';
import {MatCardModule} from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';



@NgModule({
  declarations: [
    InsightDashboardComponent
  ],
  imports: [
    CommonModule,
    MatCardModule,
    MatIconModule,
    MatButtonModule
  ]
})
export class InsightsModule { }
