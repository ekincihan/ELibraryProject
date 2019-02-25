import { BookRateService } from './../service/book-rate.service';
import { Component, OnInit, Input, ChangeDetectorRef } from "@angular/core";
import { MixedBooksService } from "./shared/mixedBooksService.service";
import { TokenService } from "../service/token.service";
import { BookRate } from "../mixed-books/shared/book-rate";

@Component({
  selector: "mixed-books",
  templateUrl: "./mixed-books.component.html",
  styleUrls: ["./mixed-books.component.css"]
})
export class MixedBooksComponent implements OnInit {
  @Input("data") data: any;
  max = 5;
  isLogin = false;
  ratedBooks: BookRate[];
  constructor(
    private mixedService: MixedBooksService,
    public tokenService: TokenService) {

    this.tokenService.isLoginChange.subscribe(() => {
      this.isLogin = this.tokenService.getIsLogin();
    })

  }
  ngOnInit() {
      let bookrateService = new BookRateService();
      bookrateService.bookList  = this.data;
      bookrateService.service = this.mixedService;
      this.data = bookrateService.getBooks();
  }


  confirmSelection(book) {
    let bookRate = this.newBookRate(book,true);
    this.mixedService.post('User/Rate', bookRate).subscribe((addedBookId) => {
      //console.log('book 2', book);
      book["ratedBookId"] = addedBookId;
      //console.log('book 3', book);

    })
  }


  newBookRate(bookRate, isNew: boolean) {
    let rateBookModel: BookRate = new BookRate();
    const user = JSON.parse(localStorage.getItem('user'));
    rateBookModel.bookId =  bookRate["id"];
    rateBookModel.token = localStorage.getItem('token');
    rateBookModel.userId = user.id;
    rateBookModel.id =  (bookRate["ratedBookId"]) ? bookRate["ratedBookId"] : null;
    rateBookModel.rate = bookRate["rate"];
    return rateBookModel;
  }

}
