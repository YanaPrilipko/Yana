import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-role.component',
  templateUrl: './role.component.html'
})
export class ListRoleComponent {
  public forecasts: Role[] = [];
  role: any;
  http: HttpClient;
  router: any;
  baseUrl: string;


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, router: Router) {
    this.http = http;
    this.router = router;
    this.baseUrl = baseUrl;
    this.readRoles();
  }

  public readRoles() {
    this.http.get<Role[]>(this.baseUrl + 'role/all').subscribe(result => {
      this.forecasts = result;
    },
      error => console.error(error));
  }

  public deleteRole(id: number) {
    this.http.post(this.baseUrl + 'role/delete/' + id, { observe: 'response' }).subscribe(result => {
      this.readRoles();
    }, error => console.error(error));
  }
}


interface Role {
  name: string;
  id: number;
}


