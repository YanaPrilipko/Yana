import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-create.house',
  templateUrl: './create.house.html'
})
export class CreateCounterComponent  {


  constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router) { }
  house: any = {
    quantity: "",
    price: "",
    description: ""
  };
  public currentCount = 0;



  public incrementCounter() {
    this.currentCount++;
  }

 
  public insert(house: any): Observable<any> {
    return this.http.post('house/insert', house, { observe: 'response' });
  }

  public create() {
    this.insert(this.house).subscribe(response => {
      alert("House created");
      this.router.navigate(['/listhouse']);
    });
  }

 
 
}
