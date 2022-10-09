import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { BaseComponent } from 'src/app/modules/Shared/core/base.component';
import { ApiService } from 'src/app/modules/Shared/Shared-Services/http/Api.service';
import { SharedLookUpsService } from 'src/app/modules/Shared/Shared-Services/LookUps/Shared-Look-Ups.service';
import { LookUps } from 'src/app/ViewModel/LookUps';

@Component({
  selector: 'app-add-Admin-MagicTools',
  templateUrl: './add-Admin-MagicTools.component.html',
  styleUrls: ['./add-Admin-MagicTools.component.css']
})
export class AddAdminMagicToolsComponent extends BaseComponent
implements OnInit {
  Form: FormGroup;
  today = new Date();
  Users:  Array<LookUps>= [];



  ControllerRoute:string = "Systems";
  constructor(
    public dialogRef: MatDialogRef<AddAdminMagicToolsComponent>,
    private api: ApiService,
    private alert: ToastrService,
    private LookUps: SharedLookUpsService,
    @Inject(MAT_DIALOG_DATA) public data: any,
  ) {
    super();
    this.Form = new FormGroup({
      // id: new FormControl('' ,[Validators.required]),
      systemName: new FormControl('', [Validators.required]),
      link: new FormControl('', [Validators.required]),
      employeeUserId: new FormControl(-1),
      isScheduledPublish: new FormControl(),
      publishDateTime: new FormControl(this.today),
    });
  }

  get form(): { [key: string]: AbstractControl } {
    return this.Form.controls;
  }

  userData: any;

  ngOnInit() {
    this.UsersExceptMe();
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
