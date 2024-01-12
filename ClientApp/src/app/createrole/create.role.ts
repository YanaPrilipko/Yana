import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-create.role',
  templateUrl: './create.role.html'
})

export class CreateRoleComponent {
  constructor(private http: HttpClient,private route: ActivatedRoute, private router: Router) { }
  role: any = {
    name: ""
  };
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }

  public insert(role: any): Observable<any> {
    return this.http.post('role/insert', this.role, { observe: 'response' });
  }

  public create() {
    this.insert(this.role).subscribe(response => {
      alert("Role updated");
      this.router.navigate(['./listrole']);
    });
  }
}
