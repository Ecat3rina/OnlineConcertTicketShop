import { HttpInterceptor, HttpEvent, HttpHandler, HttpResponse, HttpErrorResponse, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';
import { throwError } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
    providedIn: 'root'
})
export class JwtInterceptor implements HttpInterceptor {
    constructor(private router: Router,
        private snackBar: MatSnackBar) {

    }

    intercept(req: HttpRequest<any>,
        next: HttpHandler): import("rxjs").Observable<HttpEvent<any>> {
        return next.handle(req).pipe(
            catchError((error: HttpErrorResponse) => {
                if (error.status == 401) {
                    this.snackBar.open('You are not authenticated.Please login', 'OK', {
                        duration: 3000
                    });
                    this.router.navigate(['/login']);
                }
                return throwError(error);
            })
        )
    }

}