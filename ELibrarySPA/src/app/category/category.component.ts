import { Component, OnInit } from '@angular/core';
import { CategoryService } from './shared/category-service';
import { Category } from '../models/Category';
import { Publisher } from '../models/Publisher';
import { Author } from '../models/Author';

@Component({
  selector: 'category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  constructor(private categoryService : CategoryService) { }

  categories : Category[]=[];
  publishers : Publisher[]=[];
  authors : Author[]=[];
  headerCategories : Category[]=[];

  ngOnInit() {
 
      
      this.categoryService.getAll("Category/List").subscribe(res => {
        this.headerCategories = res["value"];
        console.log('kategoriler:')
      })
  
      this.categoryService.getAll("Publisher/List").subscribe(rest => {
        this.publishers = rest["value"];
        console.log('Publisher:')
      });
      
      this.categoryService.getAll("Author/List").subscribe(rest => {
        this.authors = rest["value"];
        console.log('this.authors')
      });
      this.categoryService.getAll('Category/CategoryBook').subscribe((res:Category[])=>{
        this.categories=res;
        console.log('CategoryBook:',this.categories)
      });
  }

}
