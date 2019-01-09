import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { SignInService } from './shared/signIn.service';
import Swal from 'sweetalert2'
import { Factory } from '../signin/factory';
import { TokenService } from '../service/token.service';

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
    private tokenService: TokenService,
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
        if(res["isSuccess"]){
          this.bsModalRef.hide();
          this.tokenService.isLogin = true;
          this.tokenService.isLoginChange.emit(true);
          let factory: Factory = new Factory(res["value"]);
        }else{
          Swal('Oops...', res["message"], 'error')
        }
       
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
