import { Component, NgModule } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-create.order',
  templateUrl: './create.order.html'
})
export class CreateOrderComponent {
  houseList: any[] = [];
  customerList: any[] = [];

  constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router) {
    this.http.get<any>('/house/all').subscribe(result => {
      if (result && result.length > 0) {
        this.houseList = result;
        this.order.HouseId = result[0].id;
      } else {
        this.order.HouseId = 0;
        this.houseList = [];
      }
    }, error => console.error(error));

    this.http.get<any>('/customer/all').subscribe(result => {
      if (result && result.length > 0) {
        this.customerList = result;
        this.order.CustomerId = result[0].id;
      } else {
        this.order.CustomerId = 0;
        this.customerList = [];
      }
    }, error => console.error(error));
  }

  onCountrySelect(selectedHouse: any) {
    this.order.HouseId = selectedHouse;
  }

  onCustomerSelect(selectedСustomer: any) {
    this.order.СustomerId = selectedСustomer;
  }

  order: any = {
    Description: "",
    HouseId: 0,
    CustomerId: 0
  };
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }

  public insert(order: any): Observable<any> {
    return this.http.post('order/insert', order, { observe: 'response' });
  }


  public create() {
    this.insert(this.order).subscribe(response => {
      alert("Order created");
      this.router.navigate(['./listorder']);
    });
  }
}
