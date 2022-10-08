import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Role } from '../../Shared/Enums/Role.enum';
import { AuthenticationService } from '../../Shared/Shared-Services/Auth/Authentication.service';

@Component({
  selector: 'app-Welcome',
  templateUrl: './Welcome.component.html',
  styleUrls: ['./Welcome.component.css']
})
export class WelcomeComponent implements OnInit {

  constructor(
    private alert :  ToastrService,
    private spinner :NgxSpinnerService,
    private router: Router ,
    private authenticationService: AuthenticationService
  ) { 


  }

  User:any ;
  fullname:any;
  userType :any;
  ngOnInit() {
this.User = this.authenticationService.userValue;
console.log(this.User);
this.fullname =  this.User?.fullname;
this.userType = this.User?.userType;
  }

  RedirectToUserHome()
  {
    if(this.userType == Role.Admin) {
      this.router.navigate(["/Admin"])
    }
    else if (this.userType == Role.User) {
      this.router.navigate(["/Employee"])
    }

  }


}
