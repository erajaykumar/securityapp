import { Component } from '@angular/core';
import { AuthService } from './core/auth-service.component';
import { SignalrService } from './core/signalr.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'Security App';

  isLoggedIn = false;

  constructor(
    private _authService: AuthService,
    private signalrservice: SignalrService
  ) {
    this._authService.loginChanged.subscribe((loggedIn) => {
      this.isLoggedIn = loggedIn;
    });
  }

  ngOnInit(): void {
    this._authService.isLoggedIn().then((loggedIn) => {
      this.isLoggedIn = loggedIn;
    });

    console.log(this.signalrservice.getMessage());

   
  }

  login() {
    this._authService.login();
  }

  logout() {
    this._authService.logout();
  }

  isAdmin() {
    return (
      this._authService.authContext && this._authService.authContext.isAdmin
    );
  }
}
