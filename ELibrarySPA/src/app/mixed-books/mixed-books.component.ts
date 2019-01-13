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
    if(this.user){
      this.mixedService.get('User/Rate/'+this.user.id).subscribe((res: any) =>{
        if(res.length == 0)
          this.setRatedBooks();
        else
          this.ratedBooks = res;
      })
    }
  }
  
  setRatedBooks(){
    this.ratedBooks = new Array<BookRate>();
    this.data.forEach(book => {
      this.ratedBooks.push(this.newBookRate(book));
    });
  }

  confirmSelection(book) {
   
    console.log('rateBııkModel',book);
    
    this.mixedService.post('User/Rate',book).subscribe((res) =>{
      console.log('res',res);
      
    })
  }

  newBookRate(book){
    let rateBookModel: BookRate = new BookRate();
    rateBookModel.bookId = book["id"];
    rateBookModel.token = localStorage.getItem('token');
    rateBookModel.userId = this.user.id;
    //TODO: rateid gelecek rateBookModel.id = book.rateId
    //rateBookModel.id = (book.id) ? book.id : null;
    rateBookModel.rate = (book.rate) ? book.rate : 0;
    return rateBookModel;
  }

}
