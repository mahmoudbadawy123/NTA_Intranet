import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { ToastrService } from 'ngx-toastr';
import { BaseComponent } from 'src/app/modules/Shared/core/base.component';
import { ApiService } from 'src/app/modules/Shared/Shared-Services/http/Api.service';
import { SharedLookUpsService } from 'src/app/modules/Shared/Shared-Services/LookUps/Shared-Look-Ups.service';
import { LookUps } from 'src/app/ViewModel/LookUps';

@Component({
  selector: 'app-Add-Admin-Meetings',
  templateUrl: './Add-Admin-Meetings.component.html',
  styleUrls: ['./Add-Admin-Meetings.component.css']
})
export class AddAdminMeetingsComponent extends BaseComponent
implements OnInit {
  Form: FormGroup;
  today = new Date();
  MeetingTypes:  Array<LookUps>= [];
  Users:  Array<LookUps>= [];
  
  ControllerRoute:string = "Meetings";
  constructor(
    public dialogRef: MatDialogRef<AddAdminMeetingsComponent>,
    private api: ApiService,
    private alert: ToastrService,
    private LookUps: SharedLookUpsService,
    @Inject(MAT_DIALOG_DATA) public data: any,
  ) {
    super();
    this.Form = new FormGroup({
      // id: new FormControl('' ,[Validators.required]),
      meatingName: new FormControl('', [Validators.required]),
      description: new FormControl('', [Validators.required]),
      meatingLocation: new FormControl(''),
      meatingLink: new FormControl(''),
      meatingDateTime: new FormControl(this.today),
      recieverUserIds: new FormControl(-1),
      meatingTypeId: new FormControl(-1),
      isScheduledPublish: new FormControl(false),
      publishDateTime: new FormControl(this.today),
    });
  }

  get form(): { [key: string]: AbstractControl } {
    return this.Form.controls;
  }

  userData: any;

  // ngOnInit() {
  //   this.GetMeetingTypes();
  //   this.GetUsersExceptMe();
  // }

  cancel(): void {
    this.dialogRef.close();
  }
  
 
  GetMeetingTypes() {
    this.LookUps.MeetingTypes().subscribe(
      (res: Array<LookUps>) => {
        this.MeetingTypes = res;
      },
      (error) => {}
    );
  }
  GetUsersExceptMe(){
    this.LookUps.UsersExceptMe().subscribe(
      (res: Array<LookUps>) => {
        this.Users = res;
      },
      (error) => {}
    );
  }

  // okClick(){
  //   console.log(this.Form.value);
  // }
  
  // Myform :any= {};
  okClick() {
    console.log(this.Form.value);

   

    // this.Myform["meatingName"]=this.Form.value.meatingName ;
    // this.Myform["description"]=this.Form.value.description ;
    // this.Myform["meatingLocation"]=this.Form.value.meatingLocation ;
    // this.Myform["meatingLink"]=this.Form.value.meatingLink ;
    // this.Myform["meatingDateTime"]=this.Form.value.meatingDateTime ;
    // this.Myform["meatingTypeId"]=this.Form.value.meatingTypeId ;
    // this.Myform["isScheduledPublish"]=this.Form.value.isScheduledPublish ;
    // this.Myform["publishDateTime"]=this.Form.value.publishDateTime ;
    // this.Myform["recieverUserIds"]=this.Form.value.recieverUserIds ;
    
    if(this.Form.value.meatingTypeId == -1){
      console.log(this.Form.value);
      this.alert.warning("Please Choose Meating Type");
      return;
    }

    // console.log(this.Myform);
    this.api.post(`${this.ControllerRoute}/Add`, this.Form.value).subscribe(
      (res: any) => {
        this.alert.success("Meating Notified for Choosen users Succesfully");
        this.dialogRef.close(res);
      },
      (error) => {
        console.log(error);
        this.alert.error(error);
      }
    );
  }

  OnselectReciver(){
    console.log(this.Form.value.recieverUserIds );
  }


  ischecked=false;
  Oncheck(){
    if(!this.ischecked){
      this.form["publishDateTime"].setValue(this.today);
    }
  }

  // ##################### Multi select  ##################


  // dropdownList : Array<any> =[];
  selectedItems : Array<any> =[];
  dropdownSettings = {};
  ngOnInit() {
        this.GetMeetingTypes();
    this.GetUsersExceptMe();
    // this.dropdownList = [
    //   { item_id: 1, item_text: 'Mumbai' },
    //   { item_id: 2, item_text: 'Bangaluru' },
    //   { item_id: 3, item_text: 'Pune' },
    //   { item_id: 4, item_text: 'Navsari' },
    //   { item_id: 5, item_text: 'New Delhi' }
    // ];
    this.selectedItems = [
    
    ];
    this.dropdownSettings = {
      singleSelection: false,
      idField: 'id',
      textField: 'name',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      allowSearchFilter: true
    };
  }
  onItemSelect(item: any) {
    console.log(item);
  }
  onSelectAll(items: any) {
    console.log(items);
  }


}
