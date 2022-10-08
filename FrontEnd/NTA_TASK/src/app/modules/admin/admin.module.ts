import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from './admin.component';
import { SharedModule } from '../Shared/Shared.module';
import { AdminRoutingModule } from './admin.routing';
import { AdminAnnouncementComponent } from './Admin-Announcement/Admin-Announcement.component';
import { AdminStoryComponent } from './Admin-story/Admin-story.component';
import { AdminCalenderComponent } from './Admin-Calender/Admin-Calender.component';
import { AdminMagicToolsComponent } from './Admin-MagicTools/Admin-MagicTools.component';
import { AdminMeetingsComponent } from './Admin-Meetings/Admin-Meetings.component';
import { UpdateAdminAnnouncementComponent } from './Admin-Announcement/Update-Admin-Announcement/Update-Admin-Announcement.component';
import { AddAdminAnnouncementComponent } from './Admin-Announcement/Add-Admin-Announcement/Add-Admin-Announcement.component';
import { AddAdminStoryComponent } from './Admin-story/Add-Admin-Story/Add-Admin-Story.component';
import { UpdateAdminStoryComponent } from './Admin-story/Update-Admin-Story/Update-Admin-Story.component';
import { UpdateAdminCalenderComponent } from './Admin-Calender/Update-Admin-Calender/Update-Admin-Calender.component';
import { AddAdminCalenderComponent } from './Admin-Calender/Add-Admin-Calender/Add-Admin-Calender.component';




let Modules : any[]= [


  CommonModule,
  AdminRoutingModule,
  SharedModule,

]

let EntryComponents : any[]= [
  AddAdminAnnouncementComponent,
  UpdateAdminAnnouncementComponent,
  AddAdminStoryComponent,
  UpdateAdminStoryComponent,
  AddAdminCalenderComponent,
  UpdateAdminCalenderComponent
]

let Components : any[]= [
  ...EntryComponents,
  AdminComponent,
  AdminAnnouncementComponent,
  AdminStoryComponent,
  AdminCalenderComponent,
  AdminMagicToolsComponent,
  AdminMeetingsComponent,
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
export class AdminModule { }