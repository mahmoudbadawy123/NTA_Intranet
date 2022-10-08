import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../Shared/Shared-Services/Auth/Authentication.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  constructor(

    private authenticationService: AuthenticationService
      ) { }

  ngOnInit() {
    console.log(this.authenticationService.userValue);
  }

}
