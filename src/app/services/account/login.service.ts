import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private baseUrl: string;
  constructor(private httpClient: HttpClient) { 
    this.baseUrl = environment.baseUrl;
    console.log(this.baseUrl);
  }

  Login(email:string, password:string) : boolean{
    if (email === 'a@a.com' && password === '1') {
      return true;      
    }
    else {
      return false;
    }
  }


}
