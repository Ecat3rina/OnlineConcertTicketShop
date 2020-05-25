import { Component, OnInit } from '@angular/core';
import { ProfileService } from './../../service/profile.service';
import { Router } from '@angular/router';
import { AuthService } from './../../service/auth.service';


@Component({
  selector: 'home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  username : string = "";
  displayAdmin : boolean = false;

  constructor(private profileService : ProfileService,
    private router : Router,
    private authService : AuthService) { }

  ngOnInit(): void {
    this.username = this.profileService.getDisplayName();
    this.displayAdmin = this.authService.getUserRoles().findIndex(x => x == 'Admin') > -1;
  }

  public onLogoutClick() : void{
    this.authService.logOut();
    this.router.navigate(['/login']);
  }
  public onFavoritesClick() : void{
    this.router.navigate(['home/favorites']);
  }
  public onSearchClick() : void{
    this.router.navigate(['home/search']);
  }
  public onProfileClick() : void{
    this.router.navigate(['home/profile']);
  }
  public onAdminClick() : void{
    this.router.navigate(['admin']);
  }

}
