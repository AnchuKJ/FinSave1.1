import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { finsaveService } from 'src/app/finsave.service';
import { PythonapiService } from 'src/app/pythonapi.service';
@Component({
  selector: 'app-joingoaldialog',
  templateUrl: './joingoaldialog.component.html',
  styleUrls: ['./joingoaldialog.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class JoingoaldialogComponent implements OnInit {
  goal:any;
  roundfrequency:any;
  roundamount:any;
  isGoodPrediction:any;
  predictedAmount:any;
  loadedonly:any;
  duedate:any;
  maxContribution:any;
  constructor(public dialogRef: MatDialogRef<JoingoaldialogComponent>, private finService:finsaveService, private pythonService:PythonapiService) { }

  ngOnInit(): void {
    this.goal = JSON.parse(localStorage.getItem('selectedgoal'));
    console.log(this.goal);
    this.duedate = this.goal.expiryDt;
    this.roundamount = 0;
    this.roundfrequency= "3";
   // this.onSelectChange();
    this.loadedonly = true;
  }

  onapplyclick():void{
    var currentuser = JSON.parse(localStorage.getItem("currentuser"));
    var current_date = new Date();
    var due_date = new Date(this.duedate);
    var totalmonths = (due_date.getFullYear()*12 + due_date.getMonth()) - (current_date.getFullYear()*12 + current_date.getMonth());
    
    var payload={UCID:this.goal.campId, UserID:currentuser.userId, CampaignID:this.goal.campId, RoundFreq:Number(this.roundfrequency), RoundTo:Number(this.roundamount),ContPeriod:Number(totalmonths),MaxContribution:Number(this.maxContribution)};
   
   this.finService.JoinCampaign(payload).subscribe(res=>{
      this.dialogRef.close({applysuccess:true});
    });
  }
  onSelectChange():void{
    var current_date = new Date();
    var due_date = new Date(this.duedate);
    console.log(this.duedate);
    var totalmonths = (due_date.getFullYear()*12 + due_date.getMonth()) - (current_date.getFullYear()*12 + current_date.getMonth());
    //var totalmonths = (startDate.getFullYear() - Date().getFullYear())*12 + (startDate.getMonth() - Date().getMonth())
    var payload = {
      "roundamount":this.roundamount,
      "timeframe":totalmonths
    };
    console.log(payload);
    this.pythonService.post(payload).subscribe(res=>{
      this.predictedAmount = res;
      var maxAmount = Number(this.maxContribution);
      var predicamount = Number(res);

    this.loadedonly = false;
      this.isGoodPrediction = predicamount > maxAmount;
      console.log(this.isGoodPrediction);
      console.log(predicamount);
      console.log(maxAmount);
    });
  }

  onDateChange(event):void{
    this.duedate = event;
    this.onSelectChange();
  }

  onMaxContributionChange():void{

    var maxAmount = Number(this.maxContribution);
    var predicamount = Number(this.predictedAmount);
    this.isGoodPrediction = predicamount > maxAmount;
  }
}
