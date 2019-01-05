import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { trLocale } from 'ngx-bootstrap/locale';
import { PasswordValidation } from '../signup/password-validation';
defineLocale('tr', trLocale);

@Component({
  selector: 'signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  signUp: FormGroup;
  constructor(
    public bsModalRef: BsModalRef,
    private formBuilder: FormBuilder,
    private localeService: BsLocaleService
  ) {
  }

  ngOnInit() {
    this.signUp = this.formBuilder.group({
      name: ['', Validators.required],
      surname: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', [Validators.required, Validators.minLength(6)]],
      phoneNumber: ['', [Validators.required,Validators.minLength(9)]],
      privacy: [false, [Validators.required]],
      birthdate: ['', [Validators.required]]
    }, {
      validator: PasswordValidation.MatchPassword('password', 'confirmPassword')
    });
    this.localeService.use('tr');
  }

  formSubmit() {
    if(this.signUp.valid){
      alert('valid');
      console.log('this.signUp.value',this.signUp.value);
      alert(JSON.stringify(this.signUp.value))
    }else{
      this.validateAllFormFields(this.signUp);
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
