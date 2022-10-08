import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { UpdateAdminCalenderComponent } from 'src/app/modules/admin/Admin-Calender/Update-Admin-Calender/Update-Admin-Calender.component';
import { BaseComponent } from 'src/app/modules/Shared/core/base.component';
import { ApiService } from 'src/app/modules/Shared/Shared-Services/http/Api.service';
import { SharedLookUpsService } from 'src/app/modules/Shared/Shared-Services/LookUps/Shared-Look-Ups.service';
import { LookUps } from 'src/app/ViewModel/LookUps';

@Component({
  selector: 'app-Show-Data-Calender',
  templateUrl: './Show-Data-Calender.component.html',
  styleUrls: ['./Show-Data-Calender.component.css']
})
export class ShowDataCalenderComponent  extends BaseComponent
implements OnInit {

  Form: FormGroup;
  today = new Date();
  Groups:  Array<LookUps>= [];
  ControllerRoute:string = "CalenderEvents";



  constructor(
    public dialogRef: MatDialogRef<UpdateAdminCalenderComponent>,
    private api: ApiService,
    private alert: ToastrService,
    private LookUps: SharedLookUpsService,
    @Inject(MAT_DIALOG_DATA) public data: any,
  ) {
    super();
    this.Form = new FormGroup({
      id: new FormControl(this.data?.id ,[Validators.required]),
      eventName: new FormControl(this.data?.eventName, [Validators.required]),
      description: new FormControl(this.data?.description, [Validators.required]),
      groupId: new FormControl(this.data?.groupId),
      eventDateTime: new FormControl(new Date(this.data?.eventDateTime)),
    });
  }

  get form(): { [key: string]: AbstractControl } {
    return this.Form.controls;
  }

  userData: any;

  ngOnInit() {
    this.GetGroups();
    this.Form.disable();
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

  


}
