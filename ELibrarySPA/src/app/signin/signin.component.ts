import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { SignInService } from './shared/signIn.service';

@Component({
  selector: 'signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {
  signIn: FormGroup;
  rememberPassword: FormGroup;
  constructor(
    public bsModalRef: BsModalRef,
    private formBuilder: FormBuilder,
    private signInService :SignInService) { }

  ngOnInit() {
    this.signIn = this.formBuilder.group({
      password: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
    });
    this.rememberPassword = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
    });
  }

  formSubmit() {
    if(this.signIn.valid){
      // alert('valid');
      // alert(JSON.stringify(this.signIn.value))
      this.signInService.post('Account/Login',this.signIn.value).subscribe((res)=>{
        console.log(res['value'])
      })
      
    }else{
      this.validateAllFormFields(this.signIn);
    }
  }

  rememberFormSubmit(){
    if(this.rememberPassword.valid){
      alert('valid');
      alert(JSON.stringify(this.rememberPassword.value))
    }else{
      this.validateAllFormFields(this.rememberPassword);
    }
  }

  validateAllFormFields(formGroup: FormGroup) {
    Object.keys(formGroup.controls).forEach(field => {
      const control = formGroup.get(field);
      if (control instanceof FormControl) {
        control.markAsTouched({ onlySelf: true });
      } else if (control instanceof FormGroup) {
        this.validateAllFormFields(control);
      }
    });
  }

}
