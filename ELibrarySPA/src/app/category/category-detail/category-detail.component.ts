import { LoaderService } from './../../service/loader.service';
import { SnotifyService } from 'ng-snotify';
import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../../category/shared/category-service';
import { ActivatedRoute } from '@angular/router';
import { Favorite } from '../../book-detail/shared/favorite';
import { BookRate } from '../../mixed-books/shared/book-rate';
import { BookRateService } from '../../service/book-rate.service';

@Component({
  selector: 'category-detail',
  templateUrl: './category-detail.component.html',
  styleUrls: ['./category-detail.component.css']
})
export class CategoryDetailComponent implements OnInit {
  category: any;
  categoryName: any;
  user: any;
  constructor(private categoryService: CategoryService,
    private snotifyService: SnotifyService,
    private loaderService: LoaderService,
    private activatedRoute: ActivatedRoute) {
      this.user = JSON.parse(localStorage.getItem('user'));
    this.activatedRoute.params.subscribe(params => {
      this.loaderService.show();
      this.categoryService.get("/Category/BookByCategory/" + params["categoryId"]).subscribe(res => {
        this.loaderService.hide();
        this.category = res[0];
        if(this.category && this.category['books']){
          let bookrateService = new BookRateService();
          bookrateService.bookList  = this.category['books'];
          bookrateService.service = this.categoryService;
          this.category['books'] = bookrateService.getBooks();
        }

      });
    })
  }

  ngOnInit() {
  }

  confirmSelection(fav:Favorite) {
    let bookRate = this.newBookRate(fav);
    this.loaderService.show();
    this.categoryService.post('User/Rate', bookRate).subscribe((res) => {
          this.category['books'].forEach(book => {
              if(book["bookId"] == bookRate["bookId"]){
                book["ratedId"] = res;
              }
          });
          this.loaderService.hide();
    })
  }

  newBookRate(fav:Favorite) {
    let rateBookModel: BookRate = new BookRate();
    rateBookModel.bookId = fav["bookId"];
    rateBookModel.token = localStorage.getItem('token');
    rateBookModel.userId = JSON.parse(localStorage.getItem('user'))["id"];
    rateBookModel.id = (fav["ratedId"]) ? fav["ratedId"] : fav["id"];
    rateBookModel.rate = fav["rate"];
    return rateBookModel;
  }


  favBook(book){
    this.loaderService.show();
    this.categoryService.post("/User/Favorite",this.createFavoriteModel(book)).subscribe(res => {
       //console.log('res',res);
       this.loaderService.hide();

      this.snotifyService.success('Başarılı', 'Favoriledin', {
        timeout: 2000,
        showProgressBar: true,
        closeOnClick: false,
        pauseOnHover: true
      });

     });
  }


  createFavoriteModel(book){

    let favorite: Favorite = new Favorite();
    favorite.bookId = book.bookId;
    favorite.authorId = book.authorId;
    favorite.authorName = book.authorName;
    favorite.authorSurname = book.authorSurname;
    favorite.bookName = book.bookName;
    favorite.categoryId = book.categoryId;
    favorite.categoryName = book.categoryName;
    favorite.publisherId = book.publisherId;
    favorite.publisherName = book.publisherName;
    favorite.signUrl = book.signUrl;
    favorite.token = localStorage.getItem('token');
    favorite.userId = JSON.parse(localStorage.getItem('user'))["id"];
    return favorite;
  }

}
