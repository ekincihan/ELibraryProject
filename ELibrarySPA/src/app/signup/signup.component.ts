import { LoaderService } from './../service/loader.service';
import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { PasswordValidation } from '../signup/password-validation';
import { SignUpService } from './shared/signUp.service';
import { PasswordStrengthValidator } from '../signup/password-strength.validator';
import { TokenService } from '../service/token.service';
import { SnotifyService } from 'ng-snotify';
import { Factory } from '../signin/factory';

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
    private localeService: BsLocaleService,
    private snotifyService: SnotifyService,
    private loaderService:LoaderService,
    private tokenService: TokenService,
    private signUpService: SignUpService
  ) {
  }

  ngOnInit() {
    this.signUp = this.formBuilder.group({
      name: ['', Validators.required],
      surname: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, PasswordStrengthValidator]],
      confirmPassword: ['', [Validators.required]],
      phoneNumber: ['', [Validators.required, Validators.minLength(9)]],
      privacy: [false, [Validators.required]],
      gender: ['', [Validators.required]],
      birthdate: ['', [Validators.required]]
    }, {
        validator: PasswordValidation.MatchPassword('password', 'confirmPassword')
      });
    this.localeService.use('tr');
  }

  formSubmit() {
    if (this.signUp.valid) {
      // alert('valid');
      // //console.log('this.signUp.value',this.signUp.value);
      // alert(JSON.stringify(this.signUp.value))
        delete this.signUp.value["confirmPassword"];
        delete this.signUp.value["privacy"];
        this.signUp.value["phoneNumber"] = "5" + this.signUp.value["phoneNumber"];
        this.loaderService.show();
      this.signUpService.post('Account/Register', this.signUp.value).subscribe((res) => {
        this.loaderService.hide();
        if (res["isSuccess"]) {
          this.bsModalRef.hide();
          this.tokenService.isLogin = true;
          this.tokenService.isLoginChange.emit(true);
          let factory: Factory = new Factory(res["value"]);
        } else {
          this.snotifyService.error(res["message"], 'Oops...', {
            timeout: 2000,
            showProgressBar: true,
            closeOnClick: false,
            pauseOnHover: true
          });
        }
      });
    } else {
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
