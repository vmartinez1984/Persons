import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PersonDto } from '../person.model';
import { PersonService } from '../person.service';

@Component({
  selector: 'app-list-persons',
  templateUrl: './list-persons.component.html',
  styleUrls: ['./list-persons.component.css']
})
export class ListPersonsComponent implements OnInit {
  persons: PersonDto[] = []

  constructor(private service: PersonService) {
    //this.getAll();
  }

  getAll() {
    this.service.getAll().subscribe(data => {
      this.persons = data
      console.log(this.persons)
    }, error => {console.log(error)});
    
  }

  ngOnInit(): void {
    //throw new Error('Method not implemented.');
  }
}
