import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {LoginService} from '../../../../services/account/login.service'

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html'
})
export class UserLoginComponent implements OnInit {

  public email: string;
  public password: string;
  constructor(private router: Router, private login_service: LoginService) { }

  ngOnInit() {
  }

  public Login(){
    if (this.EmailValidation(this.email) && this.password.length > 0) {
      var response = this.login_service.Login(this.email, this.password);
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
