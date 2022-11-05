import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  formGroup: FormGroup

  constructor(
    private formBuilder: FormBuilder,
    private loginService: LoginService
  ) {
    this.formGroup = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    })
  }

  ngOnInit(): void {
    
  }

  submitForm() {
    console.log(this.formGroup)
    this.loginService.login(this.formGroup.value).subscribe(
      data => {
        alert("Bienvenido " + data.nameFull)
        console.log(data)
        this.loginService.saveData(data)
      },error =>{
        //console.log(error)
        //console.log(error.error.message)
        alert(error.error.message)
        this.formGroup.reset()
        document.getElementById('email')?.focus()
      }
    )
  }

}
