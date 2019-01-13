import { Component, OnInit, Input, ChangeDetectorRef } from "@angular/core";
import { MixedBooksService } from "./shared/mixedBooksService.service";
import { Book } from "../models/Book";
import { Router } from '@angular/router';
import { TokenService } from "../service/token.service";
import { BookRate } from "../mixed-books/shared/book-rate";
import { User } from "../signin/shared/user";

@Component({
  selector: "mixed-books",
  templateUrl: "./mixed-books.component.html",
  styleUrls: ["./mixed-books.component.css"]
})
export class MixedBooksComponent implements OnInit {
  @Input("data") data: Array<any>[];
  max = 5;
  isLogin = false;
  ratedBooks: BookRate[];
  user: User;
  constructor(
    private mixedService: MixedBooksService,
    public tokenService: TokenService) {

    this.user = (localStorage.getItem('user')) ? JSON.parse(localStorage.getItem('user')) : null;
    this.tokenService.isLoginChange.subscribe(() => {
      this.isLogin = this.tokenService.getIsLogin();
    })

  }
  ngOnInit() {
    if (this.user) {
      this.mixedService.get('User/Rate/' + this.user.id).subscribe((res: any) => {
        this.setRatedBooks(res);
      })
    }
  }

  setRatedBooks(ratedBooks) {
    this.ratedBooks = new Array<BookRate>();
    if (ratedBooks.length > 0) {

      ratedBooks.forEach(book => {
        this.ratedBooks.push(this.newBookRate(book, false));
      });
      if (this.ratedBooks.length !== this.data.length) {
        for (let index = ratedBooks.length; index < this.data.length; index++) {
          this.ratedBooks.push(this.newBookRate(this.data[index], true));
        }
      }
    } else {
      this.data.forEach(book => {
        this.ratedBooks.push(this.newBookRate(book, true));
      });
    }
  }

  confirmSelection(bookRate) {
    this.mixedService.post('User/Rate', bookRate).subscribe((res) => {
     // console.log('rated book', res);

    })
  }



  newBookRate(bookRate, isNew: boolean) {
    let rateBookModel: BookRate = new BookRate();
    rateBookModel.bookId = (isNew) ? bookRate["id"] : bookRate["bookId"];
    rateBookModel.token = localStorage.getItem('token');
    rateBookModel.userId = this.user.id;
    rateBookModel.id = (isNew) ? null : bookRate["id"];
    rateBookModel.rate = (isNew) ? 0 : bookRate["rate"];
    return rateBookModel;
  }

}
