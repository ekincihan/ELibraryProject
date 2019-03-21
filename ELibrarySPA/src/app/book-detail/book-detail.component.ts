import { LoaderService } from './../service/loader.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookService } from './shared/book.service';
import { Book } from '../models/Book';
import { Favorite } from '../book-detail/shared/favorite';
import { SnotifyService } from 'ng-snotify';

@Component({
  selector: 'book-detail',
  templateUrl: './book-detail.component.html',
  styleUrls: ['./book-detail.component.css']
})
export class BookDetailComponent implements OnInit {
  readPage = {
    userId: '',
    id: '00000000-0000-0000-0000-000000000000',
    bookId: '',
    page: 0,
  }
  book: Book;
  user: any;
  isReading = false;
  constructor(private bookService: BookService,
    private activatedRoute: ActivatedRoute,
    private loaderService: LoaderService,
    private snotifyService: SnotifyService) {
      this.user = JSON.parse(localStorage.getItem('user'));
    }

  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      this.loaderService.show();
      this.bookService.get("/Book/Detail/" + params["bookId"]).subscribe(res => {
        console.log(res["value"])
        this.book = res["value"];
        this.loaderService.hide();
        if(this.user){
          this.getPageReaded();
        }
      });
    })
  }

  setReadPage(isAtHere: boolean){
    if(isAtHere){
      let currentPageNumber = document.getElementById("pageNumber")["value"];
      this.readPage.page = parseInt(currentPageNumber);
    }
    this.readPage.bookId = this.book.id;
    this.readPage.userId = JSON.parse(localStorage.getItem('user'))["id"];
  }

  getPageReaded(){
    this.setReadPage(false);
    this.loaderService.show();
    this.bookService.post('User/UserReadPage',this.readPage).subscribe(res =>{
      this.loaderService.hide();
      //console.log('res book',res);
      if(res &&  res["page"] > 0){
        this.isReading = true;
      }
    })
  }

  beginReading(book){
      this.loaderService.show();
      this.bookService.post("User/ReadBook",this.createFavoriteModel(book)).subscribe(res => {
        this.loaderService.hide();
      });
      this.loaderService.show();
      this.bookService.post("Book/ReadBook",book["id"]).subscribe(res => {
        this.loaderService.hide();
       });
  }

  favBook(book){
    this.loaderService.show();
    this.bookService.post("/User/Favorite",this.createFavoriteModel(book)).subscribe(res => {
      this.loaderService.hide();
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
    //console.log(book)
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
