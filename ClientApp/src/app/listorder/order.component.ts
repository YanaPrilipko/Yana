import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-listorder',
  templateUrl: './order.component.html'
})
export class ListOrderComponent {
  public forecasts: Order[] = [];

  http: HttpClient;
  router: any;
  baseUrl: string;


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, router: Router) {
    this.http = http;
    this.router = router;
    this.baseUrl = baseUrl;
    this.readOrder();
  }

  public readOrder() {
    this.http.get<Order[]>(this.baseUrl + 'order/all').subscribe(result => {
      this.forecasts = result;
    },
      error => console.error(error));
  }

  public deleteOrder(id: number) {
    this.http.post(this.baseUrl + 'order/delete/' + id, { observe: 'response' }).subscribe(result => {
      this.readOrder();
    }, error => console.error(error));
  }
}


interface Order {
  id: number;
  dataOfArrival: Date;
  dataOfDeparture: Date;
  house: House;
  customer: Customer;
  description: string;
}

interface House {
  id: number;
  quantity: number;
  price: number;
  description: string;
}
interface Customer {
  id: number;
  lastName: string;
  telefon: string;
}
