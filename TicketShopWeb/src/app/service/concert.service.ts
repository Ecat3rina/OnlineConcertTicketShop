import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ConcertDescriptionResponseModel } from '../model/concert-description-response.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class ConcertService {

    constructor(private _http : HttpClient){

    }

    public getTrendingConcerts() : Observable<ConcertDescriptionResponseModel[]>{
        return this._http.get<ConcertDescriptionResponseModel[]>(environment.apiBaseUrl + 'concerts/trending');
    }
    public getMyWishlist() : Observable<ConcertDescriptionResponseModel[]>{
        return this._http.get<ConcertDescriptionResponseModel[]>(environment.apiBaseUrl + 'concerts/wishlist');
    }

}