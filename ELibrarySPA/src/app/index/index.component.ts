import { LoaderService } from './../service/loader.service';
import { Component, OnInit } from "@angular/core";
import { IndexService } from "./shared/index.service";
import { Book } from "../models/Book";

@Component({
  selector: "app-index",
  templateUrl: "./index.component.html",
  styleUrls: ["./index.component.css"]
})
export class IndexComponent implements OnInit {
  constructor(private indexService: IndexService,
      private loaderService:LoaderService) {}

  lastAdded: Book[];
  mostReaded: Book[];
  isLastAdded = true;
  ngOnInit() {
    this.loaderService.show();
    this.indexService.getAll("Book/LastAdded").subscribe(res => {
      //console.log('last added',res["value"])
      this.lastAdded = res["value"];
      this.loaderService.hide();
    });
  }

  valueChange(isLastAdded: boolean){
    if(!isLastAdded){
      this.loaderService.show();
      this.isLastAdded = false;
           this.indexService.getAll("Book/MostReads").subscribe(res => {
            this.mostReaded = res["value"];
            this.loaderService.hide();
          });
    }else{
      this.loaderService.show();
      this.isLastAdded = true;
      this.indexService.getAll("Book/LastAdded").subscribe(res => {
        //console.log(res["value"])
        this.lastAdded = res["value"];
        this.loaderService.hide();
      });
    }

  }
}
