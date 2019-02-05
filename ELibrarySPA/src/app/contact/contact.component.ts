import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { SnotifyService } from 'ng-snotify';
import { ContactService } from './shared/contact.service';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {
  contact: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private snotifyService: SnotifyService,
    private contactService: ContactService
  ) { }

  ngOnInit() {
    this.contact = this.formBuilder.group({
      nameSurname: ['', Validators.required],
      message: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
    });
  }

  formSubmit() {
    if (this.contact.valid) {
      this.contactService.post('Contact/SendMail', this.contact.value).subscribe((res) => {
    
          this.snotifyService.success('Mesajınız gönderildi.', ' Başarılı', {
            timeout: 2000,
            showProgressBar: true,
            closeOnClick: false,
            pauseOnHover: true
          });
      });
    } else {
      this.validateAllFormFields(this.contact);
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
