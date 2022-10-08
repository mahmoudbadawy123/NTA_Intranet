import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from './modules/Shared/Shared-Services/Auth/Authentication.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent  implements OnInit {

  fullname:any;
  TYPE!: number;
  User: any;


  constructor(
    private router: Router,
    private authenticationService: AuthenticationService
  ) {
    this.router.events.subscribe((event: any) => {
      this.User = this.authenticationService.userValue;
      this.fullname =  this.User?.fullname;
      this.TYPE = this.User?.userType;
    });
  }

  logout() {
    sessionStorage.clear();
    localStorage.clear();
    this.authenticationService.logout();
    console.log(this.TYPE);
  }

  ngOnInit() {
  }
}




