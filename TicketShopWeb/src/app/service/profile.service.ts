import { Injectable } from '@angular/core';
import { UpdateProfileRequestModel } from '../model/updateprofile-request';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  private displayNameKey = "__DISPLAY_NAME__"
  private displayName: string;

  constructor(private _http: HttpClient) { }

  public setDisplayName(displayName: string): void {
    localStorage.setItem(this.displayNameKey, displayName);
  }

  public getDisplayName(): string {
    return localStorage.getItem(this.displayNameKey);
  }

  public updateDisplayName(request: UpdateProfileRequestModel) : Observable<any> {
    return this._http.put(environment.apiBaseUrl + 'profile', request);
  }
}
