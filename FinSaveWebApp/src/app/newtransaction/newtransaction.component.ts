import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { finsaveService } from 'src/app/finsave.service';

@Component({
  selector: 'app-newtransaction',
  templateUrl: './newtransaction.component.html',
  styleUrls: ['./newtransaction.component.scss']
})
export class NewtransactionComponent implements OnInit {

  constructor(private router: Router,public finsaveService:finsaveService) { }
  selectedAccount:any;
  accounts:any;
  currentUser:any;
  amount:any;
  ngOnInit(): void {
    this.selectedAccount = JSON.parse(localStorage.getItem("selectedAccount"));
    this.currentUser = JSON.parse(localStorage.getItem("currentuser"));
    this.accounts = this.currentUser.accounts;
  }
  onSubmit():void{
    var payload = {
      AccNum:this.selectedAccount.accNum,
      Amount: Number(this.amount)
    };
    this.finsaveService.PerformTransaction(payload).subscribe(res=>{
      this.finsaveService.GetUserAccounts(this.currentUser.userId).subscribe(res=>{
        this.currentUser.accounts = res;
        console.log(this.currentUser);
        localStorage.setItem("currentuser", JSON.stringify(this.currentUser));
        this.router.navigate(['dashboard']);
      });
    });
  }
  onCancel():void{
    this.router.navigate(['dashboard']);
  }
}
