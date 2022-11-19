import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  public isLogin = false;

  login(userLogin: any): Observable<any> {
    return this.httpClient.post(this.url, userLogin)
  }

  setDataUser(user: any) {
    localStorage.setItem('user', JSON.stringify(user))
    this.isLogin = true;
  }

  isLogIn() {
    let stringJson = localStorage.getItem('user')
    if (stringJson == null || stringJson == '')
      this.isLogin = false;
    else
      this.isLogin = true;

    let json = JSON.parse(stringJson + '')
    //console.log(json)

    return this.isLogin;
  }

  url: string;

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl + 'Api/Login';
  }
}
