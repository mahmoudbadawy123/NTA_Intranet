import { Component, Inject, OnInit } from '@angular/core';
import {
  FormGroup,
  FormControl,
  Validators,
  AbstractControl,
} from '@angular/forms';
import { ThemePalette } from '@angular/material/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { ApiService } from 'src/app/modules/Shared/Shared-Services/http/Api.service';
import { SharedLookUpsService } from 'src/app/modules/Shared/Shared-Services/LookUps/Shared-Look-Ups.service';
import { SessionService } from 'src/app/modules/Shared/Shared-Services/Session/session.service';
import { ValidPatterns } from 'src/app/modules/Shared/Vlidation-Patterns/Valid-Patterns';
import { LookUps } from 'src/app/ViewModel/LookUps';
import * as moment from 'moment';

import { HttpClient } from '@angular/common/http';
import { BaseComponent } from 'src/app/modules/Shared/core/base.component';

@Component({
  selector: 'app-Add-Admin-Announcement',
  templateUrl: './Add-Admin-Announcement.component.html',
  styleUrls: ['./Add-Admin-Announcement.component.css'],
})
export class AddAdminAnnouncementComponent 
extends BaseComponent
implements OnInit {
  Form: FormGroup;
  today = new Date();
  Groups:  Array<LookUps>= [];

  
  ControllerRoute:string = "Announcements";
  constructor(
    public dialogRef: MatDialogRef<AddAdminAnnouncementComponent>,
    private api: ApiService,
    private alert: ToastrService,
    private LookUps: SharedLookUpsService,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private Session: SessionService
  ) {
    super();
    this.Form = new FormGroup({
      // id: new FormControl('' ,[Validators.required]),
      labelName: new FormControl('', [Validators.required]),
      messageBody: new FormControl('', [Validators.required]),
      groupId: new FormControl(-1),
      isScheduledPublish: new FormControl(),
      publishDateTime: new FormControl(this.today),
    });
  }

  get form(): { [key: string]: AbstractControl } {
    return this.Form.controls;
  }

  userData: any;

  ngOnInit() {
    this.GetGroups();
  }

  cancel(): void {
    this.dialogRef.close();
  }
  
 
  GetGroups() {
    this.LookUps.Groups().subscribe(
      (res: Array<LookUps>) => {
        this.Groups = res;
      },
      (error) => {}
    );
  }

  okClick() {
    if(this.Form.value.groupId == -1){
      console.log(this.Form.value);
      this.alert.warning("Please Choose Group that you will publish announcement For");
      return;
    }

    console.log(this.Form.value);
    this.api.post(`${this.ControllerRoute}/Add`, this.Form.value).subscribe(
      (res: any) => {
        this.alert.success("announcement published Succesfully");
        this.dialogRef.close(res);
      },
      (error) => {
        this.alert.error(error);
      }
    );
  }

  ischecked=false;
  Oncheck(){
    if(!this.ischecked){
      this.form["publishDateTime"].setValue(this.today);
    }
  }
}
