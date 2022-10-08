import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { User } from 'src/app/ViewModel/User';
import { environment } from 'src/environments/environment';
import { ApiService } from '../http/Api.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private userSubject: BehaviorSubject<User>;
  public user: Observable<User>;

  constructor(private api : ApiService ,  private router: Router) {
      this.userSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('user')!));
      this.user = this.userSubject.asObservable();
  }

  public get userValue(): User {
      return this.userSubject.value;
  }

  login(LoginForm:any) {
      return this.api.post("Auth/token", LoginForm)
          .pipe(map((user:any) => {
              // store user details and jwt token in local storage to keep user logged in between page refreshes
              localStorage.setItem('user', JSON.stringify(user));
              this.userSubject.next(user);
              return user;
          }));
  }

  logout() {
      // remove user from local storage to log user out
      localStorage.removeItem('user');
      this.userSubject.next(new User());
      this.router.navigate(['/Profile/login']);
  }

}
