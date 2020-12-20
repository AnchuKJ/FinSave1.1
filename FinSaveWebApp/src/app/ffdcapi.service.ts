import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FfdcapiService {

  constructor(private httpClient: HttpClient) { }
  public baseUrl = "https://api.fusionfabric.cloud/login/v1/sandbox/";
  public post(url:any, payload: any): Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set("Accept", "application/json");
    headers = headers.set("client_id", "94971381-fd8a-4183-8311-decebc7bbf36");
    headers = headers.set("client_secret", "087accda-8f26-4895-add3-5018db4831d7");
    headers = headers.set("grant_type", "client_credentials");
    headers.set("Allow-Origin", "*");
    const options = { headers: headers };
    return this.httpClient.post(this.baseUrl+url, payload, options).pipe(
    );
  }

  generateToken(payload:any):Observable<any>{
    return this.post("oidc/token", payload);
  }

  accountsInfo(payload:any):Observable<any>{
    return this.post("oidc/accounts", payload);
  }

  fundtransfer(payload:any):Observable<any>{
    return this.post("oidc/fundtransfer", payload);
  }
  
}
