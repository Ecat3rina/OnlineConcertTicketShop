import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  private displayNameKey = "__DISPLAY_NAME__"
  private displayName: string;

  constructor() { }

  public setDisplayName(displayName: string): void {
    localStorage.setItem(this.displayNameKey, displayName);
  }

  public getDisplayName(): string {
    return localStorage.getItem(this.displayNameKey);
  }
}
