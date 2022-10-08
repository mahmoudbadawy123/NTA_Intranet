import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './modules/admin/admin.component';
import { EmployeeComponent } from './modules/Employee/Employee.component';
import { ProfileComponent } from './modules/Profile/Profile.component';
import { WelcomeComponent } from './modules/Profile/Welcome/Welcome.component';
import { PageNotFoundComponent } from './modules/Shared/Shared-Components/PageNotFound/PageNotFound.component';
import { AdminGuard } from './modules/Shared/Shared-Services/Guards/Admin-Guard.guard';
import { AdminUserGuard } from './modules/Shared/Shared-Services/Guards/Admin-User-Guard.guard';
import { UserGuard } from './modules/Shared/Shared-Services/Guards/User-Guard.guard';

const routes: Routes = [
  
  {
    path: '',
    redirectTo: 'Profile',
    pathMatch: 'full',
  },
  {
    path: 'Profile',
    component: ProfileComponent,
    loadChildren: () => import('./modules/Profile/Profile.module').then(m => m.ProfileModule)
  },

  {
    path: 'Admin',
    canActivate: [AdminGuard],
    component: AdminComponent,
    loadChildren: () => import('./modules/admin/admin.module').then(m => m.AdminModule)
  },

  {
    path: 'Employee',
    canActivate: [UserGuard],
    component: EmployeeComponent,
    loadChildren: () => import('./modules/Employee/Employee.module').then(m => m.EmployeeModule)
  },
  {
    path: 'Welcome',
    canActivate: [AdminUserGuard],
    component: WelcomeComponent 
  },
  {
    path: '**', component: PageNotFoundComponent
  },


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
