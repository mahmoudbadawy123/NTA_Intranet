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
export class AdminGuard implements CanActivate {
  constructor(private authenticationService: AuthenticationService) {}
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean {
    let flag: boolean =
      this.authenticationService.userValue.userType == Role.Admin ? true : false;
    console.log(flag);
    if (!flag) this.authenticationService.logout();
    return flag;
  }
}
