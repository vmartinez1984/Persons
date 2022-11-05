import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private isLogin: boolean = false

  saveData(data: any) {
    localStorage.setItem('login', JSON.stringify(data))
    this.isLogin = true;
  }

  getData() {
    return JSON.parse(localStorage.getItem('login') + '')
  }

  isLoggedIn() {
    var login = localStorage.getItem('login');
    if (login == undefined || login == null)
      this.isLogin = false
    else
      this.isLogin = true

    return this.isLogin;
  }

  logOut() {
    localStorage.removeItem('login')
    this.isLogin = false
    //this.isLoggedIn()
    //console.log('Cerrar sesión')
  }

  login(login: any): Observable<any> {
    return this.httpClient.post(this.url, login)
  }

  constructor(private httpClient: HttpClient,  @Inject('BASE_URL') baseUrl: string) { 
    this.url =  baseUrl + "Api/Login"
  }

  url: string 
}
