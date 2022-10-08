import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
import { ThemePalette } from '@angular/material/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { BaseComponent } from 'src/app/modules/Shared/core/base.component';
import { ApiService } from 'src/app/modules/Shared/Shared-Services/http/Api.service';
import { SharedLookUpsService } from 'src/app/modules/Shared/Shared-Services/LookUps/Shared-Look-Ups.service';
import { SessionService } from 'src/app/modules/Shared/Shared-Services/Session/session.service';
import { LookUps } from 'src/app/ViewModel/LookUps';
import { AddAdminAnnouncementComponent } from '../Add-Admin-Announcement/Add-Admin-Announcement.component';

@Component({
  selector: 'app-Update-Admin-Announcement',
  templateUrl: './Update-Admin-Announcement.component.html',
  styleUrls: ['./Update-Admin-Announcement.component.css']
})
export class UpdateAdminAnnouncementComponent 
extends BaseComponent
implements OnInit {

  Form: FormGroup;
  today = new Date();
  Groups:  Array<LookUps>= [];
  ControllerRoute:string = "Announcements";



  constructor(
    public dialogRef: MatDialogRef<UpdateAdminAnnouncementComponent>,
    private api: ApiService,
    private alert: ToastrService,
    private LookUps: SharedLookUpsService,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private Session: SessionService
  ) {
    super();
    this.Form = new FormGroup({
      id: new FormControl(this.data?.id ,[Validators.required]),
      labelName: new FormControl(this.data?.labelName, [Validators.required]),
      messageBody: new FormControl(this.data?.messageBody, [Validators.required]),
      groupId: new FormControl(this.data?.groupId),
      isScheduledPublish: new FormControl(this.data?.isScheduledPublish),
      publishDateTime: new FormControl(new Date(this.data?.publishDateTime)),
    });
  }

  get form(): { [key: string]: AbstractControl } {
    return this.Form.controls;
  }

  userData: any;

  ngOnInit() {
    this.GetGroups();
   this.ischecked = this.data?.isScheduledPublish == true ? true:false;
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
      this.alert.warning("Please Choose Group that you will Update its announcement For");
      return;
    }

    console.log(this.Form.value);
    this.api.post(`${this.ControllerRoute}/Update`, this.Form.value).subscribe(
      (res: any) => {
        this.alert.success("announcement Update Succesfully");
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
