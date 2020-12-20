import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PythonapiService {

  constructor(private httpClient: HttpClient) { }
  public baseUrl = "http://localhost:5000";
  public post(payload: any): Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set("Accept", "application/json");
    headers.set("Allow-Origin", "*");
    const options = { headers: headers };
    return this.httpClient.post(this.baseUrl, payload, options).pipe(
    );
  }
}
