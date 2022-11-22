import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PersonService } from '../person.service';

@Component({
  selector: 'app-form-person',
  templateUrl: './form-person.component.html',
  styleUrls: ['./form-person.component.css']
})
export class FormPersonComponent implements OnInit {
  formGroup: FormGroup;
  isSaving: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private service: PersonService,
    private activatedRouter: ActivatedRoute,
    private router: Router
  ) {
    let id = this.activatedRouter.snapshot.params.id;
    console.log(id)
    this.formGroup = this.formBuilder.group({
      id: [id],
      name: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      birthday: ['',[Validators.required]]
    })
  }

  ngOnInit(): void {
  }

  submitForm(){
    this.isSaving = true;
    console.log(this.formGroup)      
    if(this.formGroup.valid)  {
      if(this.formGroup.value.id == null){
        this.service.add(this.formGroup.value).subscribe(data=>{
          this.router.navigate(['/persons'])
        }, complete=>{          
          this.isSaving = false;
        })
      }else{
        this.service.edit(this.formGroup.value).subscribe(data=>{
          this.router.navigate(['/persons'])
        },complete=>{          
          this.isSaving = false;
        })
      }
    }else{
      Object.values(this.formGroup.controls).forEach(element=>{
        element.markAllAsTouched()
      })
      this.isSaving = false
    }
  }

}
