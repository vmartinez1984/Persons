import { Component } from '@angular/core';
import { LoginService } from './services/login.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  

  constructor(private loginService: LoginService) {
  }
  
  isLogin():boolean {
   return this.loginService.isLogIn();
  }
  
}
