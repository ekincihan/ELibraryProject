import { Component, OnInit, Input, ChangeDetectorRef } from "@angular/core";
import { MixedBooksService } from "./shared/mixedBooksService.service";
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
    this.data.forEach(book => {
      ratedBooks.forEach(ratedBook => {
          if(ratedBook["bookId"] == book["id"]){
            book["rate"] = ratedBook["rate"];
            book["ratedBookId"] = ratedBook["id"];
          }
      });
    });
  }

  confirmSelection(book) {
    let bookRate = this.newBookRate(book,true);
    this.mixedService.post('User/Rate', bookRate).subscribe((addedBookId) => {
      console.log('book 2', book);
      book["ratedBookId"] = addedBookId;
      console.log('book 3', book);

    })
  }


  newBookRate(bookRate, isNew: boolean) {
    let rateBookModel: BookRate = new BookRate();
    rateBookModel.bookId =  bookRate["id"];
    rateBookModel.token = localStorage.getItem('token');
    rateBookModel.userId = this.user.id;
    rateBookModel.id =  (bookRate["ratedBookId"]) ? bookRate["ratedBookId"] : null;
    rateBookModel.rate = bookRate["rate"];
    return rateBookModel;
  }

}
