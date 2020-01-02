import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../src/environments/environment';
import { UserModel } from 'app/models/usermodel';
import { Observable, of } from "rxjs";
import { map, catchError } from "rxjs/operators";

import 'rxjs/Rx';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  
  private baseUrl: string;
  private user_service: string;
  private get_user_list: string;
  private get_user_by_id: string;
  private insert: string;
  private update: string;
  private delete: string;
  constructor(private httpClient: HttpClient) {
    
    this.baseUrl = environment.baseUrl;
    this.user_service = environment.services.user_service._base;
    this.get_user_list= environment.services.user_service._getUserList;
    this.get_user_by_id= environment.services.user_service._getUserById;
    this.insert= environment.services.user_service._insert;
    this.update= environment.services.user_service._update;
    this.delete= environment.services.user_service._delete;

    console.log(this.baseUrl);
   }

   public Register(userModel: UserModel) {
    return this.httpClient.post<UserModel>(this.baseUrl + this.user_service + this.insert, userModel).toPromise();
   }
}
