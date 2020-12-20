import { Injectable } from '@angular/core';
import { ApiService } from 'src/app/api.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class finsaveService {

  constructor(private apiService:ApiService) { }
 
  public LoginUser(payload:any) :Observable<any> {
    return this.apiService.post('LoginUser',payload);
  }

  public GetAllCampaigns(payload:any):Observable<any> {
    return this.apiService.get('GetAllCampaigns/'+payload);
  }

  public JoinCampaign(payload:any):Observable<any> {
    return this.apiService.post('JoinCampaign',payload);
  }

  public GetActiveGoals(payload:any):Observable<any> {
    return this.apiService.get('GetActiveGoals/'+payload);
  }

  public GetDashboardContent():Observable<any> {
    return this.apiService.post('Dashboard','');
  }

  public CreateCampaign(payload:any):Observable<any>{
    return this.apiService.post('CreateCampaign',payload);
  }

  public PerformTransaction(payload:any):Observable<any>{
    return this.apiService.post('PerformTransaction',payload);
  }
  public GetUserAccounts(payload:any):Observable<any> {
    return this.apiService.get('GetUserAccounts/'+payload);
  }

  public AdminDashboard():Observable<any> {
    return this.apiService.get('AdminDashboard');
  }
  
  
}
