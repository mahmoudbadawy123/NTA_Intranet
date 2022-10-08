import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeeAnnouncementComponent } from './Employee-Announcement/Employee-Announcement.component';
import { EmployeeCalenderComponent } from './Employee-Calender/Employee-Calender.component';
import { EmployeeMagicToolsComponent } from './Employee-MagicTools/Employee-MagicTools.component';
import { EmployeeMeetingsComponent } from './Employee-Meetings/Employee-Meetings.component';
import { EmployeeStoryComponent } from './Employee-story/Employee-story.component';


const routes: Routes = [

  {
    path: '',
    redirectTo:'Announcement',
    pathMatch:'prefix'
  },

  {
    path: 'Announcement',
    component:EmployeeAnnouncementComponent
  },

  {
    path: 'story',
    component:EmployeeStoryComponent
  },

  {
    path: 'Calender',
    component:EmployeeCalenderComponent
  },

  {
    path: 'MagicTools',
    component:EmployeeMagicToolsComponent
  },

  {
    path: 'Meetings',
    component:EmployeeMeetingsComponent
  },
];




@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class EmployeeRoutingModule { }

