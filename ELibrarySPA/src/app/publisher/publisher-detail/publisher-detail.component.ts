import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PublisherService } from '../../publisher/shared/publisher.service';

@Component({
  selector: 'publisher-detail',
  templateUrl: './publisher-detail.component.html',
  styleUrls: ['./publisher-detail.component.css']
})
export class PublisherDetailComponent implements OnInit {
  publisher: any;
  publisherBooks: any;
  constructor(private publisherService: PublisherService,
    private activatedRoute: ActivatedRoute) {
    this.activatedRoute.params.subscribe(params => {

      this.publisherService.get("/Publisher/GetOne/" + params["publisherId"]).subscribe(res => {
        this.publisher = res["value"];
        this.publisherService.get("/Publisher/BookByPublisher/" + this.publisher.id).subscribe(res => {
            this.publisherBooks =res[0].books;
        });

      });
    })
  }

  ngOnInit() {
  }

}
