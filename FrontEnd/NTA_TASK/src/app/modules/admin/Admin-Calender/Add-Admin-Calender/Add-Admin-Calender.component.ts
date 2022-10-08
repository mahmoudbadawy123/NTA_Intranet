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
  selector: 'app-Add-Admin-Calender',
  templateUrl: './Add-Admin-Calender.component.html',
  styleUrls: ['./Add-Admin-Calender.component.css']
})
export class AddAdminCalenderComponent extends BaseComponent
implements OnInit {
  Form: FormGroup;
  today = new Date();
  Groups:  Array<LookUps>= [];

  
  ControllerRoute:string = "CalenderEvents";
  constructor(
    public dialogRef: MatDialogRef<AddAdminCalenderComponent>,
    private api: ApiService,
    private alert: ToastrService,
    private LookUps: SharedLookUpsService,
    @Inject(MAT_DIALOG_DATA) public data: any,
  ) {
    super();
    this.Form = new FormGroup({
      // id: new FormControl('' ,[Validators.required]),
      eventName: new FormControl('', [Validators.required]),
      description: new FormControl('', [Validators.required]),
      groupId: new FormControl(-1),
      eventDateTime: new FormControl(this.today),
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
      this.alert.warning("Please Choose Group that you will Notify Event For");
      return;
    }

    console.log(this.Form.value);
    this.api.post(`${this.ControllerRoute}/Add`, this.Form.value).subscribe(
      (res: any) => {
        this.alert.success("Event Notified Succesfully");
        this.dialogRef.close(res);
      },
      (error) => {
        this.alert.error(error);
      }
    );
  }


}
