import { Component, OnInit } from '@angular/core';
import { ConcertService } from 'src/app/service/concert.service';
import { ConcertDescriptionResponseModel } from 'src/app/model/concert-description-response.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'search-events',
  templateUrl: './search-events.component.html',
  styleUrls: ['./search-events.component.css']
})
export class SearchEventsComponent implements OnInit {

  trendingConcerts$ : Observable<ConcertDescriptionResponseModel[]>;
  
  constructor(private concertsService : ConcertService) { }

  ngOnInit(): void {
    this.trendingConcerts$ = this.concertsService.getTrendingConcerts();
  }

}
