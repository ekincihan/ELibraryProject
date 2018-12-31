import { Component, OnInit } from '@angular/core';
import { MixedBooksServiceService } from './shared/mixedBooksService.service';
import { Book } from '../models/Book';

@Component({
  selector: 'mixed-books',
  templateUrl: './mixed-books.component.html',
  styleUrls: ['./mixed-books.component.css']
})
export class MixedBooksComponent implements OnInit {

  constructor(private mixedService:MixedBooksServiceService) { }

  books: Book[];
  ngOnInit() {
    this.mixedService.getAll('Book/List').subscribe((res) =>{
      this.books=res['value'];
      console.log(this.books)
    })
  }


}
