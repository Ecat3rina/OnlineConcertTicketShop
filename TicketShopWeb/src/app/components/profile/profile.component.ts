import { Component, OnInit } from '@angular/core';
import { ProfileService } from './../../service/profile.service';
import { AuthService } from '../../service/auth.service';
import { ConcertDescriptionResponseModel } from '../../model/concert-description-response.model';
import { WishlistService } from '../../service/wishlist.service';
import { ConcertService } from '../../service/concert.service';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { UpdateProfileRequestModel } from '../../model/updateprofile-request';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  username: string = "";
  displayAdmin: boolean = false;
  wishlistitems: ConcertDescriptionResponseModel[];
  buttonEditClicked: boolean;
  updateProfileRequest: UpdateProfileRequestModel;
  constructor(private profileService: ProfileService, private authService: AuthService,
    private concertService: ConcertService,private _snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.buttonEditClicked = false;
    this.username = this.profileService.getDisplayName();
    this.displayAdmin = this.authService.getUserRoles().findIndex(x => x == 'Admin') > -1;
    this.updateProfileRequest = new UpdateProfileRequestModel(this.username);
    this.concertService.getMyWishlist()
      .subscribe(items => {
        this.wishlistitems = items;
      })
  }
  public onEditNameClick(): void {
    this.buttonEditClicked = true;
  }
  public onSubmitClick(): void {
    this.profileService.updateDisplayName(this.updateProfileRequest)
      .subscribe(x => {
        this._snackBar.open(`Profile name has been changed`,'OK',{
          duration : 3000
        });
        this.profileService.setDisplayName(this.updateProfileRequest.displayName);
        this.buttonEditClicked = false;
        this.username = this.profileService.getDisplayName();
      }, err => {
        this._snackBar.open(`Cannot change profile name`,'OK',{
          duration : 3000
        });
      });
    }
}
