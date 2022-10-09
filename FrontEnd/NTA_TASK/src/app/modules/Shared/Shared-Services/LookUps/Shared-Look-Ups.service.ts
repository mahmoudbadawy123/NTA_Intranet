import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { ApiService } from '../http/Api.service';

@Injectable({
  providedIn: 'root',
})
export class SharedLookUpsService {
  constructor(private api: ApiService, private alert: ToastrService) {}

  Groups(): Observable<any> {
    return this.api.get('UserGroups/GetAll').pipe();
  }

  MeetingTypes(): Observable<any> {
    return this.api.get('MeetingTypes/GetAll').pipe();
  }

  UsersExceptMe(): Observable<any> {
    return this.api.get('Users/GetAll').pipe();
  }

  
}
