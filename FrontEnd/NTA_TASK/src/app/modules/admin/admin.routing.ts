import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminAnnouncementComponent } from './Admin-Announcement/Admin-Announcement.component';
import { AdminCalenderComponent } from './Admin-Calender/Admin-Calender.component';
import { AdminMagicToolsComponent } from './Admin-MagicTools/Admin-MagicTools.component';
import { AdminMeetingsComponent } from './Admin-Meetings/Admin-Meetings.component';
import { AdminStoryComponent } from './Admin-story/Admin-story.component';


const routes: Routes = [

  {
    path: '',
    redirectTo:'Announcement',
    pathMatch:'prefix'
  },

  {
    path: 'Announcement',
    component: AdminAnnouncementComponent
  },

  {
    path: 'story',
    component: AdminStoryComponent
  },

  {
    path: 'Calender',
    component: AdminCalenderComponent
  },

  {
    path: 'MagicTools',
    component: AdminMagicToolsComponent
  },

  {
    path: 'Meetings',
    component: AdminMeetingsComponent
  },
];




@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class AdminRoutingModule { }