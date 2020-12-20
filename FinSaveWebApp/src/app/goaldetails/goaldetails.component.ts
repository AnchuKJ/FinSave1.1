import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { JoingoaldialogComponent } from 'src/app/goaldetails/joingoaldialog/joingoaldialog.component';

@Component({
  selector: 'app-goaldetails',
  templateUrl: './goaldetails.component.html',
  styleUrls: ['./goaldetails.component.scss']
})
export class GoaldetailsComponent implements OnInit {
  goal:any;
  showJoinButton:boolean;
  constructor(public dialog: MatDialog) { }

    colorScheme = {
      domain: ['#D507F4', '#EFF829', '#FA8072', '#FF7F50', '#90EE90', '#9370DB']
    };
  
  reportdata:any;
  
  ngOnInit(): void {
    this.showJoinButton = true;
    this.goal = JSON.parse(localStorage.getItem('selectedgoal'));
    this.reportdata = [
      { name: "Target Amount", value:this.goal.targetAmount},
      { name: "Raised Fund", value:this.goal.achievedAmount}
    ];
  }

  onJoinGoal():void{
    const dialogRef = this.dialog.open(JoingoaldialogComponent, {
      width: '1208px',
      height: '800px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result.applysuccess){
        this.goal.memCount++;
        this.showJoinButton = false;
      }
    });
  }
}
