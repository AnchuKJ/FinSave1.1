import { Component, OnInit } from '@angular/core';
import { finsaveService } from 'src/app/finsave.service';

@Component({
  selector: 'app-mygoalboard',
  templateUrl: './mygoalboard.component.html',
  styleUrls: ['./mygoalboard.component.scss']
})
export class MygoalboardComponent implements OnInit {

  constructor(public finsaveService:finsaveService) { 

    this.goalselected = 1;
  }
  colorScheme = {
    domain: ['#ffffff', '#90EE90', '#f49b16', '#FF7F50', '#90EE90', '#9370DB']
  };
  progressScheme = {
    domain: ['#6F0CF0', '#D8F038', '#f49b16', '#FF7F50', '#90EE90', '#9370DB']
  };

  goalselected:any;
  mygoallist:any;
  reportdata : any;
  goal:any;
  progresschart:any;

  ngOnInit(): void {  
    var currentuser = JSON.parse(localStorage.getItem("currentuser"));
    console.log(currentuser);
    this.finsaveService.GetActiveGoals(currentuser.userId).subscribe(res=>{
      if(res.length >0){
        this.mygoallist = res;
        console.log(res);
        this.mygoallist.forEach(function (value) {
          value.progresschart  = [{
            "series": [
              {
                "name": "Your Contribution",
                "value": value.contributionamount
              },
              {
                "name": "Target Fund",
                "value": value.amount
              }
            ]
          }];     
        });
       
        console.log(this.mygoallist);
        this.goalselected = "1";
        this.ongoalselectionchange(); 
      }
    });
   /* this.mygoallist = [{title:"first goal",desc:"sdsds dsd sd", amount:"1000", expires:"12/1/2021", raisedfund:"600", memberscount:"40", createdby:"User1", createdon:"01/01/2020", progresschart: [{
      "series": [
        {
          "name": "Your Contribution",
          "value": 200
        },
        {
          "name": "Raised Fund",
          "value": 600
        }
      ]
    }]},
    {title:"second goal", desc:"sdsds dsd sd",amount:"6000", expires:"12/1/2021", raisedfund:"200",memberscount:"40", createdby:"User1", createdon:"01/01/2020",progresschart: [{
      "series": [
        {
          "name": "Your Contribution",
          "value": 80
        },
        {
          "name": "Raised Fund",
          "value": 200
        }
      ]
    }]},
    {title:"second goal", desc:"sdsds dsd sd",amount:"6000", expires:"12/1/2021", raisedfund:"200",memberscount:"40", createdby:"User1", createdon:"01/01/2020", progresschart: [{
      "series": [
        {
          "name": "Your Contribution",
          "value": 60
        },
        {
          "name": "Raised Fund",
          "value": 600
        }
      ]
    }]},
    {title:"third goal", desc:"sdsds dsd sd",amount:"6000", expires:"12/1/2021", raisedfund:"200",memberscount:"40", createdby:"User1", createdon:"01/01/2020", progresschart: [{
      "series": [
        {
          "name": "Your Contribution",
          "value": 200
        },
        {
          "name": "Raised Fund",
          "value": 1000
        }
      ]
    }]}];  */
  }

  ongoalselectionchange():void{
    this.goal = this.mygoallist[this.goalselected-1];
    this.reportdata = [
      { name: "Target Amount", value: this.goal.amount },
      { name: "Raised Fund", value: this.goal.collectedamount },
      { name: "Your Contribution", value: this.goal.contributionamount }      
    ];
    
  }

}
