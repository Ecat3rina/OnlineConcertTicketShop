import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ConcertDescriptionResponseModel } from './../../model/concert-description-response.model';
import { WishlistService } from '../../service/wishlist.service';
import { WishlistRequestModel } from '../../model/wishlist.request.model';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'event-card',
  templateUrl: './event-card.component.html',
  styleUrls: ['./event-card.component.css']
})
export class EventCardComponent implements OnInit {

  @Input()
  event: ConcertDescriptionResponseModel;

  @Input()
  enableFavorite : boolean;
  
  @Input('enableDelete')
  enableDelete:boolean;

  @Output() 
  concertRemovedFromFavorite : EventEmitter<number>;



  constructor(private _wishlistService: WishlistService,
    private _snackBar: MatSnackBar) {
      this.enableFavorite = true;
      this.enableDelete = true;
      this.concertRemovedFromFavorite = new EventEmitter<number>();
     }

  onAddToFavoritesClick() {
    let request = new WishlistRequestModel();
    request.concertId = this.event.id;

    this._wishlistService.addConcertToWishlist(request)
      .subscribe(x => {
        this._snackBar.open(`${this.event.name} successfuly added to my wishlist`,'OK',{
          duration : 3000
        });
      }, err => {
        this._snackBar.open(`Cannot add ${this.event.name} to my wishlist`,'OK',{
          duration : 3000
        });
      });
  }

  onDeleteFromFavoritesClick() {
    let request = new WishlistRequestModel();
    request.concertId = this.event.id;

    this._wishlistService.deleteConcertFromWishlist(request)
      .subscribe(x => {
        this._snackBar.open(`${this.event.name} has been  removed from my wishlist`,'OK',{
          duration : 3000
        });
        this.concertRemovedFromFavorite.emit(this.event.id);
      }, err => {
        this._snackBar.open(`Cannot remove ${this.event.name} from wishlist`,'OK',{
          duration : 3000
        });
      });
    }
  ngOnInit(): void {
  }

}
