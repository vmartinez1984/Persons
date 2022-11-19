import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoginService } from '../../services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  formGroup: FormGroup;
  error: string = '';

  constructor(
    private formBuilder: FormBuilder,
    private service: LoginService
  ) {
    this.formGroup = this.formBuilder.group({
      'email': ['', [Validators.email, Validators.required]],
      'password': ['',[Validators.required]]
    })
  }

  ngOnInit(): void {
  
  }

  submitForm() {
    //console.log(this.formGroup);
    if (this.formGroup.valid) {
      this.service.login(this.formGroup.value).subscribe(data => {
        //console.log(data)
        this.service.setDataUser(data)
      }, error => { 
        //console.log(error) 
        this.error = error.error.message
      })
    }
  }
}
