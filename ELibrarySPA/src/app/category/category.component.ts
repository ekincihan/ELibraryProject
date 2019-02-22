import { Component, OnInit } from '@angular/core';
import { CategoryService } from './shared/category-service';
import { Category } from '../models/Category';
import { Publisher } from '../models/Publisher';
import { Author } from '../models/Author';
import { Favorite } from 'src/app/book-detail/shared/favorite';
import { BookRate } from 'src/app/mixed-books/shared/book-rate';
import _ from 'underscore';
@Component({
  selector: 'category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  user:any;
  constructor(private categoryService : CategoryService) { 
    if(localStorage.getItem('user'))
      this.user = JSON.parse(localStorage.getItem('user'));

    this.filterCategory = {
      publisherId: '',
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
      });
  }

  confirmSelection(fav:Favorite) {
    let bookRate = this.newBookRate(fav);
    this.categoryService.post('User/Rate', bookRate).subscribe((res) => {
     // //console.log('rated book', res);

    })
  }



  newBookRate(fav:Favorite) {
    let rateBookModel: BookRate = new BookRate();
    rateBookModel.bookId = fav["bookId"];
    rateBookModel.token = localStorage.getItem('token');
    rateBookModel.userId = this.user.id;
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
    
    this.categoryService.post('CategoryTagAssignment/Filter',this.filterCategory).subscribe(res =>{
      //console.log('res',res);
        //this.headerCategories
    }) 
    
  }
  

}
