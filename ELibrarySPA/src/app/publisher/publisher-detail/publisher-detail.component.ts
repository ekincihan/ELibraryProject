import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PublisherService } from '../../publisher/shared/publisher.service';
import { Favorite } from '../../book-detail/shared/favorite';
import { BookRate } from '../../mixed-books/shared/book-rate';
import { BookRateService } from '../../service/book-rate.service';
import { LoaderService } from '../../service/loader.service';

@Component({
  selector: 'publisher-detail',
  templateUrl: './publisher-detail.component.html',
  styleUrls: ['./publisher-detail.component.css']
})
export class PublisherDetailComponent implements OnInit {
  publisher: any;
  publisherBooks: any;
  constructor(private publisherService: PublisherService,
    private loaderService:LoaderService,
    private activatedRoute: ActivatedRoute) {
    this.activatedRoute.params.subscribe(params => {
      this.loaderService.show();
      this.publisherService.get("/Publisher/GetOne/" + params["publisherId"]).subscribe(res => {
        this.loaderService.hide();
        this.publisher = res["value"];
        this.loaderService.show();
        this.publisherService.get("/Publisher/BookByPublisher/" + this.publisher.id).subscribe(res => {
          this.loaderService.hide();
            this.publisherBooks =res[0].books;
            if(this.publisherBooks){
              let bookrateService = new BookRateService();
              bookrateService.bookList  = this.publisherBooks;
              bookrateService.service = this.publisherService;
              this.publisherBooks = bookrateService.getBooks();
            }
        });

      });
    })
  }

  ngOnInit() {
  }

  confirmSelection(fav:Favorite) {
    let bookRate = this.newBookRate(fav);
    this.loaderService.show();
    this.publisherService.post('User/Rate', bookRate).subscribe((res) => {
      this.loaderService.hide();
     // //console.log('rated book', res);
    })
  }

  newBookRate(fav:Favorite) {
    let rateBookModel: BookRate = new BookRate();
    rateBookModel.bookId = fav["bookId"];
    rateBookModel.token = localStorage.getItem('token');
    rateBookModel.userId = JSON.parse(localStorage.getItem('user'))["id"];
    rateBookModel.id = fav["id"];
    rateBookModel.rate = fav["rate"];
    return rateBookModel;
  }

}
