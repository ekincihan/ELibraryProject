import { SnotifyService } from 'ng-snotify';
import { Component, OnInit } from '@angular/core';
import { CategoryService } from './shared/category-service';
import { Category } from '../models/Category';
import { Publisher } from '../models/Publisher';
import { Author } from '../models/Author';
import { Favorite } from 'src/app/book-detail/shared/favorite';
import { BookRate } from 'src/app/mixed-books/shared/book-rate';
import _ from 'underscore';
import { BookRateService } from '../service/book-rate.service';
@Component({
  selector: 'category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  user:any;
  constructor(private categoryService : CategoryService,
      private snotifyService: SnotifyService) {

    this.filterCategory = {
      publisherId: '00000000-0000-0000-0000-000000000000',
      categoryIds: [],
      authorIds: []
    }
  }

  categories : Category[]=[];
  publishers : Publisher[]=[];
  authors : Author[]=[];
  headerCategories : Category[]=[];
  max = 5;

  filterCategory: any;
  ngOnInit() {
      this.categoryService.getAll("Category/List").subscribe(res => {
        this.headerCategories = res["value"];
      })

      this.categoryService.getAll("Publisher/List").subscribe(rest => {
        this.publishers = rest["value"];
      });

      this.categoryService.getAll("Author/List").subscribe(rest => {
        this.authors = rest["value"];
      });
      this.categoryService.getAll('Category/CategoryBook').subscribe((res:Category[])=>{
        this.categories=res;
        this.categories.forEach(cat => {
          let bookrateService = new BookRateService();
          bookrateService.bookList  = cat['books'];
          bookrateService.service = this.categoryService;
          cat['books'] = bookrateService.getBooks();
        });

      });
  }


  favBook(book){
    this.categoryService.post("/User/Favorite",this.createFavoriteModel(book)).subscribe(res => {
       //console.log('res',res);
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

  confirmSelection(fav:Favorite) {
    let bookRate = this.newBookRate(fav);
    this.categoryService.post('User/Rate', bookRate).subscribe((res) => {
     // //console.log('rated book', res);

    })
  }



  newBookRate(fav:Favorite) {
    let rateBookModel: BookRate = new BookRate();
    const user = JSON.parse(localStorage.getItem('user'));
    rateBookModel.bookId = fav["bookId"];
    rateBookModel.token = localStorage.getItem('token');
    rateBookModel.userId = user.id;
    rateBookModel.id = fav["id"];
    rateBookModel.rate = fav["rate"];
    return rateBookModel;
  }

  publisherChange(publisherId){
    this.filterCategory.publisherId = publisherId;
  }

  authorCheck(author){
    if(author["selected"]){
      let isContain = (_.contains(this.filterCategory.authorIds,author["id"]));
      if(!isContain)
        this.filterCategory.authorIds.push(author["id"])
    }else if(!author["selected"]){
      let isContain = (_.contains(this.filterCategory.authorIds,author["id"]));
      if(isContain){
        this.filterCategory.authorIds = _.reject(this.filterCategory.authorIds, (id) =>{ return id == author["id"]; });
      }
    }
  }

  categoryCheck(category){
    if(category["selected"]){
      let isContain = (_.contains(this.filterCategory.categoryIds,category["id"]));
      if(!isContain)
        this.filterCategory.categoryIds.push(category["id"])
    }else if(!category["selected"]){
      let isContain = (_.contains(this.filterCategory.categoryIds,category["id"]));
      if(isContain){
        this.filterCategory.categoryIds = _.reject(this.filterCategory.categoryIds, (id) =>{ return id == category["id"]; });
      }
    }
  }

  filter(){
    //console.log('this.filterCategory',this.filterCategory);
    // TODO: Servis entegrasyonu buraya gelecek,
    // seçili yazar,kategori ve yayınevini alıyoruz.servis yine kategori tipinde dönmeli

    this.categoryService.post('CategoryTagAssignment/Filter',this.filterCategory).subscribe((res:Category[]) =>{
      //console.log('res',res);
      this.categories=res;
    })

  }


}
