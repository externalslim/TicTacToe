import { Component } from '@angular/core';
import { SessionService } from './services/session/session.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent{

  private session_key: string;
  constructor(
    private session: SessionService,
    private router: Router
    ){
    this.session_key = 'User_';
  }

  ngOnInit(): void {
    if (!this.session.GetUserSession(this.session_key)) {
      this.router.navigate(['/user-login']);
    }    
  }
}


