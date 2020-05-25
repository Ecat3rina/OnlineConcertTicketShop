import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthRequestModel } from 'src/app/model/auth-request.model';
import { AuthService } from 'src/app/service/auth.service';
import { ProfileService } from 'src/app/service/profile.service';
import { AuthResponseModel } from 'src/app/model/auth-response.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { config } from 'rxjs';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private router: Router,
    private authService: AuthService,
    private profileService: ProfileService,
    private snackBar: MatSnackBar) { }

  public authModel: AuthRequestModel;

  ngOnInit(): void {
    this.authModel = new AuthRequestModel();
  }

  public onLoginButtonClick(): void {
    this.authService.authenticateUser(this.authModel)
      .subscribe(response => {
        let authResponseModel = response as AuthResponseModel;
        this.profileService.setDisplayName(authResponseModel.displayName);
        this.authService.setAuthToken(authResponseModel.token);
        this.authService.setUserRoles(authResponseModel.roles);
        this.router.navigate(['/home']);
      }, error => {
        this.authModel = new AuthRequestModel();
        this.snackBar.open('Authentication error','OK',{
          duration : 3000
        });
      });
  }

}
