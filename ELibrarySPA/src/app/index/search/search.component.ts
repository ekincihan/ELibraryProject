import { Component, OnInit } from '@angular/core';
import { Subject } from 'node_modules/rxjs';
import { SearchService } from '../shared/search.service';
import { LoaderService } from '../../service/loader.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  results: any;
  searchTerm$ = new Subject<string>();

  constructor(private searchService: SearchService,
    private loaderService:LoaderService   ) {
    this.loaderService.show();
    this.searchService.search(this.searchTerm$)
      .subscribe(results => {
        this.results = results;
        this.loaderService.hide();
      });
  }

  ngOnInit() {
  }

}
