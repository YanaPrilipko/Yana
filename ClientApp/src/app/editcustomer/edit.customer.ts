import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit.customer',
  templateUrl: './edit.customer.html'
})

export class EditCustomerComponent {
  baseUrl: string;
  customer: any;
  customerId: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute, private router: Router) {
    this.baseUrl = baseUrl;
    this.customerId = this.route.snapshot.params.customerId;
    this.http.get<Customer>(this.baseUrl + 'customer/get/' + this.customerId).subscribe(result => {
      this.customer = result;
      console.log(this.customer);
    },
      error => console.error(error));
  }

  public edit(customer: any): Observable<any> {
    return this.http.post('customer/edit', this.customer, { observe: 'response' });
  }

  public update() {
    this.edit(this.customer).subscribe(response => {
      alert("Customer updated");
      this.router.navigate(['/listcustomer']);
    });
  }

}

interface Customer {
  id: number;
  lastName: string;
  telefon: string;
}
