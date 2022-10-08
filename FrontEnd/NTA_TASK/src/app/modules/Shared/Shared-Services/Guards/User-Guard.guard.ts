import { Injectable } from '@angular/core';
import {
  CanActivate,
  Router,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
} from '@angular/router';
import { Role } from '../../Enums/Role.enum';
import { AuthenticationService } from '../Auth/Authentication.service';

@Injectable({
  providedIn: 'root',
})
export class UserGuard implements CanActivate {
  constructor(
    private authenticationService: AuthenticationService,
    private router: Router
  ) {}
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean {
    let flag: boolean =
      this.authenticationService.userValue.userType == Role.User ? true : false;
    console.log(flag);
    if (!flag) this.authenticationService.logout();
    return flag;
  }
}
