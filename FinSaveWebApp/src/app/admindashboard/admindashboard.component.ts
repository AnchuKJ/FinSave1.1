import { Component, OnInit } from '@angular/core';
import { finsaveService } from 'src/app/finsave.service';

@Component({
  selector: 'app-admindashboard',
  templateUrl: './admindashboard.component.html',
  styleUrls: ['./admindashboard.component.scss']
})
export class AdmindashboardComponent implements OnInit {

  admindata=[];
  constructor(public finsaveService:finsaveService) { }
  /*saleData = [
    {
      "name": "Germany",
      "series": [
        {
          "name": "2010",
          "value": 40632,
          "extra": {
            "code": "de"
          }
        },
        {
          "name": "2000",
          "value": 36953,
          "extra": {
            "code": "de"
          }
        },
        {
          "name": "1990",
          "value": 31476,
          "extra": {
            "code": "de"
          }
        }
      ]
    },
    {
      "name": "United States",
      "series": [
        {
          "name": "2010",
          "value": 0,
          "extra": {
            "code": "us"
          }
        },
        {
          "name": "2000",
          "value": 45986,
          "extra": {
            "code": "us"
          }
        },
        {
          "name": "1990",
          "value": 37060,
          "extra": {
            "code": "us"
          }
        }
      ]
    },
    {
      "name": "France",
      "series": [
        {
          "name": "2010",
          "value": 36745,
          "extra": {
            "code": "fr"
          }
        },
        {
          "name": "2000",
          "value": 34774,
          "extra": {
            "code": "fr"
          }
        },
        {
          "name": "1990",
          "value": 29476,
          "extra": {
            "code": "fr"
          }
        }
      ]
    },
    {
      "name": "United Kingdom",
      "series": [
        {
          "name": "2010",
          "value": 36240,
          "extra": {
            "code": "uk"
          }
        },
        {
          "name": "2000",
          "value": 32543,
          "extra": {
            "code": "uk"
          }
        },
        {
          "name": "1990",
          "value": 26424,
          "extra": {
            "code": "uk"
          }
        }
      ]
    }
  ];*/
 
  colorScheme =  {
    domain: ['#D507F4', '#9370DB', 'rgb(66,165,246)', '#FF7F50', '#90EE90', '#9370DB']
  };
  
  areachartdata=[
    {
      "name": "Austria",
      "series": [
        {
          "value": 4649,
          "name": "Jul"
        },
        {
          "value": 2472,
          "name": "Aug"
        },
        {
          "value": 4486,
          "name": "Sep"
        },
        {
          "value": 6184,
          "name": "Oct"
        },
        {
          "value": 4912,
          "name": "Nov"
        },
        {
          "value": 600,
          "name": "Dec"
        }
      ]
    },
    {
      "name": "Costa Rica",
      "series": [
        {
          "value": 2590,
          "name": "Jul"
        },
        {
          "value": 6849,
          "name": "Aug"
        },
        {
          "value": 5563,
          "name": "Sep"
        },
        {
          "value": 6603,
          "name": "Oct"
        },
        {
          "value": 4414,
          "name": "Nov"
        },
        {
          "value": 500,
          "name": "Dec"
        }
      ]
    }   
  ];
 
  ngOnInit(): void {
    
    this.finsaveService.AdminDashboard().subscribe(res=>{
      console.log(res);
      this.admindata = res;
    });
  }

}
