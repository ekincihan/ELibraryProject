import { Component, OnInit } from '@angular/core';
import { User } from '../signin/shared/user';
import { UserProfileService } from '../user-profile/shared/user-profile.service';
import { Favorite } from '../book-detail/shared/favorite';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';

import { defineLocale } from 'ngx-bootstrap/chronos';
import { trLocale } from 'ngx-bootstrap/locale';
import { BookRate } from '../mixed-books/shared/book-rate';
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
  
  constructor(private service: UserProfileService,
    private localeService: BsLocaleService,
    ) {
      if(localStorage.getItem('user'))
        this.user = JSON.parse(localStorage.getItem('user'));
        this.user.birthdate = new Date(this.user.birthdate)
      console.log('user.birthdate',new Date(this.user.birthdate));

      this.minDate.setDate(this.minDate.getDate());
      this.maxDate.setDate(this.maxDate.getDate());
      this.localeService.use('tr');

   }

  ngOnInit() {
    this.service.get('/User/GetFavAndReads/'+this.user.id).subscribe(res =>{
        this.favs = res["favorites"];
        this.reads = res["reads"];
    });
  }

  confirmSelection(fav:Favorite) {
    let bookRate = this.newBookRate(fav);
    this.service.post('User/Rate', bookRate).subscribe((res) => {
     // console.log('rated book', res);

    })
  }



  newBookRate(fav:Favorite) {
    let rateBookModel: BookRate = new BookRate();
    rateBookModel.bookId = fav["bookId"];
    rateBookModel.token = localStorage.getItem('token');
    rateBookModel.userId = this.user.id;
    rateBookModel.id = fav["id"];
    rateBookModel.rate = fav["rate"];
    return rateBookModel;
  }

}
