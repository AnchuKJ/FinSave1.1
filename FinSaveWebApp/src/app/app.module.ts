import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavigationComponent } from './navigation/navigation.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlexLayoutModule } from "@angular/flex-layout";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatIconModule } from "@angular/material/icon";
import { MatTableModule } from '@angular/material/table';
import { CreditreportComponent } from './creditreport/creditreport.component';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { NgxGaugeModule } from 'ngx-gauge';
import { MatDialogModule } from '@angular/material/dialog';
import { MatTabsModule } from '@angular/material/tabs';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatMomentDateModule } from '@angular/material-moment-adapter';
import {MatRadioModule} from '@angular/material/radio';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { NgxCurrencyModule } from "ngx-currency";
import { LoginComponent } from './login/login.component';
import { GoaldetailsComponent } from './goaldetails/goaldetails.component';
import { JoingoaldialogComponent } from './goaldetails/joingoaldialog/joingoaldialog.component';
import { MygoalboardComponent } from './mygoalboard/mygoalboard.component';
import { AdmindashboardComponent } from './admindashboard/admindashboard.component';
import { NewcampaignComponent } from './newcampaign/newcampaign.component';
import { NewtransactionComponent } from './newtransaction/newtransaction.component';
import { GoallistComponent } from './goallist/goallist.component';
@NgModule({
  declarations: [
    AppComponent,    
    NavigationComponent,    
    CreditreportComponent,
    LoginComponent,
    GoaldetailsComponent,
    JoingoaldialogComponent,
    MygoalboardComponent,
    AdmindashboardComponent,
    NewcampaignComponent,
    NewtransactionComponent,
    GoallistComponent
  ],
  imports: [
    MatMomentDateModule,
    FormsModule,    
    ReactiveFormsModule ,
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    FlexLayoutModule,
    MatToolbarModule,
    MatIconModule,
    NgxCurrencyModule,
    MatTabsModule,
    MatTableModule,
    MatInputModule,
    MatDatepickerModule,
    MatDialogModule,
    NgxChartsModule,
    NgxGaugeModule,
    MatRadioModule,
    MatCheckboxModule    
  ],
  entryComponents:[],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
