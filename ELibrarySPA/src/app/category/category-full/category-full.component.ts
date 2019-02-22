import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/category/shared/category-service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-category-full',
  templateUrl: './category-full.component.html',
  styleUrls: ['./category-full.component.css']
})
export class CategoryFullComponent implements OnInit {
  categories: any;
  constructor(private categoryService: CategoryService) { 
      this.categoryService.get("/Category/List").subscribe(res => {
        this.categories = res["value"];
        //console.log('this.categories',this.categories);
        
      });
  }

  ngOnInit() {
  }

}
