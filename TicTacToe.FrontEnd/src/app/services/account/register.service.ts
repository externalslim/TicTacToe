import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../src/environments/environment';
import { UserModel } from 'app/models/usermodel';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  
  private baseUrl: string;
  constructor(private httpClient: HttpClient) {
    this.baseUrl = environment.baseUrl;
    console.log(this.baseUrl);
   }

   Register(userModel: UserModel): boolean {
     console.log(userModel);
     return true;
   }
}
