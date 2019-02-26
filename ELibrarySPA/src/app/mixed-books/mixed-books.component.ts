import { SnotifyService } from 'ng-snotify';
import { BookRateService } from './../service/book-rate.service';
import { Component, OnInit, Input, ChangeDetectorRef } from "@angular/core";
import { MixedBooksService } from "./shared/mixedBooksService.service";
import { TokenService } from "../service/token.service";
import { BookRate } from "../mixed-books/shared/book-rate";
import { Favorite } from '../book-detail/shared/favorite';

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
    private snotifyService: SnotifyService,
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

  favBook(book){
    this.mixedService.post("/User/Favorite",this.createFavoriteModel(book)).subscribe(res => {
       //console.log('res',res);
      this.snotifyService.success('Başarılı', 'Favoriledin', {
        timeout: 2000,
        showProgressBar: true,
        closeOnClick: false,
        pauseOnHover: true
      });

     });
  }


  createFavoriteModel(book){

    let favorite: Favorite = new Favorite();
    favorite.bookId = book.id;
    favorite.authorId = book.authorId;
    favorite.authorName = book.author.name;
    favorite.authorSurname = book.author.surname;
    favorite.bookName = book.bookName;
    favorite.categoryId = book.category.id;
    favorite.categoryName = book.category.name;
    favorite.publisherId = book.publisher.id;
    favorite.publisherName = book.publisher.name;
    favorite.signUrl = book.thumbnail.signUrl;
    favorite.token = localStorage.getItem('token');
    favorite.userId = JSON.parse(localStorage.getItem('user'))["id"];
    return favorite;
  }

}
