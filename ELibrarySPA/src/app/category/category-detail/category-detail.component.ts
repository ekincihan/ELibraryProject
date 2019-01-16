import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../../category/shared/category-service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'category-detail',
  templateUrl: './category-detail.component.html',
  styleUrls: ['./category-detail.component.css']
})
export class CategoryDetailComponent implements OnInit {
  category: any;
  constructor(private categoryService: CategoryService,
    private activatedRoute: ActivatedRoute) { 
    this.activatedRoute.params.subscribe(params => {
      
      this.categoryService.get("/Category/GetOne/" + params["categoryId"]).subscribe(res => {
        this.category = res["value"];
        console.log('this.categories',this.category);

      });
    })
  }

  ngOnInit() {
  }

}
