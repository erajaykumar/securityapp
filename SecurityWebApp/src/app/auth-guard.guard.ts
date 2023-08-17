import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from './core/auth-service.component';
import {Injectable} from '@angular/core';

@Injectable()
export const authGuardGuard: CanActivateFn = (route, state) => {

  constructor(private router:Router, private authservice: AuthService){}

  return true;
};
