import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'author-detail',
  templateUrl: './author-detail.component.html',
  styleUrls: ['./author-detail.component.css']
})
export class AuthorDetailComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    console.log('auth');
    
  }

}
