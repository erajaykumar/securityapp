import { Component } from '@angular/core';
import { AuthService } from './core/auth-service.component';
import { Breakpoints, BreakpointObserver } from '@angular/cdk/layout';
import { map } from 'rxjs';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'Security App';
  panelOpenState = false;
  isLoggedIn = false;

  constructor(private _authService: AuthService, private breakpointObserver:BreakpointObserver) {
    this._authService.loginChanged.subscribe((loggedIn) => {
      this.isLoggedIn = loggedIn;
    });

  }

 

  ngOnInit(): void {
    this._authService.isLoggedIn().then((loggedIn) => {
      this.isLoggedIn = loggedIn;
    });
  }

  expandMobileMenu(){
    console.log('dfdfd');
    this.panelOpenState = !this.panelOpenState;
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
