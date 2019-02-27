import { Component, OnInit } from '@angular/core';
import { AuthorService } from './shared/author.service';
import { AuthorAlphabetically } from '../models/AuthorAlphabetically';
import { LoaderService } from '../service/loader.service';

@Component({
  selector: 'app-Author',
  templateUrl: './Author.component.html',
  styleUrls: ['./Author.component.css']
})
export class AuthorComponent implements OnInit {

  constructor(private authorService:AuthorService,
    private loaderService:LoaderService
    ) { }

  authors :AuthorAlphabetically[]=[];
  ngOnInit() {
    this.loaderService.show();
    this.authorService.getAll('Author/Alphabetically').subscribe((res:AuthorAlphabetically[])=>{
      this.authors=res;
      this.loaderService.hide();
      //console.log(this.authors)
      }
    )
  }

}
