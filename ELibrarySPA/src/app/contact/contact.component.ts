import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { SnotifyService } from 'ng-snotify';
import { ContactService } from './shared/contact.service';
import { LoaderService } from '../service/loader.service';
import { Contact } from '../models/Contact';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {
  contact: FormGroup;
  contactInfo:Contact;
  constructor(
    private formBuilder: FormBuilder,
    private snotifyService: SnotifyService,
    private loaderService:LoaderService,
    private contactService: ContactService
  ) { }

  ngOnInit() {

    this.contactService.get("/Contact/GetOne").subscribe(res => {
      
      this.contactInfo = res["value"];
    });
    this.contact = this.formBuilder.group({
      nameSurname: ['', Validators.required],
      message: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
    });
  }

  formSubmit() {
    if (this.contact.valid) {
      this.loaderService.show();
      this.contactService.post('Contact/SendMail', this.contact.value).subscribe((res) => {
        this.loaderService.hide();
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
