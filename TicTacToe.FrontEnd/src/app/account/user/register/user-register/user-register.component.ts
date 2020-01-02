import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import Swal from 'sweetalert2';
import { Router } from '@angular/router';
import { RegisterService } from 'app/services/account/register.service';
import { UserModel } from 'app/models/usermodel';
import { environment } from '../../../../../environments/environment';

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html'
})
export class UserRegisterComponent implements OnInit {

  public nickname: string;
  public email: string;
  public password: string;
  public passwordValidate: string;
  public userModel: UserModel = <UserModel>{};

  constructor(private toastr: ToastrService, private router: Router, private register_service: RegisterService) { }

  ngOnInit() {
  }

  public Register() {
    if (this.EmailValidation(this.email) && this.password === this.passwordValidate) {
      this.userModel.email = this.email;
      this.userModel.password = this.password;
      this.userModel.nickname = this.nickname;
      this.userModel.channelId = environment.channels.web;
      this.register_service.Register(this.userModel).then(response => {
        console.log(response);
        console.log(response.id);
        if (response.id == 0) {
          Swal.fire({
            title: 'Register',
            text: 'Exist User!',
            icon: 'warning',
            showCancelButton: false,
            confirmButtonText: 'Retry!'
          })
        }
        else {
          Swal.fire({
            title: 'Register',
            text: 'Register Complete',
            icon: 'success',
            showCancelButton: false,
            confirmButtonText: 'Continue!',
          }).then((result) => {
            if (result.value) {
              this.router.navigate(['/user-login']);
            }
          })
        }
      });
    }
  }

  public Cancel() {
    this.email = '';
    this.password = '';
    this.passwordValidate = '';
    this.router.navigate(['/user-login']);
  }

  private EmailValidation(email) {
    return /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email);
  }

}
