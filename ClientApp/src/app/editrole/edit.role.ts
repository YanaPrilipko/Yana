import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit.role',
  templateUrl: './edit.role.html'
})

export class EditRoleComponent {
  baseUrl: string;
  role: any;
  roleId: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute,
    private router: Router) {
    this.baseUrl = baseUrl;
    this.roleId = this.route.snapshot.params.roleId;
    this.http.get<Role>(this.baseUrl + 'role/get/' + this.roleId).subscribe(result => {
      this.role = result;
      console.log(this.role);
    },
      error => console.error(error));
  }

  public edit(role: any): Observable<any> {
    return this.http.post('role/edit', this.role, { observe: 'response' });
  }

  public update() {
    this.edit(this.role).subscribe(response => {
      alert("Role updated");
      this.router.navigate(['./listrole']);
    });
  }

}


interface Role {
  id: number;
  name: string;
}
