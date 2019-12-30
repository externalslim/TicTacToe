import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import Swal from 'sweetalert2';
import { Router } from '@angular/router';
import { RegisterService } from 'app/services/account/register.service';
import { UserModel } from 'app/models/usermodel';

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html'
})
export class UserRegisterComponent implements OnInit {

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
      var response = this.register_service.Register(this.userModel);
      if (response) {
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
      else {
        Swal.fire({
          title: 'Register',
          text: 'Not Valid!',
          icon: 'warning',
          showCancelButton: false,
          confirmButtonText: 'Retry!'
        })
      }
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
