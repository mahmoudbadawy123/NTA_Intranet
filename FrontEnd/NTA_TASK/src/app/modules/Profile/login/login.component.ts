import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { first } from 'rxjs';
import { AuthenticationService } from '../../Shared/Shared-Services/Auth/Authentication.service';

import { ApiService } from '../../Shared/Shared-Services/http/Api.service';
import { SessionService } from '../../Shared/Shared-Services/Session/session.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  signinForm: FormGroup;
  get form(): { [key: string]: AbstractControl; }
  {
      return this.signinForm.controls;
  }
  constructor(  
    private api : ApiService, 
    private Session : SessionService,
    private alert :  ToastrService,
    private spinner :NgxSpinnerService,
    private router: Router ,
     private authenticationService: AuthenticationService
    )
    {

    this.signinForm = new FormGroup({
      Email:new FormControl('', [Validators.required , Validators.email]),
      Password: new FormControl('', Validators.required)
    });

  }

  ngOnInit() {
    // localStorage.clear();
    this.Session.clear();
    if (this.authenticationService.userValue) { 
      this.router.navigate(['/']);
  }
  }


  Roles: Array<string> = new Array<string>();
  Oldsubmit(){
debugger;
  this.spinner.show();
    this.api.post("Auth/token" , this.signinForm.value).subscribe((res:any)=>{
      debugger;
    console.log(res);
       if(res["token"] == null ||  res["isAuthenticated"] == null){
        debugger;
         this.alert.error("Email or Password is not correct");
         this.spinner.hide();
         return;
       }

       this.Session.Set("Token" ,res["token"] );
       this.Session.setObj("User" ,res );
       this.Roles = res["roles"] ;

       if(this.Roles.length > 0 &&  this.Roles.includes("Admin")){
        if(res["isFirstlogin"] == false){
          this.router.navigate(["/Welcome"])
        }
        else {
          this.router.navigate(["/Admin"])
        }
       }
       else if( this.Roles.length > 0 &&  !this.Roles.includes("Admin")){
        if(res["isFirstlogin"] == false){
          this.router.navigate(["/Welcome"])
        }
        else {
          this.router.navigate(["/Employee"])
        }
       }
       this.spinner.hide();

  }, (error)=>{
    this.alert.error("Email or Password is not correct");
    this.spinner.hide();
  } );
  }



  submit(){
    debugger;
    this.authenticationService.login(this.signinForm.value)
    .pipe(first())
    .subscribe(
      res => {

            if(res["token"] == null ||  res["isAuthenticated"] == null){
              debugger;
               this.alert.error("Email or Password is not correct");
               this.spinner.hide();
               return;
             }
      
      
            console.log(this.authenticationService.userValue);
            this.Roles = res["roles"] ;
      
             if(this.Roles.length > 0 &&  this.Roles.includes("Admin")){
              if(res["isFirstlogin"] == false){
                this.router.navigate(["/Welcome"])
              }
              else {
                this.router.navigate(["/Admin"])
              }
             }
             else if( this.Roles.length > 0 &&  !this.Roles.includes("Admin")){
              if(res["isFirstlogin"] == false){
                this.router.navigate(["/Welcome"])
              }
              else {
                this.router.navigate(["/Employee"])
              }
             }

           
             this.spinner.hide();

        },
        error => {
          this.alert.error("Email or Password is not correct");
          this.spinner.hide();
        });
  }
}
