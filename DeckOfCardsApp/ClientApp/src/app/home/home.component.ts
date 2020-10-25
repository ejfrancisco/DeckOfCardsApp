import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { card } from '../view-model/card';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  public deckCard$: Observable<card[]>;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  ngOnInit(): void {
    const div = document.getElementById("deck");
    this.shuffleDeck(div, "true");
  }

  public async shuffleDeck(divDeck, reset) {

    const cards = divDeck.querySelectorAll('.card');

    for (let i = cards.length - 1; i >= 0; i--) {
      cards[i].style.left = "13px";
      await this.delay(20);
    }

    this.deckCard$ = this.http.get<card[]>(this.baseUrl + 'DeckOfCards/shuffledeck?reset=' + reset);
  }


  private delay(ms: number) {
    return new Promise(res => setTimeout(res, ms));
  }

}
