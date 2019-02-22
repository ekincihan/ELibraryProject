import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PublisherService } from '../../publisher/shared/publisher.service';
import { Favorite } from '../../book-detail/shared/favorite';
import { BookRate } from '../../mixed-books/shared/book-rate';

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

  confirmSelection(fav:Favorite) {
    let bookRate = this.newBookRate(fav);
    this.publisherService.post('User/Rate', bookRate).subscribe((res) => {
     // //console.log('rated book', res);

    })
  }

  newBookRate(fav:Favorite) {
    let rateBookModel: BookRate = new BookRate();
    rateBookModel.bookId = fav["bookId"];
    rateBookModel.token = localStorage.getItem('token');
    rateBookModel.userId = localStorage.getItem('user')["id"];
    rateBookModel.id = fav["id"];
    rateBookModel.rate = fav["rate"];
    return rateBookModel;
  }

}
