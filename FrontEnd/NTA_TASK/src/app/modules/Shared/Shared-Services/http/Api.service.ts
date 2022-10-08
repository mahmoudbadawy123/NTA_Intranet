import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { catchError } from 'rxjs';
import { AppError } from 'src/app/common/error/app-error';
import { ErrorExpectationFailed, ErrorBadInput, ErrorNotFound, ErrorConflict, ErrorAmbiguous, ErrorNoContent, ErrorUnauthorized, ErrorMethodNotAllowed } from 'src/app/common/error/errors-types';
import { environment } from 'src/environments/environment';


@Injectable()
export class ApiService  implements OnInit{
 private url: string = "";


public headers = new HttpHeaders();
constructor(private http: HttpClient) {

  if (environment.production== false){
    this.url = environment.url;
  }
  else{
    this.url = window.location.href.split('#')[0] + '/api/';
  }
}

ngOnInit() {

}



geturl(){
  return this.url
}
get(action: String) {
  
  return this.http.get(this.url + action, {
    headers: this.headers
  }).pipe(catchError(this.handleError));
}
postblob(action: String, paramters: any) {

  return this.http.post(this.url + action, paramters, { responseType: "blob" }).pipe(
    catchError(this.handleError));
}
post(action: String, paramters: any) {
  // this.setToken();
  console.log(paramters);
  console.log(this.headers);
  return this.http.post(this.url + action, paramters,{
    headers: this.headers
  }).pipe(
    catchError(this.handleError));
}

put(action: string, paratmers: any) {
  return this.http.put(this.url + action, paratmers,{
    headers: this.headers
  }).pipe(
    catchError(this.handleError));
}

delete(action: String) {
  return this.http.delete(this.url + action,{
    headers: this.headers
  }).pipe(
    catchError(this.handleError));
}



getNoToken(action: String) {
  
  return this.http.get(this.url + action).pipe(catchError(this.handleError));
}

postNoToken(action: String, paramters: any) {
  // this.setToken();
  return this.http.post(this.url + action, paramters).pipe(
    catchError(this.handleError));
}

putNoToken(action: string, paratmers: any) {
  return this.http.put(this.url + action, paratmers).pipe(
    catchError(this.handleError));
}

deleteNoToken(action: String) {
  return this.http.delete(this.url + action).pipe(
    catchError(this.handleError));
}


private handleError(error: Response) : any {

  if (error.statusText == "Unknown Error")
    return observableThrowError(new ErrorExpectationFailed(error));
  if (error.status === 400)
    return observableThrowError(new ErrorBadInput(error));
  else if (error.status === 404)
    return observableThrowError(new ErrorNotFound(error));
  else if (error.status === 409)
    return observableThrowError(new ErrorConflict(error));
  else if (error.status === 300)
    return observableThrowError(new ErrorAmbiguous(error));
  else if (error.status === 204)
    return observableThrowError(new ErrorNoContent(error));
  else if (error.status === 401)
    return observableThrowError(new ErrorUnauthorized(error));
  else if (error.status == 405)
    return observableThrowError(new ErrorMethodNotAllowed(error));

  else return observableThrowError(new AppError(error));
}
}
function observableThrowError(arg0: AppError) {
  throw new Error('Function not implemented.');
}

