import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IAppConfig } from '../modules/Shared/Interfaces/IAppConfig';

@Injectable()
export class AppConfigService {
  static settings: IAppConfig;
  constructor(private http: HttpClient) {}


  load() {
    const jsonFile = `assets/config/config.${environment.name}.json`;
    return new Promise<void>((resolve, reject) => {
        this.http.get(jsonFile).toPromise().then((response : any) => {
          AppConfigService.settings = <IAppConfig>response;
           resolve();
        }).catch((response: any) => {
           reject(`Could not load file '${jsonFile}': ${JSON.stringify(response)}`);
        });
    });
}


}


