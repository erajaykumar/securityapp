import { HttpClient } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import { AgGridAngular } from 'ag-grid-angular';
import {
  CellClickedEvent,
  ColDef,
  GridApi,
  GridReadyEvent,
} from 'ag-grid-community';
import { Observable } from 'rxjs';
import { IRuleData } from '../iruledata';
import { Rule } from 'src/app/model/rule';

@Component({
  selector: 'app-existing-rule',
  templateUrl: './existing-rule.component.html',
  styleUrls: ['./existing-rule.component.css'],
})
export class ExistingRuleComponent {
  constructor(private http: HttpClient) {}

  // rowData: Rule[] = [];

  // export class Rule {
  //   public enabled: boolean;
  //   public name: string;
  //   public type: string;
  //   public serverity: string;
  //   public logic: string;
  //   public notification: string;
  // }

  columnDefs: ColDef[] = [
    { field: 'enabled', sortable: true, filter: true },
    { field: 'name', sortable: true, filter: true },
    { field: 'type', sortable: true, filter: true },
    { field: 'severity', sortable: true, filter: true },
    { field: 'logic', filter: true  },
    { field: 'notification', sortable: true, filter: true },
  ];

  // "enabled": false,
  //       "name": "Rule 1",
  //       "type": "I/O",
  //       "severity": "High",
  //       "logic": "When the count of error is more than 2 from last 3 hours send notification to ...",
  //       "notification": "ajay.kumar4@rockwellautomation.com;testuser@email.com"

  rowData = [
    new Rule(
      false,
      'Rule 1',
      'I/O',
      'High',
      'When the count of error is more than 2 from last 3 hours send notification to ...',
      'ajay.kumar4@rockwellautomation.com;testuser@email.com'
    ),
  ];

  private gridApi!: GridApi<Rule>;

  onGridReady(params: GridReadyEvent<Rule>) {
    this.gridApi = params.api;

    this.http
      .get<Rule[]>('https://localhost:5010/rules')
      .subscribe((data) => params.api!.setRowData(data));
  }
}
