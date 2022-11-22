import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PersonService {
  edit(person:any):Observable<any> {
    return this.httpClient.put(this.url, person);
  }
  add(person: any): Observable<any> {
    console.log(person)
    return this.httpClient.post(this.url, person);
  }

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
