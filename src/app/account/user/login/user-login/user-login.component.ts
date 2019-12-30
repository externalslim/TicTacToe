import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {LoginService} from '../../../../services/account/login.service'
import { UserModel } from 'app/models/usermodel';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html'
})
export class UserLoginComponent implements OnInit {

  public email: string;
  public password: string;
  public userModel: UserModel = <UserModel>{};
  constructor(private router: Router, private login_service: LoginService) { }

  ngOnInit() {
  }

  public Login(){
    if (this.EmailValidation(this.email) && this.password.length > 0) {
      this.userModel.email = this.email;
      this.userModel.password = this.password;
      console.log(this.userModel);
      var response = this.login_service.Login(this.userModel);
      if (response) {
        this.router.navigate(['/xox-main']);
      } else {
        this.router.navigate(['/user-login']);
      }
    }
  }

  public UserRegister() {
    this.email = '';
    this.password = '';
    this.router.navigate(['/user-register']);
  }

  private EmailValidation(email) {
    return /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email);
  }

}
