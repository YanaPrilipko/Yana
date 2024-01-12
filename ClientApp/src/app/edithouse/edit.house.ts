import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit.house',
  templateUrl: './edit.house.html'
})

export class EditHouseComponent{
  baseUrl: string;
  house: any;
  houseId: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute, private router: Router) {
    this.baseUrl = baseUrl;
    this.houseId = this.route.snapshot.params.houseId;
    this.http.get<House>(this.baseUrl + 'house/get/' + this.houseId).subscribe(result => {
      this.house = result;
      console.log(this.house);
    },
      error => console.error(error));
  }

  public edit(house: any): Observable<any> {
    return this.http.post('house/edit', this.house, { observe: 'response' });
  }

  public update() {
    this.edit(this.house).subscribe(response => {
      alert("House updated");
      this.router.navigate(['/listhouse']);
    });
  }

}

interface House {
  id: number;
  quantity: string;
  price: number;
  description: number;
}
