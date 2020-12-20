import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class NavigationComponent implements OnInit {

  constructor() {
   
   }
   isAdmin:any;
  ngOnInit() {
    var user = JSON.parse(localStorage.getItem("currentuser"));
    console.log(user);
    this.isAdmin = (user.username == 'admin');
  }

}
