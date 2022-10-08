import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SessionService {
constructor() { }
Set(Name:string , Value: any){
  sessionStorage.setItem(Name , Value)
}
setObj(Name:string , Value: any){
  sessionStorage.setItem(Name, JSON.stringify(Value));  
}



get(Name:string){
  return sessionStorage.getItem(Name);    
}

getObj(Name:string){
  return JSON.parse(sessionStorage.getItem(Name)!);
}

Setlocal(Name:string , Value: any){
  localStorage.setItem(Name , Value)
}
setObjlocal(Name:string , Value: any){
  localStorage.setItem(Name, JSON.stringify(Value));  
}

getlocal(Name:string){
  return localStorage.getItem(Name);    
}

getObjlocal(Name:string){
  return JSON.parse(localStorage.getItem(Name)!);
}


remove(Name:string){
  sessionStorage.removeItem(Name);
  localStorage.removeItem(Name);
}

clear(){
  sessionStorage.clear();
  localStorage.clear();
}




getType() {
  var User =  JSON.parse(localStorage.getItem("user")!);
  return User?.userType;
}


}
