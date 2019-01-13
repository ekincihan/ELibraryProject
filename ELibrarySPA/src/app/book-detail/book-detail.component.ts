import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookService } from './shared/book.service';
import { Book } from '../models/Book';
import { Favorite } from '../book-detail/shared/favorite';

@Component({
  selector: 'book-detail',
  templateUrl: './book-detail.component.html',
  styleUrls: ['./book-detail.component.css']
})
export class BookDetailComponent implements OnInit {

  constructor(private bookService: BookService,
    private activatedRoute: ActivatedRoute) { }

  book: Book;
  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      this.bookService.get("/Book/Detail/" + params["bookId"]).subscribe(res => {
        this.book = res["value"];
       
      });
    })
  }

  beginReading(book){
      //console.log('this.createFavoriteModel(book);',this.createFavoriteModel(book));
      this.bookService.post("/User/ReadBook",this.createFavoriteModel(book)).subscribe(res => {
       // console.log('res',res);
          
      });
  }

  favBook(book){
    this.bookService.post("/User/Favorite",this.createFavoriteModel(book)).subscribe(res => {
      // console.log('res',res);
         
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
    favorite.signUrl = book.appFiles["0"]["signUrl"];
    favorite.token = localStorage.getItem('token');
    favorite.userId = JSON.parse(localStorage.getItem('user'))["id"];
    return favorite;
  }
}
