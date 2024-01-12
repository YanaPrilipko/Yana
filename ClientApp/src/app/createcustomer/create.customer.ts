import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-create.customer',
  templateUrl: './create.customer.html'
})
export class CreateCustomerComponent {

  constructor(private http: HttpClient,private route: ActivatedRoute, private router: Router) { }
  customer: any = {
    quantity: 0,
    price: 0,
    description: ""
  };
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }

  public insert(customer: any): Observable<any> {
    return this.http.post('customer/insert', customer, { observe: 'response' });
  }

  public create() {
    this.insert(this.customer).subscribe(response => {
      alert("Customer created");
      this.router.navigate(['/listcustomer']);
    });
  }
}
