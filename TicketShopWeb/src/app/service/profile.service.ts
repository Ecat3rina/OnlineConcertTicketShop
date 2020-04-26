import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  private displayName: string;

  constructor() { }

  public setDisplayName(dislayName: string): void {

  }

  public getDisplayName(): string {
    return this.displayName;
  }
}
