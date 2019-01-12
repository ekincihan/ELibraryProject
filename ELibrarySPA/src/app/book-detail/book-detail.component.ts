import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookService } from './shared/book.service';
import { Book } from '../models/Book';

@Component({
  selector: 'book-detail',
  templateUrl: './book-detail.component.html',
  styleUrls: ['./book-detail.component.css']
})
export class BookDetailComponent implements OnInit {

  constructor(private bookService: BookService,
    private activatedRoute: ActivatedRoute,) { }

    book: Book;
  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      this.bookService.get("/Book/Detail/"+ params["bookId"]).subscribe(res => {
        this.book = res["value"];
        console.log(this.book)
     });
  })

}
}
