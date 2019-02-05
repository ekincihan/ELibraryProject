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

  constructor(private bookService: BookService,
    private activatedRoute: ActivatedRoute,
    private snotifyService: SnotifyService) { }

  book: Book;
  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      this.bookService.get("/Book/Detail/" + params["bookId"]).subscribe(res => {
        this.book = res["value"];
       
      });
    })
  }

  beginReading(book){
      //console.log(book["id"])
      //console.log('this.createFavoriteModel(book);',this.createFavoriteModel(book));
      this.bookService.post("User/ReadBook",this.createFavoriteModel(book)).subscribe(res => {
       // console.log('res',res);
      });
      this.bookService.post("Book/ReadBook",book["id"]).subscribe(res => {
        // console.log('res',res);
       });
  }

  favBook(book){
    this.bookService.post("/User/Favorite",this.createFavoriteModel(book)).subscribe(res => {
       console.log('res',res);
      this.snotifyService.success('Başarılı', 'Favoriledin', {
        timeout: 2000,
        showProgressBar: true,
        closeOnClick: false,
        pauseOnHover: true
      });
         
     });
  }


  createFavoriteModel(book){
    console.log(book)
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
