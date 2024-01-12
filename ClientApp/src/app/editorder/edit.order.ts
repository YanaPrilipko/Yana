import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-editorder',
  templateUrl: './edit.order.html'
})

export class EditOrderComponent {
  baseUrl: string;
  order: any;
  orderId: string;
  houseList: any[] = [];
  customerList: any[] = [];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string,
    private route: ActivatedRoute, private router: Router) {
    this.baseUrl = baseUrl;
    this.orderId = this.route.snapshot.params.orderId;

    this.http.get<Order>(this.baseUrl + 'order/get/' + this.orderId).subscribe(result => {
      this.order = result;
    }, error => {
      console.error(error);
    });

    this.http.get<any[]>(this.baseUrl + 'customer/all').subscribe(result => {
      this.customerList = result;
    }, error => {
      console.error(error);
    });
    
    this.http.get<any[]>('/house/all').subscribe(result => {
      this.houseList = result;
    }, error => {
      console.error(error);
    });
  }

  public edit(order: any): Observable<any> {
    return this.http.post('order/edit', this.order, { observe: 'response' });
  }

  public update() {
    this.edit(this.order).subscribe(response => {
      alert("Order updated");
      this.router.navigate(['./listorder']);
    });
  }

}

interface Order {
  id: number;
  dataOfArrival: Date;
  dataOfDeparture: Date;
  houseId: number;
  customerId: number;
  description: string;
}
