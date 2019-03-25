import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { SnotifyService } from 'ng-snotify';
import { BannerService } from './shared/banner.service';
import { LoaderService } from '../service/loader.service';
import { Banner } from '../models/Banner';

@Component({
  selector: 'app-contact'
  //templateUrl: './contact.component.html',
 // styleUrls: ['./contact.component.css']
})
export class BannerComponent implements OnInit {
  banner: FormGroup;
  bannerInfo:Banner;
  constructor(
    private formBuilder: FormBuilder,
    private snotifyService: SnotifyService,
    private loaderService:LoaderService,
    private bannerService: BannerService
  ) { }

  ngOnInit() {

    this.bannerService.get("/Banner/GetOne").subscribe(res => {
      
      this.bannerInfo = res["value"];
    });
    this.banner = this.formBuilder.group({
      name: ['', Validators.required],
      moduleId: ['', Validators.required],
      signUrl: ['', Validators.required],
    });
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
