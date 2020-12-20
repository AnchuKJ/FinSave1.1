import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { finsaveService } from 'src/app/finsave.service';
import { isNaN } from 'lodash';
import { isNumber } from 'util';
import { Router } from '@angular/router';

@Component({
  selector: 'app-creditreport',
  templateUrl: './creditreport.component.html',
  styleUrls: ['./creditreport.component.scss'],
  encapsulation: ViewEncapsulation.None
})


export class CreditreportComponent implements OnInit {

  constructor( private router: Router, public finsaveService:finsaveService) { }
  goallist:any;
  currentUser:any;
  ngOnInit(): void {  
    this.currentUser =JSON.parse(localStorage.getItem('currentuser'));
  } 

  newtransaction(account:any):void{
    localStorage.setItem("selectedAccount", JSON.stringify(account));
    this.router.navigate(['newtransaction']);
  }
  exploreGoal():void{
    this.router.navigate(['goallist']);
  }
}
