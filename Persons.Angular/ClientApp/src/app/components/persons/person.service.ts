import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  url:string;
  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) { 
    this.url = baseUrl +'Api/Persons'
  }

  ngOnInit(): void {
  }

  getAll():Observable<any>{
    return this.httpClient.get(this.url)
  }
}
