import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { finsaveService } from 'src/app/finsave.service';
import { MatDialog } from '@angular/material/dialog';
import { JoingoaldialogComponent } from 'src/app/goaldetails/joingoaldialog/joingoaldialog.component';

@Component({
  selector: 'app-goallist',
  templateUrl: './goallist.component.html',
  styleUrls: ['./goallist.component.scss']
})
export class GoallistComponent implements OnInit {

  constructor(private router: Router, private finService:finsaveService,public dialog: MatDialog) { }
  goallist:any;

  ngOnInit(): void {
    var currentuser = JSON.parse(localStorage.getItem("currentuser"));

    this.finService.GetAllCampaigns(currentuser.userId).subscribe(res=>{
      this.goallist = res;
      console.log(this.goallist);
    });
  /*  this.goallist = [{title:"first goal",desc:"sdsds dsfsd fdsfdsf dsfd sf dsfdsfds fdsfd sfdsfdsfdsfdsf dsfdsfdsf dsfdsfdsfdsf dsfds fdsfds fdsfdsf  fds f ds f ds f dsf dsfdsfdsfdsfdsfdsfdsf dsf dsf dsfds fdsf ds fds dsd sd", amount:"4000", expires:"12/1/2021", raisedfund:"600", memberscount:"40", createdby:"User1", createdon:"01/01/2020", taxexemption:"Yes"},
    {title:"second goal", desc:"sdsds dsd sd",amount:"6000", expires:"12/1/2021", raisedfund:"200",memberscount:"40", createdby:"User1", createdon:"01/01/2020", taxexemption:"Yes"},
    {title:"third goal",desc:"sdsds dsd sd", amount:"5000", expires:"12/1/2021", raisedfund:"300",memberscount:"40",createdby:"User1", createdon:"01/01/2020", taxexemption:"Yes"}];   
  */ }

  onJoinGoal(goal):void{
    localStorage.setItem('selectedgoal',JSON.stringify(goal));
    const dialogRef = this.dialog.open(JoingoaldialogComponent, {
      width: '1208px',
      height: '850px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result.applysuccess){
        this.router.navigate(['/mygoalboard']);
      }
    });
  }
}
