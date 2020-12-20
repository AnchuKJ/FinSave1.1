import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreditreportComponent } from 'src/app/creditreport/creditreport.component';
import { LoginComponent } from 'src/app/login/login.component';
import { GoaldetailsComponent } from 'src/app/goaldetails/goaldetails.component';
import { MygoalboardComponent } from 'src/app/mygoalboard/mygoalboard.component';
import { AdmindashboardComponent } from 'src/app/admindashboard/admindashboard.component';
import { NewcampaignComponent } from 'src/app/newcampaign/newcampaign.component';
import { NewtransactionComponent } from 'src/app/newtransaction/newtransaction.component';
import { GoallistComponent } from 'src/app/goallist/goallist.component';


const routes: Routes = [
  { path:'', component:CreditreportComponent  },
  { path:'dashboard', component:CreditreportComponent  },
  { path:'login', component:LoginComponent },
  { path:'goaldetails', component:GoaldetailsComponent },
  { path:'mygoalboard', component:MygoalboardComponent },
  {path:'admindashboard', component:AdmindashboardComponent},
  {path:'newcampaign', component:NewcampaignComponent},
  {path:'newtransaction', component:NewtransactionComponent},
  {path:'goallist', component:GoallistComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
