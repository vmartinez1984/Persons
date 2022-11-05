import { Component } from '@angular/core';
import { LoginService } from './services/login.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'Person';

  constructor(private loginService: LoginService) { }

  isLogin(): boolean {
    return this.loginService.isLoggedIn();
  }
}
