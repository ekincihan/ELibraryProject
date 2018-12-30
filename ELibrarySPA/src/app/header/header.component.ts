import { Component, OnInit } from '@angular/core';
import { HeaderService } from './shared/headerService';
import { Category } from '../models/Category';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private headerService:HeaderService) { }
  categories :Category[];
  ngOnInit() {
    this.headerService.getAll('Category/List').subscribe((res) =>{
      this.categories=res['value'];
      console.log('kategor',res['value'])
    })
      
    
  }

}
