import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-user',
  templateUrl: './user.html'
})
export class UserComponent {

  constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router) { }

  user: any = {
    name: '',
    password: '',
  };
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }

  public login(user: any): void {
    this.http.post('user/auth', user, { observe: 'response' }).subscribe(response => {
      alert("Login successful");
      this.router.navigate(['/']);

    }, error => {
      alert("Invalid email or password. Please try again.");
      this.user.password = '';
    });
  }

  public authenticate(user: any) {
    this.login(user);
  }
}
