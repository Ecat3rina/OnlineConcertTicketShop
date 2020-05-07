import { Component, OnInit } from '@angular/core';
import { ProfileService } from 'src/app/service/profile.service';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/service/auth.service';

@Component({
  selector: 'home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  username : string = "iraileanu";

  constructor(private profileService : ProfileService,
    private router : Router,
    private authService : AuthService) { }

  ngOnInit(): void {
    this.username = this.profileService.getDisplayName();
  }

  public onLogoutClick() : void{
    this.authService.logOut();
    this.router.navigate(['/login']);
  }

}
