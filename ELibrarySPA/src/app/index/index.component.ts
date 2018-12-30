import { Component, OnInit } from '@angular/core';
import { IndexService } from './shared/index.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {

  constructor(private indexService: IndexService) { }

  ngOnInit() {
    this.indexService.getAll('values').subscribe((res) =>{
      console.log('res',res);
    })
  }

}
