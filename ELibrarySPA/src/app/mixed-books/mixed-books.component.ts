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
  rate = 2;
  isLogin = false;
  ratedBook: BookRate;
  user: User;
  constructor(
    private mixedService: MixedBooksService,
    private router: Router,
    private cdr: ChangeDetectorRef,
    public tokenService: TokenService) {

    this.user = (localStorage.getItem('user')) ? JSON.parse(localStorage.getItem('user')) : null;
    this.tokenService.isLoginChange.subscribe(() => {
      this.isLogin = this.tokenService.getIsLogin();
    })


  }
  ngOnInit() {
  }

  confirmSelection(book) {
    //this.ratedBook = this.rateBook(book);
    console.log('book',book);
    let rateBookModel: BookRate = new BookRate();
    rateBookModel.bookId = book["id"];
    rateBookModel.token = localStorage.getItem('token');
    rateBookModel.userId = this.user.id;
    //TODO: rateid gelecek rateBookModel.id = book.rateId
    rateBookModel.id = null;
    rateBookModel.rate = 4
    console.log('rateBookModel',rateBookModel);

    this.mixedService.post('User/Rate',rateBookModel).subscribe((res) =>{
      console.log('res',res);
      
    })


  }

  rateBook(book) {
 
    return null;
  }

}
