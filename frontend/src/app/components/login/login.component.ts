import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [],
  templateUrl: './login.component.html'
})
export class LoginComponent {
  username = 'admin';
  password = 'password';

  constructor(private http: HttpClient, private router: Router) { }

  login() {
    this.http.post<any>('https://localhost:5001/api/auth/login', {
      username: this.username,
      password: this.password
    }).subscribe(result => {
      localStorage.setItem('token', result.token);
      this.router.navigate(['/artists']);
    }, error => {
      alert('Login failed');
    });
  }
}
