import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { BaseComponent } from 'src/app/modules/Shared/core/base.component';
import { ApiService } from 'src/app/modules/Shared/Shared-Services/http/Api.service';
import { SharedLookUpsService } from 'src/app/modules/Shared/Shared-Services/LookUps/Shared-Look-Ups.service';
import { SessionService } from 'src/app/modules/Shared/Shared-Services/Session/session.service';
import { LookUps } from 'src/app/ViewModel/LookUps';

@Component({
  selector: 'app-Update-Admin-MagicTools',
  templateUrl: './Update-Admin-MagicTools.component.html',
  styleUrls: ['./Update-Admin-MagicTools.component.css']
})
export class UpdateAdminMagicToolsComponent extends BaseComponent
implements OnInit {

  Form: FormGroup;
  today = new Date();
  Users:  Array<LookUps>= [];
  ControllerRoute:string = "Systems";



  constructor(
    public dialogRef: MatDialogRef<UpdateAdminMagicToolsComponent>,
    private api: ApiService,
    private alert: ToastrService,
    private LookUps: SharedLookUpsService,
    @Inject(MAT_DIALOG_DATA) public data: any,
  ) {
    super();
    this.Form = new FormGroup({
      id: new FormControl(this.data?.id ,[Validators.required]),
      systemName: new FormControl(this.data?.systemName, [Validators.required]),
      link: new FormControl(this.data?.link, [Validators.required]),
      employeeUserId: new FormControl(this.data?.employeeUserId),
      isScheduledPublish: new FormControl(this.data?.isScheduledPublish),
      publishDateTime: new FormControl(new Date(this.data?.publishDateTime)),
    });
  }

  get form(): { [key: string]: AbstractControl } {
    return this.Form.controls;
  }

  userData: any;

  ngOnInit() {
    this.UsersExceptMe();
   this.ischecked = this.data?.isScheduledPublish == true ? true:false;
  }

  cancel(): void {
    this.dialogRef.close();
  }
  
 
  UsersExceptMe() {
    this.LookUps.UsersExceptMe().subscribe(
      (res: Array<LookUps>) => {
        this.Users = res;
      },
      (error) => {}
    );
  }

  okClick() {
    if(this.Form.value.groupId == -1){
      console.log(this.Form.value);
      this.alert.warning("Please Choose employee that you will Update his/her System ");
      return;
    }

    // console.log(this.Form.value);
    this.api.post(`${this.ControllerRoute}/Update`, this.Form.value).subscribe(
      (res: any) => {
        this.alert.success("System Updated Succesfully");
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
