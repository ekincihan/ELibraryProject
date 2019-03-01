import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { User } from '../signin/shared/user';
import { UserProfileService } from '../user-profile/shared/user-profile.service';
import { Favorite } from '../book-detail/shared/favorite';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { SnotifyService } from 'ng-snotify';

import { defineLocale } from 'ngx-bootstrap/chronos';
import { trLocale } from 'ngx-bootstrap/locale';
import { BookRate } from '../mixed-books/shared/book-rate';
import { BookRateService } from '../service/book-rate.service';
import { LoaderService } from '../service/loader.service';
import { Factory } from '../signin/factory';
defineLocale('tr', trLocale);

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  user: User;
  reads: Favorite[];
  favs: Favorite[];
  max = 5;
  minDate = new Date('01/01/1920');
  maxDate = new Date();
  ppUrl:string;
  @ViewChild('file') public file: ElementRef;

  constructor(private service: UserProfileService,
    private localeService: BsLocaleService,
    private loaderService:LoaderService,
    private snotifyService: SnotifyService
    ) {
      if(localStorage.getItem('user'))
        this.user = JSON.parse(localStorage.getItem('user'));
        this.user.birthdate = new Date(this.user.birthdate)
      //console.log('user.birthdate',new Date(this.user.birthdate));
      this.ppUrl = (this.user.gender) ? 'assets/img/male.jpg' : 'assets/img/female.jpg'
      this.minDate.setDate(this.minDate.getDate());
      this.maxDate.setDate(this.maxDate.getDate());
      this.localeService.use('tr');

   }

  ngOnInit() {
    this.loaderService.show();
    this.service.get('/User/GetFavAndReads/'+this.user.id).subscribe(res =>{
        this.loaderService.hide();
        let bookRateService = new BookRateService();
        bookRateService.bookList =  res["favorites"];
        bookRateService.service = this.service;
        this.favs = bookRateService.getBooks();
        let bookRateServiceReads = new BookRateService();
        bookRateServiceReads.bookList =  res["reads"];
        bookRateServiceReads.service = this.service;
        this.reads = bookRateServiceReads.getBooks();
    });
  }

  readUrl(event:any) {
    if (event.target.files && event.target.files[0]) {
        if(event.target.files[0].type == "image/png" || event.target.files[0].type == "image/jpeg"
         || event.target.files[0].type == "image/jpg"){
                var reader = new FileReader();
                reader.onload = (event:any) => {
                this.ppUrl =  event.target.result;
                }
                reader.readAsDataURL(event.target.files[0]);
            }else{
              this.snotifyService.error('Lütfen uzantısı ".png, .jpeg veya .jpg" olan dosya seçiniz', 'Oops...', {
                timeout: 2000,
                showProgressBar: true,
                closeOnClick: false,
                pauseOnHover: true
              });
            }
    }
}

saveUser(){
  var files = this.file.nativeElement.files;
  var formData = new FormData();
  var file = files[0];
  var name = this.user.name+ ' ' +this.user.surname;
  formData.append("File",file,name);
  console.log('formData',formData);
  //console.log('user',this.user);
  console.log(this.user)
  this.service.post('Account/Register',this.user).subscribe(item => {
    let factory: Factory = new Factory(item["value"]);
  }); 

  // this.service.post('Account/Uploadmage',this.user).subscribe(res => {
  //   if(res['success']){
  //     this.service.post('Account/Register',this.user).subscribe(item => {
    
  //     }); 
  //   }else{
  //     this.snotifyService.error('Fotoğraf yüklenirken bir hata oluştu', 'Oops...', {
  //       timeout: 2000,
  //       showProgressBar: true,
  //       closeOnClick: false,
  //       pauseOnHover: true
  //     });
  //   }
 

}

  confirmSelection(fav:Favorite) {
    let bookRate = this.newBookRate(fav);
    this.loaderService.show();
    this.service.post('User/Rate', bookRate).subscribe((res) => {
      this.loaderService.hide();
     // //console.log('rated book', res);

    })
  }



  newBookRate(fav:Favorite) {
    let rateBookModel: BookRate = new BookRate();
    const user = JSON.parse(localStorage.getItem('user'));
    rateBookModel.bookId = fav["bookId"];
    rateBookModel.token = localStorage.getItem('token');
    rateBookModel.userId = user.id;
    rateBookModel.id = fav["id"];
    rateBookModel.rate = fav["rate"];
    return rateBookModel;
  }

}
