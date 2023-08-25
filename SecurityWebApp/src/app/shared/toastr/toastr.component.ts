import { Component, Inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import {
  MAT_SNACK_BAR_DATA,
  MatSnackBarModule,
  MatSnackBar,
  MatSnackBarConfig,
} from '@angular/material/snack-bar';
import { SignalrService } from 'src/app/core/signalr.service';

@Component({
  selector: 'app-toastr',
  templateUrl: './toastr.component.html',
  styleUrls: ['./toastr.component.css'],
})
export class ToastrComponent {
  durationInSeconds = 5;
  constructor(
    private _snackBar: MatSnackBar,
    private signalrservice: SignalrService
  ) {
    // this._snackBar.open('hello', 'action', {
    //   duration: this.durationInSeconds * 1000,
    // });

    SignalrService.data.subscribe((data: any) => {
      this._snackBar.open(data, 'action', {
        duration: this.durationInSeconds * 1000,
      });
    });
  }
}
