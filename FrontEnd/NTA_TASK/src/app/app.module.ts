import { APP_INITIALIZER, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from './modules/Shared/Shared.module';
import { AppConfigService } from './Services/AppConfig.service';
import { CookieService } from 'ngx-cookie-service';
import { LocationStrategy, HashLocationStrategy } from '@angular/common';
import { MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import {  MAT_MOMENT_DATE_ADAPTER_OPTIONS } from '@angular/material-moment-adapter';
import { TokenInterceptor } from './common/auth/token.interceptor';

export const MY_DATE_FORMATS = {
  parse: {
    dateInput: 'DD/MM/YYYY',
  },
  display: {
    dateInput: 'DD/MM/YYYY',
    monthYearLabel: 'MMMM YYYY',
    dateA11yLabel: 'LL',
    monthYearA11yLabel: 'MMMM YYYY'
  },
};

var Modules: any[] = [
  BrowserModule,
  AppRoutingModule,
  BrowserAnimationsModule,
  FormsModule,
  ReactiveFormsModule,
  HttpClientModule,
  SharedModule,
];

let Components: any[] = [AppComponent];

let Services: any[] = [
  
  // https://www.npmjs.com/package/ngx-cookie-service
  CookieService,
  AppConfigService,
  { provide: LocationStrategy, useClass: HashLocationStrategy },
   TokenInterceptor,
   { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
  { provide: MAT_DATE_LOCALE, useValue: 'en-GB' },
	{provide: MAT_MOMENT_DATE_ADAPTER_OPTIONS, useValue: {useUtc: true}},
  { provide: MAT_DATE_FORMATS, useValue: MY_DATE_FORMATS },
];

let Pipes = [];

@NgModule({
  declarations: [...Components],
  imports: [...Modules],
  providers: [...Services],
  bootstrap: [AppComponent],
})
export class AppModule {}
