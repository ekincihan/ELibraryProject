import { Component, OnInit } from '@angular/core';
import { HeaderService } from './shared/headerService';
import { Category } from '../models/Category';
import { Publisher } from '../models/Publisher';
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private headerService:HeaderService) { }
  categories :Category[];
  publishers:Publisher[];
  ngOnInit() {
    this.headerService.getAll('Category/List').subscribe((res) =>{
      this.categories=res['value'];
      console.log('kategor',res['value'])
      
      this.headerService.getAll('Publisher/List').subscribe((rest)=>{
        this.publishers=rest['value'];
        console.log('publish',rest['value'])
      })
    
      }
    })
      
    
  }

}
