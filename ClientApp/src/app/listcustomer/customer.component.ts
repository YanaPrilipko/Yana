import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-customer.component',
  templateUrl: './customer.component.html'
})
export class ListCustomerComponent {
  public forecasts: Customer[] = [];

  http: HttpClient;
  router: any;
  baseUrl: string;


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, router: Router) {
    this.http = http;
    this.router = router;
    this.baseUrl = baseUrl;
    this.readCustomer();
  }

  public readCustomer() {
    this.http.get<Customer[]>(this.baseUrl + 'customer/all').subscribe(result => {
      this.forecasts = result;
    },
      error => console.error(error));
  }

  public deleteCustomer(id: number) {
    this.http.post(this.baseUrl + 'customer/delete/' + id, { observe: 'response' }).subscribe(result => {
      this.readCustomer();
    }, error => console.error(error));
  }
}

interface Customer {
  id: number;
  lastName: string;
  telefon: string;
}

