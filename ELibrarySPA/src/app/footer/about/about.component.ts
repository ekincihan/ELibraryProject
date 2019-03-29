import { Component, OnInit } from '@angular/core';
import { AboutService } from './shared/about.service';
import { About } from 'src/app/models/About';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent implements OnInit {

  constructor(private AboutService:AboutService) { }

  about:About;
  ngOnInit() {
    this.AboutService.get('About/GetAbout').subscribe((res:About)=>{
      console.log(res)
      this.about=res;
    })
  }

}
