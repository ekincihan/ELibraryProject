import { Component, OnInit } from "@angular/core";
import { IndexService } from "./shared/index.service";
import { Book } from "../models/Book";

@Component({
  selector: "app-index",
  templateUrl: "./index.component.html",
  styleUrls: ["./index.component.css"]
})
export class IndexComponent implements OnInit {
  constructor(private indexService: IndexService) {}

  lastAdded: Book[];
  mostReaded: Book[];
  isLastAdded = true;
  ngOnInit() {
    this.indexService.getAll("Book/LastAdded").subscribe(res => {
      this.lastAdded = res["value"];
    });
  }

  valueChange(isLastAdded: boolean){
    if(!isLastAdded){
      this.isLastAdded = false;
      //Buraya en çok okunanlar servisi gelecek.
          /* this.indexService.getAll("Book/.....").subscribe(res => {
            this.mostReaded = res["value"];
          }); */
    }else{
      this.isLastAdded = true;
      this.indexService.getAll("Book/LastAdded").subscribe(res => {
        this.lastAdded = res["value"];
      });
    }
    
  }
}
