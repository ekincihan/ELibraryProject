import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {
  @Input("pageName") pageName: string
  constructor() { }

  ngOnInit() {
  }

}
