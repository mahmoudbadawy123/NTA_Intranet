import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { AddAdminMeetingsComponent } from 'src/app/modules/admin/Admin-Meetings/Add-Admin-Meetings/Add-Admin-Meetings.component';
import { BaseComponent } from 'src/app/modules/Shared/core/base.component';
import { ApiService } from 'src/app/modules/Shared/Shared-Services/http/Api.service';
import { SharedLookUpsService } from 'src/app/modules/Shared/Shared-Services/LookUps/Shared-Look-Ups.service';
import { LookUps } from 'src/app/ViewModel/LookUps';

@Component({
  selector: 'app-Show-Meetings-info',
  templateUrl: './Show-Meetings-info.component.html',
  styleUrls: ['./Show-Meetings-info.component.css']
})
export class ShowMeetingsInfoComponent extends BaseComponent
implements OnInit {
  Form: FormGroup;
  today = new Date();
  MeetingTypes:  Array<LookUps>= [];
  Users:  Array<LookUps>= [];
  
  ControllerRoute:string = "Meetings";
  constructor(
    public dialogRef: MatDialogRef<ShowMeetingsInfoComponent>,
    private api: ApiService,
    private alert: ToastrService,
    private LookUps: SharedLookUpsService,
    @Inject(MAT_DIALOG_DATA) public data: any,
  ) {
    
    super();

  

    this.Form = new FormGroup({
      // id: new FormControl(data?.id ,[Validators.required]),
      meatingName: new FormControl(data?.meatingName, [Validators.required]),
      description: new FormControl(data?.description, [Validators.required]),
      meatingLocation: new FormControl(data?.meatingLocation),
      meatingLink: new FormControl(data?.meatingLink),
      meatingDateTime: new FormControl(data?.meatingDateTime),
      recieverUserIds: new FormControl(),
      meatingTypeId: new FormControl(data?.meatingTypeId),
      isScheduledPublish: new FormControl(data?.isScheduledPublish),
      publishDateTime: new FormControl(data?.publishDateTime),
    });

    this.GetMeetingTypes();
    this.GetUsersExceptMe();

    this.Form.disable();
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
      allowSearchFilter: false
    };

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



  GetMeetingUsers(){
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

    this.api.post(`${this.ControllerRoute}/Update`, this.Form.value).subscribe(
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
       



    this.LookUps.GetAllMeetingsUsers(this.data.id).subscribe(
      res => {
       this.form["recieverUserIds"].setValue(res);
      }
     );

  }
  onItemSelect(item: any) {
    console.log(item);
  }
  onSelectAll(items: any) {
    console.log(items);
  }


}
