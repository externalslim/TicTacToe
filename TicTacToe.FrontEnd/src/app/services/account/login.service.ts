import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../src/environments/environment';
import { UserModel } from 'app/models/usermodel';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private baseUrl: string;
  constructor(private httpClient: HttpClient) { 
    this.baseUrl = environment.baseUrl;
    console.log(this.baseUrl);
  }

  Login(userModel: UserModel) : boolean{
    if (userModel.email === 'a@a.com' && userModel.password === '1') {
      return true;      
    }
    else {
      return false;
    }
  }


}
