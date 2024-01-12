import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-house.component',
  templateUrl: './house.component.html'
})
export class ListhouseComponent {
  public forecasts: House[] = [];

  http: HttpClient;
  router: any;
  baseUrl: string;


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, router: Router) {
    this.http = http;
    this.router = router;
    this.baseUrl = baseUrl;
    this.readHouse();
  }

  public readHouse() {
    this.http.get<House[]>(this.baseUrl + 'house/all').subscribe(result => {
      this.forecasts = result;
    },
      error => console.error(error));
  }

  public deleteHouse(id: number) {
    this.http.post(this.baseUrl + 'house/delete/' + id, { observe: 'response' }).subscribe(result => {
      this.readHouse();
    }, error => console.error(error));
  }
}


interface House {
  id: number;
  quantity: string;
  price: number;
  description: number;
}


