import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeComponent } from './Employee.component';
import { SharedModule } from '../Shared/Shared.module';
import { EmployeeAnnouncementComponent } from './Employee-Announcement/Employee-Announcement.component';
import { EmployeeCalenderComponent } from './Employee-Calender/Employee-Calender.component';
import { EmployeeMagicToolsComponent } from './Employee-MagicTools/Employee-MagicTools.component';
import { EmployeeMeetingsComponent } from './Employee-Meetings/Employee-Meetings.component';
import { EmployeeStoryComponent } from './Employee-story/Employee-story.component';
import { EmployeeRoutingModule } from './Employee.routing';
import { ShowDataCalenderComponent } from './Employee-Calender/Show-Data-Calender/Show-Data-Calender.component';

let Modules : any[]= [
  CommonModule,
 EmployeeRoutingModule,
  SharedModule,

]

let EntryComponents : any[]= [
  ShowDataCalenderComponent,
]

let Components : any[]= [
  ...EntryComponents,
 EmployeeComponent,
 EmployeeAnnouncementComponent,
 EmployeeStoryComponent,
 EmployeeCalenderComponent,
 EmployeeMagicToolsComponent,
 EmployeeMeetingsComponent,
 
]





@NgModule({
  imports: [
    ...Modules
  ],
  declarations: [
    ...Components
  ],
  entryComponents:[
     ...EntryComponents
  ]
})
export class EmployeeModule { }
