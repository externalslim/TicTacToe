import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {LoginService} from '../../../../services/account/login.service'
import {SessionService} from '../../../../services/session/session.service'
import { UserModel } from 'app/models/usermodel';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html'
})
export class UserLoginComponent implements OnInit {

  public nickname: string;
  public password: string;
  public userModel: UserModel = <UserModel>{};
  constructor(
    private router: Router, 
    private login_service: LoginService, 
    private session_service: SessionService
  ) { }

  ngOnInit() {
    this.session_service.RemoveUserSession();
  }

  public Login(){
    if (this.nickname.length > 0 && this.password.length > 0) {
      this.userModel.nickname = this.nickname;
      this.userModel.password = this.password;
      this.login_service.Login(this.userModel).then(response => {
        console.log(response);
        if (response != null) {
          this.userModel.id = response.id;
          this.session_service.SetUserSession(this.userModel);
          this.router.navigate(['/xox-main']);
        }
        else {
          Swal.fire({
            title: 'Register',
            text: 'Exist User!',
            icon: 'warning',
            showCancelButton: false,
            confirmButtonText: 'Retry!'
          })
        }
      });
    }
  }

  public UserRegister() {
    this.nickname = '';
    this.password = '';
    this.router.navigate(['/user-register']);
  }
}
