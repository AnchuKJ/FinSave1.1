import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { finsaveService } from 'src/app/finsave.service';

@Component({
  selector: 'app-newcampaign',
  templateUrl: './newcampaign.component.html',
  styleUrls: ['./newcampaign.component.scss']
})
export class NewcampaignComponent implements OnInit {

  constructor(private router: Router,public finsaveService:finsaveService) { }
  dueDate:any;
  campaigntitle:any;
  campaigndesc:any;
  targetamount:any;
  startDate:any;  
  isCampaignJoined:any;
  ngOnInit(): void {
    this.startDate = new Date();
  }

  onSubmit():void{
    var payload = {   
      CampId:0,   
      CampaignName: this.campaigntitle,
      CampaignDesc: this.campaigndesc,
      TargetAmount:Number(this.targetamount),
      AchievedAmount:0,
      ExpiryDt:this.dueDate,
      StartDt:this.startDate, 
      MemCount:0,
      Status:0
  }
    this.isCampaignJoined = this.finsaveService.CreateCampaign(payload).subscribe(res=>{  
      this.router.navigate(['admindashboard']);
    })
  }
  onCancel():void{
    this.router.navigate(['admindashboard']);
  }
}
