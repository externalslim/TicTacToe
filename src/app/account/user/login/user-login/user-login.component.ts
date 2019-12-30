import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html'
})
export class UserLoginComponent implements OnInit {

  public email: string;
  public password: string;
  constructor(private router: Router) { }

  ngOnInit() {
  }

  public UserRegister() {
    this.email = '';
    this.password = '';
    this.router.navigate(['/user-register']);
  }

}
