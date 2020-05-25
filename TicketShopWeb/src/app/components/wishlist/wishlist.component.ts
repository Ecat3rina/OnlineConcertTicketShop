import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { WishlistService } from '../../service/wishlist.service';
import { ConcertDescriptionResponseModel } from '../../model/concert-description-response.model';
import { ConcertService } from '../../service/concert.service';
import { NumberInput } from '@angular/cdk/coercion';


@Component({
  selector: 'wishlist',
  templateUrl: './wishlist.component.html',
  styleUrls: ['./wishlist.component.css']
})
export class WishlistComponent implements OnInit {

  wishlistitems: ConcertDescriptionResponseModel[];

  constructor(private wishlistService: WishlistService, private concertService: ConcertService) { }

  ngOnInit(): void {
    this.concertService.getMyWishlist()
      .subscribe(items => {
        this.wishlistitems = items;
      })

  }

  public onItemRemovedFromFavorites(id: number): void {
    var idx = this.wishlistitems.findIndex(x => x.id == id);
    if (idx > -1) {
       this.wishlistitems.splice(idx, 1);
    }
  }

}
