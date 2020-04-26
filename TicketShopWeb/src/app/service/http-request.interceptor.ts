import { HttpInterceptor } from '@angular/common/http';
import { AuthService } from './auth.service';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
  })
export class HttpRequestInterceptor implements HttpInterceptor{
    constructor(private authService : AuthService){
        
    }
    
    intercept(req: import("@angular/common/http").HttpRequest<any>, next: import("@angular/common/http").HttpHandler): import("rxjs").Observable<import("@angular/common/http").HttpEvent<any>> {
        if(req.url.indexOf('api/auth') > -1){
            //add bearer token
            req = req.clone({
                setHeaders: {
                  Authorization: `Bearer ${this.authService.getAuthToken()}`
                }
              });
        }
        return next.handle(req);
    }
}