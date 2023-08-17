import { Component, OnInit } from '@angular/core';
import { AuthService } from '../core/auth-service.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signin-callback',
  template: `<div></div>`,
})
export class SigninRedirectCallbackComponent implements OnInit {
  constructor(private _authservice: AuthService, private _router: Router) {}

  ngOnInit() {
    this._authservice.completeLogin().then((user) => {
      this._router.navigate(['/'], { replaceUrl: true });
    });
  }
}
