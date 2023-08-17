import { Component, OnInit } from '@angular/core';
import { AuthService } from '../core/auth-service.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signin-callback',
  template: `<div></div>`,
})
export class SignoutRedirectCallbackComponent implements OnInit {
  constructor(private _authservice: AuthService, private _router: Router) {}

  ngOnInit() {
    this._authservice.completeLogout().then((_) => {
      this._router.navigate(['/'], { replaceUrl: true });
    });
  }
}
