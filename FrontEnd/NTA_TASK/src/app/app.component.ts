import { HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from './modules/Shared/Shared-Services/Auth/Authentication.service';
import { ApiService } from './modules/Shared/Shared-Services/http/Api.service';
import { SessionService } from './modules/Shared/Shared-Services/Session/session.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent  implements OnInit {




//   User:any ;
  fullname:any;
//   userType :any;
//   ngOnInit() {
// this.User = this.authenticationService.userValue;
// console.log(this.User);
// this.fullname =  this.User?.fullname;
// this.userType = this.User?.userType;


  TYPE!: number;
  User: any;


  constructor(
    private router: Router,
    private Session: SessionService,
    private api: ApiService,
    private authenticationService: AuthenticationService
  ) {

    // this.router.events.subscribe((event: any) => {
      
    //   debugger;
    //   this.Session.get("Token");
    //   var Token = this.Session.get("Token");
    //   this.userData = this.Session.getObj("User");
    //   this.TYPE = this.Session.getObj("User")?.UserType;
    
    //   var AuthHeader = "bearer " + Token;
    //   const headers = new HttpHeaders().append('Authorization', AuthHeader);
    //   this.api.headers = headers;
    // });

    this.router.events.subscribe((event: any) => {

      // this.Session.get("Token");
      // var Token = this.Session.get("Token");
      // this.userData = this.Session.getObj("User");
      // this.TYPE = this.Session.getObj("User")?.UserType;
      // ////console.log(this.TYPE);


      this.User = this.authenticationService.userValue;
      // console.log(this.User);
      this.fullname =  this.User?.fullname;
      this.TYPE = this.User?.userType;


      // var AuthHeader = "bearer " + Token;
      // const headers = new HttpHeaders().append('Authorization', AuthHeader);
      // this.api.headers = headers;

      
    });





  }



  logout() {
    sessionStorage.clear();
    localStorage.clear();
    this.authenticationService.logout();
    console.log(this.TYPE);
  }

 

  ngOnInit() {
  

    // ////console.log(JSON.stringify(this.snotifyService.config))
  
  }
}




