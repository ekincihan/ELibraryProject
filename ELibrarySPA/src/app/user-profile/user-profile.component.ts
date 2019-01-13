import { Component, OnInit } from '@angular/core';
import { User } from '../signin/shared/user';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  user: User;
  constructor() {
      if(localStorage.getItem('user'))
        this.user = JSON.parse(localStorage.getItem('user'));
      
   }

  ngOnInit() {
  }

}
