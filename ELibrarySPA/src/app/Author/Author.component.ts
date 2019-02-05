import { Component, OnInit } from '@angular/core';
import { AuthorService } from './shared/author.service';
import { AuthorAlphabetically } from '../models/AuthorAlphabetically';

@Component({
  selector: 'app-Author',
  templateUrl: './Author.component.html',
  styleUrls: ['./Author.component.css']
})
export class AuthorComponent implements OnInit {

  constructor(private authorService:AuthorService) { }

  authors :AuthorAlphabetically[]=[];
  ngOnInit() {
    this.authorService.getAll('Author/Alphabetically').subscribe((res:AuthorAlphabetically[])=>{
      this.authors=res;
      console.log(this.authors)
      }
    )
  }

}
