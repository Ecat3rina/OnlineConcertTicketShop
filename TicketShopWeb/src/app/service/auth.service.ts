import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { AuthResponseModel } from '../model/auth-response.model';
import { AuthRequestModel } from '../model/auth-request.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  ApiBaseUrl: string = environment.apiBaseUrl;
  UserTokenKey = "__TOKEN__";
  constructor(private http: HttpClient) { }

  public authenticateUser(request: AuthRequestModel): Observable<AuthResponseModel> {
    return this.http.post<AuthResponseModel>(this.ApiBaseUrl + 'auth', request);
  }

  public isUserAuthenticated(): boolean {
    var token = localStorage.getItem(this.UserTokenKey);
    if (token != null) {
      return true;
    }
    return false;
  }

  public setAuthToken(token: string): void {
    localStorage.setItem(this.UserTokenKey, token);
  }

  public getAuthToken(): string {
    return localStorage.getItem(this.UserTokenKey);
  }


}
