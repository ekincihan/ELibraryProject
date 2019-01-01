import { Component, OnInit } from '@angular/core';
import { IndexService } from './shared/index.service';
import { Book } from '../models/Book';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {

  constructor(private indexService: IndexService) { }

  lastAdded: Book[];
  ngOnInit() {
    this.indexService.getAll('Book/LastAdded').subscribe((res) =>{
      this.lastAdded=res['value'];
    })
  }

}
