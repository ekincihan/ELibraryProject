import { Component, OnInit, Input } from "@angular/core";
import { MixedBooksService } from "./shared/mixedBooksService.service";
import { Book } from "../models/Book";
import { Router } from '@angular/router';

@Component({
  selector: "mixed-books",
  templateUrl: "./mixed-books.component.html",
  styleUrls: ["./mixed-books.component.css"]
})
export class MixedBooksComponent implements OnInit {
  @Input("data") data: Array<any>[];
  constructor(private mixedService: MixedBooksService,private router:Router) {}

  // books: Book[];

  ngOnInit() {
    /* this.mixedService.getAll('Book/LastAdded').subscribe((res) =>{
      this.books=res['value'];
      console.log(this.books)
    }) */
  }
  authorDetail(id: string) {
    console.log("auth id", id);

    this.mixedService.get("/Author/Detail/" + id).subscribe(res => {
      console.log(res["value"]);
      // this.router.navigateByUrl('/user');
      this.data = res["value"];
    });
  }
}
