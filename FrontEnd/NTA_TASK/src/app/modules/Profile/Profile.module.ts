import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileComponent } from './Profile.component';
import { SharedModule } from '../Shared/Shared.module';
import { LoginComponent } from './login/login.component';
import { ProfileRoutingModule } from './Profile.routing';


let Modules : any[]= [
  CommonModule,
  ProfileRoutingModule,
  SharedModule,
]

let EntryComponents : any[]= [

]

let Components : any[]= [
  ...EntryComponents,
  ProfileComponent,
  LoginComponent,

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
export class ProfileModule { }
