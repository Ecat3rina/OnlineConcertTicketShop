import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs";
import { environment } from '../../environments/environment';
import { WishlistRequestModel } from 'src/app/model/wishlist.request.model';


@Injectable({ providedIn: 'root' })
export class WishlistService {

    constructor(private _http: HttpClient) {

    }

    public addConcertToWishlist(request : WishlistRequestModel): Observable<any> {
        return this._http.post(environment.apiBaseUrl + 'whishlist', request);
    }
    public deleteConcertFromWishlist(request : WishlistRequestModel): Observable<any> {
        return this._http.delete(environment.apiBaseUrl + 'whishlist/'+ request.concertId);
    }
   
}