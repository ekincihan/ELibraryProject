import { Component, OnInit } from '@angular/core';
import { AuthorDetailService } from './shared/author-detail.service';
import { ActivatedRoute } from '@angular/router';
import { Book } from '../models/Book';
import { Author } from '../models/Author';

@Component({
  selector: 'author-detail',
  templateUrl: './author-detail.component.html',
  styleUrls: ['./author-detail.component.css']
})
export class AuthorDetailComponent implements OnInit {

  constructor(private authorService: AuthorDetailService,
    private activatedRoute: ActivatedRoute,
    ) { }

    authBooks: Book[];
    author:any;

    ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      this.authorService.get("/Author/Detail/"+ params["authorId"]).subscribe(res => {
       // //console.log("kitaplar istendi")
        this.author = res["value"];
        console.log('this.author',this.author);

       // //console.log('YAZAR BİLGİLERİ',res["value"]);

     });
     this.authorBook(params["authorId"]);
    });
  }

  authorBook(id: string) {
    this.authorService.get("/Author/Books/" + id).subscribe(res => {
       this.authBooks = res["value"];
       ////console.log('authbooks',this.authBooks)
       ////console.log("kitaplar geldi")
    });

}
}
