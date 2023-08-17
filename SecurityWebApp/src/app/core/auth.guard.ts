import { CanActivateFn } from '@angular/router';
import { AuthService } from './auth-service.component';
import { inject } from '@angular/core';

export const authGuard: CanActivateFn = (route, state) => {
  const oauthService: AuthService = inject(AuthService);

  if (oauthService.checkLoginStatus()) {
    return true;
  }
  oauthService.login();
  return false;
};
