import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../src/environments/environment';
import { UserModel } from 'app/models/usermodel';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private baseUrl: string;
  private user_service: string;
  private get_user_list: string;
  private get_user_by_id: string;
  private get_user_by_nickname_and_password: string;
  private insert: string;
  private update: string;
  private delete: string;
  constructor(private httpClient: HttpClient) { 
    this.baseUrl = environment.baseUrl;
    this.user_service = environment.services.user_service._base;
    this.get_user_list= environment.services.user_service._getUserList;
    this.get_user_by_id= environment.services.user_service._getUserById;
    this.get_user_by_nickname_and_password = environment.services.user_service._getUserByNicknameAndPassword;
    this.insert= environment.services.user_service._insert;
    this.update= environment.services.user_service._update;
    this.delete= environment.services.user_service._delete;

  }

  public Login(userModel: UserModel){
    return this.httpClient.post<UserModel>(this.baseUrl + this.user_service + this.get_user_by_nickname_and_password, userModel).toPromise();
  }


}
