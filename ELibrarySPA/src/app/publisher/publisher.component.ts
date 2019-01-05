import { Component, OnInit } from '@angular/core';
import { PublisherService } from './shared/publisher.service';
import { PublisherUiModel as PublisherUiModel } from '../models/PublisherUiModel';

@Component({
  selector: 'app-publisher',
  templateUrl: './publisher.component.html',
  styleUrls: ['./publisher.component.css']
})
export class PublisherComponent implements OnInit {

  constructor(private publisherService:PublisherService) { }

  publisher :PublisherUiModel[]=[];
  ngOnInit() {
    this.publisherService.getAll('Publisher/Alphabetically').subscribe((res:PublisherUiModel[])=>{
      this.publisher=res;
      console.log(this.publisher)
      }
    )
  }

}