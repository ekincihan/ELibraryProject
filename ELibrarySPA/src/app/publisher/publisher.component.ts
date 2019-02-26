import { Component, OnInit } from '@angular/core';
import { PublisherService } from './shared/publisher.service';
import { PublisherUiModel as PublisherUiModel } from '../models/PublisherUiModel';
import { LoaderService } from '../service/loader.service';

@Component({
  selector: 'app-publisher',
  templateUrl: './publisher.component.html',
  styleUrls: ['./publisher.component.css']
})
export class PublisherComponent implements OnInit {

  constructor(private publisherService:PublisherService,
        private loaderService:LoaderService    ) { }

  publisher :PublisherUiModel[]=[];
  ngOnInit() {
    this.loaderService.show();
    this.publisherService.getAll('Publisher/Alphabetically').subscribe((res:PublisherUiModel[])=>{
      this.publisher=res;
      this.loaderService.hide();
      ////console.log(this.publisher)
      }
    )
  }

}
